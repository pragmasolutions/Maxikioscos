ALTER PROCEDURE [dbo].[Sync_TransferenciasProductos] 
	@XML XML,
	@SobreescribirLocal bit
AS
BEGIN
	DECLARE @idoc int, @doc nvarchar(MAX);
	SET @doc = (SELECT CAST(@XML as nvarchar(max)));

	--Create an internal representation of the XML document.
	EXEC sp_xml_preparedocument @idoc OUTPUT, @doc;
	-- Execute a SELECT statement that uses the OPENXML rowset provider.
	
	Declare @Temp table
	(
	    TransferenciaProductoId int, 
	    Identifier uniqueidentifier, 
	    Desincronizado bit,
	    FechaUltimaModificacion datetime2(7),
	    Eliminado bit, 
	    Cantidad int, 
	    PrecioVenta money, 
		StockOrigen decimal(18,2), 
		StockDestino decimal(18,2),
		Orden int,
		Costo money,
		ProductoIdentifier uniqueidentifier, 
		TransferenciaIdentifier uniqueidentifier
	);
	
	WITH TransferenciaProductoCTE (TransferenciaProductoId, Identifier, Desincronizado,
						FechaUltimaModificacion, Eliminado, Cantidad, PrecioVenta , StockOrigen, 
						StockDestino, Orden, Costo, ProductoIdentifier, TransferenciaIdentifier)
	AS (
		SELECT    *
		FROM       OPENXML (@idoc, '/Exportacion/TransferenciasProductos/TransferenciaProducto',1) 
				 WITH (TransferenciaProductoId int 'TransferenciaProductoId', 
						Identifier uniqueidentifier 'Identifier', 
						Desincronizado bit 'Desincronizado',
						FechaUltimaModificacion datetime2(7) 'FechaUltimaModificacion',
						Eliminado bit 'Eliminado', 
						Cantidad int 'Cantidad', 
						PrecioVenta money 'PrecioVenta', 
						StockOrigen decimal(18,2) 'StockOrigen', 
						StockDestino decimal(18,2) 'StockDestino',
						Orden int 'Orden',
						Costo money 'Costo',
						ProductoIdentifier uniqueidentifier 'ProductoIdentifier', 
						TransferenciaIdentifier uniqueidentifier 'TransferenciaIdentifier')
	 )
	 
	 INSERT INTO @Temp
	 SELECT * FROM TransferenciaProductoCTE
	 
	 
	 UPDATE T
	 SET ProductoId = (SELECT TOP 1 ProductoId FROM Producto WHERE Identifier = CTE.ProductoIdentifier), 
		TransferenciaId = (SELECT TOP 1 TransferenciaId FROM Transferencia WHERE Identifier = CTE.TransferenciaIdentifier), 
		Cantidad = CTE.Cantidad, 
		PrecioVenta = CTE.PrecioVenta,
		StockOrigen = CTE.StockOrigen,
		StockDestino = CTE.StockDestino,
		Orden = CTE.Orden,
		Costo = CTE.Costo,
		Desincronizado = CTE.Desincronizado,
		FechaUltimaModificacion = CTE.FechaUltimaModificacion, 
		Eliminado = CTE.Eliminado
	FROM @Temp CTE
		INNER JOIN TransferenciaProducto T
			ON CTE.Identifier = T.Identifier
	WHERE ((@SobreescribirLocal = 1 AND EXISTS (SELECT 1 FROM Transferencia WHERE Identifier = CTE.TransferenciaIdentifier))
			OR (@SobreescribirLocal = 0 AND T.Desincronizado = 0))
			AND CTE.Identifier <> '00000000-0000-0000-0000-000000000000'
	
			
	INSERT INTO TransferenciaProducto (Identifier, Desincronizado,
						FechaUltimaModificacion, Eliminado, Cantidad, PrecioVenta , StockOrigen, 
						StockDestino, Orden, Costo, ProductoId, TransferenciaId)
	SELECT Identifier,
			Desincronizado,
			FechaUltimaModificacion, 
			Eliminado,
			Cantidad, 
			PrecioVenta, 
			StockOrigen, 
			StockDestino, 
			Orden, 
			Costo,
			(SELECT TOP 1 ProductoId FROM Producto WHERE Identifier = CTE.ProductoIdentifier), 
			(SELECT TOP 1 TransferenciaId FROM Transferencia WHERE Identifier = CTE.TransferenciaIdentifier) 	
	FROM @Temp CTE
	WHERE CTE.Identifier NOT IN (SELECT Identifier FROM TransferenciaProducto)
		AND (@SobreescribirLocal = 0 OR (@SobreescribirLocal = 1 AND EXISTS (SELECT 1 FROM Transferencia WHERE Identifier = CTE.TransferenciaIdentifier)))
		AND CTE.Identifier <> '00000000-0000-0000-0000-000000000000'

	IF @SobreescribirLocal = 1
	BEGIN
		UPDATE T
		SET Desincronizado = 0
		FROM TransferenciaProducto T
		WHERE T.Identifier IN (SELECT Identifier
								FROM @Temp)
		
	END
	ELSE
		UPDATE T
		SET Desincronizado = 1
		FROM TransferenciaProducto T
		WHERE T.Identifier IN (SELECT Identifier
								FROM @Temp)
		
END


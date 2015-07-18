ALTER PROCEDURE [dbo].[Sync_ProveedorProductos] 
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
	   ProveedorProductoId INT, 
	   Identifier UNIQUEIDENTIFIER,
	   CostoSinIVA money, 
	   CostoConIVA money, 
	   Desincronizado bit,
	   FechaUltimaModificacion datetime2(7),
	   FechaUltimoCambioCosto datetime,
	   Eliminado bit,
	   ProveedorIdentifier UNIQUEIDENTIFIER,
	   ProductoIdentifier UNIQUEIDENTIFIER
	);
	
	WITH ProveedorProductoCTE (ProveedorProductoId, Identifier, CostoSinIVA, CostoConIVA, Desincronizado, 
		FechaUltimaModificacion, FechaUltimoCambioCosto, Eliminado, ProveedorIdentifier,  ProductoIdentifier)
	AS (
		SELECT    *
		FROM       OPENXML (@idoc, '/Exportacion/ProveedorProductos/PP/PROV/PROD',4) 
				 WITH (ProveedorProductoId INT '../../ProveedorProductoId', 
					   Identifier UNIQUEIDENTIFIER '../../Identifier',
					   CostoSinIVA money '../../CostoSinIVA', 
					   CostoConIVA money '../../CostoConIVA', 
					   Desincronizado bit '../../Desincronizado',
					   FechaUltimaModificacion datetime2(7) '../../FechaUltimaModificacion',
					   FechaUltimoCambioCosto datetime '../../FechaUltimoCambioCosto',
					   Eliminado bit '../../Eliminado',
					   ProveedorIdentifier UNIQUEIDENTIFIER '../ProveedorIdentifier',
					   ProductoIdentifier UNIQUEIDENTIFIER 'ProductoIdentifier')
	 )
	 
	 INSERT INTO @Temp
	 SELECT * FROM ProveedorProductoCTE
	 
	 
	 UPDATE PP
	 SET ProveedorId = (SELECT TOP 1 ProveedorId FROM Proveedor WHERE Identifier = CTE.ProveedorIdentifier),  
	    ProductoId = (SELECT TOP 1 ProductoId FROM Producto WHERE Identifier = CTE.ProductoIdentifier), 
		CostoSinIVA = CTE.CostoSinIVA,
		CostoConIVA = CTE.CostoConIVA, 
		Desincronizado = CTE.Desincronizado,
		FechaUltimaModificacion = CTE.FechaUltimaModificacion,
		FechaUltimoCambioCosto = CTE.FechaUltimoCambioCosto,
		Eliminado = CTE.Eliminado
	FROM @Temp CTE
		INNER JOIN ProveedorProducto PP
			ON CTE.Identifier = PP.Identifier
	WHERE (@SobreescribirLocal = 1 OR
			(@SobreescribirLocal = 0 AND PP.Desincronizado = 0))
	;
	 
	 INSERT INTO ProveedorProducto (Identifier, ProveedorId, ProductoId, CostoSinIVA, CostoConIVA, 
					Desincronizado,	FechaUltimaModificacion, FechaUltimoCambioCosto, Eliminado)
	 SELECT Identifier, 
			(SELECT TOP 1 ProveedorId FROM Proveedor WHERE Identifier = CTE.ProveedorIdentifier), 
			(SELECT TOP 1 ProductoId FROM Producto WHERE Identifier = CTE.ProductoIdentifier), 
			CostoSinIVA,
			CostoConIVA,
			Desincronizado,
			FechaUltimaModificacion,
			FechaUltimoCambioCosto,
			Eliminado
	 FROM @Temp CTE
	 WHERE CTE.Identifier NOT IN (SELECT Identifier FROM ProveedorProducto)
	 
	 
    IF @SobreescribirLocal = 1
	BEGIN
		UPDATE PP
		SET Desincronizado = 0
		FROM ProveedorProducto PP
		WHERE PP.Identifier IN (SELECT Identifier
								FROM @Temp)
		
	END
	ELSE
		UPDATE PP
		SET Desincronizado = 1
		FROM ProveedorProducto PP
		WHERE PP.Identifier IN (SELECT Identifier
								FROM @Temp)
		
END

/****** Object:  StoredProcedure [dbo].[Sync_VentasProductos]    Script Date: 08/09/2014 15:51:45 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Sync_VentasProductos]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Sync_VentasProductos]
GO

CREATE PROCEDURE [dbo].[Sync_VentasProductos] 
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
	    VentaProductoId int,
		Identifier uniqueidentifier,
		Costo money,
		Precio money,
		Cantidad int,
		FechaUltimaModificacion datetime2(7),
		Eliminado bit,
		Desincronizado bit,
		VentaIdentifier uniqueidentifier,
		ProductoIdentifier uniqueidentifier,
		AdicionalPorExcepcion money
	);
	
	print 'insert temp';
	WITH VentaProductoCTE (VentaProductoId, Identifier, Costo, Precio, Cantidad, FechaUltimaModificacion,	
					Eliminado, Desincronizado, VentaIdentifier, ProductoIdentifier, AdicionalPorExcepcion)
	AS (
		SELECT    *
		FROM     OPENXML (@idoc, '/Exportacion/VentasProductos/VP/V/P',3) 
				 WITH (VentaProductoId int '../../VentaProductoId',
						Identifier uniqueidentifier '../../Identifier',
						Costo money '../../Costo',
						Precio money '../../Precio',
						Cantidad int '../../Cantidad',
						FechaUltimaModificacion datetime2(7) '../../FechaUltimaModificacion',
						Eliminado bit '../../Eliminado',
						Desincronizado bit '../../Desincronizado',
						VentaIdentifier uniqueidentifier '../VentaIdentifier',
						ProductoIdentifier uniqueidentifier 'ProductoIdentifier',
						AdicionalPorExcepcion money '../../AdicionalPorExcepcion')
	 )
	 
	 INSERT INTO @Temp
	 SELECT * FROM VentaProductoCTE
	 	 	
	 print 'update VP' 
	 UPDATE VP
	 SET VentaId = (SELECT VentaId FROM Venta WHERE Identifier = CTE.VentaIdentifier),  
		ProductoId = (SELECT ProductoId FROM Producto WHERE Identifier = CTE.ProductoIdentifier),  
	    Costo = CTE.Costo, 
	    Precio = CTE.Precio, 
	    Cantidad = CTE.Cantidad, 
	    FechaUltimaModificacion = CTE.FechaUltimaModificacion,	
		Eliminado = CTE.Eliminado, 
		Desincronizado = CTE.Desincronizado,
		AdicionalPorExcepcion = CTE.AdicionalPorExcepcion
	FROM @Temp CTE
		INNER JOIN VentaProducto VP
			ON CTE.Identifier = VP.Identifier
	WHERE (@SobreescribirLocal = 1 OR
			(@SobreescribirLocal = 0 AND VP.Desincronizado = 0));
	 
	 print 'insert VP'
	 INSERT INTO VentaProducto (Identifier, 
								Costo, 
								Precio, 
								Cantidad, 
								FechaUltimaModificacion,	
								Eliminado, 
								Desincronizado, 
								VentaId, 
								ProductoId,
								AdicionalPorExcepcion)
	 SELECT Identifier, 
			Costo, 
			Precio, 
			Cantidad, 
			FechaUltimaModificacion,	
			Eliminado, 
			Desincronizado,
			(SELECT VentaId FROM Venta WHERE Identifier = CTE.VentaIdentifier),  
			(SELECT ProductoId FROM Producto WHERE Identifier = CTE.ProductoIdentifier),
			 AdicionalPorExcepcion
	 FROM @Temp CTE
	 WHERE CTE.Identifier NOT IN (SELECT Identifier FROM VentaProducto)
	 
	
	print 'UPDATE desincronizado'
	IF @SobreescribirLocal = 1
	BEGIN
		UPDATE VP
		SET Desincronizado = 0
		FROM VentaProducto VP
		WHERE VP.Identifier IN (SELECT Identifier
								FROM @Temp)
	END
	ELSE
		UPDATE VP
		SET Desincronizado = 1
		FROM VentaProducto VP
		WHERE VP.Identifier IN (SELECT Identifier
								FROM @Temp)
	
END


GO



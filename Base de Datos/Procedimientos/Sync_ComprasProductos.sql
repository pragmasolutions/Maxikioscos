/****** Object:  StoredProcedure [dbo].[Sync_ComprasProductos]    Script Date: 01/19/2015 17:50:59 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Sync_ComprasProductos]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Sync_ComprasProductos]
GO


CREATE PROCEDURE [dbo].[Sync_ComprasProductos] 
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
	   CompraProductoId INT, 
	   Identifier UNIQUEIDENTIFIER,
	   CostoActual money,
	   CostoActualizado money,
	   PrecioActual money,
	   PrecioActualizado money,
	   Cantidad decimal(18,2),
	   FechaUltimaModificacion datetime2(7),
	   Eliminado bit,
	   Desincronizado bit,
	   CompraIdentifier UNIQUEIDENTIFIER,
	   ProductoIdentifier UNIQUEIDENTIFIER
	);
		
	WITH CompraProductoCTE (CompraProductoId, Identifier, CostoActual, CostoActualizado,
	   PrecioActual, PrecioActualizado, Cantidad, FechaUltimaModificacion, Eliminado,
	   Desincronizado, CompraIdentifier, ProductoIdentifier)
	AS (
		SELECT    *
		FROM     OPENXML (@idoc, '/Exportacion/CompraProductos/CP/C/P',3) 
				 WITH (CompraProductoId INT	'../../CompraProductoId', 
					   Identifier UNIQUEIDENTIFIER   '../../Identifier',
					   CostoActual money '../../CostoActual', 
					   CostoActualizado money '../../CostoActualizado', 
					   PrecioActual money '../../PrecioActual',
					   PrecioActualizado money '../../PrecioActualizado',  
					   Cantidad decimal(18,2) '../../Cantidad',
					   FechaUltimaModificacion datetime2(7) '../../FechaUltimaModificacion',
					   Eliminado bit '../../Eliminado',
					   Desincronizado bit '../../Desincronizado',
					   CompraIdentifier UNIQUEIDENTIFIER '../CompraIdentifier',
					   ProductoIdentifier UNIQUEIDENTIFIER 'ProductoIdentifier')
	 )
	 
	 INSERT INTO @Temp
	 SELECT * FROM CompraProductoCTE
	 
	
	 --SELECT * FROM @Temp
		 
	 UPDATE CP
	 SET CompraId = (SELECT TOP 1 CompraId FROM Compra WHERE Identifier = CTE.CompraIdentifier), 
		ProductoId = (SELECT TOP 1 ProductoId FROM Producto WHERE Identifier = CTE.ProductoIdentifier), 
		CostoActual = CTE.CostoActual, 
		CostoActualizado = CTE.CostoActualizado, 
		PrecioActual = CTE.PrecioActual,
		PrecioActualizado = CTE.PrecioActualizado,
		Cantidad = CTE.Cantidad,
		FechaUltimaModificacion = CTE.FechaUltimaModificacion, 
		Desincronizado = CTE.Desincronizado,
		Eliminado = CTE.Eliminado
	FROM @Temp CTE
		INNER JOIN CompraProducto CP
			ON CTE.Identifier = CP.Identifier
	WHERE ((@SobreescribirLocal = 1 AND EXISTS (SELECT 1 FROM Compra WHERE Identifier = CTE.CompraIdentifier))
			OR  (@SobreescribirLocal = 0 AND CP.Desincronizado = 0))
	;
	 
	 
	 INSERT INTO CompraProducto (Identifier, CostoActual, CostoActualizado, PrecioActual,
			PrecioActualizado, Cantidad, Desincronizado, FechaUltimaModificacion,
				Eliminado, CompraId, ProductoId)
	 SELECT Identifier, 
			CostoActual,
			CostoActualizado,
			PrecioActual,
			PrecioActualizado,
			Cantidad,
			Desincronizado,
			FechaUltimaModificacion,
			Eliminado,
			(SELECT TOP 1 CompraId FROM Compra WHERE Identifier = CTE.CompraIdentifier), 
			(SELECT TOP 1 ProductoId FROM Producto WHERE Identifier = CTE.ProductoIdentifier)
	 FROM @Temp CTE
	 WHERE CTE.Identifier NOT IN (SELECT Identifier FROM CompraProducto)
		AND (@SobreescribirLocal = 0 OR (@SobreescribirLocal = 1 AND EXISTS (SELECT 1 FROM Compra WHERE Identifier = CTE.CompraIdentifier)))
	 
	 
    IF @SobreescribirLocal = 1
	BEGIN
		UPDATE CP
		SET Desincronizado = 0
		FROM CompraProducto CP
		WHERE CP.Identifier IN (SELECT Identifier
								FROM @Temp)
		
	END
	ELSE
		UPDATE CP
		SET Desincronizado = 1
		FROM CompraProducto CP
		WHERE CP.Identifier IN (SELECT Identifier
								FROM @Temp)
		
   	
END




GO



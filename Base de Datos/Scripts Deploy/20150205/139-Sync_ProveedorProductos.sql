/****** Object:  StoredProcedure [dbo].[Sync_ProveedorProductos]    Script Date: 08/09/2014 15:50:19 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Sync_ProveedorProductos]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Sync_ProveedorProductos]
GO



CREATE PROCEDURE [dbo].[Sync_ProveedorProductos] 
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
	   Eliminado bit,
	   ProveedorIdentifier UNIQUEIDENTIFIER,
	   ProductoIdentifier UNIQUEIDENTIFIER
	);
	
	WITH ProveedorProductoCTE (ProveedorProductoId, Identifier, CostoSinIVA, CostoConIVA, Desincronizado, 
		FechaUltimaModificacion, Eliminado, ProveedorIdentifier,  ProductoIdentifier)
	AS (
		SELECT    *
		FROM       OPENXML (@idoc, '/Exportacion/ProveedorProductos/PP/PROV/PROD',4) 
				 WITH (ProveedorProductoId INT '../../ProveedorProductoId', 
					   Identifier UNIQUEIDENTIFIER '../../Identifier',
					   CostoSinIVA money '../../CostoSinIVA', 
					   CostoConIVA money '../../CostoConIVA', 
					   Desincronizado bit '../../Desincronizado',
					   FechaUltimaModificacion datetime2(7) '../../FechaUltimaModificacion',
					   Eliminado bit '../../Eliminado',
					   ProveedorIdentifier UNIQUEIDENTIFIER '../ProveedorIdentifier',
					   ProductoIdentifier UNIQUEIDENTIFIER 'ProductoIdentifier')
	 )
	 
	 INSERT INTO @Temp
	 SELECT * FROM ProveedorProductoCTE
	 
	 UPDATE PP
	 SET ProveedorId = (SELECT ProveedorId FROM Proveedor WHERE Identifier = CTE.ProveedorIdentifier),  
	    ProductoId = (SELECT ProductoId FROM Producto WHERE Identifier = CTE.ProductoIdentifier), 
		CostoSinIVA = CTE.CostoSinIVA,
		CostoConIVA = CTE.CostoConIVA, 
		Desincronizado = CTE.Desincronizado,
		FechaUltimaModificacion = CTE.FechaUltimaModificacion,
		Eliminado = CTE.Eliminado
	FROM @Temp CTE
		INNER JOIN ProveedorProducto PP
			ON CTE.Identifier = PP.Identifier
	WHERE (@SobreescribirLocal = 1 OR
			(@SobreescribirLocal = 0 AND PP.Desincronizado = 0));
	 
	 INSERT INTO ProveedorProducto (Identifier, ProveedorId, ProductoId, CostoSinIVA, CostoConIVA, 
					Desincronizado,	FechaUltimaModificacion, Eliminado)
	 SELECT Identifier, 
			(SELECT ProveedorId FROM Proveedor WHERE Identifier = CTE.ProveedorIdentifier), 
			(SELECT ProductoId FROM Producto WHERE Identifier = CTE.ProductoIdentifier), 
			CostoSinIVA,
			CostoConIVA,
			Desincronizado,
			FechaUltimaModificacion,
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


GO



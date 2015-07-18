/****** Object:  StoredProcedure [dbo].[Sync_CodigosProducto]    Script Date: 08/09/2014 15:49:25 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Sync_CodigosProducto]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Sync_CodigosProducto]
GO


CREATE PROCEDURE [dbo].[Sync_CodigosProducto] 
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
	   CodigoProductoId INT, 
	   Identifier UNIQUEIDENTIFIER,
	   Codigo varchar(30), 
	   Desincronizado bit,
	   Eliminado bit,
	   ProductoIdentifier UNIQUEIDENTIFIER
	);
	
	WITH CodigoProductoCTE (CodigoProductoId, Identifier, Codigo, Desincronizado, Eliminado, ProductoIdentifier)
	AS (
		SELECT    *
		FROM       OPENXML (@idoc, '/Exportacion/CodigosProducto/CP/P',2) 
				 WITH (CodigoProductoId INT	'../CodigoProductoId', 
					   Identifier UNIQUEIDENTIFIER   '../Identifier',
					   Codigo varchar(30) '../Codigo', 
					   Desincronizado bit '../Desincronizado', 
					   Eliminado bit '../Eliminado', 
					   ProductoIdentifier UNIQUEIDENTIFIER 'ProductoIdentifier' )
	 )
	 
	 INSERT INTO @Temp
	 SELECT * FROM CodigoProductoCTE
	 
	 	 
	 UPDATE CP
	 SET ProductoId = (SELECT TOP 1 ProductoId FROM Producto WHERE Identifier = CTE.ProductoIdentifier), 
		Codigo = CTE.Codigo, 
		Desincronizado = CTE.Desincronizado,
		Eliminado = CTE.Eliminado
	FROM @Temp CTE
		INNER JOIN CodigoProducto CP
			ON CTE.Identifier = CP.Identifier
	WHERE (@SobreescribirLocal = 1 OR
			(@SobreescribirLocal = 0 AND CP.Desincronizado = 0))
	;
	 
	 INSERT INTO CodigoProducto (Identifier, ProductoId, Codigo, 
			Desincronizado, Eliminado)
	 SELECT Identifier, 
			(SELECT TOP 1 ProductoId FROM Producto WHERE Identifier = CTE.ProductoIdentifier), 
			Codigo,
			Desincronizado,
			Eliminado
	 FROM @Temp CTE
	 WHERE CTE.Identifier NOT IN (SELECT Identifier FROM CodigoProducto)
	 
	 
    IF @SobreescribirLocal = 1
	BEGIN
		UPDATE CP
		SET Desincronizado = 0
		FROM CodigoProducto CP
		WHERE CP.Identifier IN (SELECT Identifier
								FROM @Temp)
		
	END
	ELSE
		UPDATE CP
		SET Desincronizado = 1
		FROM CodigoProducto CP
		WHERE CP.Identifier IN (SELECT Identifier
								FROM @Temp)
		
END


GO



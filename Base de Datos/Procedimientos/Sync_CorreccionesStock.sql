/****** Object:  StoredProcedure [dbo].[Sync_CorreccionesStock]    Script Date: 01/19/2015 17:50:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Sync_CorreccionesStock]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Sync_CorreccionesStock]
GO

CREATE PROCEDURE [dbo].[Sync_CorreccionesStock] 
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
	   CorreccionStockId INT, 
	   Identifier UNIQUEIDENTIFIER,
	   Precio money,
	   Cantidad decimal(18,2),	   
	   MotivoCorreccionId int,
	   FechaUltimaModificacion datetime2(7),
	   Fecha datetime2(7),
	   Desincronizado bit,
	   Eliminado bit,
	   ProductoIdentifier UNIQUEIDENTIFIER,
	   MaxiKioscoIdentifier UNIQUEIDENTIFIER
	);
			
	WITH CorreccionStockCTE (CorreccionStockId, Identifier, Precio, Cantidad, MotivoCorreccionId, 
		FechaUltimaModificacion, Fecha, Desincronizado, Eliminado, ProductoIdentifier, MaxiKioscoIdentifier)
	AS (
		SELECT    *
		FROM     OPENXML (@idoc, '/Exportacion/CorreccionesStock/CS/P/M',3) 
				 WITH (CorreccionStockId INT	'../../CorreccionStockId', 
					   Identifier UNIQUEIDENTIFIER   '../../Identifier',
					   Precio money '../../Precio',
					   Cantidad decimal(18,2) '../../Cantidad',
					   MotivoCorreccionId int '../../MotivoCorreccionId',
					   FechaUltimaModificacion datetime2(7) '../../FechaUltimaModificacion',
					   Fecha datetime2(7) '../../Fecha',
					   Desincronizado bit '../../Desincronizado',
					   Eliminado bit '../../Eliminado',
					   ProductoIdentifier UNIQUEIDENTIFIER '../ProductoIdentifier',
					   MaxiKioscoIdentifier UNIQUEIDENTIFIER 'MaxiKioscoIdentifier')
	 )
	 
	 INSERT INTO @Temp
	 SELECT * FROM CorreccionStockCTE
	 
	 	 
	 UPDATE CS
	 SET MaxiKioscoId = (SELECT TOP 1 MaxiKioscoId FROM MaxiKiosco WHERE Identifier = CTE.MaxiKioscoIdentifier), 
		ProductoId = (SELECT TOP 1 ProductoId FROM Producto WHERE Identifier = CTE.ProductoIdentifier), 
		Precio = CTE.Precio,
	    Cantidad = CTE.Cantidad,
	    MotivoCorreccionId = CTE.MotivoCorreccionId,
	    FechaUltimaModificacion  = CTE.FechaUltimaModificacion,
	    Fecha = CTE.Fecha,
	    Desincronizado = CTE.Desincronizado,
	    Eliminado = CTE.Eliminado
	FROM @Temp CTE
		INNER JOIN CorreccionStock CS
			ON CTE.Identifier = CS.Identifier
	WHERE ((@SobreescribirLocal = 1  AND CTE.MaxiKioscoIdentifier IN (SELECT MaxikioscoIdentifier FROM ConfiguracionLocal))
			OR (@SobreescribirLocal = 0 AND CS.Desincronizado = 0))
	;
	 
	 INSERT INTO CorreccionStock (Identifier, Cantidad, Precio, Desincronizado, Eliminado, FechaUltimaModificacion,
			MotivoCorreccionId, Fecha, ProductoId, MaxiKioscoId)
	 SELECT Identifier, 
			Cantidad,
			Precio,
			Desincronizado,
			Eliminado,
			FechaUltimaModificacion,
			MotivoCorreccionId,
			Fecha,
			(SELECT TOP 1 ProductoId FROM Producto WHERE Identifier = CTE.ProductoIdentifier), 
			(SELECT TOP 1 MaxiKioscoId FROM MaxiKiosco WHERE Identifier = CTE.MaxiKioscoIdentifier)		
	 FROM @Temp CTE
	 WHERE CTE.Identifier NOT IN (SELECT Identifier FROM CorreccionStock)
		AND (@SobreescribirLocal = 0 OR (@SobreescribirLocal = 1  AND CTE.MaxiKioscoIdentifier IN (SELECT MaxikioscoIdentifier FROM ConfiguracionLocal)))
	 
	 
	IF @SobreescribirLocal = 1
	BEGIN
		UPDATE CS
		SET Desincronizado = 0
		FROM CorreccionStock CS
		WHERE CS.Identifier IN (SELECT Identifier
								FROM @Temp)
		
	END
	ELSE
		UPDATE CS
		SET Desincronizado = 1
		FROM CorreccionStock CS
		WHERE CS.Identifier IN (SELECT Identifier
								FROM @Temp)    
		
END


GO



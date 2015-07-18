ALTER PROCEDURE [dbo].[Sync_StockTransacciones] 
	@XML XML,
	@SobreescribirLocal bit,
	@MaxiKioscoIdentifier uniqueidentifier = NULL
AS
BEGIN
	DECLARE @idoc int, @doc nvarchar(MAX);
	SET @doc = (SELECT CAST(@XML as nvarchar(max)));

	--Create an internal representation of the XML document.
	EXEC sp_xml_preparedocument @idoc OUTPUT, @doc;
	-- Execute a SELECT statement that uses the OPENXML rowset provider.
	
	
	Declare @Temp table
	(
	   StockTransaccionId INT, 
	   Identifier UNIQUEIDENTIFIER,	   	   
	   Desincronizado bit,
	   FechaUltimaModificacion datetime2(7),
	   Eliminado bit,
	   Cantidad decimal(18,2),
	   StockTransaccionTipoId int,
	   StockIdentifier UNIQUEIDENTIFIER
	);
			
	WITH StockTransaccionesCTE (StockTransaccionId, Identifier, Desincronizado, FechaUltimaModificacion,
	   Eliminado, Cantidad, StockTransaccionTipoId, StockIdentifier)
	AS (
		SELECT    *
		FROM     OPENXML (@idoc, '/Exportacion/StockTransacciones/ST/S',2) 
				 WITH (StockTransaccionId INT	'../StockTransaccionId', 
					   Identifier UNIQUEIDENTIFIER   '../Identifier',
					   Desincronizado bit '../Desincronizado',
					   FechaUltimaModificacion datetime2(7) '../../FechaUltimaModificacion',
					   Eliminado bit '../Eliminado',
					   Cantidad decimal(18,2) '../Cantidad',
					   StockTransaccionTipoId int '../StockTransaccionTipoId',
					   StockIdentifier UNIQUEIDENTIFIER 'StockIdentifier')
	 )
	 
	 INSERT INTO @Temp
	 SELECT * FROM StockTransaccionesCTE
	 
	 	 
	 UPDATE ST
	 SET StockId = (SELECT TOP 1 StockId FROM Stock WHERE Identifier = CTE.StockIdentifier), 
		StockTransaccionTipoId = CTE.StockTransaccionTipoId,
	    Cantidad = CTE.Cantidad,
	    FechaUltimaModificacion  = CTE.FechaUltimaModificacion,
	    Desincronizado = CTE.Desincronizado,
	    Eliminado = CTE.Eliminado
	FROM @Temp CTE
		INNER JOIN StockTransaccion ST
			ON CTE.Identifier = ST.Identifier
	WHERE ((@SobreescribirLocal = 1 AND EXISTS (SELECT 1 FROM Stock WHERE Identifier = CTE.StockIdentifier))
			OR (@SobreescribirLocal = 0 AND ST.Desincronizado = 0))
	;
	 
	 
	 INSERT INTO StockTransaccion (Identifier,Desincronizado, FechaUltimaModificacion, Eliminado, Cantidad,
			StockTransaccionTipoId, StockId)
	 SELECT Identifier,
			Desincronizado, 
			FechaUltimaModificacion, 
			Eliminado, 
			Cantidad,
			StockTransaccionTipoId,
			(SELECT TOP 1 StockId FROM Stock WHERE Identifier = CTE.StockIdentifier)		
	 FROM @Temp CTE
	 WHERE CTE.Identifier NOT IN (SELECT Identifier FROM StockTransaccion)
		AND (@SobreescribirLocal = 0 OR (@SobreescribirLocal = 1 AND EXISTS (SELECT 1 FROM Stock WHERE Identifier = CTE.StockIdentifier)))
	 
	 	 
	IF @SobreescribirLocal = 1
	BEGIN
		UPDATE ST
		SET Desincronizado = 0
		FROM StockTransaccion ST
		WHERE ST.Identifier IN (SELECT Identifier
								FROM @Temp)
		
	END
	ELSE
		UPDATE ST
		SET Desincronizado = 1
		FROM StockTransaccion ST
		WHERE ST.Identifier IN (SELECT Identifier
								FROM @Temp)
		
	
END

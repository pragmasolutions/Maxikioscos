
CREATE PROCEDURE [dbo].[Sync_ControlesStockDetalle] 
	@XML XML,
	@SobreescribirLocal bit
AS
BEGIN

    DECLARE @MaxDetalleId int
    SET @MaxDetalleId = (SELECT ISNULL(MAX(ControlStockDetalleId), 0) FROM ControlStockDetalle)
    
	DECLARE @idoc int, @doc nvarchar(MAX);
	SET @doc = (SELECT CAST(@XML as nvarchar(max)));

	--Create an internal representation of the XML document.
	EXEC sp_xml_preparedocument @idoc OUTPUT, @doc;
	-- Execute a SELECT statement that uses the OPENXML rowset provider.
	
	
	Declare @Temp table
	(
	   Cantidad decimal(18,2), 
	   FechaUltimaModificacion datetime2(7),
	   Eliminado bit,
	   Desincronizado bit,
	   Precio money,
	   Correccion decimal(18,2),
	   MotivoCorreccionId int,	   
	   HabilitadoParaCorregir bit,	   
	   Identifier UNIQUEIDENTIFIER,
	   ControlStockIdentifier UNIQUEIDENTIFIER,
	   StockIdentifier UNIQUEIDENTIFIER,
	   ControlStockPrevioIdentifier UNIQUEIDENTIFIER
	);
		
	WITH ControlStockDetalleCTE (Cantidad, FechaUltimaModificacion, Eliminado, Desincronizado, 
		Precio, Correccion, MotivoCorreccionId, HabilitadoParaCorregir, Identifier, 
		ControlStockIdentifier, StockIdentifier, ControlStockPrevioIdentifier)
	AS (
		SELECT    *
		FROM     OPENXML (@idoc, '/Exportacion/ControlStockDetalles/CSD/CS/S/CSP',4) 
				 WITH (Cantidad decimal(18,2) '../../../Cantidad', 
					   FechaUltimaModificacion datetime2(7) '../../../FechaUltimaModificacion',
					   Eliminado bit '../../../Eliminado',
					   Desincronizado bit '../../../Desincronizado',
					   Precio money '../../../Precio',
					   Correccion decimal(18,2) '../../../Correccion',
					   MotivoCorreccionId int '../../../MotivoCorreccionId',
					   HabilitadoParaCorregir bit '../../../HabilitadoParaCorregir',
					   Identifier UNIQUEIDENTIFIER '../../../Identifier',
					   ControlStockIdentifier UNIQUEIDENTIFIER '../../ControlStockIdentifier',
					   StockIdentifier UNIQUEIDENTIFIER '../StockIdentifier',
					   ControlStockPrevioIdentifier UNIQUEIDENTIFIER 'ControlStockPrevioIdentifier')
	 )
	 
	 INSERT INTO @Temp
	 SELECT * FROM ControlStockDetalleCTE
	 
	
	 --SELECT * FROM @Temp
		 
	 UPDATE CSD
	 SET ControlStockId = (SELECT TOP 1 ControlStockId FROM ControlStock WHERE Identifier = CTE.ControlStockIdentifier), 
		StockId = (SELECT TOP 1 StockId FROM Stock WHERE Identifier = CTE.StockIdentifier), 
		ControlStockPrevioId = (SELECT TOP 1 ControlStockId FROM ControlStock WHERE Identifier = CTE.ControlStockPrevioIdentifier), 
		Cantidad = CTE.Cantidad, 
		FechaUltimaModificacion = CTE.FechaUltimaModificacion, 
		Eliminado = CTE.Eliminado, 
		Desincronizado = CTE.Desincronizado,
		Precio = CTE.Precio,
		Correccion = CTE.Correccion,	
	    MotivoCorreccionId = CTE.MotivoCorreccionId,
	    HabilitadoParaCorregir = CTE.HabilitadoParaCorregir
	FROM @Temp CTE
		INNER JOIN ControlStockDetalle CSD
			ON CTE.Identifier = CSD.Identifier
	WHERE ((@SobreescribirLocal = 1 AND EXISTS (SELECT 1 FROM ControlStock WHERE Identifier = CTE.ControlStockIdentifier))
			OR (@SobreescribirLocal = 0 AND CSD.Desincronizado = 0))
	;
	 
	 
	 INSERT INTO ControlStockDetalle (Cantidad, FechaUltimaModificacion, Desincronizado,
			Eliminado,Identifier, Correccion, Precio, MotivoCorreccionId,
			HabilitadoParaCorregir, ControlStockId, StockId, ControlStockPrevioId)
	 SELECT CTE.Cantidad, 
		CTE.FechaUltimaModificacion, 
		CTE.Desincronizado, 
		CTE.Eliminado, 		
		CTE.Identifier, 
		CTE.Correccion, 
		CTE.Precio, 
		CTE.MotivoCorreccionId,
		CTE.HabilitadoParaCorregir,
		(SELECT TOP 1 ControlStockId FROM ControlStock WHERE Identifier = CTE.ControlStockIdentifier), 
		(SELECT TOP 1 StockId FROM Stock WHERE Identifier = CTE.StockIdentifier),
		(SELECT TOP 1 ControlStockId FROM ControlStock WHERE Identifier = CTE.ControlStockPrevioIdentifier)
	 FROM @Temp CTE
	 WHERE CTE.Identifier NOT IN (SELECT Identifier FROM ControlStockDetalle)
			AND (@SobreescribirLocal = 0 OR (@SobreescribirLocal = 1 AND EXISTS (SELECT 1 FROM ControlStock WHERE Identifier = CTE.ControlStockIdentifier)))
	 
	 
    IF @SobreescribirLocal = 1
	BEGIN
		UPDATE CSD
		SET Desincronizado = 0
		FROM ControlStockDetalle CSD
		WHERE CSD.Identifier IN (SELECT Identifier
								FROM @Temp)
		
	END
	ELSE
		BEGIN
		
		UPDATE CSD
		SET Desincronizado = 1
		FROM ControlStockDetalle CSD
		WHERE CSD.Identifier IN (SELECT Identifier
								FROM @Temp)
		
		
		--HAGO EL CONTROL DE QUE, DESPUES DE LA SINCRONIZACION, NO QUEDEN EN EL PRINCIPAL
		--DETALLES QUE DEBERIAN ESTAR DESHABILITADOS
		/*UPDATE CSD
		SET HabilitadoParaCorregir = 0
		FROM ControlStockDetalle CSD 
		WHERE CSD.ControlStockDetalleId > @MaxDetalleId
			AND CSD.StockId IN*/
		
		END
	
END








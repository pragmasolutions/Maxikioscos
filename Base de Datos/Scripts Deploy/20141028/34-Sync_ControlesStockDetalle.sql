/****** Object:  StoredProcedure [dbo].[Sync_ControlesStockDetalle]    Script Date: 09/22/2014 23:28:33 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Sync_ControlesStockDetalle]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Sync_ControlesStockDetalle]
GO

CREATE PROCEDURE [dbo].[Sync_ControlesStockDetalle] 
	@XML XML,
	@SobreescribirLocal bit
AS
BEGIN

    BEGIN TRY
    BEGIN TRAN
    
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
	   StockIdentifier UNIQUEIDENTIFIER
	);
		
	WITH ControlStockDetalleCTE (Cantidad, FechaUltimaModificacion, 
		Eliminado, Desincronizado, Precio, Correccion, MotivoCorreccionId, 
		HabilitadoParaCorregir, Identifier, ControlStockIdentifier, StockIdentifier)
	AS (
		SELECT    *
		FROM     OPENXML (@idoc, '/Exportacion/ControlStockDetalles/CSD/CS/S/MC',3) 
				 WITH (Cantidad decimal(18,2) '../../Cantidad', 
					   FechaUltimaModificacion datetime2(7) '../../FechaUltimaModificacion',
					   Eliminado bit '../../Eliminado',
					   Desincronizado bit '../../Desincronizado',
					   Precio money '../../Precio',
					   Correccion decimal(18,2) '../../Correccion',
					   MotivoCorreccionId int '../../MotivoCorreccionId',
					   HabilitadoParaCorregir bit '../../HabilitadoParaCorregir',
					   Identifier UNIQUEIDENTIFIER '../../Identifier',
					   ControlStockIdentifier UNIQUEIDENTIFIER '../ControlStockIdentifier',
					   StockIdentifier UNIQUEIDENTIFIER 'StockIdentifier')
	 )
	 
	 INSERT INTO @Temp
	 SELECT * FROM ControlStockDetalleCTE
	
	 --SELECT * FROM @Temp
		 
	 UPDATE CSD
	 SET ControlStockId = (SELECT ControlStockId FROM ControlStock WHERE Identifier = CTE.ControlStockIdentifier), 
		StockId = (SELECT StockId FROM Stock WHERE Identifier = CTE.StockIdentifier), 
		Cantidad = CTE.Cantidad, 
		FechaUltimaModificacion = CTE.FechaUltimaModificacion, 
		Eliminado = CTE.Eliminado, 
		Desincronizado = CTE.Desincronizado,
		Precio = CTE.Desincronizado,
		Correccion = CTE.Desincronizado,	
	    MotivoCorreccionId = CTE.MotivoCorreccionId,
	    HabilitadoParaCorregir = CTE.HabilitadoParaCorregir
	FROM @Temp CTE
		INNER JOIN ControlStockDetalle CSD
			ON CTE.Identifier = CSD.Identifier
	WHERE (@SobreescribirLocal = 1 OR
			(@SobreescribirLocal = 0 AND CSD.Desincronizado = 0));
	 
	 
	 INSERT INTO ControlStockDetalle (Cantidad, FechaUltimaModificacion, Desincronizado,
			Eliminado,Identifier, Correccion, Precio, MotivoCorreccionId,
			HabilitadoParaCorregir, ControlStockId, StockId)
	 SELECT CTE.Cantidad, 
		CTE.FechaUltimaModificacion, 
		CTE.Desincronizado, 
		CTE.Eliminado, 		
		CTE.Identifier, 
		CTE.Correccion, 
		CTE.Precio, 
		CTE.MotivoCorreccionId,
		CTE.HabilitadoParaCorregir,
		(SELECT ControlStockId FROM ControlStock WHERE Identifier = CTE.ControlStockIdentifier), 
		(SELECT StockId FROM Stock WHERE Identifier = CTE.StockIdentifier)
	 FROM @Temp CTE
	 WHERE CTE.Identifier NOT IN (SELECT Identifier FROM ControlStockDetalle)
	 
	 
    IF @SobreescribirLocal = 1
	BEGIN
		UPDATE CSD
		SET Desincronizado = 0
		FROM ControlStockDetalle CSD
		WHERE CSD.Identifier IN (SELECT Identifier
								FROM @Temp)
	END
	ELSE
		UPDATE CSD
		SET Desincronizado = 1
		FROM ControlStockDetalle CSD
		WHERE CSD.Identifier IN (SELECT Identifier
								FROM @Temp)
    
    COMMIT TRAN
	END TRY
		
	BEGIN CATCH

		declare @error int, @message varchar(4000), @xstate int;
        select @error = ERROR_NUMBER(), @message = ERROR_MESSAGE(), @xstate = XACT_STATE();
		print @message
	END CATCH
	
END


GO



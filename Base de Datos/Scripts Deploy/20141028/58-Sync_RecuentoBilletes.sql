/****** Object:  StoredProcedure [dbo].[Sync_RecuentoBilletes]    Script Date: 10/08/2014 14:30:13 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Sync_RecuentoBilletes]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Sync_RecuentoBilletes]
GO


CREATE PROCEDURE [dbo].[Sync_RecuentoBilletes] 
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
	   RecuentoBilleteId int, 
	   Cantidad int,
	   BilleteId int,
	   Identifier uniqueidentifier,  
	   Desincronizado bit,
	   FechaUltimaModificacion datetime2(7), 
	   Eliminado bit, 
	   CierreCajaIdentifier uniqueidentifier
	);
	
	WITH RecuentoBilleteCTE (RecuentoBilleteId, Cantidad, BilleteId, Identifier, Desincronizado, 
							FechaUltimaModificacion, Eliminado, CierreCajaIdentifier)
	AS (
		SELECT    *
		FROM       OPENXML (@idoc, '/Exportacion/RecuentoBilletes/RB/CC',2) 
				 WITH (RecuentoBilleteId int '../FacturaId',
						Cantidad int '../Cantidad',
						BilleteId int '../BilleteId',
						Identifier uniqueidentifier '../Identifier',
						Desincronizado bit '../Desincronizado',
						FechaUltimaModificacion datetime2(7) '../FechaUltimaModificacion',
						Eliminado bit '../Eliminado',
						CierreCajaIdentifier uniqueidentifier 'CierreCajaIdentifier')
	 )
	 
	 INSERT INTO @Temp
	 SELECT * FROM RecuentoBilleteCTE
				 
	 UPDATE RB
	 SET CierreCajaId = (SELECT CierreCajaId FROM CierreCaja WHERE Identifier = CTE.CierreCajaIdentifier), 
		Cantidad = CTE.Cantidad, 
		BilleteId = CTE.BilleteId, 
		Identifier = CTE.Identifier, 
		Desincronizado = CTE.Desincronizado, 
		FechaUltimaModificacion = CTE.FechaUltimaModificacion, 
		Eliminado = CTE.Eliminado
	FROM @Temp CTE
		INNER JOIN RecuentoBillete RB
			ON CTE.Identifier = RB.Identifier
	WHERE (@SobreescribirLocal = 1 OR
			(@SobreescribirLocal = 0 AND RB.Desincronizado = 0))
	 
	 
	 INSERT INTO RecuentoBillete (Identifier, CierreCajaId, Cantidad, BilleteId, 
							Desincronizado,	FechaUltimaModificacion, Eliminado)
	 SELECT Identifier, 
			(SELECT CierreCajaId FROM CierreCaja WHERE Identifier = CTE.CierreCajaIdentifier),
			Cantidad, 
			BilleteId, 
			Desincronizado,
			FechaUltimaModificacion,
			Eliminado
	 FROM @Temp CTE
	 WHERE CTE.Identifier NOT IN (SELECT Identifier FROM RecuentoBillete)
	 
	 
	IF @SobreescribirLocal = 1
	BEGIN
		UPDATE RB
		SET Desincronizado = 0
		FROM RecuentoBillete RB
		WHERE RB.Identifier IN (SELECT Identifier
								FROM @Temp)
	END
	ELSE
		UPDATE RB
		SET Desincronizado = 1
		FROM RecuentoBillete RB
		WHERE RB.Identifier IN (SELECT Identifier
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



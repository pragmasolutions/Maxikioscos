/****** Object:  StoredProcedure [dbo].[Sync_RetirosPersonales]    Script Date: 01/19/2015 17:49:11 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Sync_RetirosPersonales]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Sync_RetirosPersonales]
GO


CREATE PROCEDURE [dbo].[Sync_RetirosPersonales] 
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
	    RetiroPersonalId int,
		Identifier uniqueidentifier,
		CostoTotal money,
		ImporteTotal money,
		FechaRetiroPersonal datetime,
		Eliminado bit,
		Desincronizado bit,
		FechaUltimaModificacion datetime2(7),
		CierreCajaIdentifier uniqueidentifier
	);
	
	WITH RetiroPersonalCTE (RetiroPersonalId, Identifier, CostoTotal, ImporteTotal, FechaRetiroPersonal, Eliminado, Desincronizado, 
					FechaUltimaModificacion, CierreCajaIdentifier)
	AS (
		SELECT    *
		FROM     OPENXML (@idoc, '/Exportacion/RetirosPersonales/RP/CC',2) 
				 WITH (RetiroPersonalId int '../RetiroPersonalId',
						Identifier uniqueidentifier '../Identifier',
						CostoTotal money '../CostoTotal',
						ImporteTotal money '../ImporteTotal',
						FechaRetiroPersonal datetime '../FechaRetiroPersonal',
						Eliminado bit '../Eliminado',
						Desincronizado bit '../Desincronizado',
						FechaUltimaModificacion datetime2(7) '../FechaUltimaModificacion',
						CierreCajaIdentifier uniqueidentifier 'CierreCajaIdentifier')
	 )
	 
	 INSERT INTO @Temp
	 SELECT * FROM RetiroPersonalCTE
	 
	 	 
	 UPDATE RP
	 SET CierreCajaId = (SELECT TOP 1 CierreCajaId FROM CierreCaja WHERE Identifier = CTE.CierreCajaIdentifier),  
	    CostoTotal = CTE.CostoTotal,
		ImporteTotal = CTE.ImporteTotal,
		FechaRetiroPersonal = CTE.FechaRetiroPersonal,
		Eliminado = CTE.Eliminado,
		Desincronizado = CTE.Desincronizado,
		FechaUltimaModificacion = CTE.FechaUltimaModificacion
	FROM @Temp CTE
		INNER JOIN RetiroPersonal RP
			ON CTE.Identifier = RP.Identifier
	WHERE ((@SobreescribirLocal = 1 AND (SELECT CierreCajaId FROM CierreCaja WHERE Identifier = CTE.CierreCajaIdentifier) IS NOT NULL) OR
			(@SobreescribirLocal = 0 AND RP.Desincronizado = 0));
	 
	 INSERT INTO RetiroPersonal (Identifier, 
						CostoTotal, 
						ImporteTotal, 
						FechaRetiroPersonal, 
						Eliminado, 
						Desincronizado, 
						FechaUltimaModificacion, 
						CierreCajaId)
	 SELECT Identifier, 
			CostoTotal, 
			ImporteTotal, 
			FechaRetiroPersonal, 
			Eliminado, 
			Desincronizado, 
			FechaUltimaModificacion,
			(SELECT TOP 1 CierreCajaId FROM CierreCaja WHERE Identifier = CTE.CierreCajaIdentifier)
	 FROM @Temp CTE
	 WHERE CTE.Identifier NOT IN (SELECT Identifier FROM RetiroPersonal)
		AND (SELECT CierreCajaId FROM CierreCaja WHERE Identifier = CTE.CierreCajaIdentifier) IS NOT NULL
	 
	 
	IF @SobreescribirLocal = 1
	BEGIN
		UPDATE RP
		SET Desincronizado = 0
		FROM RetiroPersonal RP
		WHERE RP.Identifier IN (SELECT Identifier
								FROM @Temp)
		
	END
	ELSE
		UPDATE RP
		SET Desincronizado = 1
		FROM RetiroPersonal RP
		WHERE RP.Identifier IN (SELECT Identifier
								FROM @Temp)
		
	
END


GO



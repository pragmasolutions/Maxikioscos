/****** Object:  StoredProcedure [dbo].[Sync_MaxiKioscosTurnos]    Script Date: 01/19/2015 17:49:59 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Sync_MaxiKioscosTurnos]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Sync_MaxiKioscosTurnos]
GO


CREATE PROCEDURE [dbo].[Sync_MaxiKioscosTurnos] 
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
	   MaxiKioscoTurnoId INT, 
	   Identifier UNIQUEIDENTIFIER,
	   TurnoId int,
	   Eliminado bit,
	   Desincronizado bit,
	   FechaUltimaModificacion datetime2(7),
	   MaxiKioscoIdentifier UNIQUEIDENTIFIER
	);
	
	
	WITH MaxiKioscoTurnoCTE (MaxiKioscoTurnoId, Identifier, TurnoId, Eliminado,
	   Desincronizado, FechaUltimaModificacion, MaxiKioscoIdentifier)
	AS (
		SELECT    *
		FROM       OPENXML (@idoc, '/Exportacion/MaxiKioscoTurnos/MT/M',2) 
				 WITH (MaxiKioscoTurnoId INT	'../MaxiKioscoTurnoId', 
					   Identifier UNIQUEIDENTIFIER   '../Identifier',
					   TurnoId int '../TurnoId', 
					   Eliminado bit '../Eliminado', 
					   Desincronizado bit '../Desincronizado',
					   FechaUltimaModificacion datetime2(7) './FechaUltimaModificacion',  
					   MaxiKioscoIdentifier UNIQUEIDENTIFIER 'MaxiKioscoIdentifier')
	 )
	 
	 INSERT INTO @Temp
	 SELECT * FROM MaxiKioscoTurnoCTE
	 
	 	 
	 UPDATE MT
	 SET MaxiKioscoId = (SELECT TOP 1 MaxiKioscoId FROM MaxiKiosco WHERE Identifier = CTE.MaxiKioscoIdentifier), 
		TurnoId = CTE.TurnoId, 
		Eliminado = CTE.Eliminado,
		Desincronizado = CTE.Desincronizado,
		FechaUltimaModificacion = CTE.FechaUltimaModificacion
	FROM @Temp CTE
		INNER JOIN MaxiKioscoTurno MT
			ON CTE.Identifier = MT.Identifier
	WHERE ((@SobreescribirLocal = 1  AND CTE.MaxiKioscoIdentifier IN (SELECT MaxikioscoIdentifier FROM ConfiguracionLocal))
			OR (@SobreescribirLocal = 0 AND MT.Desincronizado = 0))
	;
	 
	 INSERT INTO MaxiKioscoTurno (Identifier, TurnoId, Desincronizado, FechaUltimaModificacion,
				Eliminado, MaxiKioscoId)
	 SELECT Identifier, 
			TurnoId,
			Desincronizado,
			FechaUltimaModificacion,
			Eliminado,
			(SELECT TOP 1 MaxiKioscoId FROM MaxiKiosco WHERE Identifier = CTE.MaxiKioscoIdentifier)			
	 FROM @Temp CTE
	 WHERE CTE.Identifier NOT IN (SELECT Identifier FROM MaxiKioscoTurno)
		AND (@SobreescribirLocal = 0 OR (@SobreescribirLocal = 1  AND CTE.MaxiKioscoIdentifier IN (SELECT MaxikioscoIdentifier FROM ConfiguracionLocal)))
	 
	 
	IF @SobreescribirLocal = 1
	BEGIN
		UPDATE MT
		SET Desincronizado = 0
		FROM MaxiKioscoTurno MT
		WHERE MT.Identifier IN (SELECT Identifier
								FROM @Temp)
		
	END
	ELSE
		UPDATE MT
		SET Desincronizado = 1
		FROM MaxiKioscoTurno MT
		WHERE MT.Identifier IN (SELECT Identifier
								FROM @Temp)
		
    
END




GO



/****** Object:  StoredProcedure [dbo].[Sync_ExcepcionesRubros]    Script Date: 01/19/2015 17:50:17 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Sync_ExcepcionesRubros]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Sync_ExcepcionesRubros]
GO

CREATE PROCEDURE [dbo].[Sync_ExcepcionesRubros] 
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
	   ExcepcionRubroId INT, 
	   Identifier UNIQUEIDENTIFIER,
	   Desde time(7),
	   Hasta time(7),
	   RecargoAbsoluto money,
	   RecargoPorcentaje decimal(18,2),
	   FechaUltimaModificacion datetime2(7),
	   Eliminado bit,
	   Desincronizado bit,
	   RubroIdentifier UNIQUEIDENTIFIER,
	   MaxiKioscoIdentifier UNIQUEIDENTIFIER
	);
		
	WITH ExcepcionRubroCTE (ExcepcionRubroId, Identifier, Desde, Hasta,
	   RecargoAbsoluto, RecargoPorcentaje, FechaUltimaModificacion, Eliminado,
	   Desincronizado, RubroIdentifier, MaxiKioscoIdentifier)
	AS (
		SELECT    *
		FROM     OPENXML (@idoc, '/Exportacion/ExcepcionesRubros/ER/R/M',3) 
				 WITH (ExcepcionRubroId INT	'../../ExcepcionRubroId', 
					   Identifier UNIQUEIDENTIFIER   '../../Identifier',
					   Desde time(7) '../../Desde', 
					   Hasta time(7) '../../Hasta', 
					   RecargoAbsoluto money '../../RecargoAbsoluto',
					   RecargoPorcentaje decimal(18,2) '../../RecargoPorcentaje',  
					   FechaUltimaModificacion datetime2(7) '../../FechaUltimaModificacion',
					   Eliminado bit '../../Eliminado',
					   Desincronizado bit '../../Desincronizado',
					   RubroIdentifier UNIQUEIDENTIFIER '../RubroIdentifier',
					   MaxiKioscoIdentifier UNIQUEIDENTIFIER 'MaxiKioscoIdentifier')
	 )
	 
	 INSERT INTO @Temp
	 SELECT * FROM ExcepcionRubroCTE
	 	 
	 UPDATE ER
	 SET RubroId = (SELECT RubroId FROM Rubro WHERE Identifier = CTE.RubroIdentifier), 
		MaxiKioscoId = (SELECT MaxiKioscoId FROM MaxiKiosco WHERE Identifier = CTE.MaxiKioscoIdentifier), 
		Desde = CTE.Desde, 
		Hasta = CTE.Hasta, 
		RecargoAbsoluto = CTE.RecargoAbsoluto, 
		RecargoPorcentaje = CTE.RecargoPorcentaje,
		FechaUltimaModificacion = CTE.FechaUltimaModificacion, 
		Desincronizado = CTE.Desincronizado,
		Eliminado = CTE.Eliminado
	FROM @Temp CTE
		INNER JOIN ExcepcionRubro ER
			ON CTE.Identifier = ER.Identifier
	WHERE ((@SobreescribirLocal = 1  AND CTE.MaxiKioscoIdentifier IN (SELECT MaxikioscoIdentifier FROM ConfiguracionLocal))
			OR (@SobreescribirLocal = 0 AND ER.Desincronizado = 0));
	 
	 INSERT INTO ExcepcionRubro (Identifier, Desde, Hasta, RecargoAbsoluto, RecargoPorcentaje, 
		FechaUltimaModificacion, Eliminado, Desincronizado, RubroId, MaxiKioscoId)
	 SELECT Identifier, 
		Desde, 
		Hasta, 
		RecargoAbsoluto, 
		RecargoPorcentaje, 
		FechaUltimaModificacion, 
		Eliminado, 
		Desincronizado,
		(SELECT RubroId FROM Rubro WHERE Identifier = CTE.RubroIdentifier), 
		(SELECT MaxiKioscoId FROM MaxiKiosco WHERE Identifier = CTE.MaxiKioscoIdentifier)	
	 FROM @Temp CTE
	 WHERE CTE.Identifier NOT IN (SELECT Identifier FROM ExcepcionRubro)
			AND (@SobreescribirLocal = 0 OR (@SobreescribirLocal = 1  AND CTE.MaxiKioscoIdentifier IN (SELECT MaxikioscoIdentifier FROM ConfiguracionLocal)))
	 
	 
	 
	IF @SobreescribirLocal = 1
	BEGIN
		UPDATE ER
		SET Desincronizado = 0
		FROM ExcepcionRubro ER
		WHERE ER.Identifier IN (SELECT Identifier
								FROM @Temp)
	END
	ELSE
		UPDATE ER
		SET Desincronizado = 1
		FROM ExcepcionRubro ER
		WHERE ER.Identifier IN (SELECT Identifier
								FROM @Temp)
    
	
END


GO



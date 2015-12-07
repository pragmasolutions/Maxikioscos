
CREATE PROCEDURE [dbo].[Sync_CategoriasCosto] 
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
	   CategoriaCostoId INT, 
	   Identifier UNIQUEIDENTIFIER,
	   Descripcion varchar(400), 
	   OcultarEnDesktop bit,
	   PadreIdentifier uniqueidentifier,
	   Desincronizado bit, 
	   FechaUltimaModificacion datetime2(7), 
	   Eliminado bit
	);
	
	WITH CategoriaCostoCTE (CategoriaCostoId, Identifier, Descripcion, OcultarEnDesktop,
		PadreIdentifier, Desincronizado, FechaUltimaModificacion, Eliminado)
	AS (
		SELECT    *
		FROM       OPENXML (@idoc, '/Exportacion/CategoriasCosto/CC/CC2',2) 
				 WITH (CategoriaCostoId INT	'../CategoriaCostoId', 
					   Identifier UNIQUEIDENTIFIER   '../Identifier',
					   Descripcion varchar(400) '../Descripcion', 
					   OcultarEnDesktop bit '../OcultarEnDesktop',
					   PadreIdentifier uniqueidentifier 'PadreIdentifier',
					   Desincronizado bit '../Desincronizado', 
					   FechaUltimaModificacion datetime2(7)  '../FechaUltimaModificacion', 
					   Eliminado bit '../Eliminado')
	 )
	 
	 INSERT INTO @Temp
	 SELECT * FROM CategoriaCostoCTE
	 
	 --------------------------------------------------------------------------------
	 ----------------- PRIMERO LOS PADRES -------------------------------------------
	 --------------------------------------------------------------------------------
	 UPDATE CC
	 SET Descripcion = CTE.Descripcion, 
		OcultarEnDesktop = CTE.OcultarEnDesktop,
		PadreId = (SELECT TOP 1 CategoriaCostoId FROM CategoriaCosto WHERE Identifier = CTE.PadreIdentifier),
		Desincronizado = CTE.Desincronizado,
		FechaUltimaModificacion = CTE.FechaUltimaModificacion, 
		Eliminado = CTE.Eliminado
	FROM @Temp CTE
		INNER JOIN CategoriaCosto CC
			ON CTE.Identifier = CC.Identifier
	WHERE (@SobreescribirLocal = 1 OR
			(@SobreescribirLocal = 0 AND CC.Desincronizado = 0))
			AND (CTE.PadreIdentifier IS NULL);
	 
	 INSERT INTO CategoriaCosto (Identifier, Descripcion, OcultarEnDesktop,
				PadreId, Desincronizado, FechaUltimaModificacion, Eliminado)
	 SELECT Identifier, 
			Descripcion, 
			OcultarEnDesktop,
			(SELECT TOP 1 CategoriaCostoId FROM CategoriaCosto WHERE Identifier = CTE.PadreIdentifier),
			Desincronizado,
			FechaUltimaModificacion, 
			Eliminado
	 FROM @Temp CTE
	 WHERE CTE.Identifier NOT IN (SELECT Identifier FROM CategoriaCosto)
			AND (CTE.PadreIdentifier IS NULL)
			
	---------------------------------------------------------------------------------
	 ------------------ DESPUES LOS HIJOS -------------------------------------------
	 --------------------------------------------------------------------------------
	 UPDATE CC
	 SET Descripcion = CTE.Descripcion, 
		OcultarEnDesktop = CTE.OcultarEnDesktop,
		PadreId = (SELECT TOP 1 CategoriaCostoId FROM CategoriaCosto WHERE Identifier = CTE.PadreIdentifier),
		Desincronizado = CTE.Desincronizado,
		FechaUltimaModificacion = CTE.FechaUltimaModificacion, 
		Eliminado = CTE.Eliminado
	FROM @Temp CTE
		INNER JOIN CategoriaCosto CC
			ON CTE.Identifier = CC.Identifier
	WHERE (@SobreescribirLocal = 1 OR
			(@SobreescribirLocal = 0 AND CC.Desincronizado = 0))
			AND (CTE.PadreIdentifier IS NOT NULL);
	 
	 INSERT INTO CategoriaCosto (Identifier, Descripcion, OcultarEnDesktop,
				PadreId, Desincronizado, FechaUltimaModificacion, Eliminado)
	 SELECT Identifier, 
			Descripcion, 
			OcultarEnDesktop,
			(SELECT TOP 1 CategoriaCostoId FROM CategoriaCosto WHERE Identifier = CTE.PadreIdentifier),
			Desincronizado,
			FechaUltimaModificacion, 
			Eliminado
	 FROM @Temp CTE
	 WHERE CTE.Identifier NOT IN (SELECT Identifier FROM CategoriaCosto)
			AND (CTE.PadreIdentifier IS NOT NULL)
	 
	 
	 IF @SobreescribirLocal = 1
	BEGIN
		UPDATE CC
		SET Desincronizado = 0
		FROM CategoriaCosto CC
		WHERE CC.Identifier IN (SELECT Identifier
								FROM @Temp)
		
	END
	ELSE
		UPDATE CC
		SET Desincronizado = 1
		FROM CategoriaCosto CC
		WHERE CC.Identifier IN (SELECT Identifier
								FROM @Temp)
		
END





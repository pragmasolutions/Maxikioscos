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
	   MaximoBisemanal int,
	   Desincronizado bit, 
	   FechaUltimaModificacion datetime2(7), 
	   Eliminado bit
	);
	
	WITH CategoriaCostoCTE (CategoriaCostoId, Identifier, Descripcion, Desincronizado, 
		FechaUltimaModificacion, Eliminado, CuentaIdentifier)
	AS (
		SELECT    *
		FROM       OPENXML (@idoc, '/Exportacion/CategoriasCosto/CC',1) 
				 WITH (CategoriaCostoId INT	'CategoriaCostoId', 
					   Identifier UNIQUEIDENTIFIER   'Identifier',
					   Descripcion varchar(400) 'Descripcion', 
					   MaximoBisemanal int 'MaximoBisemanal', 
					   Desincronizado bit 'Desincronizado', 
					   FechaUltimaModificacion datetime2(7)  'FechaUltimaModificacion', 
					   Eliminado bit 'Eliminado')
	 )
	 
	 INSERT INTO @Temp
	 SELECT * FROM CategoriaCostoCTE
	 
	 	 
	 UPDATE CC
	 SET Descripcion = CTE.Descripcion, 
		MaximoBisemanal = CTE.MaximoBisemanal,
		Desincronizado = CTE.Desincronizado,
		FechaUltimaModificacion = CTE.FechaUltimaModificacion, 
		Eliminado = CTE.Eliminado
	FROM @Temp CTE
		INNER JOIN CategoriaCosto CC
			ON CTE.Identifier = CC.Identifier
	WHERE (@SobreescribirLocal = 1 OR
			(@SobreescribirLocal = 0 AND CC.Desincronizado = 0));
	 
	 INSERT INTO CategoriaCosto (Identifier, Descripcion, MaximoBisemanal, Desincronizado, 
							FechaUltimaModificacion, Eliminado)
	 SELECT Identifier, 
			Descripcion, 
			MaximoBisemanal,
			Desincronizado,
			FechaUltimaModificacion, 
			Eliminado
	 FROM @Temp CTE
	 WHERE CTE.Identifier NOT IN (SELECT Identifier FROM Marca)
	 
	 
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
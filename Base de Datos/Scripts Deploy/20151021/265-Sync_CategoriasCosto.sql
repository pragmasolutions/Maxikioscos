/****** Object:  StoredProcedure [dbo].[Sync_CategoriasCosto]    Script Date: 08/09/2014 15:49:55 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Sync_CategoriasCosto]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Sync_CategoriasCosto]
GO

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
	   Desincronizado bit, 
	   FechaUltimaModificacion datetime2(7), 
	   Eliminado bit
	);
	
	WITH CategoriaCostoCTE (CategoriaCostoId, Identifier, Descripcion, OcultarEnDesktop,
		Desincronizado, FechaUltimaModificacion, Eliminado)
	AS (
		SELECT    *
		FROM       OPENXML (@idoc, '/Exportacion/CategoriasCosto/CC',1) 
				 WITH (CategoriaCostoId INT	'CategoriaCostoId', 
					   Identifier UNIQUEIDENTIFIER   'Identifier',
					   Descripcion varchar(400) 'Descripcion', 
					   OcultarEnDesktop bit 'OcultarEnDesktop',
					   Desincronizado bit 'Desincronizado', 
					   FechaUltimaModificacion datetime2(7)  'FechaUltimaModificacion', 
					   Eliminado bit 'Eliminado')
	 )
	 
	 INSERT INTO @Temp
	 SELECT * FROM CategoriaCostoCTE
	 
	 	 
	 UPDATE CC
	 SET Descripcion = CTE.Descripcion, 
		OcultarEnDesktop = CTE.OcultarEnDesktop,
		Desincronizado = CTE.Desincronizado,
		FechaUltimaModificacion = CTE.FechaUltimaModificacion, 
		Eliminado = CTE.Eliminado
	FROM @Temp CTE
		INNER JOIN CategoriaCosto CC
			ON CTE.Identifier = CC.Identifier
	WHERE (@SobreescribirLocal = 1 OR
			(@SobreescribirLocal = 0 AND CC.Desincronizado = 0));
	 
	 INSERT INTO CategoriaCosto (Identifier, Descripcion, OcultarEnDesktop,
				Desincronizado, FechaUltimaModificacion, Eliminado)
	 SELECT Identifier, 
			Descripcion, 
			OcultarEnDesktop,
			Desincronizado,
			FechaUltimaModificacion, 
			Eliminado
	 FROM @Temp CTE
	 WHERE CTE.Identifier NOT IN (SELECT Identifier FROM CategoriaCosto)
	 
	 
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




GO



/****** Object:  StoredProcedure [dbo].[Sync_Marcas]    Script Date: 08/09/2014 15:49:55 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Sync_Marcas]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Sync_Marcas]
GO

CREATE PROCEDURE [dbo].[Sync_Marcas] 
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
	   MarcaId INT, 
	   Identifier UNIQUEIDENTIFIER,
	   Descripcion varchar(200), 
	   Desincronizado bit, 
	   FechaUltimaModificacion datetime2(7), 
	   Eliminado bit, 
	   CuentaIdentifier UNIQUEIDENTIFIER
	);
	
	WITH MarcaCTE (MarcaId, Identifier, Descripcion, Desincronizado, FechaUltimaModificacion, 
	   Eliminado, CuentaIdentifier)
	AS (
		SELECT    *
		FROM       OPENXML (@idoc, '/Exportacion/Marcas/M/C',2) 
				 WITH (MarcaId INT	'../MarcaId', 
					   Identifier UNIQUEIDENTIFIER   '../Identifier',
					   Descripcion varchar(200) '../Descripcion', 
					   Desincronizado bit '../Desincronizado', 
					   FechaUltimaModificacion datetime2(7)  '../FechaUltimaModificacion', 
					   Eliminado bit '../Eliminado', 
					   CuentaIdentifier UNIQUEIDENTIFIER 'CuentaIdentifier')
	 )
	 
	 INSERT INTO @Temp
	 SELECT * FROM MarcaCTE
	 
	 	 
	 UPDATE M
	 SET Descripcion = CTE.Descripcion, 
		Desincronizado = CTE.Desincronizado,
		FechaUltimaModificacion = CTE.FechaUltimaModificacion, 
		Eliminado = CTE.Eliminado, 
		CuentaId = (SELECT TOP 1 CuentaId FROM Cuenta WHERE Identifier = CTE.CuentaIdentifier)
	FROM @Temp CTE
		INNER JOIN Marca M
			ON CTE.Identifier = M.Identifier
	WHERE (@SobreescribirLocal = 1 OR
			(@SobreescribirLocal = 0 AND M.Desincronizado = 0))
	;
	 
	 INSERT INTO Marca (Identifier, Descripcion, Desincronizado, FechaUltimaModificacion, 
	   Eliminado, CuentaId)
	 SELECT Identifier, 
			Descripcion, 
			Desincronizado,
			FechaUltimaModificacion, 
			Eliminado, 
			(SELECT TOP 1 CuentaId FROM Cuenta WHERE Identifier = CTE.CuentaIdentifier)
	 FROM @Temp CTE
	 WHERE CTE.Identifier NOT IN (SELECT Identifier FROM Marca)
	 
	 
	 IF @SobreescribirLocal = 1
	BEGIN
		UPDATE M
		SET Desincronizado = 0
		FROM Marca M
		WHERE M.Identifier IN (SELECT Identifier
								FROM @Temp)
		
	END
	ELSE
		UPDATE M
		SET Desincronizado = 1
		FROM Marca M
		WHERE M.Identifier IN (SELECT Identifier
								FROM @Temp)
		
END




GO



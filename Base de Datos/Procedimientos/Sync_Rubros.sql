/****** Object:  StoredProcedure [dbo].[Sync_Rubros]    Script Date: 08/09/2014 15:50:23 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Sync_Rubros]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Sync_Rubros]
GO


CREATE PROCEDURE [dbo].[Sync_Rubros] 
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
	   RubroId INT, 
	   Identifier UNIQUEIDENTIFIER,
	   Descripcion varchar(100), 
	   Desincronizado bit, 
	   FechaUltimaModificacion datetime2(7), 
	   Eliminado bit, 
	   CuentaIdentifier UNIQUEIDENTIFIER, 
	   NoFacturar bit
	);
	
	WITH RubroCTE (RubroId, Identifier, Descripcion, Desincronizado, FechaUltimaModificacion, 
	   Eliminado, CuentaIdentifier, NoFacturar)
	AS (
		SELECT    *
		FROM       OPENXML (@idoc, '/Exportacion/Rubros/R/C',3) 
				 WITH (RubroId INT	'../RubroId', 
					   Identifier UNIQUEIDENTIFIER   '../Identifier',
					   Descripcion varchar(100) '../Descripcion', 
					   Desincronizado bit '../Desincronizado', 
					   FechaUltimaModificacion datetime2(7)  '../FechaUltimaModificacion', 
					   Eliminado bit '../Eliminado', 
					   CuentaIdentifier UNIQUEIDENTIFIER 'CuentaIdentifier', 
					   NoFacturar bit '../NoFacturar')
	 )
	 
	 INSERT INTO @Temp
	 SELECT * FROM RubroCTE
	 
	 	 	 
	 UPDATE R
	 SET Descripcion = CTE.Descripcion, 
		Desincronizado = CTE.Desincronizado,
		FechaUltimaModificacion = CTE.FechaUltimaModificacion, 
		Eliminado = CTE.Eliminado, 
		CuentaId = (SELECT TOP 1 CuentaId FROM Cuenta WHERE Identifier = CTE.CuentaIdentifier), 
		NoFacturar = CTE.NoFacturar
	FROM @Temp CTE
		INNER JOIN Rubro R
			ON CTE.Identifier = R.Identifier
	WHERE (@SobreescribirLocal = 1 OR
			(@SobreescribirLocal = 0 AND R.Desincronizado = 0))
	;
	 
	 INSERT INTO Rubro (Identifier, Descripcion, Desincronizado, FechaUltimaModificacion, 
	   Eliminado, CuentaId, NoFacturar)
	 SELECT Identifier, 
			Descripcion, 
			Desincronizado,
			FechaUltimaModificacion, 
			Eliminado, 
			(SELECT TOP 1 CuentaId FROM Cuenta WHERE Identifier = CTE.CuentaIdentifier), 
			NoFacturar
	 FROM @Temp CTE
	 WHERE CTE.Identifier NOT IN (SELECT Identifier FROM Rubro)
	 
	 
	IF @SobreescribirLocal = 1
	BEGIN
		UPDATE R
		SET Desincronizado = 0
		FROM Rubro R
		WHERE R.Identifier IN (SELECT Identifier
								FROM @Temp)
		
	END
	ELSE
		UPDATE R
		SET Desincronizado = 1
		FROM Rubro R
		WHERE R.Identifier IN (SELECT Identifier
								FROM @Temp)
		
END




GO



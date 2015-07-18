ALTER PROCEDURE [dbo].[Sync_Usuarios] 
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
	   UsuarioId INT,
	   NombreUsuario varchar(max),
	   Nombre varchar(50),
	   Apellido varchar(50), 
	   Identifier UNIQUEIDENTIFIER,
	   FechaUltimaModificacion datetime2(7),
	   Eliminado bit,
	   Desincronizado bit,
	   CuentaIdentifier UNIQUEIDENTIFIER
	);
	
	WITH UsuarioCTE (UsuarioId, NombreUsuario, Nombre, Apellido, Identifier, FechaUltimaModificacion, 
					Eliminado, Desincronizado, CuentaIdentifier)
	AS (
		SELECT    *
		FROM       OPENXML (@idoc, '/Exportacion/Usuario/U/C',2) 
				 WITH (UsuarioId INT '../UsuarioId',
					   NombreUsuario varchar(max) '../NombreUsuario',
					   Nombre varchar(50) '../Nombre',
					   Apellido varchar(50) '../Apellido', 
					   Identifier UNIQUEIDENTIFIER '../Identifier',
					   FechaUltimaModificacion datetime2(7) '../FechaUltimaModificacion',
					   Eliminado bit '../Eliminado',
					   Desincronizado bit '../Desincronizado',
					   CuentaIdentifier UNIQUEIDENTIFIER 'CuentaIdentifier')
	 )
	 
	 INSERT INTO @Temp
	 SELECT * FROM UsuarioCTE
	 
	 	 	 	 	 	 
	 UPDATE U
	 SET CuentaId = (SELECT TOP 1 CuentaId FROM Cuenta WHERE Identifier = CTE.CuentaIdentifier),
		NombreUsuario = CTE.NombreUsuario, 
		Nombre = CTE.Nombre, 
		Apellido = CTE.Apellido,
		FechaUltimaModificacion = CTE.FechaUltimaModificacion,
		Eliminado = CTE.Eliminado,
		Desincronizado = CTE.Desincronizado
	FROM @Temp CTE
		INNER JOIN Usuario U
			ON CTE.Identifier = U.Identifier
	WHERE (@SobreescribirLocal = 1 OR
			(@SobreescribirLocal = 0 AND U.Desincronizado = 0))
	;
	 
	 INSERT INTO Usuario (NombreUsuario, CuentaId, Nombre, Apellido, Identifier,
					FechaUltimaModificacion, Eliminado, Desincronizado)
	 SELECT NombreUsuario,
	        (SELECT TOP 1 CuentaId FROM Cuenta WHERE Identifier = CTE.CuentaIdentifier), 
	        Nombre,
	        Apellido,
	        Identifier, 
			FechaUltimaModificacion,
			Eliminado,
			Desincronizado
	 FROM @Temp CTE
	 WHERE CTE.Identifier NOT IN (SELECT Identifier FROM Usuario)
	 
	 
	 IF @SobreescribirLocal = 1
	BEGIN
		UPDATE U
		SET Desincronizado = 0
		FROM Usuario U
		WHERE U.Identifier IN (SELECT Identifier
								FROM @Temp)
		
	END
	ELSE
		UPDATE U
		SET Desincronizado = 1
		FROM Usuario U
		WHERE U.Identifier IN (SELECT Identifier
								FROM @Temp)
		
END
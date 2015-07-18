ALTER PROCEDURE [dbo].[Sync_UsuarioMaxiKioscos] 
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
	   UsuarioMaxiKioscoId INT,
	   Identifier UNIQUEIDENTIFIER,
	   FechaUltimaModificacion datetime2(7),
	   Eliminado bit,
	   Desincronizado bit,
	   UsuarioIdentifier UNIQUEIDENTIFIER,
	   MaxiKioscoIdentifier UNIQUEIDENTIFIER
	);
	
	WITH UsuarioMaxiKioscoCTE (UsuarioMaxiKioscoId, Identifier, FechaUltimaModificacion, Eliminado, Desincronizado, 
					UsuarioIdentifier, MaxiKioscoIdentifier)
	AS (
		SELECT    *
		FROM       OPENXML (@idoc, '/Exportacion/UsuarioMaxiKioscos/UM/M/U',3) 
				 WITH (UsuarioMaxiKioscoId INT '../../UsuarioMaxiKioscoId',
					   Identifier UNIQUEIDENTIFIER '../../Identifier',
					   FechaUltimaModificacion datetime2(7) '../../FechaUltimaModificacion',
					   Eliminado bit '../../Eliminado',
					   Desincronizado bit '../../Desincronizado',
					   UsuarioIdentifier UNIQUEIDENTIFIER 'UsuarioIdentifier',
					   MaxiKioscoIdentifier UNIQUEIDENTIFIER '../MaxiKioscoIdentifier')
	 )
	 
	 INSERT INTO @Temp
	 SELECT * FROM UsuarioMaxiKioscoCTE
	 
	 	 
	 UPDATE UM
	 SET UsuarioId = (SELECT TOP 1 UsuarioId FROM Usuario WHERE Identifier = CTE.UsuarioIdentifier),
	    MaxiKioscoId = (SELECT TOP 1 MaxiKioscoId FROM MaxiKiosco WHERE Identifier = CTE.MaxiKioscoIdentifier),
		FechaUltimaModificacion = CTE.FechaUltimaModificacion,
		Eliminado = CTE.Eliminado,
		Desincronizado = CTE.Desincronizado
	FROM @Temp CTE
		INNER JOIN UsuarioMaxiKiosco UM
			ON CTE.Identifier = UM.Identifier
	WHERE (@SobreescribirLocal = 1 OR
			(@SobreescribirLocal = 0 AND UM.Desincronizado = 0))
	;
	 
	 INSERT INTO UsuarioMaxiKiosco (UsuarioId, MaxiKioscoId, Identifier,
					FechaUltimaModificacion, Eliminado, Desincronizado)
	 SELECT (SELECT TOP 1 UsuarioId FROM Usuario WHERE Identifier = CTE.UsuarioIdentifier),
	        (SELECT TOP 1 MaxiKioscoId FROM MaxiKiosco WHERE Identifier = CTE.MaxiKioscoIdentifier), 
	        Identifier, 
			FechaUltimaModificacion,
			Eliminado,
			Desincronizado
	 FROM @Temp CTE
	 WHERE CTE.Identifier NOT IN (SELECT Identifier FROM UsuarioMaxiKiosco)
	 
	 
    IF @SobreescribirLocal = 1
	BEGIN
		UPDATE UM
		SET Desincronizado = 0
		FROM UsuarioMaxiKiosco UM
		WHERE UM.Identifier IN (SELECT Identifier
								FROM @Temp)
		
	END
	ELSE
		UPDATE UM
		SET Desincronizado = 1
		FROM UsuarioMaxiKiosco UM
		WHERE UM.Identifier IN (SELECT Identifier
								FROM @Temp)
		
	
END



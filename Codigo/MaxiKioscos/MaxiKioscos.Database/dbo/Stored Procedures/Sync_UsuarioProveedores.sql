CREATE PROCEDURE [dbo].[Sync_UsuarioProveedores] 
	@XML XML,
	@SobreescribirLocal bit
AS
BEGIN

	BEGIN TRY
    BEGIN TRAN
    
	DECLARE @idoc int, @doc nvarchar(MAX);
	SET @doc = (SELECT CAST(@XML as nvarchar(max)));

	--Create an internal representation of the XML document.
	EXEC sp_xml_preparedocument @idoc OUTPUT, @doc;
	-- Execute a SELECT statement that uses the OPENXML rowset provider.
	
	
	Declare @Temp table
	(
	   UsuarioProveedorId INT,
	   Identifier UNIQUEIDENTIFIER,
	   FechaUltimaModificacion datetime2(7),
	   Eliminado bit,
	   Desincronizado bit,
	   UsuarioIdentifier UNIQUEIDENTIFIER,
	   ProveedorIdentifier UNIQUEIDENTIFIER
	);
	
	WITH UsuarioProveedorCTE (UsuarioProveedorId, Identifier, FechaUltimaModificacion, Eliminado, Desincronizado, 
					UsuarioIdentifier, ProveedorIdentifier)
	AS (
		SELECT    *
		FROM       OPENXML (@idoc, '/Exportacion/UsuarioProveedores/UP/P/U',3) 
				 WITH (UsuarioProveedorId INT '../../UsuarioProveedorId',
					   Identifier UNIQUEIDENTIFIER '../../Identifier',
					   FechaUltimaModificacion datetime2(7) '../../FechaUltimaModificacion',
					   Eliminado bit '../../Eliminado',
					   Desincronizado bit '../../Desincronizado',
					   UsuarioIdentifier UNIQUEIDENTIFIER 'UsuarioIdentifier',
					   ProveedorIdentifier UNIQUEIDENTIFIER '../ProveedorIdentifier')
	 )
	 
	 INSERT INTO @Temp
	 SELECT * FROM UsuarioProveedorCTE
	 	 
	 UPDATE UP
	 SET UsuarioId = (SELECT UsuarioId FROM Usuario WHERE Identifier = CTE.UsuarioIdentifier),
	    ProveedorId = (SELECT ProveedorId FROM Proveedor WHERE Identifier = CTE.ProveedorIdentifier),
		FechaUltimaModificacion = CTE.FechaUltimaModificacion,
		Eliminado = CTE.Eliminado,
		Desincronizado = CTE.Desincronizado
	FROM @Temp CTE
		INNER JOIN UsuarioProveedor UP
			ON CTE.Identifier = UP.Identifier
	WHERE (@SobreescribirLocal = 1 OR
			(@SobreescribirLocal = 0 AND UP.Desincronizado = 0));
	 
	INSERT INTO UsuarioProveedor (UsuarioId, ProveedorId, Identifier,
					FechaUltimaModificacion, Eliminado, Desincronizado)
	SELECT (SELECT UsuarioId FROM Usuario WHERE Identifier = CTE.UsuarioIdentifier),
	        (SELECT ProveedorId FROM Proveedor WHERE Identifier = CTE.ProveedorIdentifier), 
	        Identifier, 
			FechaUltimaModificacion,
			Eliminado,
			Desincronizado
	FROM @Temp CTE
	WHERE CTE.Identifier NOT IN (SELECT Identifier FROM UsuarioProveedor)
	 
	 
    IF @SobreescribirLocal = 1
	BEGIN
		UPDATE UP
		SET Desincronizado = 0
		FROM UsuarioProveedor UP
		WHERE UP.Identifier IN (SELECT Identifier
								FROM @Temp)
	END
	ELSE
		UPDATE UP
		SET Desincronizado = 1
		FROM UsuarioProveedor UP
		WHERE UP.Identifier IN (SELECT Identifier
								FROM @Temp)
	
	COMMIT TRAN
	END TRY
		
	BEGIN CATCH
   
    IF @@TRANCOUNT > 0 
		declare @error int, @message varchar(4000), @xstate int;
        select @error = ERROR_NUMBER(), @message = ERROR_MESSAGE(), @xstate = XACT_STATE();
		print @message
	END CATCH
END


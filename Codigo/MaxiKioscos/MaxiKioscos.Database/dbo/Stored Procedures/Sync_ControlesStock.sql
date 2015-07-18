CREATE PROCEDURE [dbo].[Sync_ControlesStock] 
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
	   ControlStockId INT, 
	   FechaCreacion datetime,
	   NroControl int,
	   Cerrado bit,
	   FechaCorreccion datetime,
	   FechaUltimaModificacion datetime2(7),
	   Eliminado bit,
	   Desincronizado bit,
	   Identifier UNIQUEIDENTIFIER,
	   ProveedorIdentifier UNIQUEIDENTIFIER,
	   RubroIdentifier UNIQUEIDENTIFIER,
	   MaxiKioscoIdentifier UNIQUEIDENTIFIER,
	   UsuarioIdentifier UNIQUEIDENTIFIER
	);
		
	WITH ControlStockCTE (ControlStockId, FechaCreacion, NroControl, Cerrado,
		FechaCorreccion, FechaUltimaModificacion, Eliminado, Desincronizado, Identifier, 
		ProveedorIdentifier, RubroIdentifier, MaxiKioscoIdentifier, 
		UsuarioIdentifier)
	AS (
		SELECT    *
		FROM     OPENXML (@idoc, '/Exportacion/ControlesStock/CS/P/R/M/U',5) 
				 WITH (ControlStockId INT '../../../../ControlStockId', 
					   FechaCreacion datetime '../../../../FechaCreacion',
					   NroControl int '../../../../NroControl',
					   Cerrado bit '../../../../Cerrado',
					   FechaCorreccion datetime '../../../../FechaCorreccion',
					   FechaUltimaModificacion datetime2(7) '../../../../FechaUltimaModificacion',
					   Eliminado bit '../../../../Eliminado',
					   Desincronizado bit '../../../../Desincronizado',
					   Identifier UNIQUEIDENTIFIER '../../../../Identifier',
					   ProveedorIdentifier UNIQUEIDENTIFIER '../../../ProveedorIdentifier',
					   RubroIdentifier UNIQUEIDENTIFIER '../../RubroIdentifier',
					   MaxiKioscoIdentifier UNIQUEIDENTIFIER '../MaxiKioscoIdentifier',
					   UsuarioIdentifier UNIQUEIDENTIFIER 'UsuarioIdentifier')
	 )
	 
	 INSERT INTO @Temp
	 SELECT * FROM ControlStockCTE
	
	 --SELECT * FROM @Temp
		 
	 UPDATE CS
	 SET ProveedorId = (SELECT ProveedorId FROM Proveedor WHERE Identifier = CTE.ProveedorIdentifier), 
		RubroId = (SELECT RubroId FROM Rubro WHERE Identifier = CTE.RubroIdentifier), 
		MaxiKioscoId = (SELECT MaxiKioscoId FROM MaxiKiosco WHERE Identifier = CTE.MaxiKioscoIdentifier), 
		UsuarioId = (SELECT UsuarioId FROM Usuario WHERE Identifier = CTE.UsuarioIdentifier), 
		FechaCreacion = CTE.FechaCreacion, 
		NroControl = CTE.NroControl, 
		Cerrado = CTE.Cerrado,
		FechaCorreccion = CTE.FechaCorreccion,
		FechaUltimaModificacion = CTE.FechaUltimaModificacion, 
		Eliminado = CTE.Eliminado, 
		Desincronizado = CTE.Desincronizado
	FROM @Temp CTE
		INNER JOIN ControlStock CS
			ON CTE.Identifier = CS.Identifier
	WHERE ((@SobreescribirLocal = 1  AND CTE.MaxiKioscoIdentifier IN (SELECT MaxikioscoIdentifier FROM ConfiguracionLocal))
			OR (@SobreescribirLocal = 0 AND CS.Desincronizado = 0));
	 
	 
	 INSERT INTO ControlStock (FechaCreacion, NroControl, Cerrado, FechaCorreccion,
		FechaUltimaModificacion, Eliminado, Desincronizado, Identifier, 
		ProveedorId, RubroId, MaxiKioscoId, UsuarioId)
	 SELECT FechaCreacion, 
			NroControl, 
			Cerrado,
			FechaCorreccion,
			FechaUltimaModificacion, 
			Eliminado, 
			Desincronizado,
			Identifier,
			(SELECT ProveedorId FROM Proveedor WHERE Identifier = CTE.ProveedorIdentifier), 
			(SELECT RubroId FROM Rubro WHERE Identifier = CTE.RubroIdentifier), 
			(SELECT MaxiKioscoId FROM MaxiKiosco WHERE Identifier = CTE.MaxiKioscoIdentifier), 
			(SELECT UsuarioId FROM Usuario WHERE Identifier = CTE.UsuarioIdentifier)
	 FROM @Temp CTE
	 WHERE CTE.Identifier NOT IN (SELECT Identifier FROM ControlStock)
		AND (@SobreescribirLocal = 0 OR (@SobreescribirLocal = 1  AND CTE.MaxiKioscoIdentifier IN (SELECT MaxikioscoIdentifier FROM ConfiguracionLocal)))
	 
	 
    IF @SobreescribirLocal = 1
	BEGIN
		UPDATE CS
		SET Desincronizado = 0
		FROM ControlStock CS
		WHERE CS.Identifier IN (SELECT Identifier
								FROM @Temp)
	END
	ELSE
		UPDATE CS
		SET Desincronizado = 1
		FROM ControlStock CS
		WHERE CS.Identifier IN (SELECT Identifier
								FROM @Temp)
    
    COMMIT TRAN
	END TRY
		
	BEGIN CATCH

		declare @error int, @message varchar(4000), @xstate int;
        select @error = ERROR_NUMBER(), @message = ERROR_MESSAGE(), @xstate = XACT_STATE();
		print @message
	END CATCH
	
END



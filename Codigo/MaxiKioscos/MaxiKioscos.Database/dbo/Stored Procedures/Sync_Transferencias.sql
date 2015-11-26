
CREATE PROCEDURE [dbo].[Sync_Transferencias] 
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
	    TransferenciaId int, 
	    Identifier uniqueidentifier,  
	    FechaCreacion datetime, 
	    FechaAprobacion datetime, 
	    AutoNumero varchar(20),
	    Desincronizado bit,	    
		FechaUltimaModificacion datetime2(7), 
		Eliminado bit,
		OrigenIdentifier uniqueidentifier, 
		DestinoIdentifier uniqueidentifier,
		UsuarioIdentifier uniqueidentifier
	);
	
	WITH TransferenciaCTE (TransferenciaId, Identifier, FechaCreacion, FechaAprobacion, 
							AutoNumero, Desincronizado, FechaUltimaModificacion, Eliminado, 
							OrigenIdentifier, DestinoIdentifier, UsuarioIdentifier)
	AS (
		SELECT    *
		FROM       OPENXML (@idoc, '/Exportacion/Transferencias/Transferencia',1) 
				 WITH (TransferenciaId INT	'TransferenciaId', 
					   Identifier UNIQUEIDENTIFIER   'Identifier',
					   FechaCreacion DATETIME 'FechaCreacion', 
					   FechaAprobacion DATETIME	 'FechaAprobacion', 
					   AutoNumero varchar(20) 'AutoNumero',
					   Desincronizado bit 'Desincronizado', 
					   FechaUltimaModificacion datetime2(7)  'FechaUltimaModificacion', 
					   Eliminado bit 'Eliminado', 
					   OrigenIdentifier UNIQUEIDENTIFIER 'OrigenIdentifier',
					   DestinoIdentifier UNIQUEIDENTIFIER 'DestinoIdentifier',
					   UsuarioIdentifier UNIQUEIDENTIFIER 'UsuarioIdentifier')
	 )
	 
	 INSERT INTO @Temp
	 SELECT * FROM TransferenciaCTE
	 
	 
	 UPDATE T
	 SET OrigenId = (SELECT TOP 1 MaxiKioscoId FROM MaxiKiosco WHERE Identifier = CTE.OrigenIdentifier), 
		DestinoId = (SELECT TOP 1 MaxiKioscoId FROM MaxiKiosco WHERE Identifier = CTE.DestinoIdentifier), 
		UsuarioId = (SELECT TOP 1 UsuarioId FROM Usuario WHERE Identifier = CTE.UsuarioIdentifier), 
		FechaCreacion = CTE.FechaCreacion, 
		FechaAprobacion = CTE.FechaAprobacion,
		AutoNumero = CTE.AutoNumero,
		Desincronizado = CTE.Desincronizado,
		FechaUltimaModificacion = CTE.FechaUltimaModificacion, 
		Eliminado = CTE.Eliminado
	FROM @Temp CTE
		INNER JOIN Transferencia T
			ON CTE.Identifier = T.Identifier
	WHERE ((@SobreescribirLocal = 1  AND CTE.DestinoIdentifier IN (SELECT MaxikioscoIdentifier FROM ConfiguracionLocal))
			OR (@SobreescribirLocal = 0 AND T.Desincronizado = 0))
	
			
	INSERT INTO Transferencia (Identifier, OrigenId, DestinoId, UsuarioId, FechaCreacion, 
			FechaAprobacion, AutoNumero, Desincronizado,FechaUltimaModificacion, Eliminado)
	SELECT Identifier, 
			(SELECT TOP 1 MaxiKioscoId FROM MaxiKiosco WHERE Identifier = CTE.OrigenIdentifier), 
			(SELECT TOP 1 MaxiKioscoId FROM MaxiKiosco WHERE Identifier = CTE.DestinoIdentifier),
			(SELECT TOP 1 UsuarioId FROM Usuario WHERE Identifier = CTE.UsuarioIdentifier),
			FechaCreacion, 
			FechaAprobacion,
			AutoNumero,
			Desincronizado,
			FechaUltimaModificacion, 
			Eliminado		
	FROM @Temp CTE
	WHERE CTE.Identifier NOT IN (SELECT Identifier FROM Transferencia)
		AND (@SobreescribirLocal = 0 OR (@SobreescribirLocal = 1  AND CTE.DestinoIdentifier IN (SELECT MaxikioscoIdentifier FROM ConfiguracionLocal)))
		
	
	IF @SobreescribirLocal = 1
	BEGIN
		UPDATE T
		SET Desincronizado = 0
		FROM Transferencia T
		WHERE T.Identifier IN (SELECT Identifier
								FROM @Temp)
		
	END
	ELSE
		UPDATE T
		SET Desincronizado = 1
		FROM Transferencia T
		WHERE T.Identifier IN (SELECT Identifier
								FROM @Temp)
		
END



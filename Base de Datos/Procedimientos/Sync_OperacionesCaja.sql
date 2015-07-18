/****** Object:  StoredProcedure [dbo].[Sync_OperacionesCaja]    Script Date: 01/19/2015 17:49:51 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Sync_OperacionesCaja]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Sync_OperacionesCaja]
GO


CREATE PROCEDURE [dbo].[Sync_OperacionesCaja] 
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
	    OperacionCajaId int,
	    Identifier uniqueidentifier,
		Monto money,
		Fecha datetime2(7),		
		FechaUltimaModificacion datetime2(7),
		Eliminado bit,
		MotivoId int,
		Observaciones varchar(max),
		Desincronizado bit,
		CierreCajaIdentifier uniqueidentifier,
		UsuarioCreadorIdentifier uniqueidentifier,
		UsuarioModificacionIdentifier uniqueidentifier
	);
	
	WITH OperacionCajaCTE (OperacionCajaId, Identifier, Monto, Fecha, FechaUltimaModificacion, Eliminado, 
						MotivoId, Observaciones, Desincronizado, CierreCajaIdentifier, 
						UsuarioCreadorIdentifier, UsuarioModificacionIdentifier)
	AS (
		SELECT    *
		FROM       OPENXML (@idoc, '/Exportacion/OperacionesCaja/OC/CC/UC/UM',2) 
				 WITH (OperacionCajaId int '../../../OperacionCajaId',
						Identifier uniqueidentifier '../../../Identifier',
						Monto money '../../../Monto',
						Fecha datetime2(7) '../../../Fecha',		
						FechaUltimaModificacion datetime2(7) '../../../FechaUltimaModificacion',
						Eliminado bit '../../../Eliminado',
						MotivoId int '../../../MotivoId',
						Observaciones varchar(max) '../../../Observaciones',
						Desincronizado bit '../../../Desincronizado',
						CierreCajaIdentifier uniqueidentifier '../../CierreCajaIdentifier',
						UsuarioCreadorIdentifier uniqueidentifier '../UsuarioCreadorIdentifier',
						UsuarioModificacionIdentifier uniqueidentifier 'UsuarioModificacionIdentifier')
	 )
	 
	 INSERT INTO @Temp
	 SELECT * FROM OperacionCajaCTE
	 
	 	 
	 UPDATE OC
	 SET CierreCajaId = (SELECT TOP 1 CierreCajaId FROM CierreCaja WHERE Identifier = CTE.CierreCajaIdentifier), 
	    UsuarioCreadorId = (SELECT TOP 1 UsuarioId FROM Usuario WHERE Identifier = CTE.UsuarioCreadorIdentifier), 
	    UltimoUsuarioModificacionId = (SELECT TOP 1 UsuarioId FROM Usuario WHERE Identifier = CTE.UsuarioModificacionIdentifier), 
		Monto = CTE.Monto, 
		Fecha = CTE.Fecha, 
		FechaUltimaModificacion = CTE.FechaUltimaModificacion, 
		Eliminado = CTE.Eliminado, 
		MotivoId = CTE.MotivoId, 
		Observaciones = CTE.Observaciones, 
		Desincronizado = CTE.Desincronizado
	FROM @Temp CTE
		INNER JOIN OperacionCaja OC
			ON CTE.Identifier = OC.Identifier
	WHERE ((@SobreescribirLocal = 1 AND (SELECT CierreCajaId FROM CierreCaja WHERE Identifier = CTE.CierreCajaIdentifier) IS NOT NULL)
			OR (@SobreescribirLocal = 0 AND CTE.Desincronizado = 0))
	;
	 
	 INSERT INTO OperacionCaja (Identifier,
								CierreCajaId, 
								UsuarioCreadorId, 
								UltimoUsuarioModificacionId, 
								Monto, 
								Fecha, 
								FechaUltimaModificacion, 
								Eliminado, 
								MotivoId, 
								Observaciones, 
								Desincronizado)
	 SELECT Identifier,
			(SELECT TOP 1 CierreCajaId FROM CierreCaja WHERE Identifier = CTE.CierreCajaIdentifier), 
			(SELECT TOP 1 UsuarioId FROM Usuario WHERE Identifier = CTE.UsuarioCreadorIdentifier), 
	        (SELECT TOP 1 UsuarioId FROM Usuario WHERE Identifier = CTE.UsuarioModificacionIdentifier),
			Monto, 
			Fecha, 
			FechaUltimaModificacion, 
			Eliminado, 
			MotivoId, 
			Observaciones, 
			Desincronizado
			
	 FROM @Temp CTE
	 WHERE CTE.Identifier NOT IN (SELECT Identifier FROM OperacionCaja)
		AND (SELECT CierreCajaId FROM CierreCaja WHERE Identifier = CTE.CierreCajaIdentifier) IS NOT NULL
	
	 
	IF @SobreescribirLocal = 1
	BEGIN
		UPDATE OC
		SET Desincronizado = 0
		FROM OperacionCaja OC
		WHERE OC.Identifier IN (SELECT Identifier
								FROM @Temp)
		
	END
	ELSE
		UPDATE OC
		SET Desincronizado = 1
		FROM OperacionCaja OC
		WHERE OC.Identifier IN (SELECT Identifier
								FROM @Temp)
		
    
	
END




GO



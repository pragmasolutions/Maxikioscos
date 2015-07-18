/****** Object:  StoredProcedure [dbo].[Sync_CierresCaja]    Script Date: 10/28/2014 14:20:16 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Sync_CierresCaja]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Sync_CierresCaja]
GO


CREATE PROCEDURE [dbo].[Sync_CierresCaja] 
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
	    CierreCajaId int,
		Identifier uniqueidentifier,
		FechaInicio datetime2(7),
		FechaFin datetime2(7),
		CajaInicial money,
		CajaFinal money,
		CajaEsperada money,
		Desincronizado bit,
		FechaUltimaModificacion datetime2(7),
		Eliminado bit,
		UsuarioIdentifier uniqueidentifier,
		MaxiKioscoIdentifier uniqueidentifier
	);
	
	WITH CierreCajaCTE (CierreCajaId, Identifier, FechaInicio, FechaFin, CajaInicial, CajaFinal, CajaEsperada,
					 Desincronizado, FechaUltimaModificacion, Eliminado, MaxiKioscoIdentifier, UsuarioIdentifier)
	AS (
		SELECT    *
		FROM       OPENXML (@idoc, '/Exportacion/CierresCaja/CC/U/M',2) 
				 WITH (CierreCajaId int '../../CierreCajaId',
						Identifier uniqueidentifier '../../Identifier',
						FechaInicio datetime2(7) '../../FechaInicio',
						FechaFin datetime2(7) '../../FechaFin',
						CajaInicial money '../../CajaInicial',
						CajaFinal money '../../CajaFinal',
						CajaEsperada money '../../CajaEsperada',
						Desincronizado bit '../../Desincronizado',
						FechaUltimaModificacion datetime2(7) '../../FechaUltimaModificacion',
						Eliminado bit '../../Eliminado',						
						UsuarioIdentifier uniqueidentifier '../UsuarioIdentifier',
						MaxiKioscoIdentifier uniqueidentifier 'MaxiKioscoIdentifier')
	 )
	 
	 INSERT INTO @Temp
	 SELECT * FROM CierreCajaCTE
	 	 	 	 
	 UPDATE CC
	 SET UsuarioId = (SELECT UsuarioId FROM Usuario WHERE Identifier = CTE.UsuarioIdentifier), 
		MaxiKioskoId = (SELECT MaxiKioscoId FROM MaxiKiosco WHERE Identifier = CTE.MaxiKioscoIdentifier), 
		FechaInicio = CTE.FechaInicio, 
		FechaFin = CTE.FechaFin, 
		CajaInicial = CTE.CajaInicial, 
		CajaFinal = CTE.CajaFinal, 
		CajaEsperada = CTE.CajaEsperada,
		Desincronizado = CTE.Desincronizado,
		FechaUltimaModificacion = CTE.FechaUltimaModificacion, 
		Eliminado = CTE.Eliminado
	FROM @Temp CTE
		INNER JOIN CierreCaja CC
			ON CTE.Identifier = CC.Identifier;
	 
	 INSERT INTO CierreCaja (Identifier, 
							FechaInicio, 
							FechaFin, 
							CajaInicial, 
							CajaFinal, 
							CajaEsperada,
							Desincronizado, 
							FechaUltimaModificacion, 
							Eliminado, 
							UsuarioId,
							MaxiKioskoId)
	 SELECT Identifier, 
			FechaInicio, 
			FechaFin, 
			CajaInicial, 
			CajaFinal, 
			CajaEsperada,
			Desincronizado, 
			FechaUltimaModificacion, 
			Eliminado,
			(SELECT UsuarioId FROM Usuario WHERE Identifier = CTE.UsuarioIdentifier), 
			(SELECT MaxiKioscoId FROM MaxiKiosco WHERE Identifier = CTE.MaxiKioscoIdentifier)
	 FROM @Temp CTE
	 WHERE CTE.Identifier NOT IN (SELECT Identifier FROM CierreCaja)
	 
	 /*
    IF @SobreescribirLocal = 1
	BEGIN
		UPDATE CC
		SET Desincronizado = 0
		FROM CierreCaja CC
		WHERE CC.Identifier IN (SELECT Identifier
								FROM @Temp)
	END
	ELSE
		UPDATE CC
		SET Desincronizado = 1
		FROM CierreCaja CC
		WHERE CC.Identifier IN (SELECT Identifier
								FROM @Temp)
	*/
	
	---------------------------------------------------------------------------
	--NUNCA VUELVE, EL CIERRE DE CAJA VA SOLO DESDE EL DESKTOP HACIA LA WEB----
	--ASI QUE SIEMPRE QUEDA DESINCRONIZADO = 0 --------------------------------
	---------------------------------------------------------------------------
	UPDATE CC
		SET Desincronizado = 0
		FROM CierreCaja CC
		WHERE CC.Identifier IN (SELECT Identifier
								FROM @Temp)
END




GO



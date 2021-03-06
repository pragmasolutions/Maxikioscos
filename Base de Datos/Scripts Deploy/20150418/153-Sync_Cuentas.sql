
/****** Object:  StoredProcedure [dbo].[Sync_Cuentas]    Script Date: 08/09/2014 15:49:42 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Sync_Cuentas]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Sync_Cuentas]
GO



CREATE PROCEDURE [dbo].[Sync_Cuentas] 
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
	   CuentaId INT, 
	   Identifier UNIQUEIDENTIFIER,
	   Titular varchar(150), 
	   MargenImporteFactura INT,
	   AplicarPercepcionIVADesde money NULL,
	   PorcentajePercepcionIVA money NULL,
	   MargenInferiorCierreCajaAceptable money,
	   MargenSuperiorCierreCajaAceptable money,
	   MaxiKioscoIdentifierPredeterminadoTransferencias uniqueidentifier NULL,
	   Desincronizado bit, 
	   FechaUltimaModificacion datetime2(7), 
	   Eliminado bit	   
	);
	
	WITH CuentasCTE (CuentaId, Identifier, Titular, MargenImporteFactura, 
		  AplicarPercepcionIVADesde, PorcentajePercepcionIVA, 
		  MargenInferiorCierreCajaAceptable, MargenSuperiorCierreCajaAceptable,
		  MaxiKioscoIdentifierPredeterminadoTransferencias, Desincronizado, 
		  FechaUltimaModificacion, Eliminado)
	AS (
		SELECT    *
		FROM       OPENXML (@idoc, '/Exportacion/Cuentas/Cuenta',1) 
				 WITH (CuentaId INT	'MarcaId', 
					   Identifier UNIQUEIDENTIFIER   'Identifier',
					   Titular varchar(150) 'Titular', 
					   MargenImporteFactura money 'MargenImporteFactura', 
					   AplicarPercepcionIVADesde money 'AplicarPercepcionIVADesde', 
					   PorcentajePercepcionIVA money 'PorcentajePercepcionIVA', 
					   MargenInferiorCierreCajaAceptable money 'MargenInferiorCierreCajaAceptable',
					   MargenSuperiorCierreCajaAceptable money 'MargenSuperiorCierreCajaAceptable',
					   MaxiKioscoIdentifierPredeterminadoTransferencias UNIQUEIDENTIFIER 'MaxiKioscoIdentifierPredeterminadoTransferencias',
					   Desincronizado bit 'Desincronizado', 
					   FechaUltimaModificacion datetime2(7)  'FechaUltimaModificacion', 
					   Eliminado bit 'Eliminado')
	 )
	 
	 INSERT INTO @Temp
	 SELECT * FROM CuentasCTE
	 
	 	 
	 UPDATE C
	 SET Titular = CTE.Titular, 
		MargenImporteFactura = CTE.MargenImporteFactura,
		AplicarPercepcionIVADesde = CTE.AplicarPercepcionIVADesde,
		PorcentajePercepcionIVA = CTE.PorcentajePercepcionIVA,
		MargenInferiorCierreCajaAceptable = CTE.MargenInferiorCierreCajaAceptable, 
		MargenSuperiorCierreCajaAceptable = CTE.MargenSuperiorCierreCajaAceptable,
		MaxiKioscoIdentifierPredeterminadoTransferencias = CTE.MaxiKioscoIdentifierPredeterminadoTransferencias,
		Desincronizado = CTE.Desincronizado,
		FechaUltimaModificacion = CTE.FechaUltimaModificacion, 
		Eliminado = CTE.Eliminado
	FROM @Temp CTE
		INNER JOIN Cuenta C
			ON CTE.Identifier = C.Identifier
	WHERE (@SobreescribirLocal = 1 OR
			(@SobreescribirLocal = 0 AND C.Desincronizado = 0))
	;

	
	 INSERT INTO Cuenta (Identifier, Titular, MargenImporteFactura, AplicarPercepcionIVADesde, 
		PorcentajePercepcionIVA, MargenInferiorCierreCajaAceptable, MargenSuperiorCierreCajaAceptable,
		MaxiKioscoIdentifierPredeterminadoTransferencias, Desincronizado,	
		FechaUltimaModificacion, Eliminado)
	 SELECT Identifier, 
			Titular,
			MargenImporteFactura,
			AplicarPercepcionIVADesde,
			PorcentajePercepcionIVA,
			MargenInferiorCierreCajaAceptable, 
			MargenSuperiorCierreCajaAceptable,
			MaxiKioscoIdentifierPredeterminadoTransferencias,
			Desincronizado,
			FechaUltimaModificacion, 
			Eliminado
	 FROM @Temp CTE
	 WHERE CTE.Identifier NOT IN (SELECT Identifier FROM Cuenta)
	 
	 
	 
	 IF @SobreescribirLocal = 1
	 BEGIN
		UPDATE C
		SET Desincronizado = 0
		FROM Cuenta C
		WHERE C.Identifier IN (SELECT Identifier
								FROM @Temp)
		
	 END
	 ELSE
		UPDATE C
		SET Desincronizado = 1
		FROM Cuenta C
		WHERE C.Identifier IN (SELECT Identifier
								FROM @Temp)
		
	
END




GO



/****** Object:  StoredProcedure [dbo].[Sync_Compras]    Script Date: 01/19/2015 17:51:22 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Sync_Compras]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Sync_Compras]
GO


CREATE PROCEDURE [dbo].[Sync_Compras] 
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
	   CompraId INT, 
	   Identifier UNIQUEIDENTIFIER,
	   Fecha datetime2(7),
	   Numero varchar(25),
	   Desincronizado bit,
	   FechaUltimaModificacion datetime2(7),
	   Eliminado bit,
	   PercepcionIVA money,
	   PercepcionDGR money,
	   ImporteFactura money,
	   TotalCompra money,
	   Descuento money,
	   ImporteFinal money,
	   FacturaIdentifier UNIQUEIDENTIFIER,
	   CuentaIdentifier UNIQUEIDENTIFIER,
	   MaxiKioscoIdentifier UNIQUEIDENTIFIER
	);
	
	
	WITH CompraCTE (CompraId, Identifier, Fecha, Numero, Desincronizado, FechaUltimaModificacion,
	   Eliminado, PercepcionIVA,PercepcionDGR, ImporteFactura, TotalCompra, Descuento,
	   ImporteFinal, FacturaIdentifier, CuentaIdentifier, MaxiKioscoIdentifier)
	AS (
		SELECT    *
		FROM       OPENXML (@idoc, '/Exportacion/Compras/C/F/CU/M',4) 
				 WITH (CompraId INT	'../../../CompraId', 
					   Identifier UNIQUEIDENTIFIER   '../../../Identifier',
					   Fecha datetime2(7) '../../../Fecha', 
					   Numero varchar(25) '../../../Numero', 
					   Desincronizado bit '../../../Desincronizado',
					   FechaUltimaModificacion datetime2(7) '../../../FechaUltimaModificacion',  
					   Eliminado bit '../../../Eliminado', 
					   PercepcionIVA money '../../../PercepcionIVA',
					   PercepcionDGR money '../../../PercepcionDGR',
					   ImporteFactura money '../../../ImporteFactura',
					   TotalCompra money '../../../TotalCompra',
					   Descuento money '../../../Descuento',
					   ImporteFinal money '../../../ImporteFinal',
					   FacturaIdentifier UNIQUEIDENTIFIER '../../FacturaIdentifier',
					   CuentaIdentifier UNIQUEIDENTIFIER '../CuentaIdentifier',
					   MaxiKioscoIdentifier UNIQUEIDENTIFIER 'MaxiKioscoIdentifier')
	 )
	 
	 INSERT INTO @Temp
	 SELECT * FROM CompraCTE
	 
	 	 
	 UPDATE C
	 SET FacturaId = (SELECT TOP 1 FacturaId FROM Factura WHERE Identifier = CTE.FacturaIdentifier), 
		 CuentaId = (SELECT TOP 1 CuentaId FROM Cuenta WHERE Identifier = CTE.CuentaIdentifier), 
		 MaxiKioscoId = (SELECT TOP 1 MaxiKioscoId FROM MaxiKiosco WHERE Identifier = CTE.MaxiKioscoIdentifier), 
		 Fecha = CTE.Fecha, 
		 Numero = CTE.Numero, 
		 PercepcionIVA = CTE.PercepcionIVA,
		 PercepcionDGR = CTE.PercepcionDGR,
		 ImporteFactura = CTE.ImporteFactura, 
		 TotalCompra = CTE.TotalCompra, 
		 Descuento = CTE.Descuento,
	     ImporteFinal = CTE.ImporteFinal,
		 FechaUltimaModificacion = CTE.FechaUltimaModificacion, 
		 Desincronizado = CTE.Desincronizado,
		 Eliminado = CTE.Eliminado
	FROM @Temp CTE
		INNER JOIN Compra C
			ON CTE.Identifier = C.Identifier
	WHERE ((@SobreescribirLocal = 1  AND CTE.MaxiKioscoIdentifier IN (SELECT MaxikioscoIdentifier FROM ConfiguracionLocal))
			OR (@SobreescribirLocal = 0 AND C.Desincronizado = 0))
	;
	 
	 INSERT INTO Compra (Identifier, Fecha, Numero, Desincronizado, FechaUltimaModificacion,
						 Eliminado, PercepcionIVA, PercepcionDGR, ImporteFactura, 
						 TotalCompra, Descuento, ImporteFinal, FacturaId, CuentaId, MaxiKioscoId)
	 SELECT Identifier, 
			Fecha,
			Numero,
			Desincronizado,
			FechaUltimaModificacion,
			Eliminado,
			PercepcionIVA,
			PercepcionDGR,
			ImporteFactura, 
			TotalCompra, 
			Descuento,
			ImporteFinal,
			(SELECT TOP 1 FacturaId FROM Factura WHERE Identifier = CTE.FacturaIdentifier), 
			(SELECT TOP 1 CuentaId FROM Cuenta WHERE Identifier = CTE.CuentaIdentifier),
			(SELECT TOP 1 MaxiKioscoId FROM MaxiKiosco WHERE Identifier = CTE.MaxiKioscoIdentifier)
	 FROM @Temp CTE
	 WHERE CTE.Identifier NOT IN (SELECT Identifier FROM Compra)
		AND (@SobreescribirLocal = 0 OR (@SobreescribirLocal = 1  AND CTE.MaxiKioscoIdentifier IN (SELECT MaxikioscoIdentifier FROM ConfiguracionLocal)))
	 
	 
    IF @SobreescribirLocal = 1
	BEGIN
		UPDATE C
		SET Desincronizado = 0
		FROM Compra C
		WHERE C.Identifier IN (SELECT Identifier
							   FROM @Temp)
		
	END
	ELSE
		UPDATE C
		SET Desincronizado = 1
		FROM Compra C
		WHERE C.Identifier IN (SELECT Identifier
							   FROM @Temp)
		
END



GO



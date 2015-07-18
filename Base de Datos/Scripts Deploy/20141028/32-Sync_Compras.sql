
/****** Object:  StoredProcedure [dbo].[Sync_Compras]    Script Date: 08/09/2014 15:49:28 ******/
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
	   FacturaIdentifier UNIQUEIDENTIFIER,
	   CuentaIdentifier UNIQUEIDENTIFIER,
	   MaxiKioscoIdentifier UNIQUEIDENTIFIER,
	   PercepcionIVA money NULL,
	   PercepcionDGR money NULL
	);
	
	
	WITH CompraCTE (CompraId, Identifier, Fecha, Numero, Desincronizado, FechaUltimaModificacion,
	   Eliminado, FacturaIdentifier, CuentaIdentifier, MaxiKioscoIdentifier,PercepcionIVA,PercepcionDGR)
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
					   FacturaIdentifier UNIQUEIDENTIFIER '../../FacturaIdentifier',
					   CuentaIdentifier UNIQUEIDENTIFIER '../CuentaIdentifier',
					   MaxiKioscoIdentifier UNIQUEIDENTIFIER 'MaxiKioscoIdentifier',
					   PercepcionIVA money 'PercepcionIVA',
					   PercepcionDGR money 'PercepcionDGR')
	 )
	 
	 INSERT INTO @Temp
	 SELECT * FROM CompraCTE
	 	 
	 UPDATE C
	 SET FacturaId = (SELECT FacturaId FROM Factura WHERE Identifier = CTE.FacturaIdentifier), 
		 CuentaId = (SELECT CuentaId FROM Cuenta WHERE Identifier = CTE.CuentaIdentifier), 
		 MaxiKioscoId = (SELECT MaxiKioscoId FROM MaxiKiosco WHERE Identifier = CTE.MaxiKioscoIdentifier), 
		 Fecha = CTE.Fecha, 
		 Numero = CTE.Numero, 
		 PercepcionIVA = CTE.PercepcionIVA,
		 PercepcionDGR = CTE.PercepcionDGR,
		 FechaUltimaModificacion = CTE.FechaUltimaModificacion, 
		 Desincronizado = CTE.Desincronizado,
		 Eliminado = CTE.Eliminado
	FROM @Temp CTE
		INNER JOIN Compra C
			ON CTE.Identifier = C.Identifier
	WHERE (@SobreescribirLocal = 1 OR
			(@SobreescribirLocal = 0 AND C.Desincronizado = 0));
	 
	 INSERT INTO Compra (Identifier, Fecha, Numero, Desincronizado, FechaUltimaModificacion,
						 Eliminado, FacturaId, CuentaId, MaxiKioscoId, PercepcionIVA, PercepcionDGR)
	 SELECT Identifier, 
			Fecha,
			Numero,
			Desincronizado,
			FechaUltimaModificacion,
			Eliminado,
			(SELECT FacturaId FROM Factura WHERE Identifier = CTE.FacturaIdentifier), 
			(SELECT CuentaId FROM Cuenta WHERE Identifier = CTE.CuentaIdentifier),
			(SELECT MaxiKioscoId FROM MaxiKiosco WHERE Identifier = CTE.MaxiKioscoIdentifier),
			PercepcionIVA,
			PercepcionDGR			
	 FROM @Temp CTE
	 WHERE CTE.Identifier NOT IN (SELECT Identifier FROM Compra)
	 
	 
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



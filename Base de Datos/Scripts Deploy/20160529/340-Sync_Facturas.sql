/****** Object:  StoredProcedure [dbo].[Sync_Facturas]    Script Date: 01/19/2015 17:50:08 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Sync_Facturas]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Sync_Facturas]
GO

CREATE PROCEDURE [dbo].[Sync_Facturas] 
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
	   FacturaId int, 
	   Identifier uniqueidentifier,  
	   FacturaNro varchar(15), 
	   ImporteTotal money, 
	   Fecha datetime2(7), 
	   Desincronizado bit,
	   FechaUltimaModificacion datetime2(7), 
	   Eliminado bit, 
	   ProveedorIdentifier uniqueidentifier, 
	   MaxiKioscoIdentifier uniqueidentifier, 
	   CierreCajaIdentifier uniqueidentifier,
	   UsuarioIdentifier uniqueidentifier,
	   Usuario int,
	   AutoNumero varchar (20),
	   FechaCreacion datetime,
	   Finalizada bit
	);
	
	WITH FacturaCTE (FacturaId, Identifier, FacturaNro, ImporteTotal, Fecha, Desincronizado,
			FechaUltimaModificacion, Eliminado, ProveedorIdentifier, MaxiKioscoIdentifier, 
			CierreCajaIdentifier, UsuarioIdentifier, Usuario, AutoNumero, FechaCreacion,Finalizada)
	AS (
		SELECT    *
		FROM       OPENXML (@idoc, '/Exportacion/Facturas/F/P/M/CC',4) 
				 WITH (FacturaId int '../../../FacturaId',
						Identifier uniqueidentifier '../../../Identifier',
						FacturaNro varchar(15) '../../../FacturaNro',
						ImporteTotal money '../../../ImporteTotal',
						Fecha datetime2(7) '../../../Fecha',
						Desincronizado bit '../../../Desincronizado',
						FechaUltimaModificacion datetime2(7) '../../../FechaUltimaModificacion',
						Eliminado bit '../../../Eliminado',
						ProveedorIdentifier uniqueidentifier '../../ProveedorIdentifier',
						MaxiKioscoIdentifier uniqueidentifier '../MaxiKioscoIdentifier',
						CierreCajaIdentifier uniqueidentifier 'CierreCajaIdentifier',
						UsuarioIdentifier uniqueidentifier '../../../UsuarioIdentifier',
						Usuario int '../../../Usuario',
						AutoNumero varchar(20) '../../../AutoNumero',
						FechaCreacion datetime '../../../FechaCreacion',
						Finalizada bit '../../../Finalizada')
	 )
	 
	 INSERT INTO @Temp
	 SELECT * FROM FacturaCTE
	 
	 UPDATE F
	 SET ProveedorId = (SELECT TOP 1 ProveedorId FROM Proveedor WHERE Identifier = CTE.ProveedorIdentifier), 
		MaxiKioscoId = (SELECT TOP 1 MaxiKioscoId FROM MaxiKiosco WHERE Identifier = CTE.MaxiKioscoIdentifier), 
		CierreCajaId = (SELECT TOP 1 CierreCajaId FROM CierreCaja WHERE Identifier = CTE.CierreCajaIdentifier), 
		Usuario = (SELECT TOP 1 UsuarioId FROM Usuario WHERE Identifier = CTE.UsuarioIdentifier), 
		FacturaNro = CTE.FacturaNro, 
		ImporteTotal = CTE.ImporteTotal, 
		Fecha = CTE.Fecha, 
		Desincronizado = CTE.Desincronizado,
		FechaUltimaModificacion = CTE.FechaUltimaModificacion, 
		Eliminado = CTE.Eliminado, 
		AutoNumero = CTE.AutoNumero,
		FechaCreacion = CTE.FechaCreacion,
		Finalizada = ISNULL(CTE.Finalizada, 0)
	FROM @Temp CTE
		INNER JOIN Factura F
			ON CTE.Identifier = F.Identifier
	WHERE ((@SobreescribirLocal = 1  AND CTE.MaxiKioscoIdentifier IN (SELECT MaxikioscoIdentifier FROM ConfiguracionLocal))
			OR (@SobreescribirLocal = 0 AND F.Desincronizado = 0))
	
	 

	 INSERT INTO Factura (Identifier, ProveedorId, MaxiKioscoId, CierreCajaId, Usuario, FacturaNro, 
		ImporteTotal, Fecha, Desincronizado, FechaUltimaModificacion, Eliminado, AutoNumero, FechaCreacion,Finalizada)
	 SELECT Identifier, 
			(SELECT TOP 1 ProveedorId FROM Proveedor WHERE Identifier = CTE.ProveedorIdentifier), 
			(SELECT TOP 1 MaxiKioscoId FROM MaxiKiosco WHERE Identifier = CTE.MaxiKioscoIdentifier), 
			(SELECT TOP 1 CierreCajaId FROM CierreCaja WHERE Identifier = CTE.CierreCajaIdentifier),
			(SELECT TOP 1 UsuarioId FROM Usuario WHERE Identifier = CTE.UsuarioIdentifier),
			FacturaNro, 
			ImporteTotal, 
			Fecha,
			Desincronizado,
			FechaUltimaModificacion,
			Eliminado,
			AutoNumero,
			FechaCreacion,
			ISNULL(Finalizada, 0)
	 FROM @Temp CTE
	 WHERE CTE.Identifier NOT IN (SELECT Identifier FROM Factura)
		AND (@SobreescribirLocal = 0 OR (@SobreescribirLocal = 1  AND CTE.MaxiKioscoIdentifier IN (SELECT MaxikioscoIdentifier FROM ConfiguracionLocal)))
	 
	IF @SobreescribirLocal = 1
	BEGIN
		UPDATE F
		SET Desincronizado = 0
		FROM Factura F
		WHERE F.Identifier IN (SELECT Identifier
								FROM @Temp)
		
	END
	ELSE
		UPDATE F
		SET Desincronizado = 1
		FROM Factura F
		WHERE F.Identifier IN (SELECT Identifier
								FROM @Temp)
		
		
END

GO


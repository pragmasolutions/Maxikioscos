/****** Object:  StoredProcedure [dbo].[Sync_Facturas]    Script Date: 12/01/2014 10:29:05 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Sync_Facturas]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Sync_Facturas]
GO


CREATE PROCEDURE [dbo].[Sync_Facturas] 
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
	   FacturaId int, 
	   Identifier uniqueidentifier,  
	   FacturaNro varchar(15), 
	   ImporteTotal money, 
	   Fecha datetime2(7), 
	   Desincronizado bit,
	   FechaUltimaModificacion datetime2(7), 
	   Eliminado bit, 
	   DescuentoPorcentaje decimal(18,2), 
	   DescuentoEnPesos money,
	   ProveedorIdentifier uniqueidentifier, 
	   MaxiKioscoIdentifier uniqueidentifier, 
	   CierreCajaIdentifier uniqueidentifier,
	   Usuario int,
	   AutoNumero varchar (20)
	);
	
	WITH FacturaCTE (FacturaId, Identifier, FacturaNro, ImporteTotal, Fecha, Desincronizado,
			FechaUltimaModificacion, Eliminado, DescuentoPorcentaje, DescuentoEnPesos,
			ProveedorIdentifier, MaxiKioscoIdentifier, CierreCajaIdentifier,Usuario,AutoNumero)
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
						DescuentoPorcentaje decimal(18, 0) '../../../DescuentoPorcentaje',
						DescuentoEnPesos money '../../../DescuentoEnPesos',
						ProveedorIdentifier uniqueidentifier '../../ProveedorIdentifier',
						MaxiKioscoIdentifier uniqueidentifier '../MaxiKioscoIdentifier',
						CierreCajaIdentifier uniqueidentifier 'CierreCajaIdentifier',
						Usuario int '../../../Usuario',
						AutoNumero varchar(20) '../../../AutoNumero')
	 )
	 
	 INSERT INTO @Temp
	 SELECT * FROM FacturaCTE
		 
	 UPDATE F
	 SET ProveedorId = (SELECT ProveedorId FROM Proveedor WHERE Identifier = CTE.ProveedorIdentifier), 
		MaxiKioscoId = (SELECT MaxiKioscoId FROM MaxiKiosco WHERE Identifier = CTE.MaxiKioscoIdentifier), 
		CierreCajaId = (SELECT CierreCajaId FROM CierreCaja WHERE Identifier = CTE.CierreCajaIdentifier), 
		FacturaNro = CTE.FacturaNro, 
		ImporteTotal = CTE.ImporteTotal, 
		Fecha = CTE.Fecha, 
		Desincronizado = CTE.Desincronizado,
		FechaUltimaModificacion = CTE.FechaUltimaModificacion, 
		Eliminado = CTE.Eliminado, 
		DescuentoPorcentaje = CTE.DescuentoPorcentaje, 
		DescuentoEnPesos = CTE.DescuentoEnPesos,
		Usuario = CTE.Usuario,
		AutoNumero = CTE.AutoNumero
	FROM @Temp CTE
		INNER JOIN Factura F
			ON CTE.Identifier = F.Identifier
	WHERE (@SobreescribirLocal = 1 OR
			(@SobreescribirLocal = 0 AND F.Desincronizado = 0))
	 
	 
	 INSERT INTO Factura (Identifier, ProveedorId, MaxiKioscoId, CierreCajaId, FacturaNro, ImporteTotal, 
		Fecha, Desincronizado, FechaUltimaModificacion, Eliminado, DescuentoPorcentaje,	DescuentoEnPesos,Usuario,AutoNumero)
	 SELECT Identifier, 
			(SELECT ProveedorId FROM Proveedor WHERE Identifier = CTE.ProveedorIdentifier), 
			(SELECT MaxiKioscoId FROM MaxiKiosco WHERE Identifier = CTE.MaxiKioscoIdentifier), 
			(SELECT CierreCajaId FROM CierreCaja WHERE Identifier = CTE.CierreCajaIdentifier),
			FacturaNro, 
			ImporteTotal, 
			Fecha,
			Desincronizado,
			FechaUltimaModificacion,
			Eliminado,
			DescuentoPorcentaje,
			DescuentoEnPesos,
			Usuario,
			AutoNumero
	 FROM @Temp CTE
	 WHERE CTE.Identifier NOT IN (SELECT Identifier FROM Factura)
	 
	 
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
	
    COMMIT TRAN
	END TRY
		
	BEGIN CATCH

		declare @error int, @message varchar(4000), @xstate int;
        select @error = ERROR_NUMBER(), @message = ERROR_MESSAGE(), @xstate = XACT_STATE();
		print @message
	END CATCH
		
	
END



GO



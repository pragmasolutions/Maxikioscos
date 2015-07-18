/****** Object:  StoredProcedure [dbo].[Sync_Ventas]    Script Date: 01/19/2015 17:49:11 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Sync_Ventas]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Sync_Ventas]
GO


CREATE PROCEDURE [dbo].[Sync_Ventas] 
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
	    VentaId int,
		Identifier uniqueidentifier,
		CostoTotal money,
		ImporteTotal money,
		FechaVenta datetime,
		Eliminado bit,
		Desincronizado bit,
		FechaUltimaModificacion datetime2(7),
		CierreCajaIdentifier uniqueidentifier
	);
	
	WITH VentaCTE (VentaId, Identifier, CostoTotal, ImporteTotal, FechaVenta, Eliminado, Desincronizado, 
					FechaUltimaModificacion, CierreCajaIdentifier)
	AS (
		SELECT    *
		FROM     OPENXML (@idoc, '/Exportacion/Ventas/V/CC',2) 
				 WITH (VentaId int '../VentaId',
						Identifier uniqueidentifier '../Identifier',
						CostoTotal money '../CostoTotal',
						ImporteTotal money '../ImporteTotal',
						FechaVenta datetime '../FechaVenta',
						Eliminado bit '../Eliminado',
						Desincronizado bit '../Desincronizado',
						FechaUltimaModificacion datetime2(7) '../FechaUltimaModificacion',
						CierreCajaIdentifier uniqueidentifier 'CierreCajaIdentifier')
	 )
	 
	 INSERT INTO @Temp
	 SELECT * FROM VentaCTE
	 	 
	 UPDATE V
	 SET CierreCajaId = (SELECT CierreCajaId FROM CierreCaja WHERE Identifier = CTE.CierreCajaIdentifier),  
	    CostoTotal = CTE.CostoTotal,
		ImporteTotal = CTE.ImporteTotal,
		FechaVenta = CTE.FechaVenta,
		Eliminado = CTE.Eliminado,
		Desincronizado = CTE.Desincronizado,
		FechaUltimaModificacion = CTE.FechaUltimaModificacion
	FROM @Temp CTE
		INNER JOIN Venta V
			ON CTE.Identifier = V.Identifier
	WHERE ((@SobreescribirLocal = 1 AND (SELECT CierreCajaId FROM CierreCaja WHERE Identifier = CTE.CierreCajaIdentifier) IS NOT NULL) OR
			(@SobreescribirLocal = 0 AND V.Desincronizado = 0));
	 
	 INSERT INTO Venta (Identifier, 
						CostoTotal, 
						ImporteTotal, 
						FechaVenta, 
						Eliminado, 
						Desincronizado, 
						FechaUltimaModificacion, 
						CierreCajaId)
	 SELECT Identifier, 
			CostoTotal, 
			ImporteTotal, 
			FechaVenta, 
			Eliminado, 
			Desincronizado, 
			FechaUltimaModificacion,
			(SELECT CierreCajaId FROM CierreCaja WHERE Identifier = CTE.CierreCajaIdentifier)
	 FROM @Temp CTE
	 WHERE CTE.Identifier NOT IN (SELECT Identifier FROM Venta)
		AND (SELECT CierreCajaId FROM CierreCaja WHERE Identifier = CTE.CierreCajaIdentifier) IS NOT NULL
	 
	 
	IF @SobreescribirLocal = 1
	BEGIN
		UPDATE V
		SET Desincronizado = 0
		FROM Venta V
		WHERE V.Identifier IN (SELECT Identifier
								FROM @Temp)
	END
	ELSE
		UPDATE V
		SET Desincronizado = 1
		FROM Venta V
		WHERE V.Identifier IN (SELECT Identifier
								FROM @Temp)
    
	
END


GO



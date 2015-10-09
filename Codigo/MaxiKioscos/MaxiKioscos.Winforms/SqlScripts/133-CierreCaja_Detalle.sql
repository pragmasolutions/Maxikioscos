ALTER PROCEDURE [dbo].[CierreCaja_Detalle]
	@CierreCajaId int
AS
BEGIN
	WITH CTE(Orden, Concepto, Importe, Observaciones)
	AS
	(
		(SELECT TOP 1 1,'Caja Inicial', CajaInicial,  ''
		FROM CierreCaja
		WHERE CierreCajaID = @CierreCajaId)
		
		UNION 	
		
		(SELECT 2, 'Factura Paga', -F.ImporteTotal, '[' + F.FacturaNro + '] - ' + P.Nombre  
		FROM Factura F
			INNER JOIN Proveedor P
				ON F.ProveedorId = P.ProveedorId
		WHERE F.CierreCajaID = @CierreCajaId
			AND P.NoReflejarFacturaEnCaja = 0
			AND F.Eliminado = 0
		)
		
		UNION 	
		
		(SELECT 3, 'Ventas', ISNULL(SUM(ImporteTotal), 0), ''
		FROM Venta
		WHERE CierreCajaID = @CierreCajaId
		)
		
		UNION 	
		
		(SELECT 4, MOC.Descripcion, OC.Monto, ''  
		FROM OperacionCaja OC
			INNER JOIN MotivoOperacionCaja MOC
				ON OC.MotivoId = MOC.MotivoOperacionCajaId
		WHERE OC.CierreCajaID = @CierreCajaId
			AND OC.Eliminado = 0
		)
		
		UNION 	
		
		(SELECT 3, 'Costos', -ISNULL(SUM(Monto), 0), ''
		FROM Costo
		WHERE CierreCajaID = @CierreCajaId
			AND Eliminado = 0
		)
		
		UNION
		
		(SELECT 3, 'Retiros Personales', -ISNULL(SUM(ImporteTotal), 0), ''
		FROM RetiroPersonal
		WHERE CierreCajaID = @CierreCajaId
			AND Eliminado = 0
		)
		
		UNION 	
		
		(SELECT 5, 'Excepción', Importe, Descripcion  
		FROM Excepcion 
		WHERE CierreCajaID = @CierreCajaId
			AND Eliminado = 0
		)
		
		UNION 
		
		(SELECT 6,'IMPORTE TOTAL ESPERADO', CajaEsperada,  ''
		FROM CierreCaja
		WHERE CierreCajaID = @CierreCajaId)
	)
	
	SELECT Orden, Concepto, Importe, Observaciones
	FROM CTE
	ORDER BY Orden
	
END

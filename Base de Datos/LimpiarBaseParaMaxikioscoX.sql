/*
'CB83B4A6-6F25-4437-B64F-A37E153B6CE5'
10
*/

DELETE FROM Exportacion

DELETE FROM OperacionCaja
WHERE CierreCajaId NOT IN (SELECT CierreCajaId
							FROM CierreCaja
							WHERE MaxiKioskoId = 10)




DELETE FROM CompraProducto
WHERE CompraId NOT IN (SELECT CompraId 
						FROM Compra 
						WHERE FacturaId IN (SELECT FacturaId
											FROM Factura
											WHERE CierreCajaId IN (SELECT CierreCajaId
												FROM CierreCaja
												WHERE MaxiKioskoId = 10)))

DELETE FROM Compra
WHERE FacturaId NOT IN (SELECT FacturaId
						FROM Factura
						WHERE CierreCajaId IN (SELECT CierreCajaId
							FROM CierreCaja
							WHERE MaxiKioskoId = 10))


DELETE FROM Factura
WHERE CierreCajaId NOT IN (SELECT CierreCajaId
							FROM CierreCaja
							WHERE MaxiKioskoId = 10)



DELETE FROM VentaProducto
WHERE VentaId NOT IN (SELECT VentaId 
						FROM Venta 
						WHERE CierreCajaId IN (SELECT CierreCajaId
							FROM CierreCaja
							WHERE MaxiKioskoId = 10))

DELETE FROM Venta
WHERE CierreCajaId NOT IN (SELECT CierreCajaId
							FROM CierreCaja
							WHERE MaxiKioskoId = 10)



DELETE FROM RetiroPersonalProducto
WHERE RetiroPersonalId NOT IN (SELECT RetiroPersonalId 
						FROM RetiroPersonal 
						WHERE CierreCajaId IN (SELECT CierreCajaId
							FROM CierreCaja
							WHERE MaxiKioskoId = 10))

DELETE FROM RetiroPersonal
WHERE CierreCajaId NOT IN (SELECT CierreCajaId
							FROM CierreCaja
							WHERE MaxiKioskoId = 10)


DELETE FROM Excepcion
WHERE CierreCajaId NOT IN (SELECT CierreCajaId
							FROM CierreCaja
							WHERE MaxiKioskoId = 10)



DELETE FROM Costo
WHERE CierreCajaId IS NOT NULL
	AND CierreCajaId NOT IN (SELECT CierreCajaId
							FROM CierreCaja
							WHERE MaxiKioskoId = 10)



DELETE
FROM CierreCaja
WHERE MaxiKioskoId != 10 


DELETE FROM ControlStockDetalle
WHERE StockId NOT IN (SELECT StockId
				FROM Stock
				WHERE MaxiKioscoId = 10)

DELETE FROM ControlStock
WHERE MaxikioscoId != 10

DELETE FROM StockTransaccion
WHERE StockId NOT IN (SELECT StockId
				 FROM Stock
				 WHERE MaxiKioscoId = 10)		

DELETE FROM Stock
WHERE MaxiKioscoId != 10 

DELETE 
FROM CorreccionStock
WHERE MaxiKioscoId != 10 


DELETE 
FROM ExcepcionRubro
WHERE MaxiKioscoId != 10 


DELETE 
FROM MaxikioscoTurno
WHERE MaxiKioscoId != 10 


INSERT INTO ConfiguracionLocal
SELECT 1, Identifier
FROM MaxiKiosco 
WHERE MaxiKioscoId = 10


UPDATE MaxiKiosco
SET UltimoScriptCorrido = 182


INSERT INTO [dbo].[Exportacion]
     VALUES
           (1
           ,GETDATE()
           ,1
           ,'<Exportacion></Exportacion>'
           ,1
           ,0
           ,0
           ,GETDATE()
           ,1)
GO





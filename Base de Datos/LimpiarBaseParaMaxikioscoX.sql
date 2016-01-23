/*
'CB83B4A6-6F25-4437-B64F-A37E153B6CE5'
12
*/

DELETE FROM Exportacion

DELETE FROM OperacionCaja
WHERE CierreCajaId NOT IN (SELECT CierreCajaId
							FROM CierreCaja
							WHERE MaxiKioskoId = 12)




DELETE FROM CompraProducto
WHERE CompraId NOT IN (SELECT CompraId 
						FROM Compra 
						WHERE FacturaId IN (SELECT FacturaId
											FROM Factura
											WHERE CierreCajaId IN (SELECT CierreCajaId
												FROM CierreCaja
												WHERE MaxiKioskoId = 12)))

DELETE FROM Compra
WHERE FacturaId NOT IN (SELECT FacturaId
						FROM Factura
						WHERE CierreCajaId IN (SELECT CierreCajaId
							FROM CierreCaja
							WHERE MaxiKioskoId = 12))


DELETE FROM Factura
WHERE CierreCajaId NOT IN (SELECT CierreCajaId
							FROM CierreCaja
							WHERE MaxiKioskoId = 12)



DELETE FROM VentaProducto
WHERE VentaId NOT IN (SELECT VentaId 
						FROM Venta 
						WHERE CierreCajaId IN (SELECT CierreCajaId
							FROM CierreCaja
							WHERE MaxiKioskoId = 12))

DELETE FROM Venta
WHERE CierreCajaId NOT IN (SELECT CierreCajaId
							FROM CierreCaja
							WHERE MaxiKioskoId = 12)



DELETE FROM RetiroPersonalProducto
WHERE RetiroPersonalId NOT IN (SELECT RetiroPersonalId 
						FROM RetiroPersonal 
						WHERE CierreCajaId IN (SELECT CierreCajaId
							FROM CierreCaja
							WHERE MaxiKioskoId = 12))

DELETE FROM RetiroPersonal
WHERE CierreCajaId NOT IN (SELECT CierreCajaId
							FROM CierreCaja
							WHERE MaxiKioskoId = 12)


DELETE FROM Excepcion
WHERE CierreCajaId NOT IN (SELECT CierreCajaId
							FROM CierreCaja
							WHERE MaxiKioskoId = 12)



DELETE FROM Costo
WHERE CierreCajaId IS NOT NULL
	AND CierreCajaId NOT IN (SELECT CierreCajaId
							FROM CierreCaja
							WHERE MaxiKioskoId = 12)


DELETE
FROM CierreCaja
WHERE MaxiKioskoId != 12 


DELETE FROM ControlStockDetalle
WHERE StockId NOT IN (SELECT StockId
				FROM Stock
				WHERE MaxiKioscoId = 12)

DELETE FROM ControlStock
WHERE MaxikioscoId != 12

DELETE FROM StockTransaccion
WHERE StockId NOT IN (SELECT StockId
				 FROM Stock
				 WHERE MaxiKioscoId = 12)		

DELETE FROM Stock
WHERE MaxiKioscoId != 12 

DELETE 
FROM CorreccionStock
WHERE MaxiKioscoId != 12 


DELETE 
FROM ExcepcionRubro
WHERE MaxiKioscoId != 12 


DELETE 
FROM MaxikioscoTurno
WHERE MaxiKioscoId != 12 




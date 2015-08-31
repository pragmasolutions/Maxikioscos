/*
'CB83B4A6-6F25-4437-B64F-A37E153B6CE5'
11
*/

DELETE FROM OperacionCaja
WHERE CierreCajaId NOT IN (SELECT CierreCajaId
							FROM CierreCaja
							WHERE MaxiKioskoId = 11)




DELETE FROM CompraProducto
WHERE CompraId NOT IN (SELECT CompraId 
						FROM Compra 
						WHERE FacturaId IN (SELECT FacturaId
											FROM Factura
											WHERE CierreCajaId IN (SELECT CierreCajaId
												FROM CierreCaja
												WHERE MaxiKioskoId = 11)))

DELETE FROM Compra
WHERE FacturaId NOT IN (SELECT FacturaId
						FROM Factura
						WHERE CierreCajaId IN (SELECT CierreCajaId
							FROM CierreCaja
							WHERE MaxiKioskoId = 11))


DELETE FROM Factura
WHERE CierreCajaId NOT IN (SELECT CierreCajaId
							FROM CierreCaja
							WHERE MaxiKioskoId = 11)



DELETE FROM VentaProducto
WHERE VentaId NOT IN (SELECT VentaId 
						FROM Venta 
						WHERE CierreCajaId IN (SELECT CierreCajaId
							FROM CierreCaja
							WHERE MaxiKioskoId = 11))

DELETE FROM Venta
WHERE CierreCajaId NOT IN (SELECT CierreCajaId
							FROM CierreCaja
							WHERE MaxiKioskoId = 11)


DELETE FROM Excepcion
WHERE CierreCajaId NOT IN (SELECT CierreCajaId
							FROM CierreCaja
							WHERE MaxiKioskoId = 11)

DELETE
FROM CierreCaja
WHERE MaxiKioskoId != 11 


DELETE FROM ControlStockDetalle
WHERE StockId NOT IN (SELECT StockId
				FROM Stock
				WHERE MaxiKioscoId = 11)

DELETE FROM ControlStock
WHERE MaxikioscoId != 11

DELETE FROM StockTransaccion
WHERE StockId NOT IN (SELECT StockId
				 FROM Stock
				 WHERE MaxiKioscoId = 11)		

DELETE FROM Stock
WHERE MaxiKioscoId != 11 

DELETE 
FROM CorreccionStock
WHERE MaxiKioscoId != 11 


DELETE 
FROM ExcepcionRubro
WHERE MaxiKioscoId != 11 


DELETE 
FROM MaxikioscoTurno
WHERE MaxiKioscoId != 11 


DELETE FROM TransferenciaProducto
DELETE FROM Transferencia



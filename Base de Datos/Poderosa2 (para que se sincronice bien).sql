DELETE FROM StockTransaccion
DELETE FROM Stock
DELETE FROM Compra
DELETE FROM CompraProducto
DELETE FROM ControlStock
DELETE FROM ControlStockDetalle
DELETE FROM Factura
DELETE FROM Importacion
DELETE FROM OperacionCaja
DELETE FROM RecuentoBillete
DELETE FROM VentaProducto
DELETE FROM Venta
DELETE FROM CierreCaja
DELETE FROM Exportacion

UPDATE Producto SET Desincronizado = 1
UPDATE CodigoProducto SET Desincronizado = 1
UPDATE Rubro SET Desincronizado = 1
UPDATE Marca SET Desincronizado = 1
UPDATE MaxiKiosco SET Desincronizado = 1
UPDATE Proveedor SET Desincronizado = 1
UPDATE Usuario SET Desincronizado = 1
UPDATE UsuarioMaxikiosco SET Desincronizado = 1
UPDATE UsuarioProveedor SET Desincronizado = 1

DELETE FROM CompraProducto
DELETE FROM Compra

ALTER TABLE Compra
ADD ImporteFactura money NOT NULL
GO

ALTER TABLE Compra
ADD TotalCompra money NOT NULL
GO

ALTER TABLE Compra
ADD Descuento money NOT NULL
GO

ALTER TABLE Compra
ADD ImporteFinal money NOT NULL
GO





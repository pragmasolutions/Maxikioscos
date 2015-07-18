DELETE FROM CompraProducto
DELETE FROM Compra
DELETE FROM Factura

ALTER TABLE Factura
ADD FechaCreacion datetime NOT NULL
GO

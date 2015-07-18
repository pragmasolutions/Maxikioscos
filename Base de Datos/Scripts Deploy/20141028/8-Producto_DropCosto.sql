ALTER TABLE Producto
DROP COLUMN Costo
GO

UPDATE ProveedorProducto
SET FechaUltimaModificacion = GETDATE()
WHERE FechaUltimaModificacion IS NULL
GO
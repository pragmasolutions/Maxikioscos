ALTER TABLE ControlStock
ADD FechaCorreccion datetime NULL
GO

ALTER TABLE ControlStockDetalle
DROP COLUMN FechaCorreccion
GO
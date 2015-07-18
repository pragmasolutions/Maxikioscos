ALTER TABLE Producto
ADD EsPromocion bit NULL
GO

UPDATE Producto
SET EsPromocion = 0
GO

ALTER TABLE Producto
ALTER COLUMN EsPromocion bit NOT NULL
GO
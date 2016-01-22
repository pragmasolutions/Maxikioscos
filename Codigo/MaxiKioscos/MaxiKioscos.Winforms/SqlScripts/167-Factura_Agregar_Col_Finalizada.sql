ALTER TABLE Factura
ADD Finalizada bit NULL

UPDATE Factura
SET Finalizada = 0

ALTER TABLE Factura
ALTER COLUMN Finalizada bit NOT NULL



ALTER TABLE dbo.Proveedor
ADD PercepcionDGR DECIMAL(5,2) NULL
GO

UPDATE dbo.Proveedor
SET PercepcionDGR = 1.5
GO

ALTER TABLE Proveedor
ADD AplicaPercepcionIVA BIT NULL
GO

UPDATE Proveedor
SET AplicaPercepcionIVA = 0
GO

ALTER TABLE Proveedor
ALTER COLUMN AplicaPercepcionIVA BIT NOT NULL
GO


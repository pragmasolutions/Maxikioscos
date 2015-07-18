ALTER TABLE dbo.Compra
ADD PercepcionIVA money NULL
GO

UPDATE dbo.Compra
SET PercepcionIVA = 0
GO

ALTER TABLE dbo.Compra
ALTER COLUMN PercepcionIVA money NOT NULL
GO

ALTER TABLE dbo.Compra
ADD PercepcionDGR money NULL
GO

UPDATE dbo.Compra
SET PercepcionDGR = 0
GO

ALTER TABLE dbo.Compra
ALTER COLUMN PercepcionDGR money NOT NULL
GO
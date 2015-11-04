ALTER TABLE ControlStock
ADD ConStockCero BIT NULL
GO

UPDATE ControlStock
SET ConStockCero = 0
GO

ALTER TABLE ControlStock
ALTER COLUMN ConStockCero BIT NOT NULL
GO
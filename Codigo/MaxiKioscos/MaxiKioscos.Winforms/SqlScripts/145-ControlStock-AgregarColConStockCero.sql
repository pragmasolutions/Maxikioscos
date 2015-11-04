ALTER TABLE ControlStock
ADD ConStockCero BIT NULL

UPDATE ControlStock
SET ConStockCero = 0

ALTER TABLE ControlStock
ALTER COLUMN ConStockCero BIT NOT NULL
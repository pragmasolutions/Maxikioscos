ALTER TABLE ControlStockDetalle
ADD HabilitadoParaCorregir bit NULL 
GO

UPDATE ControlStockDetalle
SET HabilitadoParaCorregir = 1
GO


ALTER TABLE ControlStockDetalle
ALTER COLUMN HabilitadoParaCorregir bit NOT NULL 
GO


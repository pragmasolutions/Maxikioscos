ALTER TABLE ControlStock
ADD Cerrado bit NULL
GO

UPDATE ControlStock
SET Cerrado = 0
GO

ALTER TABLE ControlStock
ALTER COLUMN Cerrado bit NOT NULL
GO
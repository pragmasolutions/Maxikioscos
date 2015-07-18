ALTER TABLE MaxiKiosco
ADD Abreviacion varchar(4) NULL
GO

UPDATE MaxiKiosco
SET Abreviacion = UPPER(LEFT(Nombre, 4))
GO

ALTER TABLE MaxiKiosco
ALTER COLUMN Abreviacion varchar(4) NOT NULL
GO
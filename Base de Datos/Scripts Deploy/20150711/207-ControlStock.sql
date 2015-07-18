ALTER TABLE ControlStock
ADD MasVendidos bit NULL

ALTER TABLE ControlStock
ADD CantidadFilas int NULL

ALTER TABLE ControlStock
ADD LimiteInferior int NULL

ALTER TABLE ControlStock
ADD LimiteSuperior int NULL

GO

UPDATE ControlStock
SET MasVendidos = 0

UPDATE ControlStock
SET CantidadFilas = 1000

UPDATE ControlStock
SET LimiteInferior = 1 

UPDATE ControlStock
SET LimiteSuperior = 1000

GO

ALTER TABLE ControlStock
ALTER COLUMN MasVendidos BIT NOT NULL


ALTER TABLE ControlStock
ALTER COLUMN LimiteInferior INT NOT NULL


ALTER TABLE ControlStock
ALTER COLUMN LimiteSuperior INT NOT NULL
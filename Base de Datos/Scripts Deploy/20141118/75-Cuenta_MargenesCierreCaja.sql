ALTER TABLE Cuenta
ADD MargenInferiorCierreCajaAceptable money NULL
GO

UPDATE Cuenta
SET MargenInferiorCierreCajaAceptable = 50
GO

ALTER TABLE Cuenta
ALTER COLUMN MargenInferiorCierreCajaAceptable money NOT NULL
GO


ALTER TABLE Cuenta
ADD MargenSuperiorCierreCajaAceptable money NULL
GO

UPDATE Cuenta
SET MargenSuperiorCierreCajaAceptable = 50
GO

ALTER TABLE Cuenta
ALTER COLUMN MargenSuperiorCierreCajaAceptable money NOT NULL
GO
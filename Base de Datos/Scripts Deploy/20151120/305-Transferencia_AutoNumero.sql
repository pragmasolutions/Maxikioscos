ALTER TABLE Transferencia
ADD AutoNumero varchar(20) NULL
GO

UPDATE Transferencia
SET AutoNumero = 'WEB_' + CAST(TransferenciaId as varchar(10))
GO

ALTER TABLE Transferencia
ALTER COLUMN AutoNumero varchar(20) NOT NULL
GO
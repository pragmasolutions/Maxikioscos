UPDATE Factura
SET Desincronizado = 1
WHERE FechaCreacion > DATEADD(MONTH, -2, GETDATE())
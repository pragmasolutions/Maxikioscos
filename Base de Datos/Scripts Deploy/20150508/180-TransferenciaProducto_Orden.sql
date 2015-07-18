ALTER TABLE TransferenciaProducto
ADD Orden int NOT NULL DEFAULT(1)
GO

ALTER TABLE TransferenciaProducto
ADD Costo money NOT NULL DEFAULT(0)
GO

UPDATE TP
SET Costo = UC.CostoConIVA
FROM TransferenciaProducto TP
	INNER JOIN (select *  from dbo.UltimosCostos()) UC
		ON TP.ProductoId = UC.ProductoId
WHERE UC.CostoConIVA IS NOT NULL

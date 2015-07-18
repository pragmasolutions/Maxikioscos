UPDATE TP
SET Costo = UC.CostoConIVA
FROM TransferenciaProducto TP
	INNER JOIN (select *  from dbo.UltimosCostos()) UC
		ON TP.ProductoId = UC.ProductoId
WHERE UC.CostoConIVA IS NOT NULL

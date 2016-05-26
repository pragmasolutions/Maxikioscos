UPDATE F  
SET F.Finalizada = 1,
	F.Desincronizado = 1 
FROM Factura F
WHERE (YEAR(F.FechaCreacion) <  2016 OR (YEAR(F.FechaCreacion) = 2016 AND MONTH(F.FechaCreacion) < 5))
	OR EXISTS(SELECT 1 FROM Compra C WHERE C.FacturaId = F.FacturaId)
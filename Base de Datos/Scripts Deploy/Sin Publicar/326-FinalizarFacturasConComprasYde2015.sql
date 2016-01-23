UPDATE F  SET F.Finalizada = 1,F.Desincronizado = 1 
FROM Factura F
WHERE YEAR(F.FechaCreacion) = 2015 OR EXISTS(SELECT 1 FROM Compra C WHERE C.FacturaId = F.FacturaId)
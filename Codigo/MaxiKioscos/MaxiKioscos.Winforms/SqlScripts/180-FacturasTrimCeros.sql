UPDATE Factura
SET FacturaNro = SUBSTRING(FacturaNro, PATINDEX('%[^0]%', FacturaNro+'.'), LEN(FacturaNro))
WHERE FacturaNro LIKE '0%'
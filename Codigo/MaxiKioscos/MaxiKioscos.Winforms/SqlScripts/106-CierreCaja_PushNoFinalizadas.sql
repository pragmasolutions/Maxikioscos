DECLARE @PrimerFecha datetime
SET @PrimerFecha = (SELECT CONVERT('2015-04-15' as datetime))


UPDATE CierreCaja
SET Desincronizado = 1
WHERE FechaInicio > @PrimerFecha

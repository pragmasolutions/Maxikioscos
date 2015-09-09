DECLARE @PrimerFecha datetime
SET @PrimerFecha = (SELECT CAST('2015-04-14' as datetime))


UPDATE CierreCaja
SET Desincronizado = 1
WHERE FechaInicio > @PrimerFecha

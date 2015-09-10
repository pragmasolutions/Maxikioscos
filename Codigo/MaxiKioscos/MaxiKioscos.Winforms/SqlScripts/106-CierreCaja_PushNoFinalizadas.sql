DECLARE @PrimerFecha datetime
SET @PrimerFecha = (SELECT CAST('14/04/2015' as datetime))


UPDATE CierreCaja
SET Desincronizado = 1
WHERE FechaInicio > @PrimerFecha

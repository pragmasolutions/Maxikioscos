
CREATE FUNCTION [dbo].[MaxikioscoUltimoCierreCaja](
	@MaxikioscoId int)
RETURNS TABLE
AS
RETURN
(
	SELECT TOP 1 CierreCajaId = CC.CierreCajaId, FechaFin = CC.FechaFin, CajaFinal = CC.CajaFinal
	FROM dbo.CierreCaja CC
	WHERE CC.MaxiKioskoId = @MaxikioscoId
	ORDER BY CC.FechaInicio DESC
)

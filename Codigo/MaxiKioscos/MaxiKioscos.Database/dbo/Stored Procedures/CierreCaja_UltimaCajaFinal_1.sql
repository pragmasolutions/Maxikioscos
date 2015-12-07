
CREATE PROCEDURE [dbo].[CierreCaja_UltimaCajaFinal]
	@MaxikioscoId int
AS
	SELECT TOP 1 CajaFinal
	FROM CierreCaja
	WHERE MaxiKioskoId = @MaxikioscoId
	ORDER BY FechaFin DESC




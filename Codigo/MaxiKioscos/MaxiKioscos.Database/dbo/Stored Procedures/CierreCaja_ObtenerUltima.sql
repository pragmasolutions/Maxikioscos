

CREATE PROCEDURE [dbo].[CierreCaja_ObtenerUltima]
	@MaxikioscoId int
AS
	SELECT TOP 1 *
	FROM CierreCaja
	WHERE MaxiKioskoId = @MaxikioscoId
	ORDER BY CierreCajaId DESC

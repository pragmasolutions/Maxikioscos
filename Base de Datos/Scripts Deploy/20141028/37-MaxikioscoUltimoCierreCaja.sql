IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[MaxikioscoUltimoCierreCaja]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[MaxikioscoUltimoCierreCaja]
GO

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
GO

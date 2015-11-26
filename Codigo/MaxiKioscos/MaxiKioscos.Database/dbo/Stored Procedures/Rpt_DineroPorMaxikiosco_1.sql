

CREATE PROCEDURE [dbo].[Rpt_DineroPorMaxikiosco]
AS
BEGIN
	SELECT
	   M.Nombre
	  ,M.Direccion
	  ,DineroActualEnCaja = (CASE
		WHEN  MUC.FechaFin IS NULL THEN DA.DineroActualEnCaja
		ELSE  MUC.CajaFinal
		END)
	FROM
	  MaxiKiosco M
	  OUTER APPLY dbo.MaxikioscoUltimoCierreCaja(M.MaxiKioscoId) MUC
	  OUTER APPLY dbo.CierreCajaCantidadDineroActual(MUC.CierreCajaId)DA
	WHERE M.Eliminado = 0
	 ORDER BY M.Nombre,M.Direccion
END


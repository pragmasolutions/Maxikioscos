DROP PROCEDURE [dbo].[Rpt_VentasPorMaxikiosco]
GO

CREATE PROCEDURE [dbo].[Rpt_VentasPorMaxikiosco]
	@Desde datetime2(7),
	@Hasta datetime2(7),
	@CuentaId int
AS
BEGIN
	DECLARE @LocDesde datetime2(7) = @Desde,
			@LocHasta datetime2(7) = @Hasta,
			@LocCuentaId int = @CuentaId

	SELECT
	   M.Nombre
	  ,M.Direccion
	  ,SUM(V.CostoTotal) AS CostoTotal
	  ,SUM(CASE WHEN V.Facturada = 1 THEN V.ImporteTotal ELSE 0 END) AS ImporteTotalA
	  ,SUM(CASE WHEN V.Facturada = 0 THEN V.ImporteTotal ELSE 0 END) AS ImporteTotalB
	  ,SUM(V.ImporteTotal) - SUM(V.CostoTotal) AS GananciaNeta
	FROM
	  CierreCaja CC
	  INNER JOIN MaxiKiosco M
		ON CC.MaxiKioskoId = M.MaxiKioscoId
	  INNER JOIN Venta V
		ON CC.CierreCajaId = V.CierreCajaId
	 WHERE 
	        (@LocDesde IS NULL OR V.FechaVenta >= @LocDesde)
		AND (@LocHasta IS NULL OR V.FechaVenta <= @LocHasta)
		AND (@LocCuentaId IS NULL OR M.CuentaId = @LocCuentaId)
		
	 GROUP BY M.Nombre,M.Direccion
END


GO



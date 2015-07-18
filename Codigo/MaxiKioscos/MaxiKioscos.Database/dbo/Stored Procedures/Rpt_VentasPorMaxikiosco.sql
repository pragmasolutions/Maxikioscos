
CREATE PROCEDURE [dbo].[Rpt_VentasPorMaxikiosco]
	@Desde datetime2(7),
	@Hasta datetime2(7),
	@CuentaId int
AS
BEGIN
	SELECT
	   M.Nombre
	  ,M.Direccion
	  ,SUM(V.CostoTotal) AS CostoTotal
	  ,SUM(V.ImporteTotal) AS ImporteTotal
	  ,SUM(V.ImporteTotal) - SUM(V.CostoTotal) AS GananciaNeta
	FROM
	  CierreCaja CC
	  INNER JOIN MaxiKiosco M
		ON CC.MaxiKioskoId = M.MaxiKioscoId
	  INNER JOIN Venta V
		ON CC.CierreCajaId = V.CierreCajaId
	 WHERE 
	        (@Desde IS NULL OR V.FechaVenta >= @Desde)
		AND (@Hasta IS NULL OR V.FechaVenta <= @Hasta)
		AND (@CuentaId IS NULL OR M.CuentaId = @CuentaId)
		
	 GROUP BY M.Nombre,M.Direccion
END

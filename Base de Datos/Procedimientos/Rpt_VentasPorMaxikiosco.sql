
/****** Object:  StoredProcedure [dbo].[Rpt_VentasPorMaxikiosco]    Script Date: 08/09/2014 15:48:48 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Rpt_VentasPorMaxikiosco]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Rpt_VentasPorMaxikiosco]
GO


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

GO



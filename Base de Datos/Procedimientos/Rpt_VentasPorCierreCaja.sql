/****** Object:  StoredProcedure [dbo].[Rpt_VentasPorCierreCaja]    Script Date: 01/31/2015 10:38:06 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Rpt_VentasPorCierreCaja]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Rpt_VentasPorCierreCaja]
GO


CREATE PROCEDURE [dbo].[Rpt_VentasPorCierreCaja]
	@CierreCajaId int
AS
BEGIN
	SELECT
	   Rubro = R.Descripcion
	  ,Producto = P.Descripcion 
	  ,PrecioPromedio = AVG(VP.Precio)
	  ,CantidadTotal = SUM(VP.Cantidad) 
	  ,VentaTotal = SUM(VP.Precio * VP.Cantidad) 
	  ,CostoTotal = SUM(VP.Costo * VP.Cantidad) 
	  ,GananciaNeta = SUM(VP.Precio * VP.Cantidad) - SUM(VP.Costo * VP.Cantidad) 
	FROM VentaProducto VP
	  INNER JOIN Producto P
		ON VP.ProductoId = P.ProductoId
	  INNER JOIN Rubro R
		ON P.RubroId = R.RubroId
	  INNER JOIN Venta V
		ON VP.VentaId = V.VentaId
	  INNER JOIN CierreCaja CC
		ON V.CierreCajaId = CC.CierreCajaId
	  INNER JOIN MaxiKiosco M
		ON CC.MaxiKioskoId = M.MaxiKioscoId
	 WHERE 
		V.CierreCajaId = @CierreCajaId
	 GROUP BY M.Nombre,R.Descripcion,P.Descripcion
	 ORDER BY VentaTotal DESC
END



GO



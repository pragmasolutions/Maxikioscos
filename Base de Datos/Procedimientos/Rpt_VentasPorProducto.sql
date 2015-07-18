
/****** Object:  StoredProcedure [dbo].[Rpt_VentasPorProducto]    Script Date: 08/09/2014 15:48:51 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Rpt_VentasPorProducto]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Rpt_VentasPorProducto]
GO


CREATE PROCEDURE [dbo].[Rpt_VentasPorProducto]
	@Desde datetime2(7),
	@Hasta datetime2(7),
	@RubroId int,
	@MaxikioscoId int,
	@CuentaId int
AS
BEGIN
	SELECT
	   MaxiKiosco = M.Nombre
	  ,Rubro = R.Descripcion
	  ,Producto = P.Descripcion 
	  ,PrecioPromedio = AVG(VP.Precio)
	  ,CantidadTotal = SUM(VP.Cantidad) 
	  ,VentaTotal = SUM(VP.Precio * VP.Cantidad) 
	  ,CostoTotal = SUM(VP.Costo * VP.Cantidad) 
	  ,GananciaNeta = SUM(VP.Precio * VP.Cantidad) - SUM(VP.Costo * VP.Cantidad) 
	FROM
	  VentaProducto VP
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
	        (@Desde IS NULL OR V.FechaVenta >= @Desde)
		AND (@Hasta IS NULL OR V.FechaVenta <= @Hasta)
		AND (@RubroId IS NULL OR R.RubroId = @RubroId)
		AND (@MaxikioscoId IS NULL OR M.MaxikioscoId = @MaxikioscoId)
		AND (@CuentaId IS NULL OR P.CuentaId = @CuentaId)
	GROUP BY M.Nombre,R.Descripcion,P.Descripcion
	ORDER BY VentaTotal DESC
END


GO



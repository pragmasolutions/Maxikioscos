
CREATE PROCEDURE [dbo].[Rpt_VentasPorProductoRanking]
	@Desde datetime2(7),
	@Hasta datetime2(7),
	@RubroId int,
	@MaxikioscoId int,
	@CuentaId int
AS
BEGIN
	SELECT TOP 10
	   Producto = P.Descripcion 
	  ,PrecioPromedio = AVG(VP.Precio)
	  ,CantidadTotal = SUM(VP.Cantidad) 
	  ,VentaTotal = SUM(VP.Precio * VP.Cantidad) 
	  ,CostoTotal = SUM(VP.Costo * VP.Cantidad) 
	  ,GananciaNeta = SUM(VP.Precio * VP.Cantidad) - SUM(VP.Costo * VP.Cantidad) 
	FROM
	  VentaProducto VP
	  INNER JOIN Producto P
		ON VP.ProductoId = P.ProductoId
	  INNER JOIN Venta V
		ON VP.VentaId = V.VentaId
	  INNER JOIN CierreCaja CC
		ON V.CierreCajaId = CC.CierreCajaId
	  INNER JOIN MaxiKiosco M
		ON CC.MaxiKioskoId = M.MaxiKioscoId
	WHERE 
	        (@Desde IS NULL OR V.FechaVenta >= @Desde)
		AND (@Hasta IS NULL OR V.FechaVenta <= @Hasta)
		AND (@RubroId IS NULL OR P.RubroId = @RubroId)
		AND (@MaxikioscoId IS NULL OR M.MaxikioscoId = @MaxikioscoId)
		AND (@CuentaId IS NULL OR P.CuentaId = @CuentaId)
	GROUP BY P.Descripcion
	ORDER BY VentaTotal DESC
END

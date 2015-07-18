CREATE PROCEDURE [dbo].[Rpt_VentasPorProducto_TotalGeneral]
	@Desde datetime2(7),
	@Hasta datetime2(7),
	@RubroId int,
	@CuentaId int
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
	WHERE 
	        (@Desde IS NULL OR V.FechaVenta >= @Desde)
		AND (@Hasta IS NULL OR V.FechaVenta <= @Hasta)
		AND (@RubroId IS NULL OR R.RubroId = @RubroId)
		AND (@CuentaId IS NULL OR P.CuentaId = @CuentaId)
	GROUP BY R.Descripcion,P.Descripcion
	ORDER BY VentaTotal DESC
END



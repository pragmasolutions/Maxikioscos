

CREATE PROCEDURE [dbo].[Rpt_VentasPorProductoRanking]
	@Desde datetime2(7) = NULL,
	@Hasta datetime2(7) = NULL,
	@RubroId int = NULL,
	@MaxikioscoId int = NULL,
	@CuentaId int = NULL,
	@CierreCajaId int = NULL
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
	WHERE (@CierreCajaId IS NOT NULL AND V.CierreCajaId = @CierreCajaId)
	    OR (@CierreCajaId IS NULL AND (
			(@Desde IS NULL OR V.FechaVenta >= @Desde)
			AND (@Hasta IS NULL OR V.FechaVenta <= @Hasta)
			AND (@RubroId IS NULL OR P.RubroId = @RubroId)
			AND (@MaxikioscoId IS NULL OR M.MaxikioscoId = @MaxikioscoId)
			AND (@CuentaId IS NULL OR P.CuentaId = @CuentaId)
	    ))
	        
	GROUP BY P.Descripcion
	ORDER BY VentaTotal DESC
END



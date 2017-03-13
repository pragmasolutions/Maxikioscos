DROP PROCEDURE [dbo].[Rpt_VentasPorProductoCompleto]
GO


CREATE PROCEDURE [dbo].[Rpt_VentasPorProductoCompleto]
	@Desde datetime2(7),
	@Hasta datetime2(7),
	@RubroId int,
	@MaxikioscoId int,
	@CuentaId int
AS
BEGIN
	DECLARE @LocDesde datetime2(7) = @Desde,
			@LocHasta datetime2(7) = @Hasta,
			@LocRubroId int = @RubroId,
			@LocMaxikioscoId int = @MaxikioscoId,
			@LocCuentaId int = @CuentaId

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
	        (@LocDesde IS NULL OR V.FechaVenta >= @LocDesde)
		AND (@LocHasta IS NULL OR V.FechaVenta <= @LocHasta)
		AND (@LocRubroId IS NULL OR R.RubroId = @LocRubroId)
		AND (@LocMaxikioscoId IS NULL OR M.MaxikioscoId = @LocMaxikioscoId)
		AND (@LocCuentaId IS NULL OR P.CuentaId = @LocCuentaId)
	GROUP BY M.Nombre,R.Descripcion,P.Descripcion
	ORDER BY M.Nombre,R.Descripcion, VentaTotal DESC
END


GO



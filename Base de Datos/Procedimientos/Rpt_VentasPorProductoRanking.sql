DROP PROCEDURE [dbo].[Rpt_VentasPorProductoRanking]
GO

CREATE PROCEDURE [dbo].[Rpt_VentasPorProductoRanking]
	@Desde datetime2(7) = NULL,
	@Hasta datetime2(7) = NULL,
	@RubroId int = NULL,
	@MaxikioscoId int = NULL,
	@CuentaId int = NULL,
	@CierreCajaId int = NULL
	WITH RECOMPILE
AS
BEGIN
	DECLARE @LocDesde datetime2(7) = @Desde,
			@LocHasta datetime2(7) = @Hasta,
			@LocRubroId int = @RubroId,
			@LocMaxikioscoId int = @MaxikioscoId,
			@LocCuentaId int = @CuentaId,
			@LocCierreCajaId int = @CierreCajaId

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
	WHERE (@LocCierreCajaId IS NOT NULL AND V.CierreCajaId = @LocCierreCajaId)
	    OR (@LocCierreCajaId IS NULL AND (
			(@LocDesde IS NULL OR V.FechaVenta >= @LocDesde)
			AND (@LocHasta IS NULL OR V.FechaVenta <= @LocHasta)
			AND (@LocRubroId IS NULL OR P.RubroId = @LocRubroId)
			AND (@LocMaxikioscoId IS NULL OR M.MaxikioscoId = @LocMaxikioscoId)
			AND (@LocCuentaId IS NULL OR P.CuentaId = @LocCuentaId)
	    ))
	        
	GROUP BY P.Descripcion
	ORDER BY VentaTotal DESC
END


GO



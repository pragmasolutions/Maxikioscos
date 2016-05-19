IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Rpt_VentasPorProveedor_TotalGeneral]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Rpt_VentasPorProveedor_TotalGeneral]
GO

CREATE PROCEDURE [dbo].[Rpt_VentasPorProveedor_TotalGeneral]
	@Desde datetime2(7),
	@Hasta datetime2(7),
	@RubroId int,
	@ProveedorId int,
	@CuentaId int
AS
BEGIN
	SELECT Proveedor = PR.Nombre
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
	  LEFT JOIN (SELECT * FROM dbo.UltimosCostos()) UC
		ON VP.ProductoId = UC.ProductoId
	  LEFT JOIN Proveedor PR
		ON UC.ProveedorId = PR.ProveedorId
	WHERE (@Desde IS NULL OR V.FechaVenta >= @Desde)
		AND (@Hasta IS NULL OR V.FechaVenta <= @Hasta)
		AND (@RubroId IS NULL OR R.RubroId = @RubroId)
		AND (@ProveedorId IS NULL OR PR.ProveedorId = @ProveedorId)
		AND (@CuentaId IS NULL OR P.CuentaId = @CuentaId)
	GROUP BY PR.Nombre, R.Descripcion,P.Descripcion
	ORDER BY VentaTotal DESC
END



DROP PROCEDURE [dbo].[Rpt_VentasPorProveedor]
GO

CREATE PROCEDURE [dbo].[Rpt_VentasPorProveedor]
	@Desde datetime2(7),
	@Hasta datetime2(7),
	@RubroId int,
	@MaxikioscoId int,
	@ProveedorId int,
	@CuentaId int
AS
BEGIN

	DECLARE 
	@LocDesde datetime2(7) = @Desde,
	@LocHasta datetime2(7) = @Hasta,
	@LocRubroId int = @RubroId,
	@LocMaxikioscoId int = @MaxikioscoId,
	@LocProveedorId int = @ProveedorId,
	@LocCuentaId int = @CuentaId

	;WITH CTE (ProductoId, ProveedorId)
	AS
	(
		SELECT ProductoId, ProveedorId
		FROM dbo.UltimosCostos()
	)

	SELECT
	   MaxiKiosco = M.Nombre
	  ,Rubro = R.Descripcion
	  ,Producto = P.Descripcion 
	  ,Proveedor = ISNULL(PR.Nombre, 'DESCONOCIDO')
	  ,PrecioPromedio = AVG(VP.Precio)
	  ,CantidadTotal = SUM(VP.Cantidad) 
	  ,VentaTotal = SUM(VP.Precio * VP.Cantidad) 
	  ,CostoTotal = SUM(VP.Costo * VP.Cantidad) 
	  ,GananciaNeta = SUM((VP.Precio  - VP.Costo) * VP.Cantidad) 
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
	  LEFT JOIN CTE UC
		ON VP.ProductoId = UC.ProductoId
	  LEFT JOIN Proveedor PR
		ON UC.ProveedorId = PR.ProveedorId
	WHERE 
	        (@LocDesde IS NULL OR V.FechaVenta >= @LocDesde)
		AND (@LocHasta IS NULL OR V.FechaVenta <= @LocHasta)
		AND (@LocRubroId IS NULL OR R.RubroId = @LocRubroId)
		AND (@LocMaxikioscoId IS NULL OR M.MaxikioscoId = @LocMaxikioscoId)
		AND (@LocProveedorId IS NULL OR PR.ProveedorId = @LocProveedorId)
		AND (@LocCuentaId IS NULL OR P.CuentaId = @LocCuentaId)
	GROUP BY M.Nombre,PR.Nombre, R.Descripcion,P.Descripcion
	ORDER BY VentaTotal DESC
END



GO



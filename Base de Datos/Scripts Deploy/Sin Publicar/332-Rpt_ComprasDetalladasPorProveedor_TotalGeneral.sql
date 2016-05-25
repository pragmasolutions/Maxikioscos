
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Rpt_ComprasDetalladasPorProveedor_TotalGeneral]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Rpt_ComprasDetalladasPorProveedor_TotalGeneral]
GO



CREATE PROCEDURE [dbo].[Rpt_ComprasDetalladasPorProveedor_TotalGeneral]
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
	  ,PrecioPromedio = AVG(CP.PrecioActualizado)
	  ,CantidadTotal = SUM(CP.Cantidad) 
	  ,CompraTotal = SUM(CP.PrecioActualizado * CP.Cantidad) 
	  ,CostoTotal = SUM(CP.CostoActualizado * CP.Cantidad) 
	  ,GananciaNeta = SUM(CP.PrecioActualizado * CP.Cantidad) - SUM(CP.CostoActualizado * CP.Cantidad) 
	FROM
	  CompraProducto CP
	  INNER JOIN Producto P
		ON CP.ProductoId = P.ProductoId
	  INNER JOIN Rubro R
		ON P.RubroId = R.RubroId
	  INNER JOIN Compra C
		ON CP.CompraId = C.CompraId
	  INNER JOIN MaxiKiosco M
		ON C.MaxiKioscoId = M.MaxiKioscoId
	  LEFT JOIN (SELECT * FROM dbo.UltimosCostos()) UC
		ON CP.ProductoId = UC.ProductoId
	  LEFT JOIN Proveedor PR
		ON UC.ProveedorId = PR.ProveedorId
	WHERE (@Desde IS NULL OR C.Fecha >= @Desde)
		AND (@Hasta IS NULL OR C.Fecha <= @Hasta)
		AND (@RubroId IS NULL OR R.RubroId = @RubroId)
		AND (@ProveedorId IS NULL OR PR.ProveedorId = @ProveedorId)
		AND (@CuentaId IS NULL OR P.CuentaId = @CuentaId)
	GROUP BY PR.Nombre, R.Descripcion,P.Descripcion
	ORDER BY CompraTotal DESC
END



GO



DROP PROCEDURE [dbo].[Rpt_VentasNegativasPorTicket]
GO


CREATE PROCEDURE [dbo].[Rpt_VentasNegativasPorTicket] 
	@UsuarioId int,
	@Desde datetime = null,
	@Hasta datetime = null
AS
BEGIN
	DECLARE @LocUsuarioId int= @UsuarioId,
			@LocDesde datetime = @Desde,
			@LocHasta datetime = @Hasta

	DECLARE @Temp TABLE
	(
		UsuarioId int,
		CostoTotal money,
		Orden int
	);
	
	
	WITH CTE (UsuarioId, CostoTotal)
	AS
	(
		SELECT U.UsuarioId,
			SUM(VP.Costo * VP.Cantidad)
		FROM VentaProducto VP
			INNER JOIN  Venta V
				ON VP.VentaId = V.VentaId
			INNER JOIN Producto P
				ON VP.ProductoId = P.ProductoId
			INNER JOIN CierreCaja CC
				ON V.CierreCajaId = CC.CierreCajaId
			INNER JOIN Usuario U
				ON CC.UsuarioId = U.UsuarioId
		WHERE (@LocUsuarioId IS NULL OR CC.UsuarioId = @LocUsuarioId)
			AND (@LocDesde IS NULL OR @LocDesde < V.FechaVenta)
			AND (@LocHasta IS NULL OR @LocHasta > V.FechaVenta)
			AND V.Eliminado = 0
			AND VP.Cantidad < 0
		GROUP BY U.UsuarioId
	)
	
	SELECT V.VentaId Ticket,
			V.FechaVenta,
			P.Descripcion Producto,
			VP.Cantidad,
		    VP.Precio PrecioUnitario,
		    VP.Costo CostoUnitario,
		    CostoTotal = VP.Costo * VP.Cantidad,
		    Ganancia = (VP.Precio - VP.Costo) * VP.Cantidad	,
		    PrecioTotal = VP.Precio * VP.Cantidad,
		    Usuario = U.Nombre + ' ' + U.Apellido,
		    CostoPorUsuario = T.CostoTotal
	FROM VentaProducto VP
		INNER JOIN  Venta V
			ON VP.VentaId = V.VentaId
		INNER JOIN Producto P
			ON VP.ProductoId = P.ProductoId
		INNER JOIN CierreCaja CC
			ON V.CierreCajaId = CC.CierreCajaId
		INNER JOIN Usuario U
			ON CC.UsuarioId = U.UsuarioId
		INNER JOIN CTE T
			ON U.UsuarioId = T.UsuarioId
	WHERE (@LocUsuarioId IS NULL OR CC.UsuarioId = @LocUsuarioId)
		AND (@LocDesde IS NULL OR @LocDesde < V.FechaVenta)
		AND (@LocHasta IS NULL OR @LocHasta > V.FechaVenta)
		AND V.Eliminado = 0
		AND VP.Cantidad < 0
	ORDER BY T.CostoTotal
	
END



GO



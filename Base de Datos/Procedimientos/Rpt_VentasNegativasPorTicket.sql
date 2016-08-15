/****** Object:  StoredProcedure [dbo].[Rpt_VentasNegativasPorTicket]    Script Date: 08/15/2016 11:23:22 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Rpt_VentasNegativasPorTicket]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Rpt_VentasNegativasPorTicket]
GO


CREATE PROCEDURE [dbo].[Rpt_VentasNegativasPorTicket] 
	@UsuarioId int,
	@Desde datetime = null,
	@Hasta datetime = null
AS
BEGIN
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
		WHERE (@UsuarioId IS NULL OR CC.UsuarioId = @UsuarioId)
			AND (@Desde IS NULL OR @Desde < V.FechaVenta)
			AND (@Hasta IS NULL OR @Hasta > V.FechaVenta)
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
	WHERE (@UsuarioId IS NULL OR CC.UsuarioId = @UsuarioId)
		AND (@Desde IS NULL OR @Desde < V.FechaVenta)
		AND (@Hasta IS NULL OR @Hasta > V.FechaVenta)
		AND V.Eliminado = 0
		AND VP.Cantidad < 0
	ORDER BY T.CostoTotal
	
END



GO



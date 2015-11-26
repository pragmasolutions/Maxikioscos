
CREATE PROCEDURE [dbo].[Rpt_VentasNegativasPorTicket] 
	@UsuarioId int,
	@Desde datetime = null,
	@Hasta datetime = null
AS
BEGIN
	SELECT V.VentaId Ticket,
			V.FechaVenta,
			P.Descripcion Producto,
			VP.Cantidad,
		    VP.Precio PrecioUnitario,
		    VP.Costo CostoUnitario,
		    CostoTotal = VP.Costo * VP.Cantidad,
		    Ganancia = (VP.Precio - VP.Costo) * VP.Cantidad	,
		    PrecioTotal = VP.Precio * VP.Cantidad,
		    Usuario = U.Nombre + ' ' + U.Apellido
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
	ORDER BY U.Nombre, U.Apellido, V.VentaId
	
END


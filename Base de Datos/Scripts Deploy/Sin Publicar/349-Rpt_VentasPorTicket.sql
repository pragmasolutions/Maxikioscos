DROP PROCEDURE [dbo].[Rpt_VentasPorTicket]
GO


CREATE PROCEDURE [dbo].[Rpt_VentasPorTicket] 
	@CierreCajaId int
AS
BEGIN
	DECLARE @LocCierreCajaId int = @CierreCajaId

	SELECT ISNULL(V.VentaIdOriginal, V.VentaId) Ticket,
			V.FechaVenta,
			P.Descripcion Producto,
			VP.Cantidad,
		    VP.Precio PrecioUnitario,
		    VP.Costo CostoUnitario,
		    CostoTotal = VP.Costo * VP.Cantidad,
		    Ganancia = (VP.Precio - VP.Costo) * VP.Cantidad	,
		    PrecioTotal = VP.Precio * VP.Cantidad
	FROM VentaProducto VP
		INNER JOIN  Venta V
			ON VP.VentaId = V.VentaId
		INNER JOIN Producto P
			ON VP.ProductoId = P.ProductoId
	WHERE V.CierreCajaId = @LocCierreCajaId
		AND V.Eliminado = 0
END


GO



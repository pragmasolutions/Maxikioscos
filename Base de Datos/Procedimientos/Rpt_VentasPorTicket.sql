/****** Object:  StoredProcedure [dbo].[Rpt_VentasPorTicket]    Script Date: 09/24/2015 17:36:31 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Rpt_VentasPorTicket]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Rpt_VentasPorTicket]
GO

CREATE PROCEDURE [dbo].[Rpt_VentasPorTicket] 
	@CierreCajaId int
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
		    PrecioTotal = VP.Precio * VP.Cantidad
	FROM VentaProducto VP
		INNER JOIN  Venta V
			ON VP.VentaId = V.VentaId
		INNER JOIN Producto P
			ON VP.ProductoId = P.ProductoId
	WHERE V.CierreCajaId = @CierreCajaId
		AND V.Eliminado = 0
END

GO



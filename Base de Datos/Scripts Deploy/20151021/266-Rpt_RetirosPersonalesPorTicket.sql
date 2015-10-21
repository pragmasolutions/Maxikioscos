/****** Object:  StoredProcedure [dbo].[Rpt_RetirosPersonalesPorTicket]    Script Date: 09/24/2015 17:36:31 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Rpt_RetirosPersonalesPorTicket]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Rpt_RetirosPersonalesPorTicket]
GO

CREATE PROCEDURE [dbo].[Rpt_RetirosPersonalesPorTicket] 
	@UsuarioId int,
	@Desde datetime = null,
	@Hasta datetime = null
AS
BEGIN
	SELECT RP.RetiroPersonalId Ticket,
			RP.FechaRetiroPersonal,
			P.Descripcion Producto,
			RPP.Cantidad,
		    RPP.Precio PrecioUnitario,
		    RPP.Costo CostoUnitario,
		    CostoTotal = RPP.Costo * RPP.Cantidad,
		    Ganancia = (RPP.Precio - RPP.Costo) * RPP.Cantidad	,
		    PrecioTotal = RPP.Precio * RPP.Cantidad
	FROM RetiroPersonalProducto RPP
		INNER JOIN  RetiroPersonal RP
			ON RPP.RetiroPersonalId = RP.RetiroPersonalId
		INNER JOIN Producto P
			ON RPP.ProductoId = P.ProductoId
		INNER JOIN CierreCaja CC
			ON RP.CierreCajaId = CC.CierreCajaId
	WHERE (@UsuarioId IS NULL OR CC.UsuarioId = @UsuarioId)
		AND (@Desde IS NULL OR @Desde < RP.FechaRetiroPersonal)
		AND (@Hasta IS NULL OR @Hasta > RP.FechaRetiroPersonal)
		AND RP.Eliminado = 0
END

GO



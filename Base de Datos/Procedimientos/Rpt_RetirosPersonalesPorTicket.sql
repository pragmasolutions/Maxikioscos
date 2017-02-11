DROP PROCEDURE [dbo].[Rpt_RetirosPersonalesPorTicket]
GO


CREATE PROCEDURE [dbo].[Rpt_RetirosPersonalesPorTicket] 
	@UsuarioId int,
	@Desde datetime = null,
	@Hasta datetime = null
AS
BEGIN
	DECLARE @LocUsuarioId int = @UsuarioId,
			@LocDesde datetime = @Desde,
			@LocHasta datetime = @Hasta

	SELECT RP.RetiroPersonalId Ticket,
			RP.FechaRetiroPersonal,
			P.Descripcion Producto,
			RPP.Cantidad,
		    RPP.Precio PrecioUnitario,
		    RPP.Costo CostoUnitario,
		    CostoTotal = RPP.Costo * RPP.Cantidad,
		    Ganancia = (RPP.Precio - RPP.Costo) * RPP.Cantidad	,
		    PrecioTotal = RPP.Precio * RPP.Cantidad,
		    Usuario = U.Nombre + ' ' + U.Apellido
	FROM RetiroPersonalProducto RPP
		INNER JOIN  RetiroPersonal RP
			ON RPP.RetiroPersonalId = RP.RetiroPersonalId
		INNER JOIN Producto P
			ON RPP.ProductoId = P.ProductoId
		INNER JOIN CierreCaja CC
			ON RP.CierreCajaId = CC.CierreCajaId
		INNER JOIN Usuario U
			ON CC.UsuarioId = U.UsuarioId
	WHERE (@LocUsuarioId IS NULL OR CC.UsuarioId = @LocUsuarioId)
		AND (@LocDesde IS NULL OR @LocDesde < RP.FechaRetiroPersonal)
		AND (@LocHasta IS NULL OR @LocHasta > RP.FechaRetiroPersonal)
		AND RP.Eliminado = 0
	ORDER BY U.Nombre, U.Apellido, RP.RetiroPersonalId
	
END


GO



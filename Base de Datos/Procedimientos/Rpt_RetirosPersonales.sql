DROP PROCEDURE [dbo].[Rpt_RetirosPersonales]
GO


CREATE PROCEDURE [dbo].[Rpt_RetirosPersonales]
	@Desde datetime = null,
	@Hasta datetime = null,
	@UsuarioId int = null
AS
BEGIN
	DECLARE @LocDesde datetime = @Desde,
			@LocHasta datetime = @Hasta,
			@LocUsuarioId int = @UsuarioId

	SELECT RP.FechaRetiroPersonal Fecha,
		U.NombreUsuario,
		RP.CostoTotal,
		RP.ImporteTotal,
		Diferencia = RP.ImporteTotal - RP.CostoTotal
	FROM RetiroPersonal RP
		INNER JOIN CierreCaja CC
			ON RP.CierreCajaId = CC.CierreCajaId
		INNER JOIN Usuario U
			ON CC.UsuarioId = U.UsuarioId
	WHERE (@LocDesde IS NULL OR @LocDesde < RP.FechaRetiroPersonal)
		AND (@LocHasta IS NULL OR @LocHasta > RP.FechaRetiroPersonal)
		AND (@LocUsuarioId IS NULL OR @LocUsuarioId = CC.UsuarioId)
	ORDER BY RP.FechaRetiroPersonal
END


GO



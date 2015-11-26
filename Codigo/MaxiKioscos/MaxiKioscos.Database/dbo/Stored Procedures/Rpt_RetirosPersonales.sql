

CREATE PROCEDURE [dbo].[Rpt_RetirosPersonales]
	@Desde datetime = null,
	@Hasta datetime = null,
	@UsuarioId int = null
AS
BEGIN
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
	WHERE (@Desde IS NULL OR @Desde < RP.FechaRetiroPersonal)
		AND (@Hasta IS NULL OR @Hasta > RP.FechaRetiroPersonal)
		AND (@UsuarioId IS NULL OR @UsuarioId = CC.UsuarioId)
	ORDER BY RP.FechaRetiroPersonal
END


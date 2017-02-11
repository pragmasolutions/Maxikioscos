DROP PROCEDURE [dbo].[Rpt_Stock_DiferenciaCierres]
GO


CREATE PROCEDURE [dbo].[Rpt_Stock_DiferenciaCierres]
	@Desde datetime2(7),
	@Hasta datetime2(7),
	@MaxiKioscoId int,
	@CuentaId int
AS
BEGIN
	DECLARE @LocDesde datetime2(7) = @Desde,
			@LocHasta datetime2(7) = @Hasta,
			@LocMaxiKioscoId int = @MaxiKioscoId,
			@LocCuentaId int = @CuentaId

	SELECT Diferencia = ISNULL(SUM(CajaFinal - CajaEsperada), 0)	   
	FROM CierreCaja CC
		INNER JOIN MaxiKiosco M
			ON CC.MaxiKioskoId = M.MaxiKioscoId
	WHERE 
		(@LocDesde IS NULL OR CC.FechaInicio >= @LocDesde)
		AND (@LocHasta IS NULL OR CC.FechaInicio <= @LocHasta)
		AND (@LocMaxiKioscoId IS NULL OR CC.MaxiKioskoId = @LocMaxiKioscoId)
		AND (@LocCuentaId IS NULL OR M.CuentaId = @LocCuentaId)	
END


GO



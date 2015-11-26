
CREATE PROCEDURE [dbo].[Rpt_Stock_DiferenciaCierres]
	@Desde datetime2(7),
	@Hasta datetime2(7),
	@MaxiKioscoId int,
	@CuentaId int
AS
BEGIN
	SELECT Diferencia = ISNULL(SUM(CajaFinal - CajaEsperada), 0)
	   
	FROM CierreCaja CC
		INNER JOIN MaxiKiosco M
			ON CC.MaxiKioskoId = M.MaxiKioscoId
	WHERE 
		(@Desde IS NULL OR CC.FechaInicio >= @Desde)
		AND (@Hasta IS NULL OR CC.FechaInicio <= @Hasta)
		AND (@MaxiKioscoId IS NULL OR CC.MaxiKioskoId = @MaxiKioscoId)
		AND (@CuentaId IS NULL OR M.CuentaId = @CuentaId)	
END



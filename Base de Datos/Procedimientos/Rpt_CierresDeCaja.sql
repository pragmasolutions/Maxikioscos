DROP PROCEDURE [dbo].[Rpt_CierresDeCaja]
GO

CREATE PROCEDURE [dbo].[Rpt_CierresDeCaja]
	@Desde datetime2(7),
	@Hasta datetime2(7),
	@MaxiKioscoId int,
	@UsuarioId int,
	@CuentaId int
AS
BEGIN
	DECLARE @LocDesde datetime2(7) = @Desde,
			@LocHasta datetime2(7) = @Hasta,
			@LocMaxiKioscoId int = @MaxiKioscoId,
			@LocUsuarioId int = @UsuarioId,
			@LocCuentaId int = @CuentaId

	SELECT
	   MaxiKioscoNombre = M.Nombre
	  ,MaxiKioscoDireccion = M.Direccion
	  ,UsuarioNombre = U.Nombre 
	  ,UsuarioApellido = U.Apellido
	  ,CantPorDebajoEsperado = SUM(CASE 
						WHEN (CC.CajaFinal < CC.CajaEsperada) THEN 1
						ELSE 0
						END)
	  ,CantPorEncimaEsperado = SUM(CASE
						WHEN (CC.CajaFinal >= CC.CajaEsperada) THEN 1
						ELSE 0
						END)
	FROM
	  CierreCaja CC
	  INNER JOIN MaxiKiosco M
		ON CC.MaxiKioskoId = M.MaxiKioscoId
	  INNER JOIN Usuario U 
		ON CC.UsuarioId = U.UsuarioId
							
	 WHERE 
	        (@LocDesde IS NULL OR CC.FechaInicio >= @LocDesde)
		AND (@LocHasta IS NULL OR CC.FechaInicio <= @LocHasta)
		AND (@LocMaxiKioscoId IS NULL OR CC.MaxiKioskoId = @LocMaxiKioscoId)
		AND (@LocUsuarioId IS NULL OR CC.UsuarioId = @LocUsuarioId)
		AND (@LocCuentaId IS NULL OR M.CuentaId = @LocCuentaId)
		
	 GROUP BY  M.Nombre,M.Direccion,U.Nombre,U.Apellido
	
END



GO





CREATE PROCEDURE [dbo].[Rpt_CierresDeCaja]
	@Desde datetime2(7),
	@Hasta datetime2(7),
	@MaxiKioscoId int,
	@UsuarioId int,
	@CuentaId int
AS
BEGIN
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
	        (@Desde IS NULL OR CC.FechaInicio >= @Desde)
		AND (@Hasta IS NULL OR CC.FechaInicio <= @Hasta)
		AND (@MaxiKioscoId IS NULL OR CC.MaxiKioskoId = @MaxiKioscoId)
		AND (@UsuarioId IS NULL OR CC.UsuarioId = @UsuarioId)
		AND (@CuentaId IS NULL OR M.CuentaId = @CuentaId)
		
	 GROUP BY  M.Nombre,M.Direccion,U.Nombre,U.Apellido
	
END




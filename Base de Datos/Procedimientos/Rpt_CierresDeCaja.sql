/****** Object:  StoredProcedure [dbo].[Rpt_CierresDeCaja]    Script Date: 08/09/2014 15:48:26 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Rpt_CierresDeCaja]') AND type in (N'P', N'PC'))
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


GO



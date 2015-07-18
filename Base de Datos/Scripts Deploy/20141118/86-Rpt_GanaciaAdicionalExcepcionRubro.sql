/****** Object:  StoredProcedure [dbo].[Rpt_GanaciaAdicionalExcepcionRubro]    Script Date: 11/10/2014 23:18:20 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Rpt_GanaciaAdicionalExcepcionRubro]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Rpt_GanaciaAdicionalExcepcionRubro]
GO

CREATE PROCEDURE [dbo].[Rpt_GanaciaAdicionalExcepcionRubro]
	@Desde datetime2(7),
	@Hasta datetime2(7),
	@MaxiKioscoId int,
	@RubroId int,
	@CuentaId int
AS
BEGIN
	WITH CTE (Maxikiosco, Mes, Anio, Rubro, AdicionalPorExcepcion)
	AS (
		SELECT Maxikiosco = M.Nombre,
			   Mes = DATEPART(MONTH, V.FechaVenta),
			   Anio = DATEPART(YEAR, V.FechaVenta),
			   Rubro = R.Descripcion,
			   AdicionalPorExcepcion = ISNULL(SUM(VP.AdicionalPorExcepcion),0)		   
		FROM Venta V
			 INNER JOIN VentaProducto VP
				ON V.VentaId = VP.VentaId
			 INNER JOIN CierreCaja CC
				ON V.CierreCajaId = V.CierreCajaId
			 INNER JOIN MaxiKiosco M 
				ON CC.MaxiKioskoId = M.MaxiKioscoId
			 INNER JOIN Producto P
				ON VP.ProductoId = P.ProductoId
			 INNER JOIN Rubro R
				ON P.RubroId = R.RubroId
		WHERE 
			(@Desde IS NULL OR V.FechaVenta >= @Desde)
			AND (@Hasta IS NULL OR V.FechaVenta <= @Hasta)
			AND (@MaxiKioscoId IS NULL OR CC.MaxiKioskoId = @MaxiKioscoId)
			AND (@RubroId IS NULL OR R.RubroId = @RubroId)
			AND (@CuentaId IS NULL OR M.CuentaId = @CuentaId)	

		GROUP BY M.Nombre, DATEPART(YEAR, V.FechaVenta), DATEPART(MONTH, V.FechaVenta),R.Descripcion
	)

	SELECT * 
	FROM CTE
	WHERE AdicionalPorExcepcion > 0
	
END

GO



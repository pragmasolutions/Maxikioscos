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
	DECLARE @LocDesde datetime2(7) = @Desde,
			@LocHasta datetime2(7) = @Hasta,
			@LocMaxiKioscoId int = @MaxiKioscoId,
			@LocRubroId int = @RubroId,
			@LocCuentaId int = @CuentaId;

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
				ON V.CierreCajaId = CC.CierreCajaId
			 INNER JOIN MaxiKiosco M 
				ON CC.MaxiKioskoId = M.MaxiKioscoId
			 INNER JOIN Producto P
				ON VP.ProductoId = P.ProductoId
			 INNER JOIN Rubro R
				ON P.RubroId = R.RubroId
		WHERE 
			(@LocDesde IS NULL OR V.FechaVenta >= @LocDesde)
			AND (@LocHasta IS NULL OR V.FechaVenta <= @LocHasta)
			AND (@LocMaxiKioscoId IS NULL OR CC.MaxiKioskoId = @LocMaxiKioscoId)
			AND (@LocRubroId IS NULL OR R.RubroId = @LocRubroId)
			AND (@LocCuentaId IS NULL OR M.CuentaId = @LocCuentaId)	

		GROUP BY M.Nombre, DATEPART(YEAR, V.FechaVenta), DATEPART(MONTH, V.FechaVenta),R.Descripcion
	)

	SELECT * 
	FROM CTE
	WHERE AdicionalPorExcepcion > 0
	
END



GO



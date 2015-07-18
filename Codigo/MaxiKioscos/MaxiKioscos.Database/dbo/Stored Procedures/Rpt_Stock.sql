

CREATE PROCEDURE [dbo].[Rpt_Stock]
	@Desde datetime2(7),
	@Hasta datetime2(7),
	@MaxiKioscoId int,
	@CuentaId int
AS
BEGIN
	WITH CTE(MaxiKiosco, Producto, Cantidad, Monto)
	AS
	(
		SELECT
		   MaxiKiosco = M.Nombre,
		   Producto = P.Descripcion,
		   Cantidad = CS.Cantidad,
		   Monto = CS.Precio
		   
		FROM CorreccionStock CS
			INNER JOIN Producto P	
				ON CS.ProductoId = P.ProductoId
			--INNER JOIN CierreCaja CC
			--	ON CS.CierreCajaId = CC.CierreCajaId
			INNER JOIN MaxiKiosco M
				ON CS.MaxiKioscoId = M.MaxiKioscoId
		WHERE 
			--(@Desde IS NULL OR CC.FechaInicio >= @Desde)
			--AND (@Hasta IS NULL OR CC.FechaInicio <= @Hasta)
			--AND (@MaxiKioscoId IS NULL OR CC.MaxiKioskoId = @MaxiKioscoId)
			--AND (@CuentaId IS NULL OR M.CuentaId = @CuentaId)
			(@Desde IS NULL OR CS.Fecha >= @Desde)
			AND (@Hasta IS NULL OR CS.Fecha <= @Hasta)
			AND (@MaxiKioscoId IS NULL OR CS.MaxiKioscoId = @MaxiKioscoId)
			AND (@CuentaId IS NULL OR M.CuentaId = @CuentaId)			
		
	)
	
	SELECT MaxiKiosco, 
			Producto, 			
			Cantidad = ISNULL(SUM(Cantidad), 0), 
			Monto = ISNULL(SUM(Monto), 0)
	FROM CTE
	GROUP BY MaxiKiosco, Producto
	ORDER BY MaxiKiosco, Producto
	
END



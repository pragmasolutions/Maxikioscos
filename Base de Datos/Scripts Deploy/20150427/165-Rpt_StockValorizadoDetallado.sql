/****** Object:  StoredProcedure [dbo].[Rpt_StockValorizadoDetallado]    Script Date: 04/25/2015 20:25:19 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Rpt_StockValorizadoDetallado]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Rpt_StockValorizadoDetallado]
GO

CREATE PROCEDURE [dbo].[Rpt_StockValorizadoDetallado]
	@Desde datetime2(7),
	@Hasta datetime2(7),
	@RubroId int,
	@MaxikioscoId int
AS
BEGIN
	WITH VentasCTE(MaxiKioscoId, RubroId, ProductoId, VentaTotal)
	AS
	(
		SELECT
		   M.MaxiKioscoId
		  ,R.RubroId
		  ,P.ProductoId 
		  ,VentaTotal = SUM(VP.Precio * VP.Cantidad) 
		FROM
		  VentaProducto VP
		  INNER JOIN Producto P
			ON VP.ProductoId = P.ProductoId
		  INNER JOIN Rubro R
			ON P.RubroId = R.RubroId
		  INNER JOIN Venta V
			ON VP.VentaId = V.VentaId
		  INNER JOIN CierreCaja CC
			ON V.CierreCajaId = CC.CierreCajaId
		  INNER JOIN MaxiKiosco M
			ON CC.MaxiKioskoId = M.MaxiKioscoId
		WHERE 
				(@Desde IS NULL OR V.FechaVenta >= @Desde)
			AND (@Hasta IS NULL OR V.FechaVenta <= @Hasta)
			AND (@RubroId IS NULL OR R.RubroId = @RubroId)
			AND (@MaxikioscoId IS NULL OR M.MaxikioscoId = @MaxikioscoId)
		GROUP BY M.MaxiKioscoId,R.RubroId,P.ProductoId
	)
	
	SELECT Maxikiosco = M.Nombre,
		Rubro = R.Descripcion,
		Producto = P.Descripcion,
		Cantidad = ISNULL(S.StockActual, 0),
		Costo = ISNULL(UC.CostoConIVA, 0),
		PrecioVenta = P.PrecioConIVA,
		TotalesCosto = ISNULL(S.StockActual, 0) * ISNULL(UC.CostoConIVA, 0),
		TotalesVenta = ISNULL(CTE.VentaTotal, 0)
	FROM Stock S
		INNER JOIN Maxikiosco M
			ON S.MaxiKioscoId = M.MaxiKioscoId
		INNER JOIN Producto P
			ON S.ProductoId = P.ProductoId
		INNER JOIN Rubro R
			ON P.RubroId = R.RubroId
		LEFT JOIN (SELECT * FROM dbo.UltimosCostos()) UC
			ON P.ProductoId = UC.ProductoId
		LEFT JOIN VentasCTE CTE
			ON S.ProductoId = CTE.ProductoId
				AND P.ProductoId = CTE.ProductoId
				AND M.MaxiKioscoId = CTE.MaxiKioscoId
	WHERE (@RubroId IS NULL OR R.RubroId = @RubroId)
			AND (@MaxikioscoId IS NULL OR M.MaxikioscoId = @MaxikioscoId)
	ORDER BY P.Descripcion
END


GO



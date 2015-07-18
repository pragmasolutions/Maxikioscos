/****** Object:  StoredProcedure [dbo].[Rpt_StockValorizado]    Script Date: 04/25/2015 20:25:19 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Rpt_StockValorizado]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Rpt_StockValorizado]
GO

CREATE PROCEDURE [dbo].[Rpt_StockValorizado]
	@RubroId int,
	@MaxikioscoId int
AS
BEGIN
	SELECT Maxikiosco = M.Nombre,
		Rubro = R.Descripcion,
		TotalesCosto = SUM(ISNULL(UC.CostoConIVA, 0) * ISNULL(S.StockActual, 0)),
		TotalesVenta = SUM(ISNULL(P.PrecioConIVA, 0) * ISNULL(S.StockActual, 0))
	FROM Stock S
		INNER JOIN Maxikiosco M
			ON S.MaxiKioscoId = M.MaxiKioscoId
		INNER JOIN Producto P
			ON S.ProductoId = P.ProductoId
		INNER JOIN Rubro R
			ON P.RubroId = R.RubroId
		LEFT JOIN (SELECT * FROM dbo.UltimosCostos()) UC
			ON P.ProductoId = UC.ProductoId		
	WHERE (@RubroId IS NULL OR R.RubroId = @RubroId)
			AND (@MaxikioscoId IS NULL OR M.MaxikioscoId = @MaxikioscoId)
	GROUP BY M.Nombre, R.Descripcion
	ORDER BY M.Nombre, R.Descripcion
END


GO



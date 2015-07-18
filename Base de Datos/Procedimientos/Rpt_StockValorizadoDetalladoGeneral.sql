/****** Object:  StoredProcedure [dbo].[Rpt_StockValorizadoDetalladoGeneral]    Script Date: 04/25/2015 20:25:19 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Rpt_StockValorizadoDetalladoGeneral]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Rpt_StockValorizadoDetalladoGeneral]
GO

CREATE PROCEDURE [dbo].[Rpt_StockValorizadoDetalladoGeneral]
	@RubroId int
AS
BEGIN
	SELECT Rubro = R.Descripcion,
		Producto = P.Descripcion,
		Cantidad = SUM(ISNULL(S.StockActual, 0)),
		Costo = ISNULL(UC.CostoConIVA, 0),
		PrecioVenta = P.PrecioConIVA,
		TotalesCosto = SUM(ISNULL(S.StockActual, 0) * ISNULL(UC.CostoConIVA, 0)),
		TotalesVenta = SUM(ISNULL(S.StockActual, 0) * ISNULL(P.PrecioConIVA, 0))
	FROM Stock S
		INNER JOIN Producto P
			ON S.ProductoId = P.ProductoId
		INNER JOIN Rubro R
			ON P.RubroId = R.RubroId
		LEFT JOIN (SELECT * FROM dbo.UltimosCostos()) UC
			ON P.ProductoId = UC.ProductoId		
	WHERE (@RubroId IS NULL OR R.RubroId = @RubroId)
	GROUP BY R.Descripcion, P.Descripcion, UC.CostoConIVA, P.PrecioConIVA
	ORDER BY P.Descripcion
END


GO



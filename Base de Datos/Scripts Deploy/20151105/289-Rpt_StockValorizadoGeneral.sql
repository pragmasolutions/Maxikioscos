/****** Object:  StoredProcedure [dbo].[Rpt_StockValorizadoGeneral]    Script Date: 04/25/2015 20:25:19 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Rpt_StockValorizadoGeneral]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Rpt_StockValorizadoGeneral]
GO

CREATE PROCEDURE [dbo].[Rpt_StockValorizadoGeneral]
	@RubroId int
AS
BEGIN
	DECLARE @Stock TABLE
	(
		StockId int, 
		ProductoId int, 
		MaxikioscoId int,  
		StockActual decimal(18, 2)
	);

	WITH CTE(StockId, ProductoId, MaxikioscoId, Fila)
	AS
	(
		SELECT S.StockId, 
				S.ProductoId, 
				S.MaxiKioscoId,
				ROW_NUMBER() OVER(PARTITION BY S.ProductoId, S.MaxikioscoId ORDER BY S.ProductoId ASC)
		FROM Stock S
			LEFT JOIN Producto P ON S.ProductoId = P.ProductoId
		WHERE P.EsPromocion = 0
	)
	INSERT INTO @Stock
	SELECT S.StockId, 
			S.ProductoId,
			S.MaxiKioscoId,			
			S.StockActual
	FROM CTE
		INNER JOIN Stock S
			ON CTE.StockId = S.StockId
		INNER JOIN Maxikiosco M
				ON S.MaxiKioscoId = M.MaxiKioscoId
			INNER JOIN Producto P
				ON S.ProductoId = P.ProductoId			
	WHERE CTE.Fila = 1 
		AND (@RubroId IS NULL OR P.RubroId = @RubroId)
		
		

	SELECT Rubro = R.Descripcion,
		TotalesCosto = SUM(ISNULL(UC.CostoConIVA, 0) * ISNULL(S.StockActual, 0)),
		TotalesVenta = SUM(ISNULL(P.PrecioConIVA, 0) * ISNULL(S.StockActual, 0))
	FROM @Stock S
		INNER JOIN Maxikiosco M
			ON S.MaxiKioscoId = M.MaxiKioscoId
		INNER JOIN Producto P
			ON S.ProductoId = P.ProductoId
		INNER JOIN Rubro R
			ON P.RubroId = R.RubroId
		LEFT JOIN (SELECT * FROM dbo.UltimosCostos()) UC
			ON P.ProductoId = UC.ProductoId		
	WHERE (@RubroId IS NULL OR R.RubroId = @RubroId)
	GROUP BY R.Descripcion
	ORDER BY R.Descripcion
END


GO



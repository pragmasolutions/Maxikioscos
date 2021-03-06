/****** Object:  StoredProcedure [dbo].[Rpt_StockValorizadoDetallado]    Script Date: 04/25/2015 20:25:19 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Rpt_StockValorizadoDetallado]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Rpt_StockValorizadoDetallado]
GO

CREATE PROCEDURE [dbo].[Rpt_StockValorizadoDetallado]
	@RubroId int,
	@MaxikioscoId int
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
		SELECT StockId, 
				ProductoId, 
				MaxiKioscoId,
				ROW_NUMBER() OVER(PARTITION BY ProductoId, MaxikioscoId ORDER BY ProductoId ASC)
		FROM Stock 
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
		AND (@MaxikioscoId IS NULL OR M.MaxikioscoId = @MaxikioscoId)


	SELECT Maxikiosco = M.Nombre,
		Rubro = R.Descripcion,
		Producto = P.Descripcion,
		Cantidad = ISNULL(S.StockActual, 0),
		Costo = ISNULL(UC.CostoConIVA, 0),
		PrecioVenta = P.PrecioConIVA,
		TotalesCosto = ISNULL(S.StockActual, 0) * ISNULL(UC.CostoConIVA, 0),
		TotalesVenta = ISNULL(S.StockActual, 0) * ISNULL(P.PrecioConIVA, 0)
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
			AND (@MaxikioscoId IS NULL OR M.MaxikioscoId = @MaxikioscoId)
	ORDER BY P.Descripcion
END


GO



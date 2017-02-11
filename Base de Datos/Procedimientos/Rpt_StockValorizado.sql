DROP PROCEDURE [dbo].[Rpt_StockValorizado]
GO


CREATE PROCEDURE [dbo].[Rpt_StockValorizado]
	@RubroId int,
	@MaxikioscoId int
AS
BEGIN
	DECLARE @LocRubroId int = @RubroId,
			@LocMaxikioscoId int = @MaxikioscoId

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
		AND (@LocRubroId IS NULL OR P.RubroId = @LocRubroId)
		AND (@LocMaxikioscoId IS NULL OR M.MaxikioscoId = @LocMaxikioscoId);

	
	WITH UltimosCostos(ProductoId, CostoConIVA)
	AS
	(
		SELECT ProductoId, CostoConIVA 
		FROM dbo.UltimosCostos()
	)
	SELECT Maxikiosco = M.Nombre,
		Rubro = R.Descripcion,
		TotalesCosto = SUM(ISNULL(UC.CostoConIVA, 0) * ISNULL(S.StockActual, 0)),
		TotalesVenta = SUM(ISNULL(P.PrecioConIVA, 0) * ISNULL(S.StockActual, 0))
	FROM @Stock S
		INNER JOIN Maxikiosco M
			ON S.MaxiKioscoId = M.MaxiKioscoId
		INNER JOIN Producto P
			ON S.ProductoId = P.ProductoId
		INNER JOIN Rubro R
			ON P.RubroId = R.RubroId
		LEFT JOIN UltimosCostos UC
			ON P.ProductoId = UC.ProductoId		
	WHERE (@LocRubroId IS NULL OR R.RubroId = @LocRubroId)
			AND (@LocMaxikioscoId IS NULL OR M.MaxikioscoId = @LocMaxikioscoId)
			AND S.StockActual != 0
	GROUP BY M.Nombre, R.Descripcion
	ORDER BY M.Nombre, R.Descripcion
END



GO



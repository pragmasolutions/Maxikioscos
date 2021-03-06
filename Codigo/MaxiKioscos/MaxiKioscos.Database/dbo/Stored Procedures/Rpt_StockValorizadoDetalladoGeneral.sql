﻿
CREATE PROCEDURE [dbo].[Rpt_StockValorizadoDetalladoGeneral]
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
		Producto = P.Descripcion,
		Cantidad = SUM(ISNULL(S.StockActual, 0)),
		Costo = ISNULL(UC.CostoConIVA, 0),
		PrecioVenta = P.PrecioConIVA,
		TotalesCosto = SUM(ISNULL(S.StockActual, 0) * ISNULL(UC.CostoConIVA, 0)),
		TotalesVenta = SUM(ISNULL(S.StockActual, 0) * ISNULL(P.PrecioConIVA, 0))
	FROM @Stock S
		INNER JOIN Producto P
			ON S.ProductoId = P.ProductoId
		INNER JOIN Rubro R
			ON P.RubroId = R.RubroId
		LEFT JOIN (SELECT * FROM dbo.UltimosCostos()) UC
			ON P.ProductoId = UC.ProductoId		
	WHERE (@RubroId IS NULL OR R.RubroId = @RubroId)
		AND S.StockActual != 0
	GROUP BY R.Descripcion, P.Descripcion, UC.CostoConIVA, P.PrecioConIVA
	ORDER BY P.Descripcion
END



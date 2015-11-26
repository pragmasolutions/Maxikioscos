

CREATE PROCEDURE [dbo].[Rpt_ReponerStock]
	@ProductoId int = NULL,
	@ProveedorId int = NULL,
	@MaxiKioscoId int = NULL
AS
BEGIN
	SELECT DISTINCT Maxikiosco = M.Nombre,
		Producto = P.Descripcion,
		Proveedor = (SELECT SUBSTRING(
						(SELECT ',' + PR2.Nombre
						FROM ProveedorProducto PP2
							LEFT JOIN Proveedor PR2
								ON PP2.ProveedorId = PR2.ProveedorId
						WHERE PP2.ProductoId = P.ProductoId
						FOR XML PATH('')),2,200000)),
		StockActual = ISNULL(S.StockActual,0),
		P.StockReposicion
	FROM Producto P
		CROSS JOIN Maxikiosco M
		LEFT JOIN Stock S
			ON P.ProductoId = S.ProductoId
				AND M.MaxikioscoId = S.MaxikioscoId
	WHERE P.StockReposicion IS NOT NULL
		AND ISNULL(S.StockActual, 0) <= P.StockReposicion
		AND (@ProductoId IS NULL OR P.ProductoId = @ProductoId)
		AND (@ProveedorId IS NULL OR @ProveedorId IN (SELECT ProveedorId
													  FROM ProveedorProducto 
													  WHERE ProductoId = P.ProductoId))
		AND (@MaxikioscoId IS NULL OR M.MaxiKioscoId = @MaxikioscoId)
	ORDER BY M.Nombre, P.Descripcion
END





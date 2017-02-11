DROP PROCEDURE [dbo].[Rpt_ReponerStock]
GO

CREATE PROCEDURE [dbo].[Rpt_ReponerStock]
	@ProductoId int = NULL,
	@ProveedorId int = NULL,
	@MaxiKioscoId int = NULL
AS
BEGIN
	DECLARE @LocProductoId int = @ProductoId,
			@LocProveedorId int = @ProveedorId,
			@LocMaxiKioscoId int = @MaxiKioscoId

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
		AND (@LocProductoId IS NULL OR P.ProductoId = @LocProductoId)
		AND (@LocProveedorId IS NULL OR @LocProveedorId IN (SELECT ProveedorId
													  FROM ProveedorProducto 
													  WHERE ProductoId = P.ProductoId))
		AND (@LocMaxikioscoId IS NULL OR M.MaxiKioscoId = @LocMaxikioscoId)
	ORDER BY M.Nombre, P.Descripcion
END





GO



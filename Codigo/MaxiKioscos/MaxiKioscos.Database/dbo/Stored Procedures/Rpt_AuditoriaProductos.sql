

CREATE PROCEDURE [dbo].[Rpt_AuditoriaProductos]
AS
BEGIN
	SELECT DISTINCT 
		P.ProductoId, 
		Codigo = (SELECT SUBSTRING(
				(SELECT ',' + Codigo
				FROM CodigoProducto CP 
				WHERE CP.ProductoId = P.ProductoId
					AND CP.Eliminado = 0
				FOR XML PATH('')),2,200000)),
		P.Descripcion,
		Marca = M.Descripcion,
		Costo = ISNULL(UC.CostoConIVA, 0),
		PrecioConIVA = P.PrecioConIVA
	FROM Producto P
		LEFT JOIN (SELECT * FROM UltimosCostos()) UC
			ON P.ProductoId = UC.ProductoId
		LEFT JOIN Marca M
			ON P.MarcaId = M.MarcaId
	WHERE (UC.CostoConIVA IS NULL OR UC.CostoConIVA <= 0)
		OR (ISNULL(UC.CostoConIVA, 0) >= P.PrecioConIVA)
		OR P.PrecioConIVA <= 0
	ORDER BY P.Descripcion
END





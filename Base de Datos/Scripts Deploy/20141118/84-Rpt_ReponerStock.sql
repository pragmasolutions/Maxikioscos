/****** Object:  StoredProcedure [dbo].[Rpt_ReponerStock]    Script Date: 11/08/2014 15:45:06 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Rpt_ReponerStock]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Rpt_ReponerStock]
GO


CREATE PROCEDURE [dbo].[Rpt_ReponerStock]
	@ProductoId int,
	@ProveedorId int,
	@MaxiKioscoId int = NULL
AS
BEGIN
	SELECT DISTINCT
		Producto = P.Descripcion,
		Proveedor = (SELECT SUBSTRING(
						(SELECT ',' + PR2.Nombre
						FROM ProveedorProducto PP2
							LEFT JOIN Proveedor PR2
								ON PP2.ProveedorId = PR2.ProveedorId
						WHERE PP2.ProductoId = P.ProductoId
						ORDER BY PR.Nombre
						FOR XML PATH('')),2,200000)),
		StockActual = ISNULL(S.StockActual,0),
		P.StockReposicion
	FROM Producto P 
	LEFT JOIN ProveedorProducto PP
		ON P.ProductoId = PP.ProductoId 
		LEFT JOIN Proveedor PR
			ON PP.ProveedorId = PR.ProveedorId 
		LEFT JOIN Stock S 
			ON P.ProductoId=S.ProductoId
	WHERE P.StockReposicion IS NOT NULL
		AND ISNULL(S.StockActual, 0) <= P.StockReposicion
		AND (@ProductoId = 0 OR P.ProductoId = @ProductoId)
		AND (@ProveedorId = 0 OR PP.ProveedorId = @ProveedorId)
		AND (S.MaxiKioscoId IS NULL OR @MaxiKioscoId = S.MaxiKioscoId)
END


GO



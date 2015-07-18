/****** Object:  StoredProcedure [dbo].[Rpt_ReponerStock]    Script Date: 10/21/2014 23:19:22 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Rpt_ReponerStock]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Rpt_ReponerStock]
GO


CREATE PROCEDURE [dbo].[Rpt_ReponerStock]
	@ProductoId int,
	@ProveedorId int,
	@MaxiKioscoId int = NULL
AS
BEGIN
	SELECT 
		Producto = P.Descripcion,
		Proveedor = PR.Nombre,
		S.StockActual,
		P.StockReposicion
	FROM Producto P INNER JOIN ProveedorProducto PP
		ON P.ProductoId = PP.ProductoId INNER JOIN Proveedor PR
		ON PP.ProveedorId = PR.ProveedorId LEFT JOIN Stock S 
		ON P.ProductoId=S.ProductoId
	WHERE S.StockActual IS NOT NULL 
		AND S.StockActual <= P.StockReposicion
		AND (@ProductoId = 0 OR P.ProductoId = @ProductoId)
		AND (@ProveedorId = 0 OR PP.ProveedorId = @ProveedorId)
		AND (@MaxiKioscoId = S.MaxiKioscoId)
END

GO




/****** Object:  StoredProcedure [dbo].[Rpt_AuditoriaProductos]    Script Date: 12/03/2014 18:54:45 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Rpt_AuditoriaProductos]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Rpt_AuditoriaProductos]
GO


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



GO



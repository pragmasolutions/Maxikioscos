IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Producto_Exportar]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Producto_Exportar]
GO


CREATE PROCEDURE [dbo].[Producto_Exportar]

AS
BEGIN
	SELECT DISTINCT
	  Codigo = (SELECT SUBSTRING(
		 (SELECT ',' + Codigo
		 FROM CodigoProducto CP 
		 WHERE CP.ProductoId = P.ProductoId
			AND CP.Eliminado = 0
		 FOR XML PATH('')),2,200000)),
	  P.Descripcion, 
	  Marca = M.Descripcion,  
	  Rubro = R.Descripcion,
	  Costo = PP.CostoConIVA,
	  P.StockReposicion,
	  P.PrecioSinIVA,
	  P.PrecioConIVA,
	  DisponibleEnDeposito = CASE WHEN P.DisponibleEnDeposito = 1 THEN 'SI' ELSE 'NO' END
	FROM Producto P 
	  LEFT JOIN Marca M 
		ON P.MarcaId = M.MarcaId 
	  LEFT JOIN Rubro R 
		ON P.RubroId = R.RubroId 
	  LEFT JOIN (SELECT * FROM dbo.UltimosCostos()) PP
		ON P.ProductoId = PP.ProductoId
	WHERE P.Eliminado = 0
		AND P.EsPromocion = 0
	ORDER BY P.Descripcion
END








GO




/****** Object:  StoredProcedure [dbo].[Rpt_VentasPorProducto]    Script Date: 08/09/2014 15:48:51 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Rpt_ProductosEnDeposito]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Rpt_ProductosEnDeposito]
GO


CREATE PROCEDURE [dbo].[Rpt_ProductosEnDeposito]
	@RubroId int
AS
BEGIN
	SELECT
	   Codigo = (SELECT SUBSTRING(
					(SELECT ',' + Codigo
					FROM CodigoProducto CP 
					WHERE CP.ProductoId = P.ProductoId
						AND CP.Eliminado = 0
					FOR XML PATH('')),2,200000)),
	   Rubro = R.Descripcion
	  ,Producto = P.Descripcion 
	  ,Marca = M.Descripcion
	FROM Producto P
	  INNER JOIN Rubro R
		ON P.RubroId = R.RubroId
	  INNER JOIN Marca M
		ON P.MarcaId = M.MarcaId
	WHERE 
		(@RubroId IS NULL OR R.RubroId = @RubroId)
		AND P.DisponibleEnDeposito = 1
		AND P.Eliminado = 0
	ORDER BY P.Descripcion DESC
END


GO



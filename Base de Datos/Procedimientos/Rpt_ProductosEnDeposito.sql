DROP PROCEDURE [dbo].[Rpt_ProductosEnDeposito]
GO


CREATE PROCEDURE [dbo].[Rpt_ProductosEnDeposito]
	@RubroId int
AS
BEGIN
	DECLARE @LocRubroId int = @RubroId

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
		(@LocRubroId IS NULL OR R.RubroId = @LocRubroId)
		AND P.Eliminado = 0
		AND P.DisponibleEnDeposito = 1
	ORDER BY P.Descripcion
END



GO



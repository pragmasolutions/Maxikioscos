

CREATE PROCEDURE [dbo].[Rpt_ControlStockPlanilla] 
	@ControlStockId int
AS
BEGIN
	SELECT Codigo = (SELECT SUBSTRING(
			 (SELECT ',' + Codigo
			 FROM CodigoProducto CP 
			 WHERE CP.ProductoId = P.ProductoId
			 FOR XML PATH('')),2,200000)),
		   P.Descripcion Producto,
		   CSD.Cantidad,
		   MC.Descripcion Motivo,
		   CSD.Correccion Diferencia
	FROM ControlStockDetalle CSD
		LEFT JOIN Stock S ON CSD.StockId = S.StockId
		LEFT JOIN Producto P ON S.ProductoId = P.ProductoId
		LEFT JOIN MotivoCorreccion MC ON CSD.MotivoCorreccionId = MC.MotivoCorreccionId
	WHERE CSD.ControlStockId = @ControlStockId
	ORDER BY P.Descripcion
END




CREATE PROCEDURE [dbo].[Transferencia_Detalle]
	@TransferenciaId INT
AS
BEGIN
	SELECT TP.Cantidad,
			Codigo = (SELECT SUBSTRING(
					(SELECT ',' + Codigo
					FROM CodigoProducto CP 
					WHERE CP.ProductoId = P.ProductoId
						AND CP.Eliminado = 0
					FOR XML PATH('')),2,200000)),
			P.Descripcion,
			TP.PrecioVenta
	FROM TransferenciaProducto TP
		INNER JOIN Producto P
			ON TP.ProductoId = P.ProductoId
	WHERE TP.TransferenciaId = @TransferenciaId
		AND TP.Eliminado = 0
	ORDER BY TP.Orden
	
END



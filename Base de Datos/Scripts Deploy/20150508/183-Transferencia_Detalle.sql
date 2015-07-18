/****** Object:  StoredProcedure [dbo].[Transferencia_Detalle]    Script Date: 04/26/2015 11:23:05 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Transferencia_Detalle]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Transferencia_Detalle]
GO


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

GO



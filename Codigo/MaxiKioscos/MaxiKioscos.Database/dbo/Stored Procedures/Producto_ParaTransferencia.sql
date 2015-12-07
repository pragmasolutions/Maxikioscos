
CREATE PROCEDURE [dbo].[Producto_ParaTransferencia]
	@OrigenId INT,
	@DestinoId INT,
	@ProductoId INT = NULL
AS
BEGIN
	
	SELECT  P.ProductoId, 
			Codigo = (SELECT SUBSTRING(
					(SELECT ',' + Codigo
					FROM CodigoProducto CP 
					WHERE CP.ProductoId = P.ProductoId
						AND CP.Eliminado = 0
					FOR XML PATH('')),2,200000)),
			P.Descripcion,
			P.AceptaCantidadesDecimales,
			Marca = M.Descripcion,
			StockOrigen = ISNULL((SELECT SUM(ST.Cantidad)
					FROM StockTransaccion ST
						LEFT JOIN Stock S ON ST.StockId = S.StockId
						WHERE S.ProductoId = P.ProductoId
							AND S.MaxiKioscoId = @OrigenId
							AND S.Eliminado = 0
							AND ST.Eliminado = 0
			), 0),
			StockDestino = ISNULL((SELECT SUM(ST.Cantidad)
					FROM StockTransaccion ST
						LEFT JOIN Stock S ON ST.StockId = S.StockId
						WHERE S.ProductoId = P.ProductoId
							AND S.MaxiKioscoId = @DestinoId
							AND S.Eliminado = 0
							AND ST.Eliminado = 0
			), 0),
			P.PrecioSinIVA,
			P.PrecioConIVA,
			CostoConIVA = ISNULL((SELECT dbo.UltimoCosto(P.ProductoId)), 0)
		FROM Producto P
			LEFT JOIN Marca M
				ON P.MarcaId = M.MarcaId
		WHERE P.Eliminado = 0			
			AND P.ProductoId = @ProductoId
		
END



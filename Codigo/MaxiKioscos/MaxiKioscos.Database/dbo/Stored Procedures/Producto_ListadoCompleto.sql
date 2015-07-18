
CREATE PROCEDURE [dbo].[Producto_ListadoCompleto]
	@MaxiKioscoId int,
	@ProveedorId int,
	@ProductoId int = NULL
AS
BEGIN
	
	SELECT  P.ProductoId, 
			Codigo = (SELECT SUBSTRING(
					(SELECT ',' + Codigo
					FROM CodigoProducto CP WHERE CP.ProductoId = P.ProductoId
					FOR XML PATH('')),2,200000)),
			P.Descripcion,
			P.AceptaCantidadesDecimales,
			Marca = M.Descripcion,
			Stock = ISNULL((SELECT SUM(ST.Cantidad)
					FROM StockTransaccion ST
						LEFT JOIN Stock S ON ST.StockId = S.StockId
						WHERE S.ProductoId = P.ProductoId
							AND S.MaxiKioscoId = @MaxiKioscoId
							AND S.Eliminado = 0
							AND ST.Eliminado = 0
			), 0),
			CostoConIVA = PP.CostoConIVA,
			CostoSinIVA = PP.CostoSinIVA,
			P.PrecioSinIVA,
			P.PrecioConIVA
		FROM Producto P
			LEFT JOIN ProveedorProducto PP
				ON P.ProductoId = PP.ProductoId
					AND PP.ProveedorId = @ProveedorId
			LEFT JOIN Marca M
				ON P.MarcaId = M.MarcaId
		WHERE P.Eliminado = 0
			AND (PP.Eliminado IS NULL OR PP.Eliminado = 0)
			AND (@ProductoId IS NULL OR P.ProductoId = @ProductoId)
		
END



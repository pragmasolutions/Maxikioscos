/****** Object:  StoredProcedure [dbo].[Producto_ListadoCompleto]    Script Date: 03/14/2015 12:39:09 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Producto_ListadoCompleto]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Producto_ListadoCompleto]
GO

CREATE PROCEDURE [dbo].[Producto_ListadoCompleto]
	@MaxiKioscoId INT,
	@ProveedorId INT,
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
					AND PP.Eliminado = 0
			LEFT JOIN Marca M
				ON P.MarcaId = M.MarcaId
		WHERE P.Eliminado = 0			
			AND (@ProductoId IS NULL OR P.ProductoId = @ProductoId)
		
END


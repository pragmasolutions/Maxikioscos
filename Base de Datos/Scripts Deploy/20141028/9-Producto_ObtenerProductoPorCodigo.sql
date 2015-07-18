/****** Object:  StoredProcedure [dbo].[Producto_ObtenerProductoPorCodigo]    Script Date: 09/21/2014 15:28:13 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Producto_ObtenerProductoPorCodigo]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Producto_ObtenerProductoPorCodigo]
GO


CREATE PROCEDURE [dbo].[Producto_ObtenerProductoPorCodigo]
 @Codigo varchar(30),
 @MaxiKioscoId int
AS
BEGIN
 SELECT 
  P.ProductoId, 
  Codigo = (SELECT SUBSTRING(
     (SELECT ',' + Codigo
     FROM CodigoProducto CP WHERE CP.ProductoId = P.ProductoId
     FOR XML PATH('')),2,200000)),
  P.Descripcion, 
  Marca = M.Descripcion,  
  Precio = ISNULL((SELECT PrecioConIVA FROM dbo.PrecioPorHora(P.ProductoId)), P.PrecioConIVA),
  Costo = PP1.CostoConIVA,
  StockActual = (SELECT ISNULL(SUM(Cantidad), 0)
        FROM StockTransaccion ST
      LEFT JOIN Stock S ON ST.StockId = S.StockId
        WHERE S.MaxiKioscoId = @MaxiKioscoId AND S.ProductoId = P.ProductoId
       )
 FROM Producto P 
  LEFT JOIN Marca M ON P.MarcaId=M.MarcaId 
  LEFT JOIN Stock S ON P.ProductoId = S.ProductoId AND S.MaxiKioscoId = @MaxiKioscoId
  LEFT JOIN ProveedorProducto PP1
	ON P.ProductoID = PP1.ProductoID
  LEFT JOIN ProveedorProducto PP2
		ON PP1.ProductoID = PP2.ProductoID
  WHERE (@Codigo = '0' OR @Codigo IN (SELECT Codigo 
									FROM CodigoProducto CP 
									WHERE CP.ProductoId = P.ProductoId))
 AND P.Eliminado = 0
 AND (PP1.ProveedorProductoID IS NULL OR PP1.FechaUltimaModificacion > PP2.FechaUltimaModificacion)
END


GO



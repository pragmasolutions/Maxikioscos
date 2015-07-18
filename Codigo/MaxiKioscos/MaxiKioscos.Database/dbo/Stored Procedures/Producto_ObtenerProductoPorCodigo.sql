

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
  Recargo = (SELECT Recargo FROM dbo.RecargoPorProductoId(P.ProductoId)),
  Costo = PP.CostoConIVA,
  StockActual = (SELECT ISNULL(SUM(Cantidad), 0)
        FROM StockTransaccion ST
      LEFT JOIN Stock S ON ST.StockId = S.StockId
        WHERE S.MaxiKioscoId = @MaxiKioscoId AND S.ProductoId = P.ProductoId
       )
 FROM Producto P 
  LEFT JOIN Marca M ON P.MarcaId=M.MarcaId 
  LEFT JOIN Stock S ON P.ProductoId = S.ProductoId AND S.MaxiKioscoId = @MaxiKioscoId
  LEFT JOIN (SELECT * FROM dbo.UltimosCostos()) PP
	ON P.ProductoId = PP.ProductoId
  WHERE (@Codigo = '0' OR @Codigo IN (SELECT Codigo 
         FROM CodigoProducto CP 
         WHERE CP.ProductoId = P.ProductoId))
 AND P.Eliminado = 0
END




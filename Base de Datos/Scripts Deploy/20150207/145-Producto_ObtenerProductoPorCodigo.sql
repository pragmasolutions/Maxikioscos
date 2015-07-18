/****** Object:  StoredProcedure [dbo].[Producto_ObtenerProductoPorCodigo]    Script Date: 02/05/2015 18:58:41 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Producto_ObtenerProductoPorCodigo]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Producto_ObtenerProductoPorCodigo]
GO


CREATE PROCEDURE [dbo].[Producto_ObtenerProductoPorCodigo]
 @Codigo varchar(30),
 @MaxiKioscoId int
AS
BEGIN
 SELECT DISTINCT
  P.ProductoId, 
  Codigo = (SELECT SUBSTRING(
     (SELECT ',' + Codigo
     FROM CodigoProducto CP 
     WHERE CP.ProductoId = P.ProductoId
		AND CP.Eliminado = 0
     FOR XML PATH('')),2,200000)),
  P.Descripcion, 
  Marca = M.Descripcion,  
  Precio = ISNULL((SELECT TOP 1 PrecioConIVA FROM dbo.PrecioPorHora(P.ProductoId)), P.PrecioConIVA),
  Recargo = (SELECT TOP 1 Recargo FROM dbo.RecargoPorProductoId(P.ProductoId)),
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
         WHERE CP.ProductoId = P.ProductoId
			AND CP.Eliminado = 0))
 AND P.Eliminado = 0
END





GO



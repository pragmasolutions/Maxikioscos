USE [MaxiKioscos.Kiosco]
GO
/****** Object:  StoredProcedure [dbo].[Producto_ObtenerProductoPorCodigo]    Script Date: 19/01/2015 11:49:39 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


ALTER PROCEDURE [dbo].[Producto_ObtenerProductoPorCodigo]
 @Codigo varchar(30),
 @MaxiKioscoId int
AS
BEGIN
 SELECT
  P.ProductoId, 
  Codigo = (SELECT top 1 SUBSTRING(
     (SELECT top 1 ',' + Codigo
     FROM CodigoProducto CP WHERE CP.ProductoId = P.ProductoId
     FOR XML PATH('')),2,200000)),
  P.Descripcion, 
  Marca = M.Descripcion,  
  Precio = ISNULL((SELECT top 1 PrecioConIVA FROM dbo.PrecioPorHora(P.ProductoId)), P.PrecioConIVA),
  Recargo = (SELECT top 1 Recargo FROM dbo.RecargoPorProductoId(P.ProductoId)),
  Costo = PP.CostoConIVA,
  StockActual = (SELECT top 1 ISNULL(SUM(Cantidad), 0)
        FROM StockTransaccion ST
      LEFT JOIN Stock S ON ST.StockId = S.StockId
       WHERE S.MaxiKioscoId = @MaxiKioscoId AND S.ProductoId = P.ProductoId
      )
 FROM Producto P 
  LEFT JOIN Marca M ON P.MarcaId=M.MarcaId 
  LEFT JOIN Stock S ON P.ProductoId = S.ProductoId AND S.MaxiKioscoId = @MaxiKioscoId
  LEFT JOIN (SELECT TOP 1 * FROM dbo.UltimosCostos()) PP
	ON P.ProductoId = PP.ProductoId
  WHERE (@Codigo = '0' OR @Codigo IN (SELECT TOP 1 Codigo 
         FROM CodigoProducto CP 
         WHERE CP.ProductoId = P.ProductoId))
 AND P.Eliminado = 0
END




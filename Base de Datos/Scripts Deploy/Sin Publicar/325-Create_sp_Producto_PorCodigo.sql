USE [MaxiKioscos.Kiosco]
GO
/****** Object:  StoredProcedure [dbo].[Producto_ObtenerProductoPorCodigo]    Script Date: 03/15/2016 15:45:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[Producto_PorCodigo]--'7792180001641',1
 @Codigo varchar(30),
 @MaxiKioscoId int
AS
BEGIN
 SELECT DISTINCT
  P.ProductoId, 
  Codigo = @Codigo,
  P.Descripcion,         
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
  WHERE  @Codigo IN (SELECT Codigo 
         FROM CodigoProducto CP 
         WHERE CP.ProductoId = P.ProductoId
			AND CP.Eliminado = 0)
 AND P.Eliminado = 0
END








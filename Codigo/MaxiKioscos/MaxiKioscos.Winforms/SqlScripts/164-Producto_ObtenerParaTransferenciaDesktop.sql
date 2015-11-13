CREATE PROCEDURE [dbo].[Producto_ObtenerParaTransferenciaDesktop]
 @Codigo varchar(30),
 @MaxiKioscoId int
AS
BEGIN
 DECLARE @HaceUnMes datetime
 SET @HaceUnMes = (SELECT DATEADD(MONTH, -1, GETDATE()))

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
  Precio = P.PrecioConIVA,
  Costo = PP.CostoConIVA,
  StockActual = (SELECT ISNULL(SUM(Cantidad), 0)
        FROM StockTransaccion ST
      LEFT JOIN Stock S ON ST.StockId = S.StockId
        WHERE S.MaxiKioscoId = @MaxiKioscoId AND S.ProductoId = P.ProductoId
       ),
  VendidoEnUltimoMes = (SELECT SUM(VP.Cantidad)
						FROM VentaProducto VP
							LEFT JOIN Venta V
								ON VP.VentaId = V.VentaId
						WHERE VP.ProductoId = P.ProductoId
							AND V.FechaVenta > @HaceUnMes)
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
 AND P.DisponibleEnDeposito = 1
END


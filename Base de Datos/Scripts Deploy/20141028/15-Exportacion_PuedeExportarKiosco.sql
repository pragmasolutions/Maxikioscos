/****** Object:  StoredProcedure [dbo].[Exportacion_PuedeExportarKiosco]    Script Date: 09/22/2014 23:30:46 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Exportacion_PuedeExportarKiosco]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Exportacion_PuedeExportarKiosco]
GO


CREATE PROCEDURE [dbo].[Exportacion_PuedeExportarKiosco]	
AS
BEGIN
	DECLARE @DesincronizadosCount int
	SET @DesincronizadosCount = (SELECT ISNULL(
	(SELECT COUNT(*) FROM Producto WHERE Desincronizado = 1) +
	(SELECT COUNT(*) FROM CierreCaja WHERE Desincronizado = 1) +
	(SELECT COUNT(*) FROM Excepcion WHERE Desincronizado = 1) +
	(SELECT COUNT(*) FROM OperacionCaja WHERE Desincronizado = 1) +
	(SELECT COUNT(*) FROM Venta WHERE Desincronizado = 1) +
	(SELECT COUNT(*) FROM VentaProducto WHERE Desincronizado = 1) +
	(SELECT COUNT(*) FROM CodigoProducto WHERE Desincronizado = 1) +
	(SELECT COUNT(*) FROM Compra WHERE Desincronizado = 1) +
	(SELECT COUNT(*) FROM CompraProducto WHERE Desincronizado = 1) +
	(SELECT COUNT(*) FROM CorreccionStock WHERE Desincronizado = 1) +
	(SELECT COUNT(*) FROM StockTransaccion WHERE Desincronizado = 1) +
	(SELECT COUNT(*) FROM ProveedorProducto WHERE Desincronizado = 1) +        
    (SELECT COUNT(*) FROM Stock WHERE Desincronizado = 1) +  
    (SELECT COUNT(*) FROM Usuario WHERE Desincronizado = 1) +  
    (SELECT COUNT(*) FROM RecuentoBillete WHERE Desincronizado = 1) +  
    (SELECT COUNT(*) FROM Factura WHERE Desincronizado = 1) +
    (SELECT COUNT(*) FROM ControlStock WHERE Desincronizado = 1) +  
    (SELECT COUNT(*) FROM ControlStockDetalle WHERE Desincronizado = 1), 0))
	
		
	SELECT @DesincronizadosCount AS Cuenta
END


GO



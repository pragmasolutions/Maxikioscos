IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Exportacion_Resetear]') AND type in (N'P', N'PC'))
DROP PROCEDURE[dbo].[Exportacion_Resetear]
GO


CREATE PROCEDURE [dbo].[Exportacion_Resetear]	
AS
BEGIN
	
	DELETE FROM Exportacion

	UPDATE Rubro SET Desincronizado = 1
	UPDATE Marca SET Desincronizado = 1
	UPDATE Producto SET Desincronizado = 1
	UPDATE CodigoProducto SET Desincronizado = 1
	UPDATE Compra SET Desincronizado = 1
	UPDATE CompraProducto SET Desincronizado = 1
	UPDATE CorreccionStock SET Desincronizado = 1
	UPDATE StockTransaccion SET Desincronizado = 1
	UPDATE ExcepcionRubro SET Desincronizado = 1
	UPDATE MaxiKioscoTurno SET Desincronizado = 1
    UPDATE Proveedor SET Desincronizado = 1    
    UPDATE ProveedorProducto SET Desincronizado = 1        
    UPDATE Stock SET Desincronizado = 1  
    UPDATE Usuario SET Desincronizado = 1    
    UPDATE MaxiKiosco SET Desincronizado = 1  
    UPDATE Excepcion SET Desincronizado = 1
    UPDATE UsuarioProveedor SET Desincronizado = 1  
    UPDATE Factura SET Desincronizado = 1 
    UPDATE ControlStock SET Desincronizado = 1  
    UPDATE ControlStockDetalle SET Desincronizado = 1
END




GO



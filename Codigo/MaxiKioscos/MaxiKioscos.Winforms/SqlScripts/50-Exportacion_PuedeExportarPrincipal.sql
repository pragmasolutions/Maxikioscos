ALTER PROCEDURE [dbo].[Exportacion_PuedeExportarPrincipal]	
AS
BEGIN
	DECLARE @DesincronizadosCount int
	SET @DesincronizadosCount = (SELECT ISNULL(
	(SELECT COUNT(*) FROM Rubro WHERE Desincronizado = 1) +
	(SELECT COUNT(*) FROM Marca WHERE Desincronizado = 1) +
	(SELECT COUNT(*) FROM Producto WHERE Desincronizado = 1) +
	(SELECT COUNT(*) FROM CodigoProducto WHERE Desincronizado = 1) +
	(SELECT COUNT(*) FROM Compra WHERE Desincronizado = 1) +
	(SELECT COUNT(*) FROM CompraProducto WHERE Desincronizado = 1) +
	(SELECT COUNT(*) FROM CorreccionStock WHERE Desincronizado = 1) +
	(SELECT COUNT(*) FROM StockTransaccion WHERE Desincronizado = 1) +
	(SELECT COUNT(*) FROM ExcepcionRubro WHERE Desincronizado = 1) +
	(SELECT COUNT(*) FROM MaxiKioscoTurno WHERE Desincronizado = 1) +
    (SELECT COUNT(*) FROM Proveedor WHERE Desincronizado = 1) +    
    (SELECT COUNT(*) FROM ProveedorProducto WHERE Desincronizado = 1) +        
    (SELECT COUNT(*) FROM Stock WHERE Desincronizado = 1) +  
    (SELECT COUNT(*) FROM Usuario WHERE Desincronizado = 1) +    
    (SELECT COUNT(*) FROM MaxiKiosco WHERE Desincronizado = 1) +  
    (SELECT COUNT(*) FROM Excepcion WHERE Desincronizado = 1) +
    (SELECT COUNT(*) FROM UsuarioProveedor WHERE Desincronizado = 1) +  
    (SELECT COUNT(*) FROM Factura WHERE Desincronizado = 1) + 
    (SELECT COUNT(*) FROM ControlStock WHERE Desincronizado = 1) +  
    (SELECT COUNT(*) FROM ControlStockDetalle WHERE Desincronizado = 1), 0))
	
		
	SELECT @DesincronizadosCount AS Cuenta
END


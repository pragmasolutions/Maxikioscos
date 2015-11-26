/****** Object:  StoredProcedure [dbo].[Exportacion_PuedeExportarPrincipal]    Script Date: 10/04/2014 12:55:31 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Exportacion_PuedeExportarPrincipal]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Exportacion_PuedeExportarPrincipal]
GO

CREATE PROCEDURE [dbo].[Exportacion_PuedeExportarPrincipal]	
AS
BEGIN
	DECLARE @DesincronizadosCount int
	SET @DesincronizadosCount = (SELECT ISNULL(
	(SELECT COUNT(*) FROM Cuenta WHERE Desincronizado = 1) +
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
    (SELECT COUNT(*) FROM ProductoPromocion WHERE Desincronizado = 1) +  
    (SELECT COUNT(*) FROM UsuarioProveedor WHERE Desincronizado = 1) +  
    (SELECT COUNT(*) FROM Factura WHERE Desincronizado = 1) + 
    (SELECT COUNT(*) FROM CategoriaCosto WHERE Desincronizado = 1) + 
    (SELECT COUNT(*) FROM Costo WHERE Desincronizado = 1) + 
    (SELECT COUNT(*) FROM Transferencia WHERE Desincronizado = 1) +  
    (SELECT COUNT(*) FROM TransferenciaProducto WHERE Desincronizado = 1) +  
    (SELECT COUNT(*) FROM ControlStock WHERE Desincronizado = 1) +  
    (SELECT COUNT(*) FROM ControlStockDetalle WHERE Desincronizado = 1), 0))
	
		
	SELECT @DesincronizadosCount AS Cuenta
END

GO



INSERT INTO [Reporte] VALUES ('Ventas por Cierre de Caja', 'Por Cierre de Caja','Ventas','VentasPorCierreCaja')
INSERT INTO [Reporte] VALUES ('Ventas por Ticket', 'Por Ticket','Ventas','VentasPorTicket')
INSERT INTO [Reporte] VALUES ('Ventas por Maxikiosco', 'Por Maxikiosco','Ventas','VentasPorMaxikioscos')
INSERT INTO [Reporte] VALUES ('Ventas por Producto', 'Por Producto','Ventas','VentasPorProductos')
INSERT INTO [Reporte] VALUES ('Venas Negativas por Ticket', 'Negativas por Ticket','Ventas','VentasNegativasPorTicket')
INSERT INTO [Reporte] VALUES ('Cierre de Caja General', 'General','Cierres de Caja','CierresDeCaja')
INSERT INTO [Reporte] VALUES ('Cierre de Caja Detalle', 'Detalle','Cierres de Caja','CierresDeCajaDetalle')
INSERT INTO [Reporte] VALUES ('Stock General', 'Stock General','Stock','Stock')
INSERT INTO [Reporte] VALUES ('Productos para reponer', 'Productos para reponer','Stock','ProductosParaReponer')
INSERT INTO [Reporte] VALUES ('Stock Valorizado', 'Valorizado','Stock','StockValorizado')
INSERT INTO [Reporte] VALUES ('Stock Valorizado Detallado', 'Valorizado Detallado','Stock','StockValorizadoDetallado')
INSERT INTO [Reporte] VALUES ('Transferencia por Producto', 'Transferencia por Producto','Stock','TransferenciasPorProducto')
INSERT INTO [Reporte] VALUES ('Retiros Personales General', 'General','Retiros Personales','RetirosPersonales')
INSERT INTO [Reporte] VALUES ('Retiros Personales por Ticket', 'Por Ticket','Retiros Personales','RetirosPersonalesPorTicket')
INSERT INTO [Reporte] VALUES ('Compras por Proveedor', 'Compras por Proveedor','Indicadores Especiales','ComprasPorProveedor')
INSERT INTO [Reporte] VALUES ('Dinero Actual en Caja', 'Dinero Actual en Caja','Indicadores Especiales','DineroPorMaxikiosco')
INSERT INTO [Reporte] VALUES ('Dinero Sobrante/Faltante', 'Dinero Sobrante/Faltante','Indicadores Especiales','DineroSobranteFaltante')
INSERT INTO [Reporte] VALUES ('Ganacia Adicional por Excepciones en Rubros', 'Ganacia Adicional por Excepciones en Rubros','Indicadores Especiales','GanaciaAdicionalExcepcionRubro')
INSERT INTO [Reporte] VALUES ('Auditoría de Productos', 'Productos','Auditoría','AuditoriaProductos')
GO

DECLARE @AdministradorId INT
SET @AdministradorId = (SELECT TOP 1 RoleId FROM webpages_Roles WHERE RoleName = 'Administrador')
INSERT INTO ReporteRol ([RoleId],
						[ReporteId],
						[Desincronizado],
						[Eliminado],
						[FechaUltimaModificacion],
						[Identifier])
SELECT @AdministradorId,
		ReporteId,
		1,
		0,
		NULL,
		NEWID()
FROM Reporte



DECLARE @SuperAdministradorId INT
SET @SuperAdministradorId = (SELECT TOP 1 RoleId FROM webpages_Roles WHERE RoleName = 'SuperAdministrador')
INSERT INTO ReporteRol ([RoleId],
						[ReporteId],
						[Desincronizado],
						[Eliminado],
						[FechaUltimaModificacion],
						[Identifier])
SELECT @SuperAdministradorId,
		ReporteId,
		1,
		0,
		NULL,
		NEWID()
FROM Reporte



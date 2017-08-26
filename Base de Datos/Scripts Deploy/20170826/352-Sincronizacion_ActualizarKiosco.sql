IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Sincronizacion_ActualizarKiosco]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Sincronizacion_ActualizarKiosco]
GO

CREATE PROCEDURE [dbo].[Sincronizacion_ActualizarKiosco]
	@XML XML,
	@MaxikioscoIdentifier uniqueidentifier,
	@Secuencia int
AS
BEGIN
	print('Sync_Cuentas')
	EXEC dbo.Sync_Cuentas @XML, 1	
	print('Sync_Marcas')
	EXEC dbo.Sync_Marcas @XML, 1
	print('Sync_CategoriasCosto')
	EXEC dbo.Sync_CategoriasCosto @XML, 1	
	print('Sync_Rubros')
	EXEC dbo.Sync_Rubros @XML, 1	
	print('Sync_ExcepcionesRubros')
	EXEC dbo.Sync_ExcepcionesRubros @XML, 1
	print('Sync_Proveedores')
	EXEC dbo.Sync_Proveedores @XML, 1	
	print('Sync_Productos')
	EXEC dbo.Sync_Productos @XML, 1	
	print('Sync_ProveedorProductos')	
	EXEC dbo.Sync_ProveedorProductos @XML, 1
	print('Sync_ProductoPromociones')	
	EXEC dbo.Sync_ProductoPromociones @XML, 1
	print('Sync_Usuarios')	
	EXEC dbo.Sync_Usuarios @XML, 1
	print('Sync_Membership')	
	EXEC dbo.Sync_Membership @XML, 1
	print('Sync_UsuariosRoles')		
	EXEC dbo.Sync_UsuariosRoles @XML, 1	
	print('Sync_UsuarioProveedores')	
	EXEC dbo.Sync_UsuarioProveedores @XML, 1
	print('Sync_MaxiKioscos')
	EXEC dbo.Sync_MaxiKioscos @XML, 1	
	print('Sync_MaxiKioscosTurnos')
	EXEC dbo.Sync_MaxiKioscosTurnos @XML, 1	
	print('Sync_CodigosProducto')
	EXEC dbo.Sync_CodigosProducto @XML, 1	
	print('Sync_Stock')
	EXEC dbo.Sync_Stock @XML, 1
	print('Sync_StockTransacciones')
	EXEC dbo.Sync_StockTransacciones @XML, 1	
	print('Sync_Facturas')
	EXEC dbo.Sync_Facturas @XML, 1
	print('Sync_Compras')
	EXEC dbo.Sync_Compras @XML, 1
	print('Sync_Excepciones')		
	EXEC dbo.Sync_Excepciones @XML, 1
	print('Sync_ComprasProductos')
	EXEC dbo.Sync_ComprasProductos @XML, 1	
	print('Sync_CorreccionesStock')		
	EXEC dbo.Sync_CorreccionesStock @XML, 1	
	print('Sync_ControlesStock')		
	EXEC dbo.Sync_ControlesStock @XML, 1		
	print('Sync_ControlesStockDetalle')		
	EXEC dbo.Sync_ControlesStockDetalle @XML, 1
	print('Sync_Costos')		
	EXEC dbo.Sync_Costos @XML, 1
	print('Sync_Transferencias')		
	EXEC dbo.Sync_Transferencias @XML, 1
	print('Sync_TransferenciasProductos')		
	EXEC dbo.Sync_TransferenciasProductos @XML, 1
END

GO




IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Exportacion_Usuario]') AND parent_object_id = OBJECT_ID(N'[dbo].[Exportacion]'))
ALTER TABLE [dbo].[Exportacion] DROP CONSTRAINT [FK_Exportacion_Usuario]
GO


IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Exportacion_Cuenta]') AND parent_object_id = OBJECT_ID(N'[dbo].[Exportacion]'))
ALTER TABLE [dbo].[Exportacion] DROP CONSTRAINT [FK_Exportacion_Cuenta]
GO


IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Cuenta_MotivoCorreccion]') AND parent_object_id = OBJECT_ID(N'[dbo].[Cuenta]'))
ALTER TABLE [dbo].[Cuenta] DROP CONSTRAINT [FK_Cuenta_MotivoCorreccion]
GO


IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_MaxiKiosco_Cuenta]') AND parent_object_id = OBJECT_ID(N'[dbo].[MaxiKiosco]'))
ALTER TABLE [dbo].[MaxiKiosco] DROP CONSTRAINT [FK_MaxiKiosco_Cuenta]
GO




DROP TABLE Billete
DROP TABLE CategoriaCosto
DROP TABLE CierreCaja
DROP TABLE CodigoProducto
DROP TABLE Compra
DROP TABLE CompraProducto
DROP TABLE ConfiguracionLocal
DROP TABLE ControlStock
DROP TABLE ControlStockDetalle
DROP TABLE CorreccionStock
DROP TABLE Costo
DROP TABLE Cuenta
DROP TABLE ErrorSincronizacion
DROP TABLE EstadoTicket
DROP TABLE Excepcion
DROP TABLE ExcepcionRubro
DROP TABLE Factura
DROP TABLE Importacion
DROP TABLE Localidad
DROP TABLE Marca
DROP TABLE MaxiKioscoTurno
DROP TABLE MensajeTicketError
DROP TABLE MotivoCorreccion
DROP TABLE MotivoOperacionCaja
DROP TABLE OperacionCaja
DROP TABLE Permiso
DROP TABLE PermisoRol
DROP TABLE Producto
DROP TABLE ProductoPromocion
DROP TABLE Proveedor
DROP TABLE ProveedorProducto
DROP TABLE Provincia
DROP TABLE RecuentoBillete
DROP TABLE Reporte
DROP TABLE ReporteRol
DROP TABLE RetiroPersonal
DROP TABLE RetiroPersonalProducto
DROP TABLE Rubro
DROP TABLE Stock
DROP TABLE StockTransaccion
DROP TABLE StockTransaccionTipo
DROP TABLE TicketError
DROP TABLE TipoCuit
DROP TABLE Transferencia
DROP TABLE TransferenciaProducto
DROP TABLE Turno
DROP TABLE Usuario
DROP TABLE UsuarioProveedor
DROP TABLE Venta
DROP TABLE VentaProducto
DROP TABLE webpages_Membership
DROP TABLE webpages_OAuthMembership
DROP TABLE webpages_Roles
DROP TABLE webpages_UsersInRoles





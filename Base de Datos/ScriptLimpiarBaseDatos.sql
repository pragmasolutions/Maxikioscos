BEGIN TRANSACTION [Tran1]

BEGIN TRY

DELETE FROM [AlertaStock]
DELETE FROM [MensajeTicketError]
DELETE FROM [TicketError]
DELETE FROM [EstadoTicket]
DELETE FROM [VentaProducto]
DELETE FROM [Venta]
DELETE FROM [Excepcion]
DELETE FROM [CompraProducto]
DELETE FROM [Compra]
DELETE FROM [Factura]
DELETE FROM [OperacionCaja]
DELETE FROM [RecuentoBillete]
DELETE FROM [CierreCaja]
DELETE FROM [CorreccionStock]
DELETE FROM [UsuarioProveedor]
DELETE FROM [ProveedorProducto]
DELETE FROM [ControlStockDetalle]
DELETE FROM [ControlStock]
DELETE FROM [Proveedor]
DELETE FROM [StockTransaccion]
DELETE FROM [Stock]
DELETE FROM [CodigoProducto]
DELETE FROM [Producto]
DELETE FROM [Marca]
DELETE FROM [ExcepcionRubro]
DELETE FROM [Rubro]
DELETE FROM [Exportacion]
DELETE FROM [Importacion]
DELETE FROM [UsuarioMaxiKiosco]
DELETE FROM [webpages_UsersInRoles]
DELETE FROM [Usuario]
DELETE FROM [MaxiKioscoTurno]
DELETE FROM [MaxiKiosco]
DELETE FROM [Cuenta]
DELETE FROM [Turno]
DELETE FROM [TipoCuit]
DELETE FROM [StockTransaccionTipo]
DELETE FROM [MotivoCorreccion]
DELETE FROM [MotivoOperacionCaja]
DELETE FROM [Localidad]
DELETE FROM [Provincia]
DELETE FROM [Billete]
DELETE FROM [webpages_Membership]
DELETE FROM [webpages_OAuthMembership]
DELETE FROM [webpages_Roles]

DBCC CHECKIDENT ('[AlertaStock]',RESEED,0)
DBCC CHECKIDENT ('[MensajeTicketError]',RESEED,0)
DBCC CHECKIDENT ('[TicketError]',RESEED,0)
DBCC CHECKIDENT ('[VentaProducto]',RESEED,0)
DBCC CHECKIDENT ('[Venta]',RESEED,0)
DBCC CHECKIDENT ('[Excepcion]',RESEED,0)
DBCC CHECKIDENT ('[CompraProducto]',RESEED,0)
DBCC CHECKIDENT ('[Compra]',RESEED,0)
DBCC CHECKIDENT ('[Factura]',RESEED,0)
DBCC CHECKIDENT ('[OperacionCaja]',RESEED,0)
DBCC CHECKIDENT ('[RecuentoBillete]',RESEED,0)
DBCC CHECKIDENT ('[CierreCaja]',RESEED,0)
DBCC CHECKIDENT ('[CorreccionStock]',RESEED,0)
DBCC CHECKIDENT ('[UsuarioProveedor]',RESEED,0)
DBCC CHECKIDENT ('[ProveedorProducto]',RESEED,0)
DBCC CHECKIDENT ('[Proveedor]',RESEED,0)
DBCC CHECKIDENT ('[StockTransaccion]',RESEED,0)
DBCC CHECKIDENT ('[Stock]',RESEED,0)
DBCC CHECKIDENT ('[CodigoProducto]',RESEED,0)
DBCC CHECKIDENT ('[Producto]',RESEED,0)
DBCC CHECKIDENT ('[Marca]',RESEED,0)
DBCC CHECKIDENT ('[ExcepcionRubro]',RESEED,0)
DBCC CHECKIDENT ('[Rubro]',RESEED,0)
DBCC CHECKIDENT ('[UsuarioMaxiKiosco]',RESEED,0)
DBCC CHECKIDENT ('[Usuario]',RESEED,0)
DBCC CHECKIDENT ('[Exportacion]',RESEED,0)
DBCC CHECKIDENT ('[Importacion]',RESEED,0)
DBCC CHECKIDENT ('[MaxiKioscoTurno]',RESEED,0)
DBCC CHECKIDENT ('[MaxiKiosco]',RESEED,0)
DBCC CHECKIDENT ('[Cuenta]',RESEED,0)
DBCC CHECKIDENT ('[Turno]',RESEED,0)
DBCC CHECKIDENT ('[Localidad]',RESEED,0)
DBCC CHECKIDENT ('[Provincia]',RESEED,0)
DBCC CHECKIDENT ('[ControlStockDetalle]',RESEED,0)
DBCC CHECKIDENT ('[ControlStock]',RESEED,0)
DBCC CHECKIDENT ('[webpages_Roles]',RESEED,0)

--Insert datos del sistema.
SET IDENTITY_INSERT [dbo].[Cuenta] ON
INSERT [dbo].[Cuenta] ([CuentaId], [Titular], [Identifier], [FechaUltimaModificacion], [Eliminado], [MargenImporteFactura], [Desincronizado]) VALUES (1, N'Matías Gancio', N'816c81c3-c895-40da-b3b6-c24e8d3529de', NULL, 0, 500.0000, 0)
SET IDENTITY_INSERT [dbo].[Cuenta] OFF

SET IDENTITY_INSERT [dbo].[webpages_Roles] ON
INSERT [dbo].[webpages_Roles] ([RoleId], [RoleName]) VALUES (1, N'Administrador')
INSERT [dbo].[webpages_Roles] ([RoleId], [RoleName]) VALUES (3, N'Encargado')
INSERT [dbo].[webpages_Roles] ([RoleId], [RoleName]) VALUES (2, N'Operador')
INSERT [dbo].[webpages_Roles] ([RoleId], [RoleName]) VALUES (4, N'SuperAdministrador')
SET IDENTITY_INSERT [dbo].[webpages_Roles] OFF

SET IDENTITY_INSERT [dbo].[Turno] ON
INSERT [dbo].[Turno] ([TurnoId], [Descripcion], [Desde], [Hasta]) VALUES (1, N'Mañana', CAST(0x00BC700000000000 AS Time), CAST(0x00C0A80000000000 AS Time))
INSERT [dbo].[Turno] ([TurnoId], [Descripcion], [Desde], [Hasta]) VALUES (2, N'Siesta', CAST(0x00FCA80000000000 AS Time), CAST(0x0000E10000000000 AS Time))
INSERT [dbo].[Turno] ([TurnoId], [Descripcion], [Desde], [Hasta]) VALUES (3, N'Tarde', CAST(0x003CE10000000000 AS Time), CAST(0x0040190100000000 AS Time))
INSERT [dbo].[Turno] ([TurnoId], [Descripcion], [Desde], [Hasta]) VALUES (4, N'Noche', CAST(0x007C190100000000 AS Time), CAST(0x0000000000000000 AS Time))
INSERT [dbo].[Turno] ([TurnoId], [Descripcion], [Desde], [Hasta]) VALUES (5, N'Tarde', CAST(0x003C000000000000 AS Time), CAST(0x0080700000000000 AS Time))
SET IDENTITY_INSERT [dbo].[Turno] OFF

INSERT [dbo].[TipoCuit] ([TipoCuitId], [Descripcion], [FechaUltimaModificacion], [Eliminado], [Desincronizado]) VALUES (1, N'Consumidor Final', NULL, 0, 0)
INSERT [dbo].[TipoCuit] ([TipoCuitId], [Descripcion], [FechaUltimaModificacion], [Eliminado], [Desincronizado]) VALUES (2, N'Resp. Inscripto', NULL, 0, 0)
INSERT [dbo].[TipoCuit] ([TipoCuitId], [Descripcion], [FechaUltimaModificacion], [Eliminado], [Desincronizado]) VALUES (3, N'Resp. No Inscripto', NULL, 0, 0)
INSERT [dbo].[TipoCuit] ([TipoCuitId], [Descripcion], [FechaUltimaModificacion], [Eliminado], [Desincronizado]) VALUES (4, N'No Responsable', NULL, 0, 0)
INSERT [dbo].[TipoCuit] ([TipoCuitId], [Descripcion], [FechaUltimaModificacion], [Eliminado], [Desincronizado]) VALUES (5, N'Excento', NULL, 0, 0)
INSERT [dbo].[TipoCuit] ([TipoCuitId], [Descripcion], [FechaUltimaModificacion], [Eliminado], [Desincronizado]) VALUES (6, N'Monotributista', NULL, 0, 0)
INSERT [dbo].[TipoCuit] ([TipoCuitId], [Descripcion], [FechaUltimaModificacion], [Eliminado], [Desincronizado]) VALUES (7, N'Resp. No Insc. N.I.', NULL, 0, 0)

INSERT [dbo].[StockTransaccionTipo] ([StockTransaccionTipoId], [Nombre]) VALUES (1, N'Venta')
INSERT [dbo].[StockTransaccionTipo] ([StockTransaccionTipoId], [Nombre]) VALUES (2, N'Compra')
INSERT [dbo].[StockTransaccionTipo] ([StockTransaccionTipoId], [Nombre]) VALUES (3, N'Corrección')

INSERT [dbo].[EstadoTicket] ([EstadoTicketId], [Descripcion]) VALUES (1, N'Pendiente')
INSERT [dbo].[EstadoTicket] ([EstadoTicketId], [Descripcion]) VALUES (2, N'En Progreso')
INSERT [dbo].[EstadoTicket] ([EstadoTicketId], [Descripcion]) VALUES (3, N'Cerrado')
INSERT [dbo].[EstadoTicket] ([EstadoTicketId], [Descripcion]) VALUES (4, N'Eliminado')

SET IDENTITY_INSERT [dbo].[Provincia] ON
INSERT [dbo].[Provincia] ([ProvinciaId], [Descripcion], [FechaUltimaModificacion], [Eliminado], [Desincronizado]) VALUES (1, N'Corrientes', NULL, 0, 0)
SET IDENTITY_INSERT [dbo].[Provincia] OFF

INSERT [dbo].[MotivoOperacionCaja] ([MotivoOperacionCajaId], [Descripcion], [FechaUltimaModificacion], [Eliminado], [Desincronizado], [SumarACierreCaja]) VALUES (1, N'Refuerzo', NULL, 0, 1, 1)
INSERT [dbo].[MotivoOperacionCaja] ([MotivoOperacionCajaId], [Descripcion], [FechaUltimaModificacion], [Eliminado], [Desincronizado], [SumarACierreCaja]) VALUES (2, N'Extracción', NULL, 0, 1, 0)

INSERT [dbo].[MotivoCorreccion] ([MotivoCorreccionId], [Descripcion], [SumarAStock], [MostrarEnDropdown]) VALUES (1, N'Retiro', 0, 1)
INSERT [dbo].[MotivoCorreccion] ([MotivoCorreccionId], [Descripcion], [SumarAStock], [MostrarEnDropdown]) VALUES (2, N'Vencimiento', 0, 1)
INSERT [dbo].[MotivoCorreccion] ([MotivoCorreccionId], [Descripcion], [SumarAStock], [MostrarEnDropdown]) VALUES (3, N'Mercadería Dañada', 0, 1)
INSERT [dbo].[MotivoCorreccion] ([MotivoCorreccionId], [Descripcion], [SumarAStock], [MostrarEnDropdown]) VALUES (4, N'Reposición', 1, 1)
INSERT [dbo].[MotivoCorreccion] ([MotivoCorreccionId], [Descripcion], [SumarAStock], [MostrarEnDropdown]) VALUES (5, N'Transferencia', 0, 0)
INSERT [dbo].[MotivoCorreccion] ([MotivoCorreccionId], [Descripcion], [SumarAStock], [MostrarEnDropdown]) VALUES (6, N'Sin Motivo', 0, 1)

INSERT [dbo].[Billete] ([BilleteId], [Monto]) VALUES (1, 100)
INSERT [dbo].[Billete] ([BilleteId], [Monto]) VALUES (2, 50)
INSERT [dbo].[Billete] ([BilleteId], [Monto]) VALUES (3, 20)
INSERT [dbo].[Billete] ([BilleteId], [Monto]) VALUES (4, 10)
INSERT [dbo].[Billete] ([BilleteId], [Monto]) VALUES (5, 5)
INSERT [dbo].[Billete] ([BilleteId], [Monto]) VALUES (6, 2)

SET IDENTITY_INSERT [dbo].[Localidad] ON
INSERT [dbo].[Localidad] ([LocalidadId], [Descripcion], [ProvinciaId], [CodigoPostal], [FechaUltimaModificacion], [Eliminado], [Desincronizado]) VALUES (1, N'Corrientes', 1, N'3400', NULL, 0, 0)
SET IDENTITY_INSERT [dbo].[Localidad] OFF

--Insert admin user
INSERT [dbo].[webpages_Membership] ([UserId], [CreateDate], [ConfirmationToken], [IsConfirmed], [LastPasswordFailureDate], [PasswordFailuresSinceLastSuccess], [Password], [PasswordChangedDate], [PasswordSalt], [PasswordVerificationToken], [PasswordVerificationTokenExpirationDate]) VALUES (1, GETDATE(), NULL, 1, CAST(0x0000A2F500247660 AS DateTime), 0, N'AJoOlAqcDnMpg/3nOSNw6no/Dy0asBEW/rDo014VQPAvAQ28Q+PumdrzDUqHPFPQlQ==', CAST(0x0000A35F0124E4A0 AS DateTime), N'', NULL, NULL)
SET IDENTITY_INSERT [dbo].[Usuario] ON
INSERT [dbo].[Usuario] ([UsuarioId], [NombreUsuario], [CuentaId], [Nombre], [Apellido], [Identifier], [FechaUltimaModificacion], [Eliminado], [Desincronizado]) VALUES (1, N'admin', 1, N'Juan', N'Rossi', N'64e38a0c-c4aa-414b-92d2-0d2f594323ca', CAST(0x07D0655620C44F380B AS DateTime2), 0, 0)
SET IDENTITY_INSERT [dbo].[Usuario] OFF
INSERT [dbo].[webpages_UsersInRoles] ([UserId], [RoleId]) VALUES (1, 4)


COMMIT TRANSACTION [Tran1]

PRINT('El script se ha ejecutado correctamente')

END TRY
BEGIN CATCH
  ROLLBACK TRANSACTION [Tran1]
  PRINT('El script no se ha ejecutado correctamente')
  SELECT
	ERROR_NUMBER() AS ErrorNumber,
	ERROR_SEVERITY() AS ErrorSeverity,
	ERROR_STATE() AS ErrorState,
	ERROR_PROCEDURE() AS ErrorProcedure,
	ERROR_LINE() AS ErrorLine,
	ERROR_MESSAGE() AS ErrorMessage;
END CATCH  
GO
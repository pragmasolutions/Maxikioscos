INSERT INTO [Permiso] VALUES ('PRODUCTOS', 'PRODUCTOS', 0, 0, GETDATE(), NEWID())
INSERT INTO [Permiso] VALUES ('MARCAS', 'MARCAS', 0, 0, GETDATE(), NEWID())
INSERT INTO [Permiso] VALUES ('RUBROS', 'RUBROS', 0, 0, GETDATE(), NEWID())
INSERT INTO [Permiso] VALUES ('PROMOCIONES', 'PROMOCIONES', 0, 0, GETDATE(), NEWID())
INSERT INTO [Permiso] VALUES ('STOCK', 'STOCK', 0, 0, GETDATE(), NEWID())
INSERT INTO [Permiso] VALUES ('COMPRAS', 'COMPRAS', 0, 0, GETDATE(), NEWID())
INSERT INTO [Permiso] VALUES ('GASTOS', 'GASTOS', 0, 0, GETDATE(), NEWID())
INSERT INTO [Permiso] VALUES ('TRASFERENCIAS', 'TRASFERENCIAS', 0, 0, GETDATE(), NEWID())
INSERT INTO [Permiso] VALUES ('CONTROLDESTOCK', 'CONTROL DE STOCK', 0, 0, GETDATE(), NEWID())
INSERT INTO [Permiso] VALUES ('FACTURAS', 'FACTURAS', 0, 0, GETDATE(), NEWID())
INSERT INTO [Permiso] VALUES ('EXCEPCIONES', 'EXCEPCIONES', 0, 0, GETDATE(), NEWID())
INSERT INTO [Permiso] VALUES ('PROVEEDORES', 'PROVEEDORES', 0, 0, GETDATE(), NEWID())
INSERT INTO [Permiso] VALUES ('MAXIKIOSCOS', 'MAXIKIOSCOS', 0, 0, GETDATE(), NEWID())
INSERT INTO [Permiso] VALUES ('EXCEPCIONESPORRUBRO', 'EXCEPCIONES POR RUBRO', 0, 0, GETDATE(), NEWID())
INSERT INTO [Permiso] VALUES ('CATEGORIASDEGASTOS', 'CATEGORIAS DEG ASTOS', 0, 0, GETDATE(), NEWID())
INSERT INTO [Permiso] VALUES ('USUARIOS', 'USUARIOS', 0, 0, GETDATE(), NEWID())
INSERT INTO [Permiso] VALUES ('ROLES', 'ROLES', 0, 0, GETDATE(), NEWID())
INSERT INTO [Permiso] VALUES ('SINCRONIZACION', 'SINCRONIZACION', 0, 0, GETDATE(), NEWID())
INSERT INTO [Permiso] VALUES ('TICKETS', 'TICKETS', 0, 0, GETDATE(), NEWID())
GO

DECLARE @AdministradorId INT
SET @AdministradorId = (SELECT TOP 1 RoleId FROM webpages_Roles WHERE RoleName = 'Administrador')
INSERT INTO PermisoRol ([RoleId],
						[PermisoId],
						[Desincronizado],
						[Eliminado],
						[FechaUltimaModificacion],
						[Identifier])
SELECT @AdministradorId,
		PermisoId,
		1,
		0,
		NULL,
		NEWID()
FROM Permiso


DECLARE @SuperAdministradorId INT
SET @SuperAdministradorId = (SELECT TOP 1 RoleId FROM webpages_Roles WHERE RoleName = 'SuperAdministrador')
INSERT INTO PermisoRol ([RoleId],
						[PermisoId],
						[Desincronizado],
						[Eliminado],
						[FechaUltimaModificacion],
						[Identifier])
SELECT @SuperAdministradorId,
		PermisoId,
		1,
		0,
		NULL,
		NEWID()
FROM Permiso



INSERT INTO [Permiso] VALUES ('PRODUCTOS', 0, 0, GETDATE(), NEWID())
INSERT INTO [Permiso] VALUES ('MARCAS', 0, 0, GETDATE(), NEWID())
INSERT INTO [Permiso] VALUES ('RUBROS', 0, 0, GETDATE(), NEWID())
INSERT INTO [Permiso] VALUES ('PROMOCIONES', 0, 0, GETDATE(), NEWID())
INSERT INTO [Permiso] VALUES ('STOCK', 0, 0, GETDATE(), NEWID())
INSERT INTO [Permiso] VALUES ('COMPRAS', 0, 0, GETDATE(), NEWID())
INSERT INTO [Permiso] VALUES ('GASTOS', 0, 0, GETDATE(), NEWID())
INSERT INTO [Permiso] VALUES ('TRASFERENCIAS', 0, 0, GETDATE(), NEWID())
INSERT INTO [Permiso] VALUES ('CONTROLDESTOCK', 0, 0, GETDATE(), NEWID())
INSERT INTO [Permiso] VALUES ('FACTURAS', 0, 0, GETDATE(), NEWID())
INSERT INTO [Permiso] VALUES ('EXCEPCIONES', 0, 0, GETDATE(), NEWID())
INSERT INTO [Permiso] VALUES ('PROVEEDORES', 0, 0, GETDATE(), NEWID())
INSERT INTO [Permiso] VALUES ('MAXIKIOSCOS', 0, 0, GETDATE(), NEWID())
INSERT INTO [Permiso] VALUES ('EXCEPCIONESPORRUBRO', 0, 0, GETDATE(), NEWID())
INSERT INTO [Permiso] VALUES ('CATEGORIASDEGASTOS', 0, 0, GETDATE(), NEWID())
INSERT INTO [Permiso] VALUES ('USUARIOS', 0, 0, GETDATE(), NEWID())
INSERT INTO [Permiso] VALUES ('ROLES', 0, 0, GETDATE(), NEWID())
INSERT INTO [Permiso] VALUES ('SINCRONIZACION', 0, 0, GETDATE(), NEWID())
INSERT INTO [Permiso] VALUES ('TICKETS', 0, 0, GETDATE(), NEWID())
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



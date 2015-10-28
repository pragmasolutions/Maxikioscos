
CREATE TABLE dbo.Permiso
	(
	PermisoId int NOT NULL IDENTITY (1, 1),
	Nombre varchar(250) NOT NULL,
	Desincronizado bit NOT NULL,
	Eliminado bit NOT NULL,
	FechaUltimaModificacion datetime2(7) NULL,
	Identifier uniqueidentifier NOT NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.Permiso ADD CONSTRAINT
	PK_Permiso PRIMARY KEY CLUSTERED 
	(
	PermisoId
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.Permiso SET (LOCK_ESCALATION = TABLE)
GO

ALTER TABLE dbo.webpages_Roles SET (LOCK_ESCALATION = TABLE)
GO

CREATE TABLE dbo.PermisoRol
	(
	PermisoRolId int NOT NULL IDENTITY (1, 1),
	RoleId int NOT NULL,
	PermisoId int NOT NULL,
	Desincronizado bit NOT NULL,
	Eliminado bit NOT NULL,
	FechaUltimaModificacion datetime2(7) NULL,
	Identifier uniqueidentifier NOT NULL
	)  ON [PRIMARY]
GO

ALTER TABLE dbo.PermisoRol ADD CONSTRAINT
	PK_PermisoRol PRIMARY KEY CLUSTERED 
	(
	PermisoRolId
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO

ALTER TABLE dbo.PermisoRol ADD CONSTRAINT
	FK_PermisoRol_webpages_Roles FOREIGN KEY
	(
	RoleId
	) REFERENCES dbo.webpages_Roles
	(
	RoleId
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO

ALTER TABLE dbo.PermisoRol ADD CONSTRAINT
	FK_PermisoRol_Permiso FOREIGN KEY
	(
	PermisoId
	) REFERENCES dbo.Permiso
	(
	PermisoId
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO

ALTER TABLE dbo.PermisoRol SET (LOCK_ESCALATION = TABLE)
GO

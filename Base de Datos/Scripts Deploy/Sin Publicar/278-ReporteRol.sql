CREATE TABLE dbo.ReporteRol
	(
	ReporteRoleId int NOT NULL IDENTITY (1, 1),
	RoleId int NOT NULL,
	ReporteId int NOT NULL,
	Desincronizado bit NOT NULL,
	Eliminado bit NOT NULL,
	FechaUltimaModificacion datetime2(7) NULL,
	Identifier uniqueidentifier NOT NULL
	)  ON [PRIMARY]

ALTER TABLE dbo.ReporteRol ADD CONSTRAINT
	PK_ReporteRol PRIMARY KEY CLUSTERED 
	(
	ReporteRoleId
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

ALTER TABLE dbo.ReporteRol SET (LOCK_ESCALATION = TABLE)



ALTER TABLE [dbo].[ReporteRol]  WITH CHECK ADD  CONSTRAINT [FK_ReporteRol_Reporte] FOREIGN KEY([ReporteId])
REFERENCES [dbo].[Reporte] ([ReporteId])
GO

ALTER TABLE [dbo].[ReporteRol] CHECK CONSTRAINT [FK_ReporteRol_Reporte]
GO



ALTER TABLE [dbo].[ReporteRol]  WITH CHECK ADD  CONSTRAINT [FK_ReporteRol_Rol] FOREIGN KEY([RoleId])
REFERENCES [dbo].[webpages_Roles] ([RoleId])
GO

ALTER TABLE [dbo].[ReporteRol] CHECK CONSTRAINT [FK_ReporteRol_Rol]
GO



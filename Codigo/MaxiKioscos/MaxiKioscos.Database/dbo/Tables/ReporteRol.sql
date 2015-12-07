CREATE TABLE [dbo].[ReporteRol] (
    [ReporteRoleId]           INT              IDENTITY (1, 1) NOT NULL,
    [RoleId]                  INT              NOT NULL,
    [ReporteId]               INT              NOT NULL,
    [Desincronizado]          BIT              NOT NULL,
    [Eliminado]               BIT              NOT NULL,
    [FechaUltimaModificacion] DATETIME2 (7)    NULL,
    [Identifier]              UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [PK_ReporteRol] PRIMARY KEY CLUSTERED ([ReporteRoleId] ASC),
    CONSTRAINT [FK_ReporteRol_Reporte] FOREIGN KEY ([ReporteId]) REFERENCES [dbo].[Reporte] ([ReporteId]),
    CONSTRAINT [FK_ReporteRol_Rol] FOREIGN KEY ([RoleId]) REFERENCES [dbo].[webpages_Roles] ([RoleId])
);


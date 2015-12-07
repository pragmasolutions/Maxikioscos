CREATE TABLE [dbo].[PermisoRol] (
    [PermisoRolId]            INT              IDENTITY (1, 1) NOT NULL,
    [RoleId]                  INT              NOT NULL,
    [PermisoId]               INT              NOT NULL,
    [Desincronizado]          BIT              NOT NULL,
    [Eliminado]               BIT              NOT NULL,
    [FechaUltimaModificacion] DATETIME2 (7)    NULL,
    [Identifier]              UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [PK_PermisoRol] PRIMARY KEY CLUSTERED ([PermisoRolId] ASC),
    CONSTRAINT [FK_PermisoRol_Permiso] FOREIGN KEY ([PermisoId]) REFERENCES [dbo].[Permiso] ([PermisoId]),
    CONSTRAINT [FK_PermisoRol_webpages_Roles] FOREIGN KEY ([RoleId]) REFERENCES [dbo].[webpages_Roles] ([RoleId])
);


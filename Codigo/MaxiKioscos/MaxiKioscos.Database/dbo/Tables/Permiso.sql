CREATE TABLE [dbo].[Permiso] (
    [PermisoId]               INT              IDENTITY (1, 1) NOT NULL,
    [Nombre]                  VARCHAR (250)    NOT NULL,
    [NombreCompleto]          VARCHAR (250)    NOT NULL,
    [Desincronizado]          BIT              NOT NULL,
    [Eliminado]               BIT              NOT NULL,
    [FechaUltimaModificacion] DATETIME2 (7)    NULL,
    [Identifier]              UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [PK_Permiso] PRIMARY KEY CLUSTERED ([PermisoId] ASC)
);


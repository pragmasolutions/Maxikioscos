CREATE TABLE [dbo].[UsuarioProveedor] (
    [UsuarioProveedorId]      INT              IDENTITY (1, 1) NOT NULL,
    [UsuarioId]               INT              NOT NULL,
    [ProveedorId]             INT              NOT NULL,
    [Desincronizado]          BIT              NOT NULL,
    [Eliminado]               BIT              NOT NULL,
    [FechaUltimaModificacion] DATETIME2 (7)    NULL,
    [Identifier]              UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [PK_UsuarioProveedor] PRIMARY KEY CLUSTERED ([UsuarioProveedorId] ASC),
    CONSTRAINT [FK_UsuarioProveedor_Proveedor] FOREIGN KEY ([ProveedorId]) REFERENCES [dbo].[Proveedor] ([ProveedorId]),
    CONSTRAINT [FK_UsuarioProveedor_Usuario] FOREIGN KEY ([UsuarioId]) REFERENCES [dbo].[Usuario] ([UsuarioId])
);


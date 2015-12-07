CREATE TABLE [dbo].[ProveedorProducto] (
    [ProveedorProductoId]     INT              IDENTITY (1, 1) NOT NULL,
    [Identifier]              UNIQUEIDENTIFIER NOT NULL,
    [ProveedorId]             INT              NOT NULL,
    [ProductoId]              INT              NOT NULL,
    [Desincronizado]          BIT              NOT NULL,
    [FechaUltimaModificacion] DATETIME2 (7)    NULL,
    [Eliminado]               BIT              NOT NULL,
    [CostoSinIVA]             MONEY            NOT NULL,
    [CostoConIVA]             MONEY            NOT NULL,
    [FechaUltimoCambioCosto]  DATETIME         NULL,
    CONSTRAINT [PK_ProveedorProducto] PRIMARY KEY CLUSTERED ([ProveedorProductoId] ASC),
    CONSTRAINT [FK_ProveedorProducto_Producto] FOREIGN KEY ([ProductoId]) REFERENCES [dbo].[Producto] ([ProductoId]),
    CONSTRAINT [FK_ProveedorProducto_Proveedor] FOREIGN KEY ([ProveedorId]) REFERENCES [dbo].[Proveedor] ([ProveedorId])
);


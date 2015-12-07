CREATE TABLE [dbo].[CompraProducto] (
    [CompraProductoId]        INT              IDENTITY (1, 1) NOT NULL,
    [CompraId]                INT              NOT NULL,
    [Identifier]              UNIQUEIDENTIFIER NOT NULL,
    [ProductoId]              INT              NOT NULL,
    [CostoActual]             MONEY            NOT NULL,
    [CostoActualizado]        MONEY            NULL,
    [PrecioActual]            MONEY            NOT NULL,
    [PrecioActualizado]       MONEY            NULL,
    [Cantidad]                DECIMAL (18, 2)  NOT NULL,
    [Desincronizado]          BIT              NOT NULL,
    [FechaUltimaModificacion] DATETIME2 (7)    NULL,
    [Eliminado]               BIT              NOT NULL,
    CONSTRAINT [PK_CompraProducto] PRIMARY KEY CLUSTERED ([CompraProductoId] ASC),
    CONSTRAINT [FK_CompraProducto_Compra] FOREIGN KEY ([CompraId]) REFERENCES [dbo].[Compra] ([CompraId]),
    CONSTRAINT [FK_CompraProducto_Producto] FOREIGN KEY ([ProductoId]) REFERENCES [dbo].[Producto] ([ProductoId])
);


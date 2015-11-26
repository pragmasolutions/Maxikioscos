CREATE TABLE [dbo].[CodigoProducto] (
    [CodigoProductoId]        INT              IDENTITY (1, 1) NOT NULL,
    [ProductoId]              INT              NOT NULL,
    [Codigo]                  VARCHAR (30)     NOT NULL,
    [Desincronizado]          BIT              NOT NULL,
    [FechaUltimaModificacion] DATETIME2 (7)    NULL,
    [Eliminado]               BIT              NOT NULL,
    [Identifier]              UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [PK_CodigoProducto] PRIMARY KEY CLUSTERED ([CodigoProductoId] ASC),
    CONSTRAINT [FK_CodigoProducto_Producto] FOREIGN KEY ([ProductoId]) REFERENCES [dbo].[Producto] ([ProductoId])
);


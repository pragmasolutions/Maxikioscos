CREATE TABLE [dbo].[VentaProducto] (
    [VentaProductoId]         INT              IDENTITY (1, 1) NOT NULL,
    [Identifier]              UNIQUEIDENTIFIER NOT NULL,
    [VentaId]                 INT              NOT NULL,
    [ProductoId]              INT              NOT NULL,
    [Costo]                   MONEY            NOT NULL,
    [Precio]                  MONEY            NULL,
    [Cantidad]                DECIMAL (18, 2)  NOT NULL,
    [FechaUltimaModificacion] DATETIME2 (7)    NULL,
    [Eliminado]               BIT              NOT NULL,
    [Desincronizado]          BIT              NOT NULL,
    [AdicionalPorExcepcion]   MONEY            NULL,
    CONSTRAINT [PK_VentaProducto] PRIMARY KEY CLUSTERED ([VentaProductoId] ASC),
    CONSTRAINT [FK_VentaProducto_Producto] FOREIGN KEY ([ProductoId]) REFERENCES [dbo].[Producto] ([ProductoId]),
    CONSTRAINT [FK_VentaProducto_Venta] FOREIGN KEY ([VentaId]) REFERENCES [dbo].[Venta] ([VentaId])
);


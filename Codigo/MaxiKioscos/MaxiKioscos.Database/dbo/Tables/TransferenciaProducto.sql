CREATE TABLE [dbo].[TransferenciaProducto] (
    [TransferenciaProductoId] INT              IDENTITY (1, 1) NOT NULL,
    [TransferenciaId]         INT              NOT NULL,
    [ProductoId]              INT              NOT NULL,
    [Cantidad]                INT              NOT NULL,
    [PrecioVenta]             MONEY            NOT NULL,
    [Desincronizado]          BIT              NOT NULL,
    [FechaUltimaModificacion] DATETIME2 (7)    NULL,
    [Identifier]              UNIQUEIDENTIFIER NOT NULL,
    [Eliminado]               BIT              NOT NULL,
    [StockOrigen]             DECIMAL (18, 2)  NULL,
    [StockDestino]            DECIMAL (18, 2)  NOT NULL,
    [Orden]                   INT              DEFAULT ((1)) NOT NULL,
    [Costo]                   MONEY            DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_TransferenciaProducto] PRIMARY KEY CLUSTERED ([TransferenciaProductoId] ASC),
    CONSTRAINT [FK_TransferenciaProducto_Producto] FOREIGN KEY ([ProductoId]) REFERENCES [dbo].[Producto] ([ProductoId]),
    CONSTRAINT [FK_TransferenciaProducto_Transferencia] FOREIGN KEY ([TransferenciaId]) REFERENCES [dbo].[Transferencia] ([TransferenciaId])
);


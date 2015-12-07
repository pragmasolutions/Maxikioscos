CREATE TABLE [dbo].[RetiroPersonalProducto] (
    [RetiroPersonalProductoId] INT              IDENTITY (1, 1) NOT NULL,
    [Identifier]               UNIQUEIDENTIFIER NOT NULL,
    [RetiroPersonalId]         INT              NOT NULL,
    [ProductoId]               INT              NOT NULL,
    [Costo]                    MONEY            NOT NULL,
    [Precio]                   MONEY            NULL,
    [Cantidad]                 DECIMAL (18, 2)  NOT NULL,
    [FechaUltimaModificacion]  DATETIME2 (7)    NULL,
    [Eliminado]                BIT              NOT NULL,
    [Desincronizado]           BIT              NOT NULL,
    [AdicionalPorExcepcion]    MONEY            NULL,
    CONSTRAINT [PK_RetiroPersonalProducto] PRIMARY KEY CLUSTERED ([RetiroPersonalProductoId] ASC),
    CONSTRAINT [FK_RetiroPersonalProducto_Producto] FOREIGN KEY ([ProductoId]) REFERENCES [dbo].[Producto] ([ProductoId]),
    CONSTRAINT [FK_RetiroPersonalProducto_RetiroPersonal] FOREIGN KEY ([RetiroPersonalId]) REFERENCES [dbo].[RetiroPersonal] ([RetiroPersonalId])
);


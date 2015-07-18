CREATE TABLE [dbo].[StockTransaccion] (
    [StockTransaccionId]      INT              IDENTITY (1, 1) NOT NULL,
    [StockId]                 INT              NOT NULL,
    [Identifier]              UNIQUEIDENTIFIER NOT NULL,
    [Desincronizado]          BIT              NOT NULL,
    [FechaUltimaModificacion] DATETIME2 (7)    NULL,
    [Eliminado]               BIT              NOT NULL,
    [Cantidad]                DECIMAL (18, 2)  NOT NULL,
    [StockTransaccionTipoId]  INT              NOT NULL,
    CONSTRAINT [PK_StockTransaccion] PRIMARY KEY CLUSTERED ([StockTransaccionId] ASC),
    CONSTRAINT [FK_StockTransaccion_Stock] FOREIGN KEY ([StockId]) REFERENCES [dbo].[Stock] ([StockId]),
    CONSTRAINT [FK_StockTransaccion_StockTransaccionTipo] FOREIGN KEY ([StockTransaccionTipoId]) REFERENCES [dbo].[StockTransaccionTipo] ([StockTransaccionTipoId])
);


CREATE TABLE [dbo].[ControlStockDetalle] (
    [ControlStockDetalleId]   INT              IDENTITY (1, 1) NOT NULL,
    [ControlStockId]          INT              NOT NULL,
    [StockId]                 INT              NOT NULL,
    [Cantidad]                DECIMAL (18, 2)  NOT NULL,
    [FechaUltimaModificacion] DATETIME         NULL,
    [Desincronizado]          BIT              NOT NULL,
    [Eliminado]               BIT              NOT NULL,
    [Identifier]              UNIQUEIDENTIFIER NOT NULL,
    [Correccion]              DECIMAL (18, 2)  NULL,
    [Precio]                  MONEY            NULL,
    [MotivoCorreccionId]      INT              NULL,
    [HabilitadoParaCorregir]  BIT              NOT NULL,
    [ControlStockPrevioId]    INT              NULL,
    CONSTRAINT [PK_ControlStockDetalle] PRIMARY KEY CLUSTERED ([ControlStockDetalleId] ASC),
    CONSTRAINT [FK_ControlStockDetalle_ControlStock] FOREIGN KEY ([ControlStockId]) REFERENCES [dbo].[ControlStock] ([ControlStockId]),
    CONSTRAINT [FK_ControlStockDetalle_ControlStockPrevio] FOREIGN KEY ([ControlStockPrevioId]) REFERENCES [dbo].[ControlStock] ([ControlStockId]),
    CONSTRAINT [FK_ControlStockDetalle_MotivoCorreccion] FOREIGN KEY ([MotivoCorreccionId]) REFERENCES [dbo].[MotivoCorreccion] ([MotivoCorreccionId]),
    CONSTRAINT [FK_ControlStockDetalle_Stock] FOREIGN KEY ([StockId]) REFERENCES [dbo].[Stock] ([StockId])
);


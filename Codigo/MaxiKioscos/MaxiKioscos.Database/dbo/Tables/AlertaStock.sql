CREATE TABLE [dbo].[AlertaStock] (
    [AlertStockId]   INT             IDENTITY (1, 1) NOT NULL,
    [StockId]        INT             NOT NULL,
    [CantidadActual] DECIMAL (18, 2) NOT NULL,
    [Fecha]          DATETIME2 (7)   NOT NULL,
    [Marcada]        BIT             NOT NULL,
    CONSTRAINT [PK_AlertaStock] PRIMARY KEY CLUSTERED ([AlertStockId] ASC),
    CONSTRAINT [FK_AlertaStock_Stock] FOREIGN KEY ([StockId]) REFERENCES [dbo].[Stock] ([StockId])
);


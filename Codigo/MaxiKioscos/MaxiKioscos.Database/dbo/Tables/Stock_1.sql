CREATE TABLE [dbo].[Stock] (
    [StockId]                 INT              IDENTITY (1, 1) NOT NULL,
    [ProductoId]              INT              NOT NULL,
    [MaxiKioscoId]            INT              NOT NULL,
    [Identifier]              UNIQUEIDENTIFIER NOT NULL,
    [StockActual]             DECIMAL (18, 2)  NOT NULL,
    [Desincronizado]          BIT              NOT NULL,
    [FechaUltimaModificacion] DATETIME2 (7)    NULL,
    [Eliminado]               BIT              NOT NULL,
    [OperacionCreacion]       VARCHAR (1000)   NULL,
    [FechaCreacion]           DATETIME         NULL,
    CONSTRAINT [PK_ProductoMaxiKiosco] PRIMARY KEY CLUSTERED ([StockId] ASC),
    CONSTRAINT [FK_ProductoMaxiKiosco_MaxiKiosco] FOREIGN KEY ([MaxiKioscoId]) REFERENCES [dbo].[MaxiKiosco] ([MaxiKioscoId]),
    CONSTRAINT [FK_ProductoMaxiKiosco_Producto] FOREIGN KEY ([ProductoId]) REFERENCES [dbo].[Producto] ([ProductoId])
);


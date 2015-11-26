CREATE TABLE [dbo].[CorreccionStock] (
    [CorreccionStockId]       INT              IDENTITY (1, 1) NOT NULL,
    [ProductoId]              INT              NOT NULL,
    [Cantidad]                DECIMAL (18, 2)  NOT NULL,
    [Precio]                  MONEY            NOT NULL,
    [Desincronizado]          BIT              NOT NULL,
    [FechaUltimaModificacion] DATETIME2 (7)    NULL,
    [Identifier]              UNIQUEIDENTIFIER NOT NULL,
    [MotivoCorreccionId]      INT              NOT NULL,
    [Fecha]                   DATETIME         NOT NULL,
    [MaxiKioscoId]            INT              NOT NULL,
    [Eliminado]               BIT              DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_CorreccionStock] PRIMARY KEY CLUSTERED ([CorreccionStockId] ASC),
    CONSTRAINT [FK_CorreccionStock_MaxiKiosco] FOREIGN KEY ([MaxiKioscoId]) REFERENCES [dbo].[MaxiKiosco] ([MaxiKioscoId]),
    CONSTRAINT [FK_CorreccionStock_MotivoCorreccion] FOREIGN KEY ([MotivoCorreccionId]) REFERENCES [dbo].[MotivoCorreccion] ([MotivoCorreccionId]),
    CONSTRAINT [FK_CorreccionStock_Producto] FOREIGN KEY ([ProductoId]) REFERENCES [dbo].[Producto] ([ProductoId])
);


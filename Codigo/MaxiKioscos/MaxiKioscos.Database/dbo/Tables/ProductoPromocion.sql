CREATE TABLE [dbo].[ProductoPromocion] (
    [ProductoPromocionId]     INT              IDENTITY (1, 1) NOT NULL,
    [PadreId]                 INT              NOT NULL,
    [HijoId]                  INT              NOT NULL,
    [Unidades]                INT              NOT NULL,
    [Identifier]              UNIQUEIDENTIFIER NOT NULL,
    [Desincronizado]          BIT              NOT NULL,
    [FechaUltimaModificacion] DATETIME2 (7)    NULL,
    [Eliminado]               BIT              NOT NULL,
    CONSTRAINT [PK_ProductoPromocion] PRIMARY KEY CLUSTERED ([ProductoPromocionId] ASC),
    CONSTRAINT [FK_ProductoPromocion_ProductoHijo] FOREIGN KEY ([HijoId]) REFERENCES [dbo].[Producto] ([ProductoId]),
    CONSTRAINT [FK_ProductoPromocion_ProductoPadre] FOREIGN KEY ([PadreId]) REFERENCES [dbo].[Producto] ([ProductoId])
);


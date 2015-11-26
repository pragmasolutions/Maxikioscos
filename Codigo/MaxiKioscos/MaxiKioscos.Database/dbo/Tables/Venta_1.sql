CREATE TABLE [dbo].[Venta] (
    [VentaId]                 INT              IDENTITY (1, 1) NOT NULL,
    [Identifier]              UNIQUEIDENTIFIER NOT NULL,
    [CierreCajaId]            INT              NOT NULL,
    [CostoTotal]              MONEY            NOT NULL,
    [ImporteTotal]            MONEY            NOT NULL,
    [FechaVenta]              DATETIME         NOT NULL,
    [Eliminado]               BIT              NOT NULL,
    [Desincronizado]          BIT              NOT NULL,
    [FechaUltimaModificacion] DATETIME2 (7)    NULL,
    CONSTRAINT [PK_Venta] PRIMARY KEY CLUSTERED ([VentaId] ASC),
    CONSTRAINT [FK_Venta_CierreCaja] FOREIGN KEY ([CierreCajaId]) REFERENCES [dbo].[CierreCaja] ([CierreCajaId])
);


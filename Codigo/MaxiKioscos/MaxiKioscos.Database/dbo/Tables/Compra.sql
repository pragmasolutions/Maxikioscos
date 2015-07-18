CREATE TABLE [dbo].[Compra] (
    [CompraId]                INT              IDENTITY (1, 1) NOT NULL,
    [Identifier]              UNIQUEIDENTIFIER NOT NULL,
    [Fecha]                   DATETIME2 (7)    NOT NULL,
    [Numero]                  VARCHAR (25)     NOT NULL,
    [FacturaId]               INT              NOT NULL,
    [CuentaId]                INT              NOT NULL,
    [Desincronizado]          BIT              NOT NULL,
    [FechaUltimaModificacion] DATETIME2 (7)    NULL,
    [Eliminado]               BIT              NOT NULL,
    [MaxiKioscoId]            INT              NOT NULL,
    [PercepcionIVA]           MONEY            NOT NULL,
    [PercepcionDGR]           MONEY            NOT NULL,
    [ImporteFactura]          MONEY            NOT NULL,
    [TotalCompra]             MONEY            NOT NULL,
    [Descuento]               MONEY            NOT NULL,
    [ImporteFinal]            MONEY            NOT NULL,
    CONSTRAINT [PK_Compra] PRIMARY KEY CLUSTERED ([CompraId] ASC),
    CONSTRAINT [FK_Compra_Cuenta] FOREIGN KEY ([CuentaId]) REFERENCES [dbo].[Cuenta] ([CuentaId]),
    CONSTRAINT [FK_Compra_Factura] FOREIGN KEY ([FacturaId]) REFERENCES [dbo].[Factura] ([FacturaId]),
    CONSTRAINT [FK_Compra_MaxiKiosco] FOREIGN KEY ([MaxiKioscoId]) REFERENCES [dbo].[MaxiKiosco] ([MaxiKioscoId])
);


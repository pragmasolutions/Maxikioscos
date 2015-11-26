CREATE TABLE [dbo].[Producto] (
    [ProductoId]                INT              IDENTITY (1, 1) NOT NULL,
    [Identifier]                UNIQUEIDENTIFIER NOT NULL,
    [RubroId]                   INT              NOT NULL,
    [MarcaId]                   INT              NULL,
    [Descripcion]               VARCHAR (300)    NOT NULL,
    [StockReposicion]           INT              NULL,
    [Desincronizado]            BIT              NOT NULL,
    [FechaUltimaModificacion]   DATETIME2 (7)    NULL,
    [Eliminado]                 BIT              NOT NULL,
    [CuentaId]                  INT              NOT NULL,
    [AceptaCantidadesDecimales] BIT              NOT NULL,
    [PrecioConIVA]              MONEY            NOT NULL,
    [PrecioSinIVA]              MONEY            NOT NULL,
    [EsPromocion]               BIT              NOT NULL,
    [DisponibleEnDeposito]      BIT              DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_Producto] PRIMARY KEY CLUSTERED ([ProductoId] ASC),
    CONSTRAINT [FK_Producto_Cuenta] FOREIGN KEY ([CuentaId]) REFERENCES [dbo].[Cuenta] ([CuentaId]),
    CONSTRAINT [FK_Producto_Marca] FOREIGN KEY ([MarcaId]) REFERENCES [dbo].[Marca] ([MarcaId]),
    CONSTRAINT [FK_Producto_Rubro] FOREIGN KEY ([RubroId]) REFERENCES [dbo].[Rubro] ([RubroId])
);


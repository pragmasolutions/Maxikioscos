CREATE TABLE [dbo].[Factura] (
    [FacturaId]               INT              IDENTITY (1, 1) NOT NULL,
    [Identifier]              UNIQUEIDENTIFIER NOT NULL,
    [ProveedorId]             INT              NOT NULL,
    [FacturaNro]              VARCHAR (15)     NOT NULL,
    [ImporteTotal]            MONEY            NOT NULL,
    [Fecha]                   DATETIME2 (7)    NOT NULL,
    [MaxiKioscoId]            INT              NOT NULL,
    [Desincronizado]          BIT              NOT NULL,
    [FechaUltimaModificacion] DATETIME2 (7)    NULL,
    [Eliminado]               BIT              NOT NULL,
    [CierreCajaId]            INT              NULL,
    [Usuario]                 INT              NULL,
    [AutoNumero]              VARCHAR (20)     NULL,
    [FechaCreacion]           DATETIME         NOT NULL,
    CONSTRAINT [PK_Factura] PRIMARY KEY CLUSTERED ([FacturaId] ASC),
    CONSTRAINT [FK_Factura_CierreCaja] FOREIGN KEY ([CierreCajaId]) REFERENCES [dbo].[CierreCaja] ([CierreCajaId]),
    CONSTRAINT [FK_Factura_MaxiKiosco] FOREIGN KEY ([MaxiKioscoId]) REFERENCES [dbo].[MaxiKiosco] ([MaxiKioscoId]),
    CONSTRAINT [FK_Factura_Proveedor] FOREIGN KEY ([ProveedorId]) REFERENCES [dbo].[Proveedor] ([ProveedorId]),
    CONSTRAINT [FK_Factura_Usuario] FOREIGN KEY ([Usuario]) REFERENCES [dbo].[Usuario] ([UsuarioId])
);


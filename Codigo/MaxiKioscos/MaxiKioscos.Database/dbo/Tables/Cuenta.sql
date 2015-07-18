CREATE TABLE [dbo].[Cuenta] (
    [CuentaId]                          INT              IDENTITY (1, 1) NOT NULL,
    [Titular]                           VARCHAR (150)    NOT NULL,
    [Identifier]                        UNIQUEIDENTIFIER NOT NULL,
    [FechaUltimaModificacion]           DATETIME2 (7)    NULL,
    [Eliminado]                         BIT              NOT NULL,
    [MargenImporteFactura]              MONEY            NULL,
    [Desincronizado]                    BIT              NOT NULL,
    [AplicarPercepcionIVADesde]         MONEY            NULL,
    [PorcentajePercepcionIVA]           DECIMAL (5, 2)   NULL,
    [MotivoCorreccionPorDefecto]        INT              NOT NULL,
    [MargenInferiorCierreCajaAceptable] MONEY            NOT NULL,
    [MargenSuperiorCierreCajaAceptable] MONEY            NOT NULL,
    CONSTRAINT [PK_Cuenta] PRIMARY KEY CLUSTERED ([CuentaId] ASC),
    CONSTRAINT [FK_Cuenta_MotivoCorreccion] FOREIGN KEY ([MotivoCorreccionPorDefecto]) REFERENCES [dbo].[MotivoCorreccion] ([MotivoCorreccionId])
);


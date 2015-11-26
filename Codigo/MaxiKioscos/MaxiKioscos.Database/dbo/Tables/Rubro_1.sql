CREATE TABLE [dbo].[Rubro] (
    [RubroId]                 INT              IDENTITY (1, 1) NOT NULL,
    [Identifier]              UNIQUEIDENTIFIER NOT NULL,
    [Descripcion]             VARCHAR (100)    NOT NULL,
    [Desincronizado]          BIT              NOT NULL,
    [FechaUltimaModificacion] DATETIME2 (7)    NULL,
    [Eliminado]               BIT              NOT NULL,
    [CuentaId]                INT              NOT NULL,
    [NoFacturar]              BIT              NOT NULL,
    CONSTRAINT [PK_Rubro] PRIMARY KEY CLUSTERED ([RubroId] ASC),
    CONSTRAINT [FK_Rubro_Cuenta] FOREIGN KEY ([CuentaId]) REFERENCES [dbo].[Cuenta] ([CuentaId])
);


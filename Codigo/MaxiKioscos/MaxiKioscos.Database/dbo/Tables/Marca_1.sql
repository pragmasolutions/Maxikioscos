CREATE TABLE [dbo].[Marca] (
    [MarcaId]                 INT              IDENTITY (1, 1) NOT NULL,
    [Identifier]              UNIQUEIDENTIFIER NOT NULL,
    [Descripcion]             VARCHAR (200)    NOT NULL,
    [Desincronizado]          BIT              NOT NULL,
    [FechaUltimaModificacion] DATETIME2 (7)    NULL,
    [Eliminado]               BIT              NOT NULL,
    [CuentaId]                INT              NOT NULL,
    CONSTRAINT [PK_Marca] PRIMARY KEY CLUSTERED ([MarcaId] ASC),
    CONSTRAINT [FK_Marca_Cuenta] FOREIGN KEY ([CuentaId]) REFERENCES [dbo].[Cuenta] ([CuentaId])
);


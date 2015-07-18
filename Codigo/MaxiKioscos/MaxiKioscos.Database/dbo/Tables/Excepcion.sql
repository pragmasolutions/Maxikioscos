CREATE TABLE [dbo].[Excepcion] (
    [ExcepcionId]             INT              IDENTITY (1, 1) NOT NULL,
    [Identifier]              UNIQUEIDENTIFIER NOT NULL,
    [CierreCajaId]            INT              NOT NULL,
    [Importe]                 MONEY            NOT NULL,
    [Descripcion]             VARCHAR (2000)   NOT NULL,
    [FechaCarga]              DATETIME2 (7)    NOT NULL,
    [Desincronizado]          BIT              NOT NULL,
    [FechaUltimaModificacion] DATETIME2 (7)    NULL,
    [Eliminado]               BIT              NOT NULL,
    CONSTRAINT [PK_Excepcion] PRIMARY KEY CLUSTERED ([ExcepcionId] ASC),
    CONSTRAINT [FK_Excepcion_CierreCaja] FOREIGN KEY ([CierreCajaId]) REFERENCES [dbo].[CierreCaja] ([CierreCajaId])
);


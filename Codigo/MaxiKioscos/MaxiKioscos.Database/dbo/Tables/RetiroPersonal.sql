CREATE TABLE [dbo].[RetiroPersonal] (
    [RetiroPersonalId]        INT              IDENTITY (1, 1) NOT NULL,
    [Identifier]              UNIQUEIDENTIFIER NOT NULL,
    [CierreCajaId]            INT              NOT NULL,
    [CostoTotal]              MONEY            NOT NULL,
    [ImporteTotal]            MONEY            NOT NULL,
    [FechaRetiroPersonal]     DATETIME         NOT NULL,
    [Eliminado]               BIT              NOT NULL,
    [Desincronizado]          BIT              NOT NULL,
    [FechaUltimaModificacion] DATETIME2 (7)    NULL,
    CONSTRAINT [PK_RetiroPersonal] PRIMARY KEY CLUSTERED ([RetiroPersonalId] ASC),
    CONSTRAINT [FK_RetiroPersonal_CierreCaja] FOREIGN KEY ([CierreCajaId]) REFERENCES [dbo].[CierreCaja] ([CierreCajaId])
);


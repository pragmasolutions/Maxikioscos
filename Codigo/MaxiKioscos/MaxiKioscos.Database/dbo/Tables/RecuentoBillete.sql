CREATE TABLE [dbo].[RecuentoBillete] (
    [RecuentoBilleteId]       INT              IDENTITY (1, 1) NOT NULL,
    [CierreCajaId]            INT              NOT NULL,
    [BilleteId]               INT              NOT NULL,
    [Cantidad]                INT              NOT NULL,
    [Identifier]              UNIQUEIDENTIFIER NOT NULL,
    [Desincronizado]          BIT              NOT NULL,
    [FechaUltimaModificacion] DATETIME2 (7)    NULL,
    [Eliminado]               BIT              NOT NULL,
    CONSTRAINT [PK_RecuentoBillete] PRIMARY KEY CLUSTERED ([RecuentoBilleteId] ASC),
    CONSTRAINT [FK_RecuentoBillete_Billete] FOREIGN KEY ([BilleteId]) REFERENCES [dbo].[Billete] ([BilleteId]),
    CONSTRAINT [FK_RecuentoBillete_CierreCaja] FOREIGN KEY ([CierreCajaId]) REFERENCES [dbo].[CierreCaja] ([CierreCajaId])
);


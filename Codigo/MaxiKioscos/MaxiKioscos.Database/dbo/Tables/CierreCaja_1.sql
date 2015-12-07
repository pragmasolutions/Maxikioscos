CREATE TABLE [dbo].[CierreCaja] (
    [CierreCajaId]            INT              IDENTITY (1, 1) NOT NULL,
    [Identifier]              UNIQUEIDENTIFIER NOT NULL,
    [FechaInicio]             DATETIME2 (7)    NOT NULL,
    [FechaFin]                DATETIME2 (7)    NULL,
    [CajaInicial]             MONEY            NOT NULL,
    [CajaFinal]               MONEY            NULL,
    [CajaEsperada]            MONEY            NULL,
    [UsuarioId]               INT              NOT NULL,
    [MaxiKioskoId]            INT              NOT NULL,
    [Desincronizado]          BIT              NOT NULL,
    [FechaUltimaModificacion] DATETIME2 (7)    NULL,
    [Eliminado]               BIT              NOT NULL,
    [Diferencia]              AS               ([CajaFinal]-[CajaEsperada]),
    CONSTRAINT [PK_CierreCaja] PRIMARY KEY CLUSTERED ([CierreCajaId] ASC),
    CONSTRAINT [FK_CierreCaja_MaxiKiosco] FOREIGN KEY ([MaxiKioskoId]) REFERENCES [dbo].[MaxiKiosco] ([MaxiKioscoId]),
    CONSTRAINT [FK_CierreCaja_Usuario] FOREIGN KEY ([UsuarioId]) REFERENCES [dbo].[Usuario] ([UsuarioId])
);


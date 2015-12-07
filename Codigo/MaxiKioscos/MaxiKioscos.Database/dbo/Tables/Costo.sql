CREATE TABLE [dbo].[Costo] (
    [CostoId]                 INT              IDENTITY (1, 1) NOT NULL,
    [CierreCajaId]            INT              NULL,
    [CategoriaCostoId]        INT              NOT NULL,
    [Observaciones]           VARCHAR (5000)   NULL,
    [NroComprobante]          VARCHAR (50)     NULL,
    [Monto]                   MONEY            NOT NULL,
    [Fecha]                   DATETIME         NOT NULL,
    [Aprobado]                BIT              NOT NULL,
    [Identifier]              UNIQUEIDENTIFIER NOT NULL,
    [Desincronizado]          BIT              NOT NULL,
    [Eliminado]               BIT              NOT NULL,
    [FechaUltimaModificacion] DATETIME2 (7)    NULL,
    [UsuarioId]               INT              NULL,
    [TurnoId]                 INT              NULL,
    [MaxikioscoId]            INT              NULL,
    CONSTRAINT [PK_Costo] PRIMARY KEY CLUSTERED ([CostoId] ASC),
    CONSTRAINT [FK_Costo_CategoriaCosto] FOREIGN KEY ([CategoriaCostoId]) REFERENCES [dbo].[CategoriaCosto] ([CategoriaCostoId]),
    CONSTRAINT [FK_Costo_CierreCaja] FOREIGN KEY ([CierreCajaId]) REFERENCES [dbo].[CierreCaja] ([CierreCajaId]),
    CONSTRAINT [FK_Costo_Maxikiosco] FOREIGN KEY ([MaxikioscoId]) REFERENCES [dbo].[MaxiKiosco] ([MaxiKioscoId]),
    CONSTRAINT [FK_Costo_Turno] FOREIGN KEY ([TurnoId]) REFERENCES [dbo].[Turno] ([TurnoId]),
    CONSTRAINT [FK_Costo_Usuario] FOREIGN KEY ([UsuarioId]) REFERENCES [dbo].[Usuario] ([UsuarioId])
);


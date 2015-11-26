CREATE TABLE [dbo].[MaxiKioscoTurno] (
    [MaxiKioscoTurnoId]          INT              IDENTITY (1, 1) NOT NULL,
    [MaxiKioscoId]               INT              NOT NULL,
    [TurnoId]                    INT              NOT NULL,
    [MontoMaximoVentaConTickets] MONEY            NULL,
    [Eliminado]                  BIT              NOT NULL,
    [Desincronizado]             BIT              NOT NULL,
    [FechaUltimaModificacion]    DATETIME2 (7)    NULL,
    [Identifier]                 UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [PK_MaxiKioscoTurno] PRIMARY KEY CLUSTERED ([MaxiKioscoTurnoId] ASC),
    CONSTRAINT [FK_MaxiKioscoTurno_MaxiKiosco] FOREIGN KEY ([MaxiKioscoId]) REFERENCES [dbo].[MaxiKiosco] ([MaxiKioscoId]),
    CONSTRAINT [FK_MaxiKioscoTurno_Turno] FOREIGN KEY ([TurnoId]) REFERENCES [dbo].[Turno] ([TurnoId])
);


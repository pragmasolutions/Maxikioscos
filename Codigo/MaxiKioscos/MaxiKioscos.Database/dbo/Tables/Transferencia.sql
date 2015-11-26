CREATE TABLE [dbo].[Transferencia] (
    [TransferenciaId]         INT              IDENTITY (1, 1) NOT NULL,
    [FechaCreacion]           DATETIME         NOT NULL,
    [OrigenId]                INT              NOT NULL,
    [DestinoId]               INT              NOT NULL,
    [UsuarioId]               INT              NOT NULL,
    [FechaAprobacion]         DATETIME         NULL,
    [Desincronizado]          BIT              NOT NULL,
    [FechaUltimaModificacion] DATETIME2 (7)    NULL,
    [Identifier]              UNIQUEIDENTIFIER NOT NULL,
    [Eliminado]               BIT              NOT NULL,
    [AutoNumero]              VARCHAR (20)     NOT NULL,
    CONSTRAINT [PK_Transferencia] PRIMARY KEY CLUSTERED ([TransferenciaId] ASC),
    CONSTRAINT [FK_Transferencia_Destino] FOREIGN KEY ([DestinoId]) REFERENCES [dbo].[MaxiKiosco] ([MaxiKioscoId]),
    CONSTRAINT [FK_Transferencia_Origen] FOREIGN KEY ([OrigenId]) REFERENCES [dbo].[MaxiKiosco] ([MaxiKioscoId]),
    CONSTRAINT [FK_Transferencia_Usuario] FOREIGN KEY ([UsuarioId]) REFERENCES [dbo].[Usuario] ([UsuarioId])
);


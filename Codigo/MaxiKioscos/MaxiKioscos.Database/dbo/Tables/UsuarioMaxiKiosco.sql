CREATE TABLE [dbo].[UsuarioMaxiKiosco] (
    [UsuarioMaxiKioscoId]     INT              IDENTITY (1, 1) NOT NULL,
    [UsuarioId]               INT              NOT NULL,
    [MaxiKioscoId]            INT              NOT NULL,
    [Desincronizado]          BIT              NOT NULL,
    [Eliminado]               BIT              NOT NULL,
    [FechaUltimaModificacion] DATETIME2 (7)    NULL,
    [Identifier]              UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [PK_UsuarioMaxiKiosco] PRIMARY KEY CLUSTERED ([UsuarioMaxiKioscoId] ASC),
    CONSTRAINT [FK_UsuarioMaxiKiosco_MaxiKiosco] FOREIGN KEY ([MaxiKioscoId]) REFERENCES [dbo].[MaxiKiosco] ([MaxiKioscoId]),
    CONSTRAINT [FK_UsuarioMaxiKiosco_Usuario] FOREIGN KEY ([UsuarioId]) REFERENCES [dbo].[Usuario] ([UsuarioId])
);


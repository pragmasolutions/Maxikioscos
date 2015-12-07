CREATE TABLE [dbo].[OperacionCaja] (
    [OperacionCajaId]             INT              IDENTITY (1, 1) NOT NULL,
    [Monto]                       MONEY            NOT NULL,
    [Fecha]                       DATETIME2 (7)    NOT NULL,
    [CierreCajaId]                INT              NOT NULL,
    [FechaUltimaModificacion]     DATETIME2 (7)    NULL,
    [Eliminado]                   BIT              NOT NULL,
    [MotivoId]                    INT              NULL,
    [Observaciones]               VARCHAR (MAX)    NULL,
    [Desincronizado]              BIT              NOT NULL,
    [UsuarioCreadorId]            INT              NOT NULL,
    [UltimoUsuarioModificacionId] INT              NULL,
    [Identifier]                  UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [PK_OperacionCaja] PRIMARY KEY CLUSTERED ([OperacionCajaId] ASC),
    CONSTRAINT [FK_OperacionCaja_CierreCaja] FOREIGN KEY ([CierreCajaId]) REFERENCES [dbo].[CierreCaja] ([CierreCajaId]),
    CONSTRAINT [FK_OperacionCaja_MotivoOperacionCaja] FOREIGN KEY ([MotivoId]) REFERENCES [dbo].[MotivoOperacionCaja] ([MotivoOperacionCajaId]),
    CONSTRAINT [FK_OperacionCaja_UsuarioCreador] FOREIGN KEY ([UsuarioCreadorId]) REFERENCES [dbo].[Usuario] ([UsuarioId]),
    CONSTRAINT [FK_OperacionCaja_UsuarioModificador] FOREIGN KEY ([UltimoUsuarioModificacionId]) REFERENCES [dbo].[Usuario] ([UsuarioId])
);


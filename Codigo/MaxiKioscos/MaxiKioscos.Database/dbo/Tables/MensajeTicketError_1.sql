CREATE TABLE [dbo].[MensajeTicketError] (
    [MensajeTicketErrorId] INT           IDENTITY (1, 1) NOT NULL,
    [TicketErrorId]        INT           NOT NULL,
    [Texto]                VARCHAR (MAX) NOT NULL,
    [Fecha]                DATETIME      NOT NULL,
    [UsuarioId]            INT           NOT NULL,
    [EsDeAdmin]            BIT           NOT NULL,
    CONSTRAINT [PK_MensajeTicketError] PRIMARY KEY CLUSTERED ([MensajeTicketErrorId] ASC),
    CONSTRAINT [FK_MensajeTicketError_TicketError] FOREIGN KEY ([TicketErrorId]) REFERENCES [dbo].[TicketError] ([TicketErrorId]),
    CONSTRAINT [FK_MensajeTicketError_Usuario] FOREIGN KEY ([UsuarioId]) REFERENCES [dbo].[Usuario] ([UsuarioId])
);


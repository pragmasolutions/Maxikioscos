CREATE TABLE [dbo].[TicketError] (
    [TicketErrorId]   INT            IDENTITY (1, 1) NOT NULL,
    [Fecha]           DATETIME       NOT NULL,
    [UsuarioId]       INT            NOT NULL,
    [Origen]          INT            NOT NULL,
    [Mensaje]         VARCHAR (MAX)  NOT NULL,
    [EstadoTicketId]  INT            NOT NULL,
    [FechaEnProgreso] DATETIME       NULL,
    [FechaCierre]     DATETIME       NULL,
    [Email]           VARCHAR (100)  NOT NULL,
    [Titulo]          VARCHAR (1000) NOT NULL,
    CONSTRAINT [PK_TicketErrorID] PRIMARY KEY CLUSTERED ([TicketErrorId] ASC),
    CONSTRAINT [FK_TicketError_EstadoTicket] FOREIGN KEY ([EstadoTicketId]) REFERENCES [dbo].[EstadoTicket] ([EstadoTicketId]),
    CONSTRAINT [FK_TicketError_Usuario] FOREIGN KEY ([UsuarioId]) REFERENCES [dbo].[Usuario] ([UsuarioId])
);


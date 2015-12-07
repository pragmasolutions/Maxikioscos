CREATE TABLE [dbo].[EstadoTicket] (
    [EstadoTicketId] INT          NOT NULL,
    [Descripcion]    VARCHAR (50) NOT NULL,
    CONSTRAINT [PK_EstadoTicket] PRIMARY KEY CLUSTERED ([EstadoTicketId] ASC)
);


/****** Object:  Table [dbo].[EstadoTicket]    Script Date: 09/13/2014 18:19:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[EstadoTicket](
	[EstadoTicketId] [int] NOT NULL,
	[Descripcion] [varchar](50) NOT NULL,
 CONSTRAINT [PK_EstadoTicket] PRIMARY KEY CLUSTERED 
(
	[EstadoTicketId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[EstadoTicket] ([EstadoTicketId], [Descripcion]) VALUES (1, N'Pendiente')
INSERT [dbo].[EstadoTicket] ([EstadoTicketId], [Descripcion]) VALUES (2, N'En Progreso')
INSERT [dbo].[EstadoTicket] ([EstadoTicketId], [Descripcion]) VALUES (3, N'Cerrado')
INSERT [dbo].[EstadoTicket] ([EstadoTicketId], [Descripcion]) VALUES (4, N'Eliminado')
/****** Object:  Table [dbo].[TicketError]    Script Date: 09/13/2014 18:19:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TicketError](
	[TicketErrorId] [int] IDENTITY(1,1) NOT NULL,
	[Fecha] [datetime] NOT NULL,
	[UsuarioId] [int] NOT NULL,
	[Origen] [int] NOT NULL,
	[Mensaje] [varchar](max) NOT NULL,
	[EstadoTicketId] [int] NOT NULL,
	[FechaEnProgreso] [datetime] NULL,
	[FechaCierre] [datetime] NULL,
	[Email] [varchar](100) NOT NULL,
	[Titulo] [varchar](1000) NOT NULL,
 CONSTRAINT [PK_TicketErrorID] PRIMARY KEY CLUSTERED 
(
	[TicketErrorId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO

/****** Object:  Table [dbo].[MensajeTicketError]    Script Date: 09/13/2014 18:19:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[MensajeTicketError](
	[MensajeTicketErrorId] [int] IDENTITY(1,1) NOT NULL,
	[TicketErrorId] [int] NOT NULL,
	[Texto] [varchar](max) NOT NULL,
	[Fecha] [datetime] NOT NULL,
	[UsuarioId] [int] NOT NULL,
	[EsDeAdmin] [bit] NOT NULL,
 CONSTRAINT [PK_MensajeTicketError] PRIMARY KEY CLUSTERED 
(
	[MensajeTicketErrorId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  ForeignKey [FK_MensajeTicketError_TicketError]    Script Date: 09/13/2014 18:19:18 ******/
ALTER TABLE [dbo].[MensajeTicketError]  WITH CHECK ADD  CONSTRAINT [FK_MensajeTicketError_TicketError] FOREIGN KEY([TicketErrorId])
REFERENCES [dbo].[TicketError] ([TicketErrorId])
GO
ALTER TABLE [dbo].[MensajeTicketError] CHECK CONSTRAINT [FK_MensajeTicketError_TicketError]
GO
/****** Object:  ForeignKey [FK_MensajeTicketError_Usuario]    Script Date: 09/13/2014 18:19:18 ******/
ALTER TABLE [dbo].[MensajeTicketError]  WITH CHECK ADD  CONSTRAINT [FK_MensajeTicketError_Usuario] FOREIGN KEY([UsuarioId])
REFERENCES [dbo].[Usuario] ([UsuarioId])
GO
ALTER TABLE [dbo].[MensajeTicketError] CHECK CONSTRAINT [FK_MensajeTicketError_Usuario]
GO
/****** Object:  ForeignKey [FK_TicketError_EstadoTicket]    Script Date: 09/13/2014 18:19:18 ******/
ALTER TABLE [dbo].[TicketError]  WITH CHECK ADD  CONSTRAINT [FK_TicketError_EstadoTicket] FOREIGN KEY([EstadoTicketId])
REFERENCES [dbo].[EstadoTicket] ([EstadoTicketId])
GO
ALTER TABLE [dbo].[TicketError] CHECK CONSTRAINT [FK_TicketError_EstadoTicket]
GO
/****** Object:  ForeignKey [FK_TicketError_Usuario]    Script Date: 09/13/2014 18:19:18 ******/
ALTER TABLE [dbo].[TicketError]  WITH CHECK ADD  CONSTRAINT [FK_TicketError_Usuario] FOREIGN KEY([UsuarioId])
REFERENCES [dbo].[Usuario] ([UsuarioId])
GO
ALTER TABLE [dbo].[TicketError] CHECK CONSTRAINT [FK_TicketError_Usuario]
GO

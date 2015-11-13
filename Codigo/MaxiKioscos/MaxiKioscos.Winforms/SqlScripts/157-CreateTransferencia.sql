CREATE TABLE [dbo].[Transferencia](
	[TransferenciaId] [int] IDENTITY(1,1) NOT NULL,
	[FechaCreacion] [datetime] NOT NULL,
	[OrigenId] [int] NOT NULL,
	[DestinoId] [int] NOT NULL,
	[UsuarioId] [int] NOT NULL,
	[FechaAprobacion] [datetime] NULL,
	[AutoNumero] [varchar(20)] NULL,
	[Desincronizado] [bit] NOT NULL,
	[FechaUltimaModificacion] [datetime2](7) NULL,
	[Identifier] [uniqueidentifier] NOT NULL,
	[Eliminado] [bit] NOT NULL,
 CONSTRAINT [PK_Transferencia] PRIMARY KEY CLUSTERED 
(
	[TransferenciaId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]


ALTER TABLE [dbo].[Transferencia]  WITH CHECK ADD  CONSTRAINT [FK_Transferencia_Destino] FOREIGN KEY([DestinoId])
REFERENCES [dbo].[MaxiKiosco] ([MaxiKioscoId])

ALTER TABLE [dbo].[Transferencia] CHECK CONSTRAINT [FK_Transferencia_Destino]

ALTER TABLE [dbo].[Transferencia]  WITH CHECK ADD  CONSTRAINT [FK_Transferencia_Origen] FOREIGN KEY([OrigenId])
REFERENCES [dbo].[MaxiKiosco] ([MaxiKioscoId])

ALTER TABLE [dbo].[Transferencia] CHECK CONSTRAINT [FK_Transferencia_Origen]

ALTER TABLE [dbo].[Transferencia]  WITH CHECK ADD  CONSTRAINT [FK_Transferencia_Usuario] FOREIGN KEY([UsuarioId])
REFERENCES [dbo].[Usuario] ([UsuarioId])

ALTER TABLE [dbo].[Transferencia] CHECK CONSTRAINT [FK_Transferencia_Usuario]



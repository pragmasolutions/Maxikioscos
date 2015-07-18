
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Transferencia_Destino]') AND parent_object_id = OBJECT_ID(N'[dbo].[Transferencia]'))
ALTER TABLE [dbo].[Transferencia] DROP CONSTRAINT [FK_Transferencia_Destino]
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Transferencia_Origen]') AND parent_object_id = OBJECT_ID(N'[dbo].[Transferencia]'))
ALTER TABLE [dbo].[Transferencia] DROP CONSTRAINT [FK_Transferencia_Origen]
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Transferencia_Usuario]') AND parent_object_id = OBJECT_ID(N'[dbo].[Transferencia]'))
ALTER TABLE [dbo].[Transferencia] DROP CONSTRAINT [FK_Transferencia_Usuario]
GO


/****** Object:  Table [dbo].[Transferencia]    Script Date: 04/17/2015 10:26:48 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Transferencia]') AND type in (N'U'))
DROP TABLE [dbo].[Transferencia]
GO


CREATE TABLE [dbo].[Transferencia](
	[TransferenciaId] [int] IDENTITY(1,1) NOT NULL,
	[FechaCreacion] [datetime] NOT NULL,
	[OrigenId] [int] NOT NULL,
	[DestinoId] [int] NOT NULL,
	[UsuarioId] [int] NOT NULL,
	[FechaAprobacion] [datetime] NULL,
	[Desincronizado] [bit] NOT NULL,
	[FechaUltimaModificacion] [datetime2](7) NULL,
	[Identifier] [uniqueidentifier] NOT NULL,
	[Eliminado] [bit] NOT NULL,
 CONSTRAINT [PK_Transferencia] PRIMARY KEY CLUSTERED 
(
	[TransferenciaId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[Transferencia]  WITH CHECK ADD  CONSTRAINT [FK_Transferencia_Destino] FOREIGN KEY([DestinoId])
REFERENCES [dbo].[MaxiKiosco] ([MaxiKioscoId])
GO

ALTER TABLE [dbo].[Transferencia] CHECK CONSTRAINT [FK_Transferencia_Destino]
GO

ALTER TABLE [dbo].[Transferencia]  WITH CHECK ADD  CONSTRAINT [FK_Transferencia_Origen] FOREIGN KEY([OrigenId])
REFERENCES [dbo].[MaxiKiosco] ([MaxiKioscoId])
GO

ALTER TABLE [dbo].[Transferencia] CHECK CONSTRAINT [FK_Transferencia_Origen]
GO

ALTER TABLE [dbo].[Transferencia]  WITH CHECK ADD  CONSTRAINT [FK_Transferencia_Usuario] FOREIGN KEY([UsuarioId])
REFERENCES [dbo].[Usuario] ([UsuarioId])
GO

ALTER TABLE [dbo].[Transferencia] CHECK CONSTRAINT [FK_Transferencia_Usuario]
GO



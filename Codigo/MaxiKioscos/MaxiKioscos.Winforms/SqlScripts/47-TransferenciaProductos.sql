IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_TransferenciaProducto_Producto]') AND parent_object_id = OBJECT_ID(N'[dbo].[TransferenciaProducto]'))
ALTER TABLE [dbo].[TransferenciaProducto] DROP CONSTRAINT [FK_TransferenciaProducto_Producto]

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_TransferenciaProducto_Transferencia]') AND parent_object_id = OBJECT_ID(N'[dbo].[TransferenciaProducto]'))
ALTER TABLE [dbo].[TransferenciaProducto] DROP CONSTRAINT [FK_TransferenciaProducto_Transferencia]


/****** Object:  Table [dbo].[TransferenciaProducto]    Script Date: 04/22/2015 19:58:47 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TransferenciaProducto]') AND type in (N'U'))
DROP TABLE [dbo].[TransferenciaProducto]


CREATE TABLE [dbo].[TransferenciaProducto](
	[TransferenciaProductoId] [int] IDENTITY(1,1) NOT NULL,
	[TransferenciaId] [int] NOT NULL,
	[ProductoId] [int] NOT NULL,
	[Cantidad] [int] NOT NULL,
	[PrecioVenta] [money] NOT NULL,
	[Desincronizado] [bit] NOT NULL,
	[FechaUltimaModificacion] [datetime2](7) NULL,
	[Identifier] [uniqueidentifier] NOT NULL,
	[Eliminado] [bit] NOT NULL,
 CONSTRAINT [PK_TransferenciaProducto] PRIMARY KEY CLUSTERED 
(
	[TransferenciaProductoId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]


ALTER TABLE [dbo].[TransferenciaProducto]  WITH CHECK ADD  CONSTRAINT [FK_TransferenciaProducto_Producto] FOREIGN KEY([ProductoId])
REFERENCES [dbo].[Producto] ([ProductoId])

ALTER TABLE [dbo].[TransferenciaProducto] CHECK CONSTRAINT [FK_TransferenciaProducto_Producto]

ALTER TABLE [dbo].[TransferenciaProducto]  WITH CHECK ADD  CONSTRAINT [FK_TransferenciaProducto_Transferencia] FOREIGN KEY([TransferenciaId])
REFERENCES [dbo].[Transferencia] ([TransferenciaId])

ALTER TABLE [dbo].[TransferenciaProducto] CHECK CONSTRAINT [FK_TransferenciaProducto_Transferencia]




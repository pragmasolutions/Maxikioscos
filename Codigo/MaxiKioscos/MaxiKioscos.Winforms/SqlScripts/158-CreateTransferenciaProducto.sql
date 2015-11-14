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
	[StockOrigen] [decimal](18, 2) NULL,
	[StockDestino] [decimal](18, 2) NOT NULL,
	[Orden] [int] NOT NULL,
	[Costo] [money] NOT NULL,
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

ALTER TABLE [dbo].[TransferenciaProducto] ADD  DEFAULT ((1)) FOR [Orden]

ALTER TABLE [dbo].[TransferenciaProducto] ADD  DEFAULT ((0)) FOR [Costo]




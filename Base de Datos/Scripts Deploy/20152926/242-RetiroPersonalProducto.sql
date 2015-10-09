CREATE TABLE [dbo].[RetiroPersonalProducto](
	[RetiroPersonalProductoId] [int] IDENTITY(1,1) NOT NULL,
	[Identifier] [uniqueidentifier] NOT NULL,
	[RetiroPersonalId] [int] NOT NULL,
	[ProductoId] [int] NOT NULL,
	[Costo] [money] NOT NULL,
	[Precio] [money] NULL,
	[Cantidad] [decimal](18, 2) NOT NULL,
	[FechaUltimaModificacion] [datetime2](7) NULL,
	[Eliminado] [bit] NOT NULL,
	[Desincronizado] [bit] NOT NULL,
	[AdicionalPorExcepcion] [money] NULL,
 CONSTRAINT [PK_RetiroPersonalProducto] PRIMARY KEY CLUSTERED 
(
	[RetiroPersonalProductoId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]


ALTER TABLE [dbo].[RetiroPersonalProducto]  WITH CHECK ADD  CONSTRAINT [FK_RetiroPersonalProducto_Producto] FOREIGN KEY([ProductoId])
REFERENCES [dbo].[Producto] ([ProductoId])


ALTER TABLE [dbo].[RetiroPersonalProducto] CHECK CONSTRAINT [FK_RetiroPersonalProducto_Producto]

ALTER TABLE [dbo].[RetiroPersonalProducto]  WITH CHECK ADD  CONSTRAINT [FK_RetiroPersonalProducto_RetiroPersonal] FOREIGN KEY([RetiroPersonalId])
REFERENCES [dbo].[RetiroPersonal] ([RetiroPersonalId])


ALTER TABLE [dbo].[RetiroPersonalProducto] CHECK CONSTRAINT [FK_RetiroPersonalProducto_RetiroPersonal]



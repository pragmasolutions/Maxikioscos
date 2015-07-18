CREATE TABLE [dbo].[ProductoPromocion](
	[ProductoPromocionId] [int] IDENTITY(1,1) NOT NULL,
	[PadreId] [int] NOT NULL,
	[HijoId] [int] NOT NULL,
	[Unidades] [int] NOT NULL,
	[Identifier] [uniqueidentifier] NOT NULL,
	[Desincronizado] [bit] NOT NULL,
	[FechaUltimaModificacion] [datetime2](7) NULL,
	[Eliminado] [bit] NOT NULL,
 CONSTRAINT [PK_ProductoPromocion] PRIMARY KEY CLUSTERED 
(
	[ProductoPromocionId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

ALTER TABLE [dbo].[ProductoPromocion]  WITH CHECK ADD  CONSTRAINT [FK_ProductoPromocion_ProductoHijo] FOREIGN KEY([HijoId])
REFERENCES [dbo].[Producto] ([ProductoId])

ALTER TABLE [dbo].[ProductoPromocion] CHECK CONSTRAINT [FK_ProductoPromocion_ProductoHijo]

ALTER TABLE [dbo].[ProductoPromocion]  WITH CHECK ADD  CONSTRAINT [FK_ProductoPromocion_ProductoPadre] FOREIGN KEY([PadreId])
REFERENCES [dbo].[Producto] ([ProductoId])

ALTER TABLE [dbo].[ProductoPromocion] CHECK CONSTRAINT [FK_ProductoPromocion_ProductoPadre]

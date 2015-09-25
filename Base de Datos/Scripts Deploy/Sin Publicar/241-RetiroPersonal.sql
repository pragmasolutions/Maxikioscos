
CREATE TABLE [dbo].[RetiroPersonal](
	[RetiroPersonalId] [int] IDENTITY(1,1) NOT NULL,
	[Identifier] [uniqueidentifier] NOT NULL,
	[CierreCajaId] [int] NOT NULL,
	[CostoTotal] [money] NOT NULL,
	[ImporteTotal] [money] NOT NULL,
	[FechaRetiroPersonal] [datetime] NOT NULL,
	[Eliminado] [bit] NOT NULL,
	[Desincronizado] [bit] NOT NULL,
	[FechaUltimaModificacion] [datetime2](7) NULL,
 CONSTRAINT [PK_RetiroPersonal] PRIMARY KEY CLUSTERED 
(
	[RetiroPersonalId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]


ALTER TABLE [dbo].[RetiroPersonal]  WITH CHECK ADD  CONSTRAINT [FK_RetiroPersonal_CierreCaja] FOREIGN KEY([CierreCajaId])
REFERENCES [dbo].[CierreCaja] ([CierreCajaId])
GO

ALTER TABLE [dbo].[RetiroPersonal] CHECK CONSTRAINT [FK_RetiroPersonal_CierreCaja]
GO



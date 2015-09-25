ALTER TABLE dbo.Costo ADD CONSTRAINT
	PK_Costo PRIMARY KEY CLUSTERED 
	(
	CostoId
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]


ALTER TABLE [dbo].[Costo]  WITH CHECK ADD  CONSTRAINT [FK_Costo_CierreCaja] FOREIGN KEY([CierreCajaId])
REFERENCES [dbo].[CierreCaja] ([CierreCajaId])

ALTER TABLE [dbo].[Costo] CHECK CONSTRAINT [FK_Costo_CierreCaja]


ALTER TABLE [dbo].[Costo]  WITH CHECK ADD  CONSTRAINT [FK_Costo_CategoriaCosto] FOREIGN KEY([CategoriaCostoId])
REFERENCES [dbo].[CategoriaCosto] ([CategoriaCostoId])

ALTER TABLE [dbo].[Costo] CHECK CONSTRAINT [FK_Costo_CategoriaCosto]


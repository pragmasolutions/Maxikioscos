CREATE TABLE dbo.Costo
	(
	CostoId int NOT NULL IDENTITY (1, 1),
	CierreCajaId int NOT NULL,
	CategoriaCostoId int NOT NULL,
	Observaciones varchar(5000) NULL,
	NroComprobante varchar(50) NULL,
	Monto money NOT NULL,
	Fecha datetime NOT NULL,
	Aprobado bit NOT NULL,
	Identifier uniqueidentifier NOT NULL,
	Desincronizado bit NOT NULL,
	Eliminado bit NOT NULL,
	FechaUltimaModificacion datetime2(7) NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.Costo ADD CONSTRAINT
	PK_Costo PRIMARY KEY CLUSTERED 
	(
	CostoId
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO


ALTER TABLE [dbo].[Costo]  WITH CHECK ADD  CONSTRAINT [FK_Costo_CierreCaja] FOREIGN KEY([CierreCajaId])
REFERENCES [dbo].[CierreCaja] ([CierreCajaId])
GO

ALTER TABLE [dbo].[Costo] CHECK CONSTRAINT [FK_Costo_CierreCaja]
GO


ALTER TABLE [dbo].[Costo]  WITH CHECK ADD  CONSTRAINT [FK_Costo_CategoriaCosto] FOREIGN KEY([CategoriaCostoId])
REFERENCES [dbo].[CategoriaCosto] ([CategoriaCostoId])
GO

ALTER TABLE [dbo].[Costo] CHECK CONSTRAINT [FK_Costo_CategoriaCosto]
GO


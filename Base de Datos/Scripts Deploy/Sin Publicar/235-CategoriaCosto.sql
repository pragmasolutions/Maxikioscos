CREATE TABLE dbo.CategoriaCosto
	(
	CategoriaCostoId int NOT NULL IDENTITY (1, 1),
	Descripcion varchar(400) NOT NULL,
	MaximoBisemanal int NULL,
	Identifier uniqueidentifier NOT NULL,
	Desincronizado bit NOT NULL,
	Eliminado bit NOT NULL,
	FechaUltimaModificacion datetime2(7) NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.CategoriaCosto ADD CONSTRAINT
	PK_CategoriaCosto PRIMARY KEY CLUSTERED 
	(
	CategoriaCostoId
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO

ALTER TABLE dbo.CategoriaCosto SET (LOCK_ESCALATION = TABLE)
GO
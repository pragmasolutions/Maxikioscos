
ALTER TABLE dbo.CategoriaCosto ADD CONSTRAINT
	PK_CategoriaCosto PRIMARY KEY CLUSTERED 
	(
	CategoriaCostoId
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]


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

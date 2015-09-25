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
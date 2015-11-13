
CREATE TABLE dbo.ReporteStock
(
	ReporteStockId int NOT NULL IDENTITY (1, 1),
	Mes int NOT NULL,
	Anio int NOT NULL,
	FechaCreacion datetime NOT NULL,
	Valorizado varbinary(MAX) NOT NULL,
	ValorizadoGeneral varbinary(MAX) NOT NULL,
	ValorizadoDetallado varbinary(MAX) NOT NULL,
	ValorizadoDetalladoGeneral varbinary(MAX) NOT NULL
)  ON [PRIMARY]
 TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE dbo.ReporteStock ADD CONSTRAINT
	PK_ReporteStock PRIMARY KEY CLUSTERED 
	(
	ReporteStockId
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.ReporteStock SET (LOCK_ESCALATION = TABLE)
GO
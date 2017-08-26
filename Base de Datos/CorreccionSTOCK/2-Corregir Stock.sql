DECLARE @MaxiKioscoId int = 10

--Creo tabla temporal
CREATE TABLE [dbo].[StockTransaccion2](
	[StockTransaccionId] [int] IDENTITY(1,1) NOT NULL,
	[StockId] [int] NOT NULL,
	[Identifier] [uniqueidentifier] NOT NULL,
	[Desincronizado] [bit] NOT NULL,
	[FechaUltimaModificacion] [datetime2](7) NULL,
	[Eliminado] [bit] NOT NULL,
	[Cantidad] [decimal](18, 2) NOT NULL,
	[StockTransaccionTipoId] [int] NOT NULL,
 CONSTRAINT [PK_StockTransaccion2] PRIMARY KEY CLUSTERED 
(
	[StockTransaccionId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

--Copio stock a tabla temporal
INSERT INTO [StockTransaccion2]
           ([StockId]
           ,[Identifier]
           ,[Desincronizado]
           ,[FechaUltimaModificacion]
           ,[Eliminado]
           ,[Cantidad]
           ,[StockTransaccionTipoId])
SELECT S.StockId,
 	S.Identifier,
 	0,
 	NULL,
 	0,
	ISNULL((SELECT SUM(ST.Cantidad)
			FROM StockTransaccion ST
				LEFT JOIN Stock S ON ST.StockId = S.StockId
				WHERE S.ProductoId = P.ProductoId
					AND S.MaxiKioscoId = @MaxiKioscoId
					AND S.Eliminado = 0
					AND ST.Eliminado = 0
			), 0),
	1
FROM Producto P
	INNER JOIN Stock S
		ON P.ProductoId = S.ProductoId
			AND S.MaxiKioscoId = @MaxiKioscoId
WHERE P.Eliminado = 0
GO

--Borro el stock de la table original
DELETE FROM StockTransaccion
WHERE StockId IN (SELECT StockId
				FROM Stock
				WHERE MaxiKioscoId = @MaxiKioscoId)
GO

--Creo el stock para la tabla original
INSERT INTO [StockTransaccion]
           ([StockId]
           ,[Identifier]
           ,[Desincronizado]
           ,[FechaUltimaModificacion]
           ,[Eliminado]
           ,[Cantidad]
           ,[StockTransaccionTipoId])
SELECT [StockId]
           ,[Identifier]
           ,[Desincronizado]
           ,[FechaUltimaModificacion]
           ,[Eliminado]
           ,[Cantidad]
           ,[StockTransaccionTipoId]
FROM StockTransaccion2
GO

DROP TABLE StockTransaccion2
GO
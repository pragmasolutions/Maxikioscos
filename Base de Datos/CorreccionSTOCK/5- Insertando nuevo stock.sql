

INSERT INTO [SQL5010.SMARTERASP.NET].[DB_9B2582_MaxiKioscos].[dbo].[Stock]
           ([ProductoId]
           ,[MaxiKioscoId]
           ,[Identifier]
           ,[StockActual]
           ,[Desincronizado]
           ,[FechaUltimaModificacion]
           ,[Eliminado]
           ,[OperacionCreacion]
           ,[FechaCreacion])
SELECT P2.[ProductoId]
           ,12
           ,S.[Identifier]
           ,S.[StockActual]
           ,0
           ,S.FechaUltimaModificacion
           ,S.Eliminado
           ,S.OperacionCreacion
           ,S.FechaCreacion
FROM Stock S
	INNER JOIN Producto P ON S.ProductoId = P.ProductoId
	INNER JOIN [SQL5010.SMARTERASP.NET].[DB_9B2582_MaxiKioscos].[dbo].[Producto] P2
		ON P.Identifier = P2.Identifier
WHERE S.MaxiKioscoId = 12
GO



INSERT INTO [SQL5010.SMARTERASP.NET].[DB_9B2582_MaxiKioscos].[dbo].[StockTransaccion]
           ([StockId]
           ,[Identifier]
           ,[Desincronizado]
           ,[FechaUltimaModificacion]
           ,[Eliminado]
           ,[Cantidad]
           ,[StockTransaccionTipoId])
SELECT S2.StockId
           ,ST.[Identifier]
           ,0
           ,ST.FechaUltimaModificacion
           ,ST.[Eliminado]
           ,ST.[Cantidad]
           ,ST.[StockTransaccionTipoId]
FROM StockTransaccion ST
	INNER JOIN Stock S
		ON ST.StockId = S.StockId
	INNER JOIN [SQL5010.SMARTERASP.NET].[DB_9B2582_MaxiKioscos].[dbo].[Stock] S2
		ON S.Identifier = S2.Identifier
WHERE S.MaxiKioscoId = 12
GO


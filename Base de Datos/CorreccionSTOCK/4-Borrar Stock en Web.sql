DECLARE @MaxiKioscoId int = 10

DELETE FROM StockTransaccion
WHERE StockId IN (SELECT StockId
				FROM Stock
				WHERE MaxiKioscoId = @MaxiKioscoId)


DELETE FROM ControlStockDetalle
WHERE StockId IN (SELECT StockId
				FROM Stock
				WHERE MaxiKioscoId = @MaxiKioscoId)



DELETE FROM ControlStock
WHERE MaxiKioscoId = @MaxiKioscoId

DELETE FROM Stock
WHERE MaxiKioscoId = @MaxiKioscoId

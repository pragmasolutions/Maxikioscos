IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name = 'IX_StockTransaccion_Eliminado_Cantidad' AND object_id = OBJECT_ID('StockTransaccion'))
BEGIN
    CREATE NONCLUSTERED INDEX [IX_StockTransaccion_Eliminado_Cantidad]
	ON [dbo].[StockTransaccion] ([StockId])
	INCLUDE ([Eliminado],[Cantidad])
END
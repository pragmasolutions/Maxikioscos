CREATE NONCLUSTERED INDEX [IX_VentaProducto_ProdId]
ON [dbo].[VentaProducto] ([ProductoId])
INCLUDE ([VentaId],[Cantidad])
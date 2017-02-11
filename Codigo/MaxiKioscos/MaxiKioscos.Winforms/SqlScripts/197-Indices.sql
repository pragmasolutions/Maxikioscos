CREATE NONCLUSTERED INDEX IX_Factura_Eliminado
ON [dbo].[Factura] ([Eliminado])
INCLUDE ([ProveedorId],[ImporteTotal],[MaxiKioscoId],[CierreCajaId],[FechaCreacion])

CREATE NONCLUSTERED INDEX IX_CompraProducto_CompraId
ON [dbo].[CompraProducto] ([CompraId])
INCLUDE ([ProductoId],[CostoActualizado],[PrecioActualizado],[Cantidad])

CREATE NONCLUSTERED INDEX IX_Compra_TipoComprobante
ON [dbo].[Compra] ([TipoComprobante])
INCLUDE ([FacturaId])

CREATE NONCLUSTERED INDEX IX_Compra_FacturaId
ON [dbo].[Compra] ([FacturaId],[TipoComprobante])

CREATE NONCLUSTERED INDEX IX_Factura_ProveedorId
ON [dbo].[Factura] ([ProveedorId])
INCLUDE ([FacturaId],[ImporteTotal],[Fecha])

CREATE NONCLUSTERED INDEX IX_CodigoProducto_ProductoId
ON [dbo].[CodigoProducto] ([ProductoId])

CREATE NONCLUSTERED INDEX IX_ControlStockDetalle_ControlStockId
ON [dbo].[ControlStockDetalle] ([ControlStockId])
INCLUDE ([StockId],[Cantidad],[Correccion],[MotivoCorreccionId])

CREATE NONCLUSTERED INDEX IX_Factura_EliminadoCierreCajaId
ON [dbo].[Factura] ([Eliminado],[CierreCajaId])

CREATE NONCLUSTERED INDEX IX_Venta_CierreCajaIdEliminado
ON [dbo].[Venta] ([CierreCajaId],[Eliminado])
INCLUDE ([ImporteTotal])

CREATE NONCLUSTERED INDEX IX_CierreCaja_MaxiKioscoId
ON [dbo].[CierreCaja] ([MaxiKioskoId])
INCLUDE ([CierreCajaId],[FechaInicio],[FechaFin],[CajaFinal])

CREATE NONCLUSTERED INDEX IX_Producto_Identifier
ON [dbo].[Producto] ([Identifier])
INCLUDE ([ProductoId],[Desincronizado])

CREATE NONCLUSTERED INDEX IX_Producto_Identifier2
ON [dbo].[Producto] ([Identifier])


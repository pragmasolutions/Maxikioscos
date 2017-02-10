CREATE NONCLUSTERED INDEX IX_Venta_CierreCaja
ON [dbo].[Venta] ([CierreCajaId])
INCLUDE ([VentaId],[FechaVenta])

CREATE NONCLUSTERED INDEX IX_VentaProducto_VentaId
ON [dbo].[VentaProducto] ([VentaId])
INCLUDE ([ProductoId],[Costo],[Precio],[Cantidad])
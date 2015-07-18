ALTER TABLE ControlStockDetalle
ADD Correccion decimal(18,2) NULL
GO

ALTER TABLE ControlStockDetalle
ADD Precio money NULL
GO

ALTER TABLE ControlStockDetalle
ADD FechaCorreccion datetime NULL
GO

ALTER TABLE ControlStockDetalle
ADD MotivoCorreccionId int NULL
GO

ALTER TABLE [dbo].[ControlStockDetalle]  WITH CHECK ADD  CONSTRAINT [FK_ControlStockDetalle_MotivoCorreccion] FOREIGN KEY([MotivoCorreccionId])
REFERENCES [dbo].[MotivoCorreccion] ([MotivoCorreccionId])
GO

ALTER TABLE [dbo].[ControlStockDetalle] CHECK CONSTRAINT [FK_ControlStockDetalle_MotivoCorreccion]
GO


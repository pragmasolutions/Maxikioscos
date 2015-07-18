ALTER TABLE ControlStockDetalle
ADD ControlStockPrevioId int NULL
GO

ALTER TABLE [dbo].[ControlStockDetalle]  WITH CHECK ADD  CONSTRAINT [FK_ControlStockDetalle_ControlStockPrevio] FOREIGN KEY([ControlStockPrevioId])
REFERENCES [dbo].[ControlStock] ([ControlStockId])
GO

ALTER TABLE [dbo].[ControlStockDetalle] CHECK CONSTRAINT [FK_ControlStockDetalle_ControlStockPrevio]
GO


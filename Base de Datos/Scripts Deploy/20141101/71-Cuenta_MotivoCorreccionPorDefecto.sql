ALTER TABLE Cuenta
ADD MotivoCorreccionPorDefecto int NULL
GO

UPDATE Cuenta
SET MotivoCorreccionPorDefecto = 1
GO

ALTER TABLE Cuenta
ALTER COLUMN MotivoCorreccionPorDefecto int NOT NULL
GO



ALTER TABLE [dbo].[Cuenta]  WITH CHECK ADD  CONSTRAINT [FK_Cuenta_MotivoCorreccion] FOREIGN KEY([MotivoCorreccionPorDefecto])
REFERENCES [dbo].[MotivoCorreccion] ([MotivoCorreccionId])
GO

ALTER TABLE [dbo].[Cuenta] CHECK CONSTRAINT [FK_Cuenta_MotivoCorreccion]
GO


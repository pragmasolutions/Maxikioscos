
UPDATE Factura
SET Usuario = NULL
WHERE Usuario IS NOT NULL
	AND Usuario NOT IN (SELECT UsuarioId FROM Usuario)
GO


ALTER TABLE [dbo].[Factura]  WITH CHECK ADD  CONSTRAINT [FK_Factura_Usuario] FOREIGN KEY([Usuario])
REFERENCES [dbo].[Usuario] ([UsuarioId])
GO

ALTER TABLE [dbo].[Factura] CHECK CONSTRAINT [FK_Factura_Usuario]
GO



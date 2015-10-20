ALTER TABLE Costo
ALTER COLUMN CierreCajaId INT NULL


ALTER TABLE Costo
ADD UsuarioId INT NULL


ALTER TABLE [dbo].[Costo]  WITH CHECK ADD  CONSTRAINT [FK_Costo_Usuario] FOREIGN KEY([UsuarioId])
REFERENCES [dbo].[Usuario] ([UsuarioId])


ALTER TABLE [dbo].[Costo] CHECK CONSTRAINT [FK_Costo_Usuario]



ALTER TABLE Costo
ADD TurnoId INT NULL


ALTER TABLE [dbo].[Costo]  WITH CHECK ADD  CONSTRAINT [FK_Costo_Turno] FOREIGN KEY([TurnoId])
REFERENCES [dbo].[Turno] ([TurnoId])


ALTER TABLE [dbo].[Costo] CHECK CONSTRAINT [FK_Costo_Turno]



ALTER TABLE CategoriaCosto
ADD PadreId int NULL 

ALTER TABLE [dbo].[CategoriaCosto]  WITH CHECK ADD  CONSTRAINT [FK_CategoriaCosto_CategoriaCosto] FOREIGN KEY([PadreId])
REFERENCES [dbo].[CategoriaCosto] ([CategoriaCostoId])


ALTER TABLE [dbo].[CategoriaCosto] CHECK CONSTRAINT [FK_CategoriaCosto_CategoriaCosto]




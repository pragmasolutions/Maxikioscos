IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Transferencia_Destino]') AND parent_object_id = OBJECT_ID(N'[dbo].[Transferencia]'))
ALTER TABLE [dbo].[Transferencia] DROP CONSTRAINT [FK_Transferencia_Destino]

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Transferencia_Origen]') AND parent_object_id = OBJECT_ID(N'[dbo].[Transferencia]'))
ALTER TABLE [dbo].[Transferencia] DROP CONSTRAINT [FK_Transferencia_Origen]


IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Transferencia_Usuario]') AND parent_object_id = OBJECT_ID(N'[dbo].[Transferencia]'))
ALTER TABLE [dbo].[Transferencia] DROP CONSTRAINT [FK_Transferencia_Usuario]

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Transferencia]') AND type in (N'U'))
DROP TABLE [dbo].[Transferencia]
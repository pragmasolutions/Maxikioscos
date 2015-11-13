IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_TransferenciaProducto_Producto]') AND parent_object_id = OBJECT_ID(N'[dbo].[TransferenciaProducto]'))
ALTER TABLE [dbo].[TransferenciaProducto] DROP CONSTRAINT [FK_TransferenciaProducto_Producto]


IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_TransferenciaProducto_Transferencia]') AND parent_object_id = OBJECT_ID(N'[dbo].[TransferenciaProducto]'))
ALTER TABLE [dbo].[TransferenciaProducto] DROP CONSTRAINT [FK_TransferenciaProducto_Transferencia]


IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF__Transfere__Orden__2818EA29]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[TransferenciaProducto] DROP CONSTRAINT [DF__Transfere__Orden__2818EA29]


IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF__Transfere__Costo__290D0E62]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[TransferenciaProducto] DROP CONSTRAINT [DF__Transfere__Costo__290D0E62]
END

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TransferenciaProducto]') AND type in (N'U'))
DROP TABLE [dbo].[TransferenciaProducto]
END
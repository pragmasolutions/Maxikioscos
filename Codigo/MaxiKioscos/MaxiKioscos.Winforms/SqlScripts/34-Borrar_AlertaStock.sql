
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AlertaStock]') AND type in (N'U'))
DROP TABLE [dbo].[AlertaStock]


IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AlertaStock_Generar]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[AlertaStock_Generar]

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AlertaStock_MarcarTodas]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[AlertaStock_MarcarTodas]

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AlertaStock_Obtener]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[AlertaStock_Obtener]

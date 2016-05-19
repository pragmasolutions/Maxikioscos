
IF  EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[MaxiKiosco]') AND name = N'PK_MaxiKiosco')
ALTER TABLE [dbo].[MaxiKiosco] DROP CONSTRAINT [PK_MaxiKiosco]
GO


IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_MaxiKiosco_Cuenta]') AND parent_object_id = OBJECT_ID(N'[dbo].[MaxiKiosco]'))
ALTER TABLE [dbo].[MaxiKiosco] DROP CONSTRAINT [FK_MaxiKiosco_Cuenta]
GO

ALTER TABLE MaxiKiosco 
DROP COLUMN MaxiKioscoId
GO

ALTER TABLE MaxiKiosco 
DROP COLUMN Direccion
GO

ALTER TABLE MaxiKiosco 
DROP COLUMN Telefono
GO

ALTER TABLE MaxiKiosco 
DROP COLUMN EstaOnLine
GO

ALTER TABLE MaxiKiosco 
DROP COLUMN CuentaId
GO

ALTER TABLE MaxiKiosco 
DROP COLUMN Desincronizado
GO

ALTER TABLE MaxiKiosco 
DROP COLUMN FechaUltimaModificacion
GO

ALTER TABLE MaxiKiosco 
DROP COLUMN Asignado
GO


ALTER TABLE MaxiKiosco 
DROP COLUMN Abreviacion
GO

ALTER TABLE MaxiKiosco 
DROP COLUMN UltimoScriptCorrido
GO

ALTER TABLE MaxiKiosco 
DROP COLUMN UltimaConexion
GO

ALTER TABLE MaxiKiosco 
DROP COLUMN NombreMaquina
GO

EXEC sp_rename 'dbo.MaxiKiosco', 'SyncMaxiKiosco'
GO


ALTER TABLE [dbo].[SyncMaxiKiosco] ADD  CONSTRAINT [PK_MaxiKiosco] PRIMARY KEY CLUSTERED 
(
	[Identifier] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Exportacion_Cuenta]') AND parent_object_id = OBJECT_ID(N'[dbo].[Exportacion]'))
ALTER TABLE [dbo].[Exportacion] DROP CONSTRAINT [FK_Exportacion_Cuenta]
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Exportacion_Usuario]') AND parent_object_id = OBJECT_ID(N'[dbo].[Exportacion]'))
ALTER TABLE [dbo].[Exportacion] DROP CONSTRAINT [FK_Exportacion_Usuario]
GO


EXEC sp_rename 'dbo.Exportacion', 'SyncExportacion'
GO


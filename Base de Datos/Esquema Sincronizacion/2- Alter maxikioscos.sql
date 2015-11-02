/****** Object:  Index [PK_MaxiKiosco]    Script Date: 10/31/2015 17:15:59 ******/
IF  EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[MaxiKiosco]') AND name = N'PK_MaxiKiosco')
ALTER TABLE [dbo].[MaxiKiosco] DROP CONSTRAINT [PK_MaxiKiosco]
GO


ALTER TABLE [dbo].[MaxiKiosco] ADD  CONSTRAINT [PK_MaxiKiosco] PRIMARY KEY CLUSTERED 
(
	[Identifier] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
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
DROP COLUMN Eliminado
GO

ALTER TABLE MaxiKiosco
DROP COLUMN Asignado
GO

ALTER TABLE MaxiKiosco
DROP COLUMN Abreviacion
GO

ALTER TABLE MaxiKiosco
DROP COLUMN UltimaSincronizacionExitosa
GO

ALTER TABLE MaxiKiosco
DROP COLUMN UltimaConexion
GO


ALTER TABLE MaxiKiosco
DROP COLUMN UltimoScriptCorrido
GO

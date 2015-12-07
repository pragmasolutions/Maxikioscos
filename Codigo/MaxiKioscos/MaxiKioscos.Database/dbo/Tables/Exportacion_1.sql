CREATE TABLE [dbo].[Exportacion] (
    [ExportacionId]           INT           IDENTITY (1, 1) NOT NULL,
    [Secuencia]               INT           NOT NULL,
    [Fecha]                   DATETIME2 (7) NOT NULL,
    [CreadorId]               INT           NOT NULL,
    [Archivo]                 XML           NOT NULL,
    [CuentaId]                INT           NOT NULL,
    [Nombre]                  AS            (((('EXP-'+CONVERT([varchar],[Secuencia],0))+' (')+CONVERT([char](10),[Fecha],(120)))+')'),
    [Eliminado]               BIT           NOT NULL,
    [Desincronizado]          BIT           NOT NULL,
    [FechaUltimaModificacion] DATETIME2 (7) NULL,
    [Acusada]                 BIT           NOT NULL,
    CONSTRAINT [PK_Exportacion] PRIMARY KEY CLUSTERED ([ExportacionId] ASC),
    CONSTRAINT [FK_Exportacion_Cuenta] FOREIGN KEY ([CuentaId]) REFERENCES [dbo].[Cuenta] ([CuentaId]),
    CONSTRAINT [FK_Exportacion_Usuario] FOREIGN KEY ([CreadorId]) REFERENCES [dbo].[Usuario] ([UsuarioId])
);


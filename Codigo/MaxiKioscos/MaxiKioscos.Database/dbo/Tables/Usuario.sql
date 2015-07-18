CREATE TABLE [dbo].[Usuario] (
    [UsuarioId]               INT              IDENTITY (1, 1) NOT NULL,
    [NombreUsuario]           NVARCHAR (MAX)   NOT NULL,
    [CuentaId]                INT              NOT NULL,
    [Nombre]                  VARCHAR (50)     NOT NULL,
    [Apellido]                VARCHAR (50)     NOT NULL,
    [Identifier]              UNIQUEIDENTIFIER NOT NULL,
    [FechaUltimaModificacion] DATETIME2 (7)    NULL,
    [Eliminado]               BIT              NOT NULL,
    [Desincronizado]          BIT              NOT NULL,
    CONSTRAINT [PK__UserProf__1788CC4C4316F928] PRIMARY KEY CLUSTERED ([UsuarioId] ASC),
    CONSTRAINT [FK_Usuario_Cuenta] FOREIGN KEY ([CuentaId]) REFERENCES [dbo].[Cuenta] ([CuentaId])
);


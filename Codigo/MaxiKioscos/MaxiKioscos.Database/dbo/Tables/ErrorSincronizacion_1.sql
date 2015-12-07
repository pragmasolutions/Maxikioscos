CREATE TABLE [dbo].[ErrorSincronizacion] (
    [ErrorSincronizacionId] INT             IDENTITY (1, 1) NOT NULL,
    [Numero]                INT             NOT NULL,
    [Mensaje]               NVARCHAR (4000) NOT NULL,
    CONSTRAINT [PK_ErrorSincronizacion] PRIMARY KEY CLUSTERED ([ErrorSincronizacionId] ASC)
);


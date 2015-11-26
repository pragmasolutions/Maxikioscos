CREATE TABLE [dbo].[TipoCuit] (
    [TipoCuitId]              INT           NOT NULL,
    [Descripcion]             VARCHAR (150) NOT NULL,
    [FechaUltimaModificacion] DATETIME2 (7) NULL,
    [Eliminado]               BIT           NOT NULL,
    [Desincronizado]          BIT           NOT NULL,
    CONSTRAINT [PK_TipoCuit] PRIMARY KEY CLUSTERED ([TipoCuitId] ASC)
);


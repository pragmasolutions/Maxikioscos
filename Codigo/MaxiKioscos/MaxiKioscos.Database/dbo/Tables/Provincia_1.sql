CREATE TABLE [dbo].[Provincia] (
    [ProvinciaId]             INT           IDENTITY (1, 1) NOT NULL,
    [Descripcion]             VARCHAR (200) NOT NULL,
    [FechaUltimaModificacion] DATETIME2 (7) NULL,
    [Eliminado]               BIT           NOT NULL,
    [Desincronizado]          BIT           NOT NULL,
    CONSTRAINT [PK_Provincia] PRIMARY KEY CLUSTERED ([ProvinciaId] ASC)
);


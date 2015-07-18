CREATE TABLE [dbo].[Localidad] (
    [LocalidadId]             INT           IDENTITY (1, 1) NOT NULL,
    [Descripcion]             VARCHAR (200) NOT NULL,
    [ProvinciaId]             INT           NOT NULL,
    [CodigoPostal]            VARCHAR (10)  NOT NULL,
    [FechaUltimaModificacion] DATETIME2 (7) NULL,
    [Eliminado]               BIT           NOT NULL,
    [Desincronizado]          BIT           NOT NULL,
    CONSTRAINT [PK_Localidad] PRIMARY KEY CLUSTERED ([LocalidadId] ASC),
    CONSTRAINT [FK_Localidad_Provincia] FOREIGN KEY ([ProvinciaId]) REFERENCES [dbo].[Provincia] ([ProvinciaId])
);


CREATE TABLE [dbo].[CategoriaCosto] (
    [CategoriaCostoId]        INT              IDENTITY (1, 1) NOT NULL,
    [Descripcion]             VARCHAR (400)    NOT NULL,
    [Identifier]              UNIQUEIDENTIFIER NOT NULL,
    [Desincronizado]          BIT              NOT NULL,
    [Eliminado]               BIT              NOT NULL,
    [FechaUltimaModificacion] DATETIME2 (7)    NULL,
    [OcultarEnDesktop]        BIT              DEFAULT ((0)) NOT NULL,
    [PadreId]                 INT              NULL,
    CONSTRAINT [PK_CategoriaCosto] PRIMARY KEY CLUSTERED ([CategoriaCostoId] ASC),
    CONSTRAINT [FK_CategoriaCosto_CategoriaCosto] FOREIGN KEY ([PadreId]) REFERENCES [dbo].[CategoriaCosto] ([CategoriaCostoId])
);


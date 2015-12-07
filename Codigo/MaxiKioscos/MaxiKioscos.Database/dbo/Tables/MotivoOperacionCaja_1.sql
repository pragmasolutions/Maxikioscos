CREATE TABLE [dbo].[MotivoOperacionCaja] (
    [MotivoOperacionCajaId]   INT           NOT NULL,
    [Descripcion]             VARCHAR (200) NOT NULL,
    [FechaUltimaModificacion] DATETIME2 (7) NULL,
    [Eliminado]               BIT           NOT NULL,
    [Desincronizado]          BIT           NOT NULL,
    [SumarACierreCaja]        BIT           NOT NULL,
    CONSTRAINT [PK_MotivoOperacionCaja] PRIMARY KEY CLUSTERED ([MotivoOperacionCajaId] ASC)
);


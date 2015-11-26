CREATE TABLE [dbo].[ExcepcionRubro] (
    [ExcepcionRubroId]        INT              IDENTITY (1, 1) NOT NULL,
    [Identifier]              UNIQUEIDENTIFIER NOT NULL,
    [RubroId]                 INT              NOT NULL,
    [Desde]                   TIME (7)         NOT NULL,
    [Hasta]                   TIME (7)         NOT NULL,
    [RecargoAbsoluto]         MONEY            NULL,
    [RecargoPorcentaje]       DECIMAL (18, 2)  NULL,
    [FechaUltimaModificacion] DATETIME2 (7)    NULL,
    [Eliminado]               BIT              NOT NULL,
    [Desincronizado]          BIT              NOT NULL,
    [MaxiKioscoId]            INT              NOT NULL,
    CONSTRAINT [PK_ExcepcionRubro] PRIMARY KEY CLUSTERED ([ExcepcionRubroId] ASC),
    CONSTRAINT [FK_ExcepcionRubro_MaxiKiosco] FOREIGN KEY ([MaxiKioscoId]) REFERENCES [dbo].[MaxiKiosco] ([MaxiKioscoId]),
    CONSTRAINT [FK_ExcepcionRubro_Rubro] FOREIGN KEY ([RubroId]) REFERENCES [dbo].[Rubro] ([RubroId])
);


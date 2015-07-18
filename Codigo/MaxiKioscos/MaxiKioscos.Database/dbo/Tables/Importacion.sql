CREATE TABLE [dbo].[Importacion] (
    [ImportacionID] INT           IDENTITY (1, 1) NOT NULL,
    [Fecha]         DATETIME2 (7) NOT NULL,
    [MaxiKioscoID]  INT           NOT NULL,
    [Nombre]        VARCHAR (300) NOT NULL,
    [Secuencia]     INT           NOT NULL,
    CONSTRAINT [PK_Importacion] PRIMARY KEY CLUSTERED ([ImportacionID] ASC),
    CONSTRAINT [FK_Importacion_MaxiKiosco] FOREIGN KEY ([MaxiKioscoID]) REFERENCES [dbo].[MaxiKiosco] ([MaxiKioscoId])
);


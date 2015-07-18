CREATE TABLE [dbo].[MotivoCorreccion] (
    [MotivoCorreccionId] INT           NOT NULL,
    [Descripcion]        VARCHAR (300) NOT NULL,
    [SumarAStock]        BIT           DEFAULT ('False') NOT NULL,
    [MostrarEnDropdown]  BIT           NOT NULL,
    CONSTRAINT [PK_MotivoCorreccion] PRIMARY KEY CLUSTERED ([MotivoCorreccionId] ASC)
);


CREATE TABLE [dbo].[Reporte] (
    [ReporteId]      INT           IDENTITY (1, 1) NOT NULL,
    [NombreCompleto] VARCHAR (250) NOT NULL,
    [Nombre]         VARCHAR (250) NOT NULL,
    [Padre]          VARCHAR (100) NOT NULL,
    [Path]           VARCHAR (400) NOT NULL,
    CONSTRAINT [PK_Reporte] PRIMARY KEY CLUSTERED ([ReporteId] ASC)
);


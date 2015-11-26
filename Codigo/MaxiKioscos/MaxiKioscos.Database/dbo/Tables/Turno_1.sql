CREATE TABLE [dbo].[Turno] (
    [TurnoId]     INT          IDENTITY (1, 1) NOT NULL,
    [Descripcion] VARCHAR (50) NOT NULL,
    [Desde]       TIME (0)     NOT NULL,
    [Hasta]       TIME (0)     NOT NULL,
    [HoraMedia]   TIME (0)     NOT NULL,
    CONSTRAINT [PK_Turno] PRIMARY KEY CLUSTERED ([TurnoId] ASC)
);


CREATE TABLE [dbo].[ReporteStock] (
    [ReporteStockId]             INT             IDENTITY (1, 1) NOT NULL,
    [Mes]                        INT             NOT NULL,
    [Anio]                       INT             NOT NULL,
    [FechaCreacion]              DATETIME        NOT NULL,
    [Valorizado]                 VARBINARY (MAX) NOT NULL,
    [ValorizadoGeneral]          VARBINARY (MAX) NOT NULL,
    [ValorizadoDetallado]        VARBINARY (MAX) NOT NULL,
    [ValorizadoDetalladoGeneral] VARBINARY (MAX) NOT NULL,
    CONSTRAINT [PK_ReporteStock] PRIMARY KEY CLUSTERED ([ReporteStockId] ASC)
);


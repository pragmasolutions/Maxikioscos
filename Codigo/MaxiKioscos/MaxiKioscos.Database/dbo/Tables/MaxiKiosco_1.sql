CREATE TABLE [dbo].[MaxiKiosco] (
    [MaxiKioscoId]                INT              IDENTITY (1, 1) NOT NULL,
    [Identifier]                  UNIQUEIDENTIFIER NOT NULL,
    [Nombre]                      VARCHAR (100)    NOT NULL,
    [Direccion]                   VARCHAR (200)    NOT NULL,
    [Telefono]                    VARCHAR (20)     NULL,
    [EstaOnLine]                  BIT              NOT NULL,
    [CuentaId]                    INT              NOT NULL,
    [Desincronizado]              BIT              NOT NULL,
    [FechaUltimaModificacion]     DATETIME2 (7)    NULL,
    [Eliminado]                   BIT              NOT NULL,
    [UltimaSecuenciaExportacion]  INT              NULL,
    [UltimaSecuenciaAcusada]      INT              NULL,
    [Asignado]                    BIT              NOT NULL,
    [Abreviacion]                 VARCHAR (4)      NOT NULL,
    [UltimoScriptCorrido]         INT              NULL,
    [UltimaSincronizacionExitosa] DATETIME         NULL,
    [UltimaConexion]              DATETIME         NULL,
    CONSTRAINT [PK_MaxiKiosco] PRIMARY KEY CLUSTERED ([MaxiKioscoId] ASC),
    CONSTRAINT [FK_MaxiKiosco_Cuenta] FOREIGN KEY ([CuentaId]) REFERENCES [dbo].[Cuenta] ([CuentaId])
);


﻿CREATE TABLE [dbo].[Proveedor] (
    [ProveedorId]             INT              IDENTITY (1, 1) NOT NULL,
    [Identifier]              UNIQUEIDENTIFIER NOT NULL,
    [Nombre]                  VARCHAR (100)    NOT NULL,
    [Contacto]                VARCHAR (100)    NULL,
    [Direccion]               VARCHAR (200)    NULL,
    [LocalidadId]             INT              NULL,
    [Telefono]                VARCHAR (16)     NULL,
    [Celular]                 VARCHAR (18)     NULL,
    [TipoCuitId]              INT              NULL,
    [CuitNro]                 VARCHAR (14)     NULL,
    [Email]                   VARCHAR (200)    NULL,
    [PaginaWeb]               VARCHAR (200)    NULL,
    [Observaciones]           VARCHAR (MAX)    NULL,
    [Desincronizado]          BIT              NOT NULL,
    [FechaUltimaModificacion] DATETIME2 (7)    NULL,
    [Eliminado]               BIT              NOT NULL,
    [CuentaId]                INT              NOT NULL,
    [PercepcionDGR]           DECIMAL (5, 2)   NULL,
    [AplicaPercepcionIVA]     BIT              NOT NULL,
    [NoReflejarFacturaEnCaja] BIT              DEFAULT ((0)) NOT NULL,
    [TipoComprobante]         VARCHAR (3)      NULL,
    CONSTRAINT [PK_Proveedor] PRIMARY KEY CLUSTERED ([ProveedorId] ASC),
    CONSTRAINT [FK_Proveedor_Cuenta] FOREIGN KEY ([CuentaId]) REFERENCES [dbo].[Cuenta] ([CuentaId]),
    CONSTRAINT [FK_Proveedor_Localidad] FOREIGN KEY ([LocalidadId]) REFERENCES [dbo].[Localidad] ([LocalidadId]),
    CONSTRAINT [FK_Proveedor_TipoCuit] FOREIGN KEY ([TipoCuitId]) REFERENCES [dbo].[TipoCuit] ([TipoCuitId])
);


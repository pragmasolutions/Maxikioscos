CREATE TABLE [dbo].[ControlStock] (
    [ControlStockId]          INT              IDENTITY (1, 1) NOT NULL,
    [FechaCreacion]           DATETIME         NOT NULL,
    [ProveedorId]             INT              NULL,
    [RubroId]                 INT              NULL,
    [MaxiKioscoId]            INT              NOT NULL,
    [UsuarioId]               INT              NOT NULL,
    [NroControl]              INT              NULL,
    [FechaUltimaModificacion] DATETIME         NULL,
    [Desincronizado]          BIT              NOT NULL,
    [Eliminado]               BIT              NOT NULL,
    [Identifier]              UNIQUEIDENTIFIER NOT NULL,
    [Cerrado]                 BIT              NOT NULL,
    [FechaCorreccion]         DATETIME         NULL,
    CONSTRAINT [PK_ControlStock] PRIMARY KEY CLUSTERED ([ControlStockId] ASC),
    CONSTRAINT [FK_ControlStock_MaxiKiosco] FOREIGN KEY ([MaxiKioscoId]) REFERENCES [dbo].[MaxiKiosco] ([MaxiKioscoId]),
    CONSTRAINT [FK_ControlStock_Proveedor] FOREIGN KEY ([ProveedorId]) REFERENCES [dbo].[Proveedor] ([ProveedorId]),
    CONSTRAINT [FK_ControlStock_Rubro] FOREIGN KEY ([RubroId]) REFERENCES [dbo].[Rubro] ([RubroId]),
    CONSTRAINT [FK_ControlStock_Usuario] FOREIGN KEY ([UsuarioId]) REFERENCES [dbo].[Usuario] ([UsuarioId])
);


GO

CREATE TRIGGER [dbo].[TGR_ControlStock_OnInsert_NroControl]
	ON [dbo].[ControlStock]
	FOR INSERT
AS
BEGIN
	
	/*------------------------------------------------
	----------- GENERO EL NRO DE CONTROL ---------------		
	--------------------------------------------------*/

	DECLARE @ControlStockId int
	DECLARE @NroControl int
	SELECT @ControlStockId = ControlStockId,
			@NroControl = NroControl
	FROM inserted
	
	IF @NroControl IS NULL
	BEGIN
		UPDATE ControlStock
		SET NroControl = ISNULL(((SELECT MAX(NroControl)
							FROM ControlStock) + 1), 1)
		WHERE ControlStockId = @ControlStockId
	END
	
END


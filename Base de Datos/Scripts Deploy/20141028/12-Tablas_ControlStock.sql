
/****** Object:  Table [dbo].[ControlStock]    Script Date: 09/22/2014 22:47:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ControlStock](
	[ControlStockId] [int] IDENTITY(1,1) NOT NULL,
	[FechaCreacion] [datetime] NOT NULL,
	[ProveedorId] [int] NULL,
	[RubroId] [int] NULL,
	[MaxiKioscoId] [int] NOT NULL,
	[UsuarioId] [int] NOT NULL,
	[NroControl] [int] NULL,
	[FechaUltimaModificacion] [datetime] NULL,
	[Desincronizado] [bit] NOT NULL,
	[Eliminado] [bit] NOT NULL,
	[Identifier] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_ControlStock] PRIMARY KEY CLUSTERED 
(
	[ControlStockId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Trigger [TGR_ControlStock_OnInsert_NroControl]    Script Date: 09/22/2014 22:47:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
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
		UPDATE ControlStocl
		SET NroControl = ISNULL(((SELECT MAX(NroControl)
							FROM ControlStock) + 1), 1)
		WHERE ControlStockId = @ControlStockId
	END
	
END
GO
/****** Object:  Table [dbo].[ControlStockDetalle]    Script Date: 09/22/2014 22:47:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ControlStockDetalle](
	[ControlStockDetalleId] [int] IDENTITY(1,1) NOT NULL,
	[ControlStockId] [int] NOT NULL,
	[StockId] [int] NOT NULL,
	[Cantidad] [decimal](18, 2) NOT NULL,
	[FechaUltimaModificacion] [datetime] NULL,
	[Desincronizado] [bit] NOT NULL,
	[Eliminado] [bit] NOT NULL,
	[Identifier] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_ControlStockDetalle] PRIMARY KEY CLUSTERED 
(
	[ControlStockDetalleId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  ForeignKey [FK_ControlStock_MaxiKiosco]    Script Date: 09/22/2014 22:47:26 ******/
ALTER TABLE [dbo].[ControlStock]  WITH CHECK ADD  CONSTRAINT [FK_ControlStock_MaxiKiosco] FOREIGN KEY([MaxiKioscoId])
REFERENCES [dbo].[MaxiKiosco] ([MaxiKioscoId])
GO
ALTER TABLE [dbo].[ControlStock] CHECK CONSTRAINT [FK_ControlStock_MaxiKiosco]
GO
/****** Object:  ForeignKey [FK_ControlStock_Proveedor]    Script Date: 09/22/2014 22:47:26 ******/
ALTER TABLE [dbo].[ControlStock]  WITH CHECK ADD  CONSTRAINT [FK_ControlStock_Proveedor] FOREIGN KEY([ProveedorId])
REFERENCES [dbo].[Proveedor] ([ProveedorId])
GO
ALTER TABLE [dbo].[ControlStock] CHECK CONSTRAINT [FK_ControlStock_Proveedor]
GO
/****** Object:  ForeignKey [FK_ControlStock_Rubro]    Script Date: 09/22/2014 22:47:26 ******/
ALTER TABLE [dbo].[ControlStock]  WITH CHECK ADD  CONSTRAINT [FK_ControlStock_Rubro] FOREIGN KEY([RubroId])
REFERENCES [dbo].[Rubro] ([RubroId])
GO
ALTER TABLE [dbo].[ControlStock] CHECK CONSTRAINT [FK_ControlStock_Rubro]
GO
/****** Object:  ForeignKey [FK_ControlStock_Usuario]    Script Date: 09/22/2014 22:47:26 ******/
ALTER TABLE [dbo].[ControlStock]  WITH CHECK ADD  CONSTRAINT [FK_ControlStock_Usuario] FOREIGN KEY([UsuarioId])
REFERENCES [dbo].[Usuario] ([UsuarioId])
GO
ALTER TABLE [dbo].[ControlStock] CHECK CONSTRAINT [FK_ControlStock_Usuario]
GO
/****** Object:  ForeignKey [FK_ControlStockDetalle_ControlStock]    Script Date: 09/22/2014 22:47:26 ******/
ALTER TABLE [dbo].[ControlStockDetalle]  WITH CHECK ADD  CONSTRAINT [FK_ControlStockDetalle_ControlStock] FOREIGN KEY([ControlStockId])
REFERENCES [dbo].[ControlStock] ([ControlStockId])
GO
ALTER TABLE [dbo].[ControlStockDetalle] CHECK CONSTRAINT [FK_ControlStockDetalle_ControlStock]
GO
/****** Object:  ForeignKey [FK_ControlStockDetalle_Stock]    Script Date: 09/22/2014 22:47:26 ******/
ALTER TABLE [dbo].[ControlStockDetalle]  WITH CHECK ADD  CONSTRAINT [FK_ControlStockDetalle_Stock] FOREIGN KEY([StockId])
REFERENCES [dbo].[Stock] ([StockId])
GO
ALTER TABLE [dbo].[ControlStockDetalle] CHECK CONSTRAINT [FK_ControlStockDetalle_Stock]
GO

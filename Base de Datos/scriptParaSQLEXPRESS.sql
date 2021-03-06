USE [MaxiKioscos]
GO
/****** Object:  Table [dbo].[webpages_Roles]    Script Date: 05/07/2014 23:26:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[webpages_Roles](
	[RoleId] [int] IDENTITY(1,1) NOT NULL,
	[RoleName] [nvarchar](256) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[RoleId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[RoleName] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[webpages_OAuthMembership]    Script Date: 05/07/2014 23:26:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[webpages_OAuthMembership](
	[Provider] [nvarchar](30) NOT NULL,
	[ProviderUserId] [nvarchar](100) NOT NULL,
	[UserId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Provider] ASC,
	[ProviderUserId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[webpages_Membership]    Script Date: 05/07/2014 23:26:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[webpages_Membership](
	[UserId] [int] NOT NULL,
	[CreateDate] [datetime] NULL,
	[ConfirmationToken] [nvarchar](128) NULL,
	[IsConfirmed] [bit] NULL,
	[LastPasswordFailureDate] [datetime] NULL,
	[PasswordFailuresSinceLastSuccess] [int] NOT NULL,
	[Password] [nvarchar](128) NOT NULL,
	[PasswordChangedDate] [datetime] NULL,
	[PasswordSalt] [nvarchar](128) NOT NULL,
	[PasswordVerificationToken] [nvarchar](128) NULL,
	[PasswordVerificationTokenExpirationDate] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Turno]    Script Date: 05/07/2014 23:26:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Turno](
	[TurnoId] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [varchar](50) NOT NULL,
	[Desde] [time](0) NOT NULL,
	[Hasta] [time](0) NOT NULL,
 CONSTRAINT [PK_Turno] PRIMARY KEY CLUSTERED 
(
	[TurnoId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TipoCuit]    Script Date: 05/07/2014 23:26:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TipoCuit](
	[TipoCuitId] [int] NOT NULL,
	[Descripcion] [varchar](150) NOT NULL,
	[FechaUltimaModificacion] [datetime2](7) NULL,
	[Eliminado] [bit] NOT NULL,
	[Desincronizado] [bit] NOT NULL,
 CONSTRAINT [PK_TipoCuit] PRIMARY KEY CLUSTERED 
(
	[TipoCuitId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[StockTransaccionTipo]    Script Date: 05/07/2014 23:26:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[StockTransaccionTipo](
	[StockTransaccionTipoId] [int] NOT NULL,
	[Nombre] [varchar](200) NOT NULL,
 CONSTRAINT [PK_StockTransaccionTipo] PRIMARY KEY CLUSTERED 
(
	[StockTransaccionTipoId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  UserDefinedFunction [dbo].[EntreHorarios]    Script Date: 05/07/2014 23:26:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date, ,>
-- Description:	<Description, ,>
-- =============================================
CREATE FUNCTION [dbo].[EntreHorarios]
(
	@Desde time(7),
	@Hasta time(7)
)
RETURNS bit
AS
BEGIN
	
	DECLARE @EstaEntre bit
	DECLARE @FechaDesde datetime2(7)
	DECLARE @FechaHasta datetime2(7)
	SET @FechaDesde=CAST((CONVERT(varchar(10),GETDATE(),120) + ' ' + CAST(@Desde as varchar(30))) as datetime2(7))
	SET @FechaHasta=CAST((CONVERT(varchar(10),GETDATE(),120) + ' ' + CAST(@Hasta as varchar(30))) as datetime2(7))
	IF (@FechaDesde>@FechaHasta)
	BEGIN	
			IF (@FechaDesde<=GETDATE() AND GETDATE()>@FechaHasta)
				SET @fechahasta=DATEADD(day,1,@fechahasta)
			ELSE
				BEGIN 
					IF (@FechaDesde>GETDATE() AND GETDATE()<=@FechaHasta)
						SET @FechaDesde=DATEADD(day,-1,@FechaDesde)
				END
	END	
	SET @EstaEntre=CASE
						WHEN (GETDATE() >= @FechaDesde AND GETDATE()<= @FechaHasta) THEN 1
						ELSE 0
					END	
	-- Return the result of the function
	RETURN (@EstaEntre)

END
GO
/****** Object:  Table [dbo].[Cuenta]    Script Date: 05/07/2014 23:26:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Cuenta](
	[CuentaId] [int] IDENTITY(1,1) NOT NULL,
	[Titular] [varchar](150) NOT NULL,
	[Identifier] [uniqueidentifier] NOT NULL,
	[FechaUltimaModificacion] [datetime2](7) NULL,
	[Eliminado] [bit] NOT NULL,
	[MargenImporteFactura] [money] NULL,
	[Desincronizado] [bit] NOT NULL,
 CONSTRAINT [PK_Cuenta] PRIMARY KEY CLUSTERED 
(
	[CuentaId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [dbo].[ActualizarPrincipal]    Script Date: 05/07/2014 23:26:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ActualizarPrincipal]
	@MaxiKioscoId int,
	@XML xml,
	@Secuencia int
AS
BEGIN
	SELECT @Secuencia as Secuencia
END
GO
/****** Object:  UserDefinedFunction [dbo].[ID_Splitter]    Script Date: 05/07/2014 23:26:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION  [dbo].[ID_Splitter](@IDs Varchar(8000) )  
RETURNS @Tbl_IDs TABLE  (ID Int)  As  

BEGIN 
 -- Append comma

 SET @IDs =  @IDs + ',' 
 -- Indexes to keep the position of searching

 DECLARE @Pos1 Int
 DECLARE @pos2 Int
 
 -- Start from first character 

 SET @Pos1=1
 SET @Pos2=1

 WHILE @Pos1<LEN(@IDs)
 BEGIN
  SET @Pos1 = CHARINDEX(',',@IDs,@Pos1)
  INSERT @Tbl_IDs Select  CAST(SUBSTRING(@IDs,@Pos2,@Pos1-@Pos2) AS INT)
  -- Go to next non comma character

  SET @Pos2=@Pos1+1
  -- Search from the next charcater

  SET @Pos1 = @Pos1+1
 END 
 RETURN
END
GO
/****** Object:  Table [dbo].[Provincia]    Script Date: 05/07/2014 23:26:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Provincia](
	[ProvinciaId] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [varchar](200) NOT NULL,
	[FechaUltimaModificacion] [datetime2](7) NULL,
	[Eliminado] [bit] NOT NULL,
	[Desincronizado] [bit] NOT NULL,
 CONSTRAINT [PK_Provincia] PRIMARY KEY CLUSTERED 
(
	[ProvinciaId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[MotivoOperacionCaja]    Script Date: 05/07/2014 23:26:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[MotivoOperacionCaja](
	[MotivoOperacionCajaId] [int] NOT NULL,
	[Descripcion] [varchar](200) NOT NULL,
	[FechaUltimaModificacion] [datetime2](7) NULL,
	[Eliminado] [bit] NOT NULL,
	[Desincronizado] [bit] NOT NULL,
	[SumarACierreCaja] [bit] NOT NULL,
 CONSTRAINT [PK_MotivoOperacionCaja] PRIMARY KEY CLUSTERED 
(
	[MotivoOperacionCajaId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[MotivoCorreccion]    Script Date: 05/07/2014 23:26:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[MotivoCorreccion](
	[MotivoCorreccionId] [int] NOT NULL,
	[Descripcion] [varchar](300) NOT NULL,
 CONSTRAINT [PK_MotivoCorreccion] PRIMARY KEY CLUSTERED 
(
	[MotivoCorreccionId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[MaxiKiosco]    Script Date: 05/07/2014 23:26:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[MaxiKiosco](
	[MaxiKioscoId] [int] IDENTITY(1,1) NOT NULL,
	[Identifier] [uniqueidentifier] NOT NULL,
	[Nombre] [varchar](100) NOT NULL,
	[Direccion] [varchar](200) NOT NULL,
	[Telefono] [varchar](20) NULL,
	[CuentaId] [int] NOT NULL,
	[Desincronizado] [bit] NOT NULL,
	[FechaUltimaModificacion] [datetime2](7) NULL,
	[Eliminado] [bit] NOT NULL,
	[UltimaSecuenciaExportacion] [int] NULL,
 CONSTRAINT [PK_MaxiKiosco] PRIMARY KEY CLUSTERED 
(
	[MaxiKioscoId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Marca]    Script Date: 05/07/2014 23:26:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Marca](
	[MarcaId] [int] IDENTITY(1,1) NOT NULL,
	[Identifier] [uniqueidentifier] NOT NULL,
	[Descripcion] [varchar](200) NOT NULL,
	[Desincronizado] [bit] NOT NULL,
	[FechaUltimaModificacion] [datetime2](7) NULL,
	[Eliminado] [bit] NOT NULL,
	[CuentaId] [int] NOT NULL,
 CONSTRAINT [PK_Marca] PRIMARY KEY CLUSTERED 
(
	[MarcaId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Localidad]    Script Date: 05/07/2014 23:26:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Localidad](
	[LocalidadId] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [varchar](200) NOT NULL,
	[ProvinciaId] [int] NOT NULL,
	[CodigoPostal] [varchar](10) NOT NULL,
	[FechaUltimaModificacion] [datetime2](7) NULL,
	[Eliminado] [bit] NOT NULL,
	[Desincronizado] [bit] NOT NULL,
 CONSTRAINT [PK_Localidad] PRIMARY KEY CLUSTERED 
(
	[LocalidadId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Rubro]    Script Date: 05/07/2014 23:26:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Rubro](
	[RubroId] [int] IDENTITY(1,1) NOT NULL,
	[Identifier] [uniqueidentifier] NOT NULL,
	[Descripcion] [varchar](100) NOT NULL,
	[Desincronizado] [bit] NOT NULL,
	[FechaUltimaModificacion] [datetime2](7) NULL,
	[Eliminado] [bit] NOT NULL,
	[CuentaId] [int] NOT NULL,
	[NoFacturar] [bit] NOT NULL,
 CONSTRAINT [PK_Rubro] PRIMARY KEY CLUSTERED 
(
	[RubroId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 05/07/2014 23:26:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Usuario](
	[UsuarioId] [int] IDENTITY(1,1) NOT NULL,
	[NombreUsuario] [nvarchar](max) NOT NULL,
	[CuentaId] [int] NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Apellido] [varchar](50) NOT NULL,
	[Identifier] [uniqueidentifier] NOT NULL,
	[FechaUltimaModificacion] [datetime2](7) NULL,
	[Eliminado] [bit] NOT NULL,
	[Desincronizado] [bit] NOT NULL,
 CONSTRAINT [PK__UserProf__1788CC4C4316F928] PRIMARY KEY CLUSTERED 
(
	[UsuarioId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [dbo].[Usuario_ObtenerMembresia]    Script Date: 05/07/2014 23:26:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Usuario_ObtenerMembresia]
	@UsuarioId int
AS
BEGIN
	SELECT *
	FROM dbo.webpages_Membership
	WHERE UserId = @UsuarioId
END
GO
/****** Object:  Table [dbo].[webpages_UsersInRoles]    Script Date: 05/07/2014 23:26:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[webpages_UsersInRoles](
	[UserId] [int] NOT NULL,
	[RoleId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UsuarioMaxiKiosco]    Script Date: 05/07/2014 23:26:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UsuarioMaxiKiosco](
	[UsuarioMaxiKioscoId] [int] IDENTITY(1,1) NOT NULL,
	[UsuarioId] [int] NOT NULL,
	[MaxiKioscoId] [int] NOT NULL,
	[Desincronizado] [bit] NOT NULL,
	[Eliminado] [bit] NOT NULL,
	[FechaUltimaModificacion] [datetime2](7) NULL,
 CONSTRAINT [PK_UsuarioMaxiKiosco] PRIMARY KEY CLUSTERED 
(
	[UsuarioMaxiKioscoId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MaxiKioscoTurno]    Script Date: 05/07/2014 23:26:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MaxiKioscoTurno](
	[MaxiKioscoTurnoId] [int] IDENTITY(1,1) NOT NULL,
	[MaxiKioscoId] [int] NOT NULL,
	[TurnoId] [int] NOT NULL,
	[MontoMaximoVentaConTickets] [money] NULL,
	[Eliminado] [bit] NOT NULL,
	[Desincronizado] [bit] NOT NULL,
	[FechaUltimaModificacion] [datetime2](7) NULL,
	[Identifier] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_MaxiKioscoTurno] PRIMARY KEY CLUSTERED 
(
	[MaxiKioscoTurnoId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Proveedor]    Script Date: 05/07/2014 23:26:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Proveedor](
	[ProveedorId] [int] IDENTITY(1,1) NOT NULL,
	[Identifier] [uniqueidentifier] NOT NULL,
	[Nombre] [varchar](100) NOT NULL,
	[Contacto] [varchar](100) NULL,
	[Direccion] [varchar](200) NULL,
	[LocalidadId] [int] NULL,
	[Telefono] [varchar](16) NULL,
	[Celular] [varchar](18) NULL,
	[TipoCuitId] [int] NULL,
	[CuitNro] [varchar](14) NULL,
	[Email] [varchar](200) NULL,
	[PaginaWeb] [varchar](200) NULL,
	[Observaciones] [varchar](max) NULL,
	[Desincronizado] [bit] NOT NULL,
	[FechaUltimaModificacion] [datetime2](7) NULL,
	[Eliminado] [bit] NOT NULL,
	[CuentaId] [int] NOT NULL,
 CONSTRAINT [PK_Proveedor] PRIMARY KEY CLUSTERED 
(
	[ProveedorId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Producto]    Script Date: 05/07/2014 23:26:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Producto](
	[ProductoId] [int] IDENTITY(1,1) NOT NULL,
	[Identifier] [uniqueidentifier] NOT NULL,
	[RubroId] [int] NOT NULL,
	[MarcaId] [int] NOT NULL,
	[Descripcion] [varchar](300) NOT NULL,
	[Precio] [money] NOT NULL,
	[StockReposicion] [int] NULL,
	[Desincronizado] [bit] NOT NULL,
	[FechaUltimaModificacion] [datetime2](7) NULL,
	[Eliminado] [bit] NOT NULL,
	[CuentaId] [int] NOT NULL,
	[AceptaCantidadesDecimales] [bit] NOT NULL,
 CONSTRAINT [PK_Producto] PRIMARY KEY CLUSTERED 
(
	[ProductoId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Exportacion]    Script Date: 05/07/2014 23:26:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Exportacion](
	[ExportacionId] [int] IDENTITY(1,1) NOT NULL,
	[Secuencia] [int] NOT NULL,
	[Fecha] [datetime2](7) NOT NULL,
	[CreadorId] [int] NOT NULL,
	[Archivo] [xml] NOT NULL,
	[CuentaId] [int] NOT NULL,
	[Nombre]  AS (((('EXP-'+CONVERT([varchar],[Secuencia],0))+' (')+CONVERT([char](10),[Fecha],(120)))+')'),
	[Eliminado] [bit] NOT NULL,
	[Desincronizado] [bit] NOT NULL,
	[FechaUltimaModificacion] [datetime2](7) NULL,
 CONSTRAINT [PK_Exportacion] PRIMARY KEY CLUSTERED 
(
	[ExportacionId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ExcepcionRubro]    Script Date: 05/07/2014 23:26:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ExcepcionRubro](
	[ExcepcionRubroId] [int] IDENTITY(1,1) NOT NULL,
	[Identifier] [uniqueidentifier] NOT NULL,
	[RubroId] [int] NOT NULL,
	[Desde] [time](7) NOT NULL,
	[Hasta] [time](7) NOT NULL,
	[RecargoAbsoluto] [money] NULL,
	[RecargoPorcentaje] [decimal](18, 2) NULL,
	[FechaUltimaModificacion] [datetime2](7) NULL,
	[Eliminado] [bit] NOT NULL,
	[Desincronizado] [bit] NOT NULL,
	[MaxiKioscoId] [int] NOT NULL,
 CONSTRAINT [PK_ExcepcionRubro] PRIMARY KEY CLUSTERED 
(
	[ExcepcionRubroId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CierreCaja]    Script Date: 05/07/2014 23:26:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CierreCaja](
	[CierreCajaId] [int] IDENTITY(1,1) NOT NULL,
	[Identifier] [uniqueidentifier] NOT NULL,
	[FechaInicio] [datetime2](7) NOT NULL,
	[FechaFin] [datetime2](7) NULL,
	[CajaInicial] [money] NOT NULL,
	[CajaFinal] [money] NULL,
	[CajaEsperada] [money] NULL,
	[UsuarioId] [int] NOT NULL,
	[MaxiKioskoId] [int] NOT NULL,
	[Desincronizado] [bit] NOT NULL,
	[FechaUltimaModificacion] [datetime2](7) NULL,
	[Eliminado] [bit] NOT NULL,
	[Diferencia]  AS ([CajaFinal]-[CajaEsperada]),
 CONSTRAINT [PK_CierreCaja] PRIMARY KEY CLUSTERED 
(
	[CierreCajaId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CorreccionStock]    Script Date: 05/07/2014 23:26:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CorreccionStock](
	[CorreccionStockId] [int] IDENTITY(1,1) NOT NULL,
	[ProductoId] [int] NOT NULL,
	[Cantidad] [decimal](18, 2) NOT NULL,
	[Precio] [money] NOT NULL,
	[Desincronizado] [bit] NOT NULL,
	[FechaUltimaModificacion] [datetime2](7) NULL,
	[Identifier] [uniqueidentifier] NOT NULL,
	[MotivoCorreccionId] [int] NOT NULL,
	[Fecha] [datetime] NOT NULL,
	[MaxiKioscoId] [int] NOT NULL,
 CONSTRAINT [PK_CorreccionStock] PRIMARY KEY CLUSTERED 
(
	[CorreccionStockId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Factura]    Script Date: 05/07/2014 23:26:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Factura](
	[FacturaId] [int] IDENTITY(1,1) NOT NULL,
	[Identifier] [uniqueidentifier] NOT NULL,
	[ProveedorId] [int] NOT NULL,
	[FacturaNro] [varchar](15) NOT NULL,
	[ImporteTotal] [money] NOT NULL,
	[Fecha] [datetime2](7) NOT NULL,
	[MaxiKioscoId] [int] NOT NULL,
	[Desincronizado] [bit] NOT NULL,
	[FechaUltimaModificacion] [datetime2](7) NULL,
	[Eliminado] [bit] NOT NULL,
	[CierreCajaId] [int] NOT NULL,
	[DescuentoPorcentaje] [decimal](18, 0) NULL,
	[DescuentoEnPesos] [money] NULL,
	[ImporteFinal]  AS ([ImporteTotal]+isnull([DescuentoEnPesos],(0))),
 CONSTRAINT [PK_Factura] PRIMARY KEY CLUSTERED 
(
	[FacturaId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Excepcion]    Script Date: 05/07/2014 23:26:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Excepcion](
	[ExcepcionId] [int] IDENTITY(1,1) NOT NULL,
	[Identifier] [uniqueidentifier] NOT NULL,
	[CierreCajaId] [int] NOT NULL,
	[Importe] [money] NOT NULL,
	[Descripcion] [varchar](2000) NOT NULL,
	[FechaCarga] [datetime2](7) NOT NULL,
	[Desincronizado] [bit] NOT NULL,
	[FechaUltimaModificacion] [datetime2](7) NULL,
	[Eliminado] [bit] NOT NULL,
 CONSTRAINT [PK_Excepcion] PRIMARY KEY CLUSTERED 
(
	[ExcepcionId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CodigoProducto]    Script Date: 05/07/2014 23:26:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CodigoProducto](
	[CodigoProductoId] [int] IDENTITY(1,1) NOT NULL,
	[ProductoId] [int] NOT NULL,
	[Codigo] [varchar](30) NOT NULL,
	[Desincronizado] [bit] NOT NULL,
	[FechaUltimaModificacion] [datetime2](7) NULL,
	[Eliminado] [bit] NOT NULL,
 CONSTRAINT [PK_CodigoProducto] PRIMARY KEY CLUSTERED 
(
	[CodigoProductoId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  UserDefinedFunction [dbo].[PrecioPorHora]    Script Date: 05/07/2014 23:26:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE FUNCTION [dbo].[PrecioPorHora]
(	
	@ProductoId int
)
RETURNS @Precio TABLE (	Precio money)
AS
BEGIN
	INSERT @Precio SELECT Precio=CASE 
									WHEN (dbo.EntreHorarios(ER.Desde,ER.Hasta)=1)
									THEN (P.Precio + ISNULL(ER.RecargoAbsoluto, (Precio * (ER.RecargoPorcentaje/100)))) 
									ELSE P.Precio
								END
					FROM ExcepcionRubro ER INNER JOIN Producto P
						ON ER.RubroId=P.RubroId
					WHERE P.ProductoId=@ProductoId
					AND  dbo.EntreHorarios(ER.Desde,ER.Hasta)=1
						
					
	
	RETURN 
END
GO
/****** Object:  Table [dbo].[OperacionCaja]    Script Date: 05/07/2014 23:26:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[OperacionCaja](
	[OperacionCajaId] [int] IDENTITY(1,1) NOT NULL,
	[Monto] [money] NOT NULL,
	[Fecha] [datetime2](7) NOT NULL,
	[CierreCajaId] [int] NOT NULL,
	[FechaUltimaModificacion] [datetime2](7) NULL,
	[Eliminado] [bit] NOT NULL,
	[MotivoId] [int] NULL,
	[Observaciones] [varchar](max) NULL,
	[Desincronizado] [bit] NOT NULL,
	[UsuarioCreadorId] [int] NOT NULL,
	[UltimoUsuarioModificacionId] [int] NULL,
 CONSTRAINT [PK_OperacionCaja] PRIMARY KEY CLUSTERED 
(
	[OperacionCajaId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ProveedorProducto]    Script Date: 05/07/2014 23:26:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProveedorProducto](
	[ProveedorProductoId] [int] IDENTITY(1,1) NOT NULL,
	[Identifier] [uniqueidentifier] NOT NULL,
	[ProveedorId] [int] NOT NULL,
	[ProductoId] [int] NOT NULL,
	[Costo] [money] NOT NULL,
	[Desincronizado] [bit] NOT NULL,
	[FechaUltimaModificacion] [datetime2](7) NULL,
	[Eliminado] [bit] NOT NULL,
 CONSTRAINT [PK_ProveedorProducto] PRIMARY KEY CLUSTERED 
(
	[ProveedorProductoId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[Rpt_Stock_DiferenciaCierres]    Script Date: 05/07/2014 23:26:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Rpt_Stock_DiferenciaCierres]
	@Desde datetime2(7),
	@Hasta datetime2(7),
	@MaxiKioscoId int,
	@CuentaId int
AS
BEGIN
	SELECT Diferencia = ISNULL(SUM(CajaFinal - CajaEsperada), 0)
	   
	FROM CierreCaja CC
		INNER JOIN MaxiKiosco M
			ON CC.MaxiKioskoId = M.MaxiKioscoId
	WHERE 
		(@Desde IS NULL OR CC.FechaInicio >= @Desde)
		AND (@Hasta IS NULL OR CC.FechaInicio <= @Hasta)
		AND (@MaxiKioscoId IS NULL OR CC.MaxiKioskoId = @MaxiKioscoId)
		AND (@CuentaId IS NULL OR M.CuentaId = @CuentaId)	
END
GO
/****** Object:  StoredProcedure [dbo].[Rpt_CierresDeCaja]    Script Date: 05/07/2014 23:26:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Rpt_CierresDeCaja]
	@Desde datetime2(7),
	@Hasta datetime2(7),
	@MaxiKioscoId int,
	@UsuarioId int,
	@CuentaId int
AS
BEGIN
	SELECT
	   MaxiKioscoNombre = M.Nombre
	  ,MaxiKioscoDireccion = M.Direccion
	  ,UsuarioNombre = U.Nombre 
	  ,UsuarioApellido = U.Apellido
	  ,PromedioInicial = AVG(CC.CajaInicial)
	  ,PromedioFinal = AVG(CC.CajaFinal)
	  ,CantPorDebajoEsperado = SUM(CASE 
						WHEN (CC.CajaFinal < CC.CajaEsperada) THEN 1
						ELSE 0
						END)
	  ,CantPorEncimaEsperado = SUM(CASE
						WHEN (CC.CajaFinal >= CC.CajaEsperada) THEN 1
						ELSE 0
						END)
	FROM
	  CierreCaja CC
	  INNER JOIN MaxiKiosco M
		ON CC.MaxiKioskoId = M.MaxiKioscoId
	  INNER JOIN Usuario U 
		ON CC.UsuarioId = U.UsuarioId
							
	 WHERE 
	        (@Desde IS NULL OR CC.FechaInicio >= @Desde)
		AND (@Hasta IS NULL OR CC.FechaInicio <= @Hasta)
		AND (@MaxiKioscoId IS NULL OR CC.MaxiKioskoId = @MaxiKioscoId)
		AND (@UsuarioId IS NULL OR CC.UsuarioId = @UsuarioId)
		AND (@CuentaId IS NULL OR M.CuentaId = @CuentaId)
		
	 GROUP BY  M.Nombre,M.Direccion,U.Nombre,U.Apellido
	
END
GO
/****** Object:  Table [dbo].[Venta]    Script Date: 05/07/2014 23:26:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Venta](
	[VentaId] [int] IDENTITY(1,1) NOT NULL,
	[Identifier] [uniqueidentifier] NOT NULL,
	[CierreCajaId] [int] NOT NULL,
	[ImporteTotal] [money] NOT NULL,
	[FechaVenta] [datetime] NOT NULL,
	[Eliminado] [bit] NOT NULL,
	[Desincronizado] [bit] NOT NULL,
	[FechaUltimaModificacion] [datetime2](7) NULL,
 CONSTRAINT [PK_Venta] PRIMARY KEY CLUSTERED 
(
	[VentaId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UsuarioProveedor]    Script Date: 05/07/2014 23:26:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UsuarioProveedor](
	[UsuarioProveedorId] [int] IDENTITY(1,1) NOT NULL,
	[UsuarioId] [int] NOT NULL,
	[ProveedorId] [int] NOT NULL,
	[Desincronizado] [bit] NOT NULL,
	[Eliminado] [bit] NOT NULL,
	[FechaUltimaModificacion] [datetime2](7) NULL,
 CONSTRAINT [PK_UsuarioProveedor] PRIMARY KEY CLUSTERED 
(
	[UsuarioProveedorId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Stock]    Script Date: 05/07/2014 23:26:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Stock](
	[StockId] [int] IDENTITY(1,1) NOT NULL,
	[ProductoId] [int] NOT NULL,
	[MaxiKioscoId] [int] NOT NULL,
	[Identifier] [uniqueidentifier] NOT NULL,
	[StockActual] [decimal](18, 2) NOT NULL,
	[Desincronizado] [bit] NOT NULL,
	[FechaUltimaModificacion] [datetime2](7) NULL,
	[Eliminado] [bit] NOT NULL,
 CONSTRAINT [PK_ProductoMaxiKiosco] PRIMARY KEY CLUSTERED 
(
	[StockId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[Rubro_ListadoPorKiosco]    Script Date: 05/07/2014 23:26:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Rubro_ListadoPorKiosco]
	@MaxiKioscoId int
AS
BEGIN
	SELECT R.*,
			TieneExcepciones = (CASE 
									WHEN (SELECT TOP 1 1 FROM ExcepcionRubro ER 
									 WHERE ER.RubroId = R.RubroId
									 AND ER.MaxiKioscoId = @MaxiKioscoId) IS NULL THEN 'No'
									ELSE 'Si'
								END)
	FROM Rubro R
	WHERE R.Eliminado = 0
									 
	
END
GO
/****** Object:  StoredProcedure [dbo].[Usuario_InsertarDependencias]    Script Date: 05/07/2014 23:26:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Usuario_InsertarDependencias]
	@UsuarioId int,
	@RolesIds varchar(500) = null,
	@MaxikioscosIds varchar(500) = null,
	@ProveedoresIds varchar(5000) = null
AS
BEGIN
	DELETE FROM webpages_UsersInRoles
	WHERE UserId = @UsuarioId
	
	UPDATE UsuarioMaxiKiosco
	SET Eliminado = 1
	WHERE UsuarioId = @UsuarioId
	
	UPDATE UsuarioProveedor
	SET Eliminado = 1
	WHERE UsuarioId = @UsuarioId
	
	INSERT INTO webpages_UsersInRoles (UserId, RoleId)
	SELECT @UsuarioId, ID
	FROM dbo.ID_Splitter(@RolesIds)

	INSERT INTO UsuarioMaxiKiosco (UsuarioId, MaxiKioscoId, Desincronizado, Eliminado, FechaUltimaModificacion)
	SELECT @UsuarioId, ID, 1, 0, GETDATE()
	FROM dbo.ID_Splitter(@MaxikioscosIds)
	
	INSERT INTO UsuarioProveedor (UsuarioId, ProveedorId, Desincronizado, Eliminado, FechaUltimaModificacion)
	SELECT @UsuarioId, ID, 1, 0, GETDATE()
	FROM dbo.ID_Splitter(@ProveedoresIds)
	
	SELECT @UsuarioId
	
END
GO
/****** Object:  Table [dbo].[VentaProducto]    Script Date: 05/07/2014 23:26:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VentaProducto](
	[VentaProductoId] [int] IDENTITY(1,1) NOT NULL,
	[Identifier] [uniqueidentifier] NOT NULL,
	[VentaId] [int] NOT NULL,
	[ProductoId] [int] NOT NULL,
	[Precio] [money] NULL,
	[Cantidad] [int] NOT NULL,
	[FechaUltimaModificacion] [datetime2](7) NULL,
	[Eliminado] [bit] NOT NULL,
	[Desincronizado] [bit] NOT NULL,
 CONSTRAINT [PK_VentaProducto] PRIMARY KEY CLUSTERED 
(
	[VentaProductoId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StockTransaccion]    Script Date: 05/07/2014 23:26:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StockTransaccion](
	[StockTransaccionId] [int] IDENTITY(1,1) NOT NULL,
	[StockId] [int] NOT NULL,
	[Identifier] [uniqueidentifier] NOT NULL,
	[Desincronizado] [bit] NOT NULL,
	[FechaUltimaModificacion] [datetime2](7) NULL,
	[Eliminado] [bit] NOT NULL,
	[Cantidad] [decimal](18, 2) NOT NULL,
	[StockTransaccionTipoId] [int] NOT NULL,
 CONSTRAINT [PK_StockTransaccion] PRIMARY KEY CLUSTERED 
(
	[StockTransaccionId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[Rpt_VentasPorMaxikiosco]    Script Date: 05/07/2014 23:26:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Rpt_VentasPorMaxikiosco]
	@Desde datetime2(7),
	@Hasta datetime2(7),
	@CuentaId int
AS
BEGIN
	SELECT
	   M.Nombre
	  ,M.Direccion
	  ,SUM(V.ImporteTotal) AS ImporteTotal
	FROM
	  CierreCaja CC
	  INNER JOIN MaxiKiosco M
		ON CC.MaxiKioskoId = M.MaxiKioscoId
	  INNER JOIN Venta V
		ON CC.CierreCajaId = V.CierreCajaId
	 WHERE 
	        (@Desde IS NULL OR V.FechaVenta >= @Desde)
		AND (@Hasta IS NULL OR V.FechaVenta <= @Hasta)
		AND (@CuentaId IS NULL OR M.CuentaId = @CuentaId)
		
	 GROUP BY M.Nombre,M.Direccion
END
GO
/****** Object:  StoredProcedure [dbo].[Rpt_Stock]    Script Date: 05/07/2014 23:26:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Rpt_Stock]
	@Desde datetime2(7),
	@Hasta datetime2(7),
	@MaxiKioscoId int,
	@CuentaId int
AS
BEGIN
	WITH CTE(MaxiKiosco, Producto, Cantidad, Monto)
	AS
	(
		SELECT
		   MaxiKiosco = M.Nombre,
		   Producto = P.Descripcion,
		   Cantidad = CS.Cantidad,
		   Monto = CS.Precio
		   
		FROM CorreccionStock CS
			INNER JOIN Producto P	
				ON CS.ProductoId = P.ProductoId
			INNER JOIN CierreCaja CC
				ON CS.CierreCajaId = CC.CierreCajaId
			INNER JOIN MaxiKiosco M
				ON CC.MaxiKioskoId = M.MaxiKioscoId
		WHERE 
			(@Desde IS NULL OR CC.FechaInicio >= @Desde)
			AND (@Hasta IS NULL OR CC.FechaInicio <= @Hasta)
			AND (@MaxiKioscoId IS NULL OR CC.MaxiKioskoId = @MaxiKioscoId)
			AND (@CuentaId IS NULL OR M.CuentaId = @CuentaId)		
		
	)
	
	SELECT MaxiKiosco, 
			Producto, 			
			Cantidad = ISNULL(SUM(Cantidad), 0), 
			Monto = ISNULL(SUM(Monto), 0)
	FROM CTE
	GROUP BY MaxiKiosco, Producto
	ORDER BY MaxiKiosco, Producto
	
END
GO
/****** Object:  StoredProcedure [dbo].[Producto_ObtenerProductoPorCodigo]    Script Date: 05/07/2014 23:26:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Producto_ObtenerProductoPorCodigo]
	@Codigo varchar(30)
AS
BEGIN

	SELECT 
		P.ProductoId, 
		Codigo = (SELECT SUBSTRING(
					(SELECT ',' + Codigo
					FROM CodigoProducto CP WHERE CP.ProductoId = P.ProductoId
					FOR XML PATH('')),2,200000)),
		P.Descripcion, 
		Marca=M.Descripcion,		
		Precio = ISNULL((SELECT PRECIO FROM dbo.PrecioPorHora(P.ProductoId)), P.Precio),
		S.StockActual
	FROM Producto P INNER JOIN CodigoProducto CP
		ON P.ProductoId=CP.ProductoId INNER JOIN Marca M
		ON P.MarcaId=M.MarcaId INNER JOIN Stock S
		ON P.ProductoId=S.ProductoId
	WHERE @Codigo=0 OR CP.Codigo=@Codigo		

END
GO
/****** Object:  StoredProcedure [dbo].[CierreCaja_Detalle]    Script Date: 05/07/2014 23:26:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CierreCaja_Detalle]
	@CierreCajaId int
AS
BEGIN
	WITH CTE(Orden, Concepto, Importe, Observaciones)
	AS
	(
		(SELECT TOP 1 1,'Caja Inicial', CajaInicial,  ''
		FROM CierreCaja
		WHERE CierreCajaID = @CierreCajaId)
		
		UNION 	
		
		(SELECT 2, 'Factura', -F.ImporteTotal, '[' + F.FacturaNro + '] - ' + P.Nombre  
		FROM Factura F
			INNER JOIN Proveedor P
				ON F.ProveedorId = P.ProveedorId
		WHERE F.CierreCajaID = @CierreCajaId
		)
		
		UNION 	
		
		(SELECT 3, 'Ventas', ISNULL(SUM(ImporteTotal), 0), ''
		FROM Venta
		WHERE CierreCajaID = @CierreCajaId
		)
		
		UNION 	
		
		(SELECT 4, MOC.Descripcion, OC.Monto, ''  
		FROM OperacionCaja OC
			INNER JOIN MotivoOperacionCaja MOC
				ON OC.MotivoId = MOC.MotivoOperacionCajaId
		WHERE OC.CierreCajaID = @CierreCajaId
		)
		
		UNION 	
		
		(SELECT 5, 'Excepción', Importe, Descripcion  
		FROM Excepcion 
		WHERE CierreCajaID = @CierreCajaId
		)
		
		UNION 
		
		(SELECT 6,'IMPORTE TOTAL ESPERADO', CajaEsperada,  ''
		FROM CierreCaja
		WHERE CierreCajaID = @CierreCajaId)
	)
	
	SELECT Orden, Concepto, Importe, Observaciones
	FROM CTE
	ORDER BY Orden
	
END
GO
/****** Object:  StoredProcedure [dbo].[CierreCaja_Cerrar]    Script Date: 05/07/2014 23:26:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CierreCaja_Cerrar]
	@MaxiKioscoId int,
	@CajaFinal money
AS
BEGIN
	
	DECLARE @CierreCajaId int
	SET @CierreCajaId = (SELECT TOP 1 CierreCajaId 
						 FROM CierreCaja
						 WHERE FechaFin IS NULL AND MaxiKioskoId = @MaxiKioscoId)					
	
	UPDATE CierreCaja
	SET CajaFinal = @CajaFinal,
		Desincronizado = 1,
		FechaUltimaModificacion = GETDATE(),
		FechaFin = GETDATE(),
		CajaEsperada = (
							CajaInicial 
							+ (SELECT ISNULL(SUM(Monto), 0)
							 FROM OperacionCaja
							 WHERE CierreCajaId = @CierreCajaId
							)
							- (SELECT ISNULL(SUM(ImporteTotal), 0)
							 FROM Factura
							 WHERE CierreCajaId = @CierreCajaId
							)
							+ (SELECT ISNULL(SUM(Importe), 0)
							 FROM Excepcion
							 WHERE CierreCajaId = @CierreCajaId
							)
							+ (SELECT ISNULL(SUM(ImporteTotal), 0)
							 FROM Venta
							 WHERE CierreCajaId = @CierreCajaId
							)
						)
	WHERE CierreCajaId = @CierreCajaId
	
	SELECT @CierreCajaId as CierreCajaId
	
END
GO
/****** Object:  StoredProcedure [dbo].[Exportacion_PuedeExportar]    Script Date: 05/07/2014 23:26:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Exportacion_PuedeExportar]	
AS
BEGIN
	DECLARE @DesincronizadosCount int
	SET @DesincronizadosCount = (SELECT ISNULL(
	(SELECT COUNT(*) FROM Producto WHERE Desincronizado = 1) +
    (SELECT COUNT(*) FROM Proveedor WHERE Desincronizado = 1) +
    (SELECT COUNT(*) FROM CierreCaja WHERE Desincronizado = 1) +
    (SELECT COUNT(*) FROM CodigoProducto WHERE Desincronizado = 1) +
    (SELECT COUNT(*) FROM ExcepcionRubro WHERE Desincronizado = 1) +
    (SELECT COUNT(*) FROM Factura WHERE Desincronizado = 1) +
    (SELECT COUNT(*) FROM Marca WHERE Desincronizado = 1) +
    (SELECT COUNT(*) FROM MaxiKiosco WHERE Desincronizado = 1) +
    (SELECT COUNT(*) FROM OperacionCaja WHERE Desincronizado = 1) +
    (SELECT COUNT(*) FROM ProveedorProducto WHERE Desincronizado = 1) +
    (SELECT COUNT(*) FROM Rubro WHERE Desincronizado = 1) +
    (SELECT COUNT(*) FROM Usuario WHERE Desincronizado = 1) +
    (SELECT COUNT(*) FROM UsuarioMaxiKiosco WHERE Desincronizado = 1) +
    (SELECT COUNT(*) FROM Venta WHERE Desincronizado = 1), 0))
	
		
	SELECT @DesincronizadosCount AS Cuenta
END
GO
/****** Object:  Table [dbo].[Compra]    Script Date: 05/07/2014 23:26:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Compra](
	[CompraId] [int] IDENTITY(1,1) NOT NULL,
	[Identifier] [uniqueidentifier] NOT NULL,
	[Fecha] [datetime2](7) NOT NULL,
	[Numero] [varchar](25) NOT NULL,
	[FacturaId] [int] NOT NULL,
	[CuentaId] [int] NOT NULL,
	[Desincronizado] [bit] NOT NULL,
	[FechaUltimaModificacion] [datetime2](7) NULL,
	[Eliminado] [bit] NOT NULL,
	[MaxiKioscoId] [int] NOT NULL,
 CONSTRAINT [PK_Compra] PRIMARY KEY CLUSTERED 
(
	[CompraId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CompraProducto]    Script Date: 05/07/2014 23:26:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CompraProducto](
	[CompraProductoId] [int] IDENTITY(1,1) NOT NULL,
	[CompraId] [int] NOT NULL,
	[Identifier] [uniqueidentifier] NOT NULL,
	[ProductoId] [int] NOT NULL,
	[CostoActual] [money] NOT NULL,
	[CostoActualizado] [money] NULL,
	[PrecioActual] [money] NOT NULL,
	[PrecioActualizado] [money] NULL,
	[Cantidad] [decimal](18, 2) NOT NULL,
	[Desincronizado] [bit] NOT NULL,
	[FechaUltimaModificacion] [datetime2](7) NULL,
	[Eliminado] [bit] NOT NULL,
	[StockTransaccionId] [int] NOT NULL,
 CONSTRAINT [PK_CompraProducto] PRIMARY KEY CLUSTERED 
(
	[CompraProductoId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[Factura_ObtenerAbiertasPorUsuario]    Script Date: 05/07/2014 23:26:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Factura_ObtenerAbiertasPorUsuario]
	@UsuarioId int,
	@MaxiKioscoId int
AS
BEGIN
	DECLARE @AdminRoleId int
	SET @AdminRoleId = (SELECT TOP 1 UR.RoleId
						FROM dbo.webpages_UsersInRoles UR
							INNER JOIN  dbo.webpages_Roles R
							ON UR.RoleId = R.RoleId
						WHERE @UsuarioId = UR.UserId
							AND R.RoleName = 'Administrador')
	
	IF @AdminRoleId IS NOT NULL
	
	SELECT F.*,
			NombreCompleto = F.FacturaNro + ' (' + P.Nombre + ')'
	FROM Factura F
		LEFT JOIN Proveedor P ON F.ProveedorId = P.ProveedorId
	WHERE 
		NOT EXISTS (SELECT 1
						 FROM Compra
						 WHERE FacturaId = F.FacturaId)
		AND ((@AdminRoleID IS NOT NULL) 
			  OR (F.ProveedorId IN (SELECT ProveedorId
									FROM UsuarioProveedor
									WHERE UsuarioId = @UsuarioId
								   )
				 )	  
		)
		AND F.MaxiKioscoId = @MaxiKioscoId
END
GO
/****** Object:  StoredProcedure [dbo].[Exportacion_NuevoXml]    Script Date: 05/07/2014 23:26:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Exportacion_NuevoXml]
	@UsuarioId int
AS
BEGIN
	DECLARE @Secuencia int
	SELECT @Secuencia = ISNULL(MAX(Secuencia) + 1, 1) FROM Exportacion
	
	DECLARE @CuentaId int
	SELECT @CuentaId = (SELECT TOP 1 CuentaId FROM Usuario WHERE UsuarioId = @UsuarioId)	
	
	DECLARE @ExportacionId int
	SET @ExportacionId = 0
	
	DECLARE @XML XML
	
	BEGIN TRY
    BEGIN TRAN
		--OBTENGO EL XML
		SET @XML = (
		SELECT
		(SELECT * FROM Producto WHERE Desincronizado = 1	FOR XML AUTO, ELEMENTS, ROOT('Productos'), TYPE),
		(SELECT * FROM Proveedor WHERE Desincronizado = 1 FOR XML AUTO, ELEMENTS, ROOT('Proveedores'), TYPE),
		(SELECT * FROM CierreCaja WHERE Desincronizado = 1 FOR XML AUTO, ELEMENTS, ROOT('CierreCaja'), TYPE),
		(SELECT * FROM CodigoProducto WHERE Desincronizado = 1 FOR XML AUTO, ELEMENTS, ROOT('CodigosProducto'), TYPE),
		(SELECT * FROM ExcepcionRubro WHERE Desincronizado = 1 FOR XML AUTO, ELEMENTS, ROOT('ExcepcionesRubros'), TYPE),
		(SELECT * FROM Factura WHERE Desincronizado = 1 FOR XML AUTO, ELEMENTS, ROOT('Facturas'), TYPE),
		(SELECT * FROM Marca WHERE Desincronizado = 1 FOR XML AUTO, ELEMENTS, ROOT('Marcas'), TYPE),
		(SELECT * FROM MaxiKiosco WHERE Desincronizado = 1 FOR XML AUTO, ELEMENTS, ROOT('MaxiKioscos'), TYPE),
		(SELECT * FROM OperacionCaja WHERE Desincronizado = 1 FOR XML AUTO, ELEMENTS, ROOT('OperacionesCaja'), TYPE),
		(SELECT * FROM ProveedorProducto WHERE Desincronizado = 1 FOR XML AUTO, ELEMENTS, ROOT('ProveedorProductos'), TYPE),
		(SELECT * FROM Rubro WHERE Desincronizado = 1 FOR XML AUTO, ELEMENTS, ROOT('Rubro'), TYPE),
		(SELECT * FROM Usuario WHERE Desincronizado = 1 FOR XML AUTO, ELEMENTS, ROOT('Usuario'), TYPE),
		(SELECT UM.*, 
				M.Identifier MaxiKioscoIdentifier,
				U.Identifier UsuarioIdentifier
			FROM UsuarioMaxiKiosco  UM
				INNER JOIN Usuario U ON UM.UsuarioId = U.UsuarioId
				INNER JOIN MaxiKiosco M ON UM.MaxiKioscoId = M.MaxiKioscoId
			WHERE UM.Desincronizado = 1 FOR XML AUTO, ELEMENTS, ROOT('UsuarioMaxiKioscos'), TYPE),
		(SELECT UP.*, 
				P.Identifier ProveedorIdentifier,
				U.Identifier UsuarioIdentifier
			FROM UsuarioProveedor UP
				INNER JOIN Usuario U ON UP.UsuarioId = U.UsuarioId
				INNER JOIN Proveedor P ON UP.ProveedorId = P.ProveedorId
			WHERE UP.Desincronizado = 1 FOR XML AUTO, ELEMENTS, ROOT('UsuarioMaxiKioscos'), TYPE),
		(SELECT * FROM Venta WHERE Desincronizado = 1 FOR XML AUTO, ELEMENTS, ROOT('Ventas'), TYPE),
		(SELECT VP.*, VentaIdentifier = V.Identifier FROM VentaProducto VP 
		 INNER JOIN Venta V ON VP.VentaId = V.VentaId
		 WHERE V.Desincronizado = 1 FOR XML AUTO, ELEMENTS, ROOT('VentaProductos'), TYPE),
		(SELECT M.*, UsuarioIdentifier = U.Identifier 
		 FROM webpages_Membership M 
		 INNER JOIN Usuario U ON M.UserId = U.UsuarioId
		 WHERE U.Desincronizado = 1 FOR XML AUTO, ELEMENTS, ROOT('Membership'), TYPE),
		 (SELECT UR.*, UsuarioIdentifier = U.Identifier 
		 FROM webpages_UsersInRoles UR 
		 INNER JOIN Usuario U ON UR.UserId = U.UsuarioId
		 WHERE U.Desincronizado = 1 FOR XML AUTO, ELEMENTS, ROOT('UsersInRoles'), TYPE)
		
		FOR XML PATH(''), ROOT('Exportacion'))
		
		--RESETEO LOS BIT DESINCRONIZADOS
		UPDATE Producto SET Desincronizado = 0 WHERE Desincronizado = 1
		UPDATE Proveedor SET Desincronizado = 0 WHERE Desincronizado = 1
		UPDATE CierreCaja SET Desincronizado = 0 WHERE Desincronizado = 1
		UPDATE CodigoProducto SET Desincronizado = 0 WHERE Desincronizado = 1
		UPDATE ExcepcionRubro SET Desincronizado = 0 WHERE Desincronizado = 1
		UPDATE Factura SET Desincronizado = 0 WHERE Desincronizado = 1
		UPDATE Marca SET Desincronizado = 0 WHERE Desincronizado = 1
		UPDATE MaxiKiosco SET Desincronizado = 0 WHERE Desincronizado = 1
		UPDATE OperacionCaja SET Desincronizado = 0 WHERE Desincronizado = 1
		UPDATE ProveedorProducto SET Desincronizado = 0 WHERE Desincronizado = 1
		UPDATE Rubro SET Desincronizado = 0 WHERE Desincronizado = 1
		UPDATE Usuario SET Desincronizado = 0 WHERE Desincronizado = 1
		UPDATE UsuarioMaxiKiosco SET Desincronizado = 0 WHERE Desincronizado = 1
		UPDATE Venta SET Desincronizado = 0 WHERE Desincronizado = 1
		
		--INSERTAMOS EL NUEVO XML
		INSERT INTO Exportacion(Secuencia, Fecha, CreadorId, CuentaId, Archivo, Eliminado, FechaUltimaModificacion)
		VALUES (@Secuencia, GETDATE(), @UsuarioId, @CuentaId, @XML, 0, GETDATE())
	
	COMMIT TRAN
	
	SET @ExportacionId = CONVERT(INT,SCOPE_IDENTITY())
	SELECT @ExportacionId AS ExportacionId
	
	END TRY
	
	BEGIN CATCH
    
    IF @@TRANCOUNT > 0 ROLLBACK

    SELECT 0 AS ExportacionId
	
    /*************************************
    *  Return from the Stored Procedure
    *************************************/
    RETURN 0                               -- =0 if success,  <>0 if failure

END CATCH
	
	
	
END
GO
/****** Object:  StoredProcedure [dbo].[Producto_ListadoCompleto]    Script Date: 05/07/2014 23:26:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Producto_ListadoCompleto]
	@MaxiKioscoId int,
	@ProveedorId int
AS
BEGIN
	
	SELECT  P.ProductoId, 
			Codigo = (SELECT SUBSTRING(
					(SELECT ',' + Codigo
					FROM CodigoProducto CP WHERE CP.ProductoId = P.ProductoId
					FOR XML PATH('')),2,200000)),
			P.Descripcion,
			P.AceptaCantidadesDecimales,
			Marca = M.Descripcion,
			Stock = ISNULL((SELECT SUM(ST.Cantidad)
					FROM StockTransaccion ST
						LEFT JOIN Stock S ON ST.StockId = S.StockId
						WHERE S.ProductoId = P.ProductoId
							AND S.MaxiKioscoId = @MaxiKioscoId
							AND S.Eliminado = 0
							AND ST.Eliminado = 0
			), 0),
			Costo = PP.Costo,
			Precio = P.Precio
		FROM Producto P
			LEFT JOIN ProveedorProducto PP
				ON P.ProductoId = PP.ProductoId
					AND PP.ProveedorId = @ProveedorId
			LEFT JOIN Marca M
				ON P.MarcaId = M.MarcaId
		WHERE P.Eliminado = 0
			AND (PP.Eliminado IS NULL OR PP.Eliminado = 0)
		
END
GO
/****** Object:  StoredProcedure [dbo].[Rpt_VentasPorProductoRanking]    Script Date: 05/07/2014 23:26:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Rpt_VentasPorProductoRanking]
	@Desde datetime2(7),
	@Hasta datetime2(7),
	@CuentaId int
AS
BEGIN
	SELECT TOP 10
	   Producto = P.Descripcion 
	  ,PrecioPromedio = AVG(VP.Precio)
	  ,CantidadTotal = SUM(VP.Cantidad) 
	  ,VentaTotal = SUM(VP.Precio * VP.Cantidad) 
	FROM
	  VentaProducto VP
	  INNER JOIN Producto P
		ON VP.ProductoId = P.ProductoId
	  INNER JOIN Venta V
		ON VP.VentaId = V.VentaId
	WHERE 
	        (@Desde IS NULL OR V.FechaVenta >= @Desde)
		AND (@Hasta IS NULL OR V.FechaVenta <= @Hasta)
		AND (@CuentaId IS NULL OR P.CuentaId = @CuentaId)
	GROUP BY P.Descripcion
	ORDER BY VentaTotal DESC
END
GO
/****** Object:  StoredProcedure [dbo].[Rpt_VentasPorProducto]    Script Date: 05/07/2014 23:26:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Rpt_VentasPorProducto]
	@Desde datetime2(7),
	@Hasta datetime2(7),
	@RubroId int,
	@CuentaId int
AS
BEGIN
	SELECT
	   Rubro = R.Descripcion
	  ,Producto = P.Descripcion 
	  ,PrecioPromedio = AVG(VP.Precio)
	  ,CantidadTotal = SUM(VP.Cantidad) 
	  ,VentaTotal = SUM(VP.Precio * VP.Cantidad) 
	FROM
	  VentaProducto VP
	  INNER JOIN Producto P
		ON VP.ProductoId = P.ProductoId
	  INNER JOIN Rubro R
		ON P.RubroId = R.RubroId
	  INNER JOIN Venta V
		ON VP.VentaId = V.VentaId
	WHERE 
	        (@Desde IS NULL OR V.FechaVenta >= @Desde)
		AND (@Hasta IS NULL OR V.FechaVenta <= @Hasta)
		AND (@RubroId IS NULL OR R.RubroId = @RubroId)
		AND (@CuentaId IS NULL OR P.CuentaId = @CuentaId)
	GROUP BY R.Descripcion,P.Descripcion
	ORDER BY VentaTotal DESC
END
GO
/****** Object:  StoredProcedure [dbo].[Rpt_CierresDeCajaDetalle]    Script Date: 05/07/2014 23:26:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Rpt_CierresDeCajaDetalle]
	@Desde datetime2(7),
	@Hasta datetime2(7),
	@MaxiKioscoId int,
	@UsuarioId int,
	@CuentaId int
AS
BEGIN
	SELECT
	   MaxiKioscoNombre = M.Nombre
	  ,MaxiKioscoDireccion = M.Direccion
	  ,UsuarioNombre = U.Nombre 
	  ,UsuarioApellido = U.Apellido
	  ,Fecha = CC.FechaInicio
	  ,Inicial = CC.CajaInicial
	  ,Ventas = V.Monto
	  ,Compras = C.Monto
	  ,Ingresos = OPCR.Monto
	  ,Gastos = 0
	  ,Retiros = OPCE.Monto
	  ,Diferencia = V.Monto + OPCR.Monto - OPCE.Monto
	  ,Cierre = CC.CajaFinal
	 
	FROM
	  CierreCaja CC
	  INNER JOIN OperacionCaja OPC
		ON CC.CierreCajaId = OPC.CierreCajaId
	  INNER JOIN MaxiKiosco M
		ON CC.MaxiKioskoId = M.MaxiKioscoId
	  INNER JOIN Usuario U 
		ON CC.UsuarioId = U.UsuarioId
	  CROSS APPLY (SELECT Monto = SUM(V.ImporteTotal) 
				   FROM Venta V 
				   WHERE V.CierreCajaId = CC.CierreCajaid) V
	  CROSS APPLY (SELECT Monto = SUM(CP.Cantidad * CP.CostoActualizado) 
				   FROM Compra C
				   INNER JOIN CompraProducto CP 
				   ON C.CompraId = CP.CompraId
				   WHERE C.Fecha >= CC.FechaInicio AND C.Fecha <= CC.FechaFin) C
	  CROSS APPLY (SELECT Monto = SUM(OPC.Monto) 
				   FROM OperacionCaja OPC 
				   WHERE OPC.CierreCajaId = CC.CierreCajaid
				   --MotivoId = 1 Refuerzo
				   AND OPC.MotivoId = 1) OPCR
	  CROSS APPLY (SELECT Monto = SUM(OPC.Monto) 
				   FROM OperacionCaja OPC 
				   WHERE OPC.CierreCajaId = CC.CierreCajaid
				   --MotivoId = 2 Extracción
				   AND OPC.MotivoId = 2) OPCE
							
	 WHERE 
	        (@Desde IS NULL OR CC.FechaInicio >= @Desde)
		AND (@Hasta IS NULL OR CC.FechaInicio <= @Hasta)
		AND (@MaxiKioscoId IS NULL OR CC.MaxiKioskoId = @MaxiKioscoId)
		AND (@UsuarioId IS NULL OR CC.UsuarioId = @UsuarioId)
		AND (@CuentaId IS NULL OR M.CuentaId = @CuentaId)
	
END
GO
/****** Object:  StoredProcedure [dbo].[Exportacion_NuevoXmlPrincipal]    Script Date: 05/07/2014 23:26:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Exportacion_NuevoXmlPrincipal]
	@UsuarioId int
AS
BEGIN
	DECLARE @Secuencia int
	SELECT @Secuencia = ISNULL(MAX(Secuencia) + 1, 1) FROM Exportacion
	
	DECLARE @CuentaId int
	SELECT @CuentaId = (SELECT TOP 1 CuentaId FROM Usuario WHERE UsuarioId = @UsuarioId)	
	
	DECLARE @ExportacionId int
	SET @ExportacionId = 0
	
	DECLARE @XML XML
	
	BEGIN TRY
    BEGIN TRAN
		--OBTENGO EL XML
		SET @XML = (
		SELECT
		(SELECT * FROM CodigoProducto WHERE Desincronizado = 1 FOR XML AUTO, ELEMENTS, ROOT('CodigosProducto'), TYPE),
		(SELECT * FROM Compra WHERE Desincronizado = 1 FOR XML AUTO, ELEMENTS, ROOT('Compras'), TYPE),
		(SELECT CP.*, CompraIdentifier = C.Identifier FROM 
		 CompraProducto CP 
		 INNER JOIN Compra C ON CP.CompraId = C.CompraId
		 WHERE C.Desincronizado = 1 FOR XML AUTO, ELEMENTS, ROOT('CompraProductos'), TYPE),
		(SELECT CS.*, ProductoIdentifier = P.Identifier, CierreCajaIdentifier = CC.Identifier
		 FROM CorreccionStock CS
			INNER JOIN Producto P ON CS.ProductoId = P.ProductoId
			INNER JOIN CierreCaja CC ON CS.CierreCajaId = CC.CierreCajaId
		 WHERE CS.Desincronizado = 1 FOR XML AUTO, ELEMENTS, ROOT('CorreccionesStock'), TYPE),
		 (SELECT ST.*, StockIdentifier = S.Identifier
		 FROM StockTransaccion ST
			INNER JOIN Stock S ON ST.StockId = S.StockId
		 WHERE ST.Desincronizado = 1 FOR XML AUTO, ELEMENTS, ROOT('StockTransacciones'), TYPE),
		(SELECT * FROM Cuenta WHERE Desincronizado = 1	FOR XML AUTO, ELEMENTS, ROOT('Cuentas'), TYPE),
		(SELECT * FROM ExcepcionRubro WHERE Desincronizado = 1 FOR XML AUTO, ELEMENTS, ROOT('ExcepcionesRubros'), TYPE),
		(SELECT * FROM Marca WHERE Desincronizado = 1 FOR XML AUTO, ELEMENTS, ROOT('Marcas'), TYPE),
		(SELECT MT.*, MaxiKioscoIdentifier = M.Identifier 
		FROM MaxiKioscoTurno MT
			INNER JOIN MaxiKiosco M
				ON MT.MaxiKioscoId = M.MaxiKioscoId
		WHERE MT.Desincronizado = 1 FOR XML AUTO, ELEMENTS, ROOT('MaxiKioscoTurnos'), TYPE),
		(SELECT * FROM Producto WHERE Desincronizado = 1	FOR XML AUTO, ELEMENTS, ROOT('Productos'), TYPE),
		(SELECT * FROM Proveedor WHERE Desincronizado = 1 FOR XML AUTO, ELEMENTS, ROOT('Proveedores'), TYPE),
		(SELECT * FROM ProveedorProducto WHERE Desincronizado = 1 FOR XML AUTO, ELEMENTS, ROOT('ProveedorProductos'), TYPE),
		(SELECT * FROM Rubro WHERE Desincronizado = 1 FOR XML AUTO, ELEMENTS, ROOT('Rubro'), TYPE),
		(SELECT S.*, MaxiKioscoIdentifier = M.Identifier, ProductoIdentifier = P.Identifier
		 FROM Stock S
			INNER JOIN Producto P
				ON S.ProductoId = P.ProductoId
			INNER JOIN MaxiKiosco M
				ON S.MaxiKioscoId = M.MaxiKioscoId
		 WHERE S.Desincronizado = 1 FOR XML AUTO, ELEMENTS, ROOT('Stock'), TYPE),
		(SELECT * FROM Usuario WHERE Desincronizado = 1 FOR XML AUTO, ELEMENTS, ROOT('Usuario'), TYPE),
		(SELECT UM.*, 
				M.Identifier MaxiKioscoIdentifier,
				U.Identifier UsuarioIdentifier
			FROM UsuarioMaxiKiosco  UM
				INNER JOIN Usuario U ON UM.UsuarioId = U.UsuarioId
				INNER JOIN MaxiKiosco M ON UM.MaxiKioscoId = M.MaxiKioscoId
			WHERE UM.Desincronizado = 1 FOR XML AUTO, ELEMENTS, ROOT('UsuarioMaxiKioscos'), TYPE),
		(SELECT UP.*, 
				P.Identifier ProveedorIdentifier,
				U.Identifier UsuarioIdentifier
			FROM UsuarioProveedor UP
				INNER JOIN Usuario U ON UP.UsuarioId = U.UsuarioId
				INNER JOIN Proveedor P ON UP.ProveedorId = P.ProveedorId
			WHERE UP.Desincronizado = 1 FOR XML AUTO, ELEMENTS, ROOT('UsuarioProveedores'), TYPE),
		(SELECT M.*, UsuarioIdentifier = U.Identifier 
		 FROM webpages_Membership M 
		 INNER JOIN Usuario U ON M.UserId = U.UsuarioId
		 WHERE U.Desincronizado = 1 FOR XML AUTO, ELEMENTS, ROOT('Membership'), TYPE),
		 (SELECT UR.*, UsuarioIdentifier = U.Identifier 
		 FROM webpages_UsersInRoles UR 
		 INNER JOIN Usuario U ON UR.UserId = U.UsuarioId
		 WHERE U.Desincronizado = 1 FOR XML AUTO, ELEMENTS, ROOT('UsersInRoles'), TYPE)
		
		FOR XML PATH(''), ROOT('Exportacion'))
		
		--RESETEO LOS BIT DESINCRONIZADOS
		UPDATE CodigoProducto SET Desincronizado = 0 WHERE Desincronizado = 1
		UPDATE Compra SET Desincronizado = 0 WHERE Desincronizado = 1
		UPDATE CompraProducto SET Desincronizado = 0 WHERE Desincronizado = 1
		UPDATE CorreccionStock SET Desincronizado = 0 WHERE Desincronizado = 1
		UPDATE StockTransaccion SET Desincronizado = 0 WHERE Desincronizado = 1
		UPDATE Cuenta SET Desincronizado = 0 WHERE Desincronizado = 1
		UPDATE ExcepcionRubro SET Desincronizado = 0 WHERE Desincronizado = 1
		UPDATE Marca SET Desincronizado = 0 WHERE Desincronizado = 1
		UPDATE MaxiKioscoTurno SET Desincronizado = 0 WHERE Desincronizado = 1
		UPDATE Producto SET Desincronizado = 0 WHERE Desincronizado = 1
		UPDATE Proveedor SET Desincronizado = 0 WHERE Desincronizado = 1
		UPDATE ProveedorProducto SET Desincronizado = 0 WHERE Desincronizado = 1
		UPDATE Rubro SET Desincronizado = 0 WHERE Desincronizado = 1
		UPDATE Stock SET Desincronizado = 0 WHERE Desincronizado = 1
		UPDATE Usuario SET Desincronizado = 0 WHERE Desincronizado = 1
		UPDATE UsuarioMaxiKiosco SET Desincronizado = 0 WHERE Desincronizado = 1
		UPDATE UsuarioProveedor SET Desincronizado = 0 WHERE Desincronizado = 1
		--INSERTAMOS EL NUEVO XML
		INSERT INTO Exportacion(Secuencia, Fecha, CreadorId, CuentaId, Archivo, Eliminado, FechaUltimaModificacion)
		VALUES (@Secuencia, GETDATE(), @UsuarioId, @CuentaId, @XML, 0, GETDATE())
	
	COMMIT TRAN
	
	SET @ExportacionId = CONVERT(INT,SCOPE_IDENTITY())
	SELECT @ExportacionId AS ExportacionId
	
	END TRY
	
	BEGIN CATCH
    
    IF @@TRANCOUNT > 0 ROLLBACK

    SELECT 0 AS ExportacionId
	
    /*************************************
    *  Return from the Stored Procedure
    *************************************/
    RETURN 0                               -- =0 if success,  <>0 if failure

END CATCH
	
	
	
END
GO
/****** Object:  StoredProcedure [dbo].[Exportacion_NuevoXmlKiosco]    Script Date: 05/07/2014 23:26:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Exportacion_NuevoXmlKiosco]
	@UsuarioId int
AS
BEGIN
	DECLARE @Secuencia int
	SELECT @Secuencia = ISNULL(MAX(Secuencia) + 1, 1) FROM Exportacion
	
	DECLARE @CuentaId int
	SELECT @CuentaId = (SELECT TOP 1 CuentaId FROM Usuario WHERE UsuarioId = @UsuarioId)	
	
	DECLARE @ExportacionId int
	SET @ExportacionId = 0
	
	DECLARE @XML XML
	
	BEGIN TRY
    BEGIN TRAN
		--OBTENGO EL XML
		SET @XML = (
		SELECT
		(SELECT * FROM Producto WHERE Desincronizado = 1	FOR XML AUTO, ELEMENTS, ROOT('Productos'), TYPE),
		(SELECT * FROM CierreCaja WHERE Desincronizado = 1 FOR XML AUTO, ELEMENTS, ROOT('CierreCaja'), TYPE),
		(SELECT * FROM CodigoProducto WHERE Desincronizado = 1 FOR XML AUTO, ELEMENTS, ROOT('CodigosProducto'), TYPE),
		(SELECT * FROM Factura WHERE Desincronizado = 1 FOR XML AUTO, ELEMENTS, ROOT('Facturas'), TYPE),
		(SELECT * FROM OperacionCaja WHERE Desincronizado = 1 FOR XML AUTO, ELEMENTS, ROOT('OperacionesCaja'), TYPE),
		(SELECT * FROM ProveedorProducto WHERE Desincronizado = 1 FOR XML AUTO, ELEMENTS, ROOT('ProveedorProductos'), TYPE),
		(SELECT * FROM Venta WHERE Desincronizado = 1 FOR XML AUTO, ELEMENTS, ROOT('Ventas'), TYPE),
		(SELECT VP.*, VentaIdentifier = V.Identifier FROM 
		 VentaProducto VP 
		 INNER JOIN Venta V ON VP.VentaId = V.VentaId
		 WHERE V.Desincronizado = 1 FOR XML AUTO, ELEMENTS, ROOT('VentaProductos'), TYPE),
		(SELECT * FROM Compra WHERE Desincronizado = 1 FOR XML AUTO, ELEMENTS, ROOT('Compras'), TYPE),
		(SELECT CP.*, CompraIdentifier = C.Identifier FROM 
		 CompraProducto CP 
		 INNER JOIN Compra C ON CP.CompraId = C.CompraId
		 WHERE C.Desincronizado = 1 FOR XML AUTO, ELEMENTS, ROOT('CompraProductos'), TYPE),
		 (SELECT CS.*, ProductoIdentifier = P.Identifier, CierreCajaIdentifier = CC.Identifier
		 FROM CorreccionStock CS
			INNER JOIN Producto P ON CS.ProductoId = P.ProductoId
			INNER JOIN CierreCaja CC ON CS.CierreCajaId = CC.CierreCajaId
		 WHERE CS.Desincronizado = 1 FOR XML AUTO, ELEMENTS, ROOT('CorreccionesStock'), TYPE),
		 (SELECT ST.*, StockIdentifier = S.Identifier
		 FROM StockTransaccion ST
			INNER JOIN Stock S ON ST.StockId = S.StockId
		 WHERE ST.Desincronizado = 1 FOR XML AUTO, ELEMENTS, ROOT('StockTransacciones'), TYPE),
		 (SELECT E.*, CierreCajaIdentifier = CC.Identifier
		 FROM Excepcion E
			INNER JOIN CierreCaja CC ON E.CierreCajaId = CC.CierreCajaId
		 WHERE E.Desincronizado = 1 FOR XML AUTO, ELEMENTS, ROOT('Excepciones'), TYPE)
		 
		
		FOR XML PATH(''), ROOT('Exportacion'))
		
		--RESETEO LOS BIT DESINCRONIZADOS
		UPDATE Producto SET Desincronizado = 0 WHERE Desincronizado = 1
		UPDATE CierreCaja SET Desincronizado = 0 WHERE Desincronizado = 1
		UPDATE CodigoProducto SET Desincronizado = 0 WHERE Desincronizado = 1
		UPDATE Factura SET Desincronizado = 0 WHERE Desincronizado = 1
		UPDATE OperacionCaja SET Desincronizado = 0 WHERE Desincronizado = 1
		UPDATE ProveedorProducto SET Desincronizado = 0 WHERE Desincronizado = 1
		UPDATE Venta SET Desincronizado = 0 WHERE Desincronizado = 1
		UPDATE VentaProducto SET Desincronizado = 0 WHERE Desincronizado = 1
		UPDATE Compra SET Desincronizado = 0 WHERE Desincronizado = 1
		UPDATE CompraProducto SET Desincronizado = 0 WHERE Desincronizado = 1
		UPDATE CorreccionStock SET Desincronizado = 0 WHERE Desincronizado = 1
		UPDATE StockTransaccion SET Desincronizado = 0 WHERE Desincronizado = 1
		UPDATE Excepcion SET Desincronizado = 0 WHERE Desincronizado = 1
		
		--INSERTAMOS EL NUEVO XML
		INSERT INTO Exportacion(Secuencia, Fecha, CreadorId, CuentaId, Archivo, Eliminado, FechaUltimaModificacion)
		VALUES (@Secuencia, GETDATE(), @UsuarioId, @CuentaId, @XML, 0, GETDATE())
	
	COMMIT TRAN
	
	SET @ExportacionId = CONVERT(INT,SCOPE_IDENTITY())
	SELECT @ExportacionId AS ExportacionId
	
	END TRY
	
	BEGIN CATCH
    
    IF @@TRANCOUNT > 0 ROLLBACK

    SELECT 0 AS ExportacionId
	
    /*************************************
    *  Return from the Stored Procedure
    *************************************/
    RETURN 0                               -- =0 if success,  <>0 if failure

END CATCH
	
	
	
END
GO
/****** Object:  Default [DF__webpages___IsCon__48CFD27E]    Script Date: 05/07/2014 23:26:51 ******/
ALTER TABLE [dbo].[webpages_Membership] ADD  DEFAULT ((0)) FOR [IsConfirmed]
GO
/****** Object:  Default [DF__webpages___Passw__49C3F6B7]    Script Date: 05/07/2014 23:26:51 ******/
ALTER TABLE [dbo].[webpages_Membership] ADD  DEFAULT ((0)) FOR [PasswordFailuresSinceLastSuccess]
GO
/****** Object:  ForeignKey [FK_CierreCaja_MaxiKiosco]    Script Date: 05/07/2014 23:26:51 ******/
ALTER TABLE [dbo].[CierreCaja]  WITH CHECK ADD  CONSTRAINT [FK_CierreCaja_MaxiKiosco] FOREIGN KEY([MaxiKioskoId])
REFERENCES [dbo].[MaxiKiosco] ([MaxiKioscoId])
GO
ALTER TABLE [dbo].[CierreCaja] CHECK CONSTRAINT [FK_CierreCaja_MaxiKiosco]
GO
/****** Object:  ForeignKey [FK_CierreCaja_Usuario]    Script Date: 05/07/2014 23:26:51 ******/
ALTER TABLE [dbo].[CierreCaja]  WITH CHECK ADD  CONSTRAINT [FK_CierreCaja_Usuario] FOREIGN KEY([UsuarioId])
REFERENCES [dbo].[Usuario] ([UsuarioId])
GO
ALTER TABLE [dbo].[CierreCaja] CHECK CONSTRAINT [FK_CierreCaja_Usuario]
GO
/****** Object:  ForeignKey [FK_CodigoProducto_Producto]    Script Date: 05/07/2014 23:26:51 ******/
ALTER TABLE [dbo].[CodigoProducto]  WITH CHECK ADD  CONSTRAINT [FK_CodigoProducto_Producto] FOREIGN KEY([ProductoId])
REFERENCES [dbo].[Producto] ([ProductoId])
GO
ALTER TABLE [dbo].[CodigoProducto] CHECK CONSTRAINT [FK_CodigoProducto_Producto]
GO
/****** Object:  ForeignKey [FK_Compra_Cuenta]    Script Date: 05/07/2014 23:26:51 ******/
ALTER TABLE [dbo].[Compra]  WITH CHECK ADD  CONSTRAINT [FK_Compra_Cuenta] FOREIGN KEY([CuentaId])
REFERENCES [dbo].[Cuenta] ([CuentaId])
GO
ALTER TABLE [dbo].[Compra] CHECK CONSTRAINT [FK_Compra_Cuenta]
GO
/****** Object:  ForeignKey [FK_Compra_Factura]    Script Date: 05/07/2014 23:26:51 ******/
ALTER TABLE [dbo].[Compra]  WITH CHECK ADD  CONSTRAINT [FK_Compra_Factura] FOREIGN KEY([FacturaId])
REFERENCES [dbo].[Factura] ([FacturaId])
GO
ALTER TABLE [dbo].[Compra] CHECK CONSTRAINT [FK_Compra_Factura]
GO
/****** Object:  ForeignKey [FK_Compra_MaxiKiosco]    Script Date: 05/07/2014 23:26:51 ******/
ALTER TABLE [dbo].[Compra]  WITH CHECK ADD  CONSTRAINT [FK_Compra_MaxiKiosco] FOREIGN KEY([MaxiKioscoId])
REFERENCES [dbo].[MaxiKiosco] ([MaxiKioscoId])
GO
ALTER TABLE [dbo].[Compra] CHECK CONSTRAINT [FK_Compra_MaxiKiosco]
GO
/****** Object:  ForeignKey [FK_CompraProducto_Compra]    Script Date: 05/07/2014 23:26:51 ******/
ALTER TABLE [dbo].[CompraProducto]  WITH CHECK ADD  CONSTRAINT [FK_CompraProducto_Compra] FOREIGN KEY([CompraId])
REFERENCES [dbo].[Compra] ([CompraId])
GO
ALTER TABLE [dbo].[CompraProducto] CHECK CONSTRAINT [FK_CompraProducto_Compra]
GO
/****** Object:  ForeignKey [FK_CompraProducto_Producto]    Script Date: 05/07/2014 23:26:51 ******/
ALTER TABLE [dbo].[CompraProducto]  WITH CHECK ADD  CONSTRAINT [FK_CompraProducto_Producto] FOREIGN KEY([ProductoId])
REFERENCES [dbo].[Producto] ([ProductoId])
GO
ALTER TABLE [dbo].[CompraProducto] CHECK CONSTRAINT [FK_CompraProducto_Producto]
GO
/****** Object:  ForeignKey [FK_CompraProducto_StockTransaccion]    Script Date: 05/07/2014 23:26:51 ******/
ALTER TABLE [dbo].[CompraProducto]  WITH CHECK ADD  CONSTRAINT [FK_CompraProducto_StockTransaccion] FOREIGN KEY([StockTransaccionId])
REFERENCES [dbo].[StockTransaccion] ([StockTransaccionId])
GO
ALTER TABLE [dbo].[CompraProducto] CHECK CONSTRAINT [FK_CompraProducto_StockTransaccion]
GO
/****** Object:  ForeignKey [FK_CorreccionStock_MaxiKiosco]    Script Date: 05/07/2014 23:26:51 ******/
ALTER TABLE [dbo].[CorreccionStock]  WITH CHECK ADD  CONSTRAINT [FK_CorreccionStock_MaxiKiosco] FOREIGN KEY([MaxiKioscoId])
REFERENCES [dbo].[MaxiKiosco] ([MaxiKioscoId])
GO
ALTER TABLE [dbo].[CorreccionStock] CHECK CONSTRAINT [FK_CorreccionStock_MaxiKiosco]
GO
/****** Object:  ForeignKey [FK_CorreccionStock_MotivoCorreccion]    Script Date: 05/07/2014 23:26:51 ******/
ALTER TABLE [dbo].[CorreccionStock]  WITH CHECK ADD  CONSTRAINT [FK_CorreccionStock_MotivoCorreccion] FOREIGN KEY([MotivoCorreccionId])
REFERENCES [dbo].[MotivoCorreccion] ([MotivoCorreccionId])
GO
ALTER TABLE [dbo].[CorreccionStock] CHECK CONSTRAINT [FK_CorreccionStock_MotivoCorreccion]
GO
/****** Object:  ForeignKey [FK_CorreccionStock_Producto]    Script Date: 05/07/2014 23:26:51 ******/
ALTER TABLE [dbo].[CorreccionStock]  WITH CHECK ADD  CONSTRAINT [FK_CorreccionStock_Producto] FOREIGN KEY([ProductoId])
REFERENCES [dbo].[Producto] ([ProductoId])
GO
ALTER TABLE [dbo].[CorreccionStock] CHECK CONSTRAINT [FK_CorreccionStock_Producto]
GO
/****** Object:  ForeignKey [FK_Excepcion_CierreCaja]    Script Date: 05/07/2014 23:26:51 ******/
ALTER TABLE [dbo].[Excepcion]  WITH CHECK ADD  CONSTRAINT [FK_Excepcion_CierreCaja] FOREIGN KEY([CierreCajaId])
REFERENCES [dbo].[CierreCaja] ([CierreCajaId])
GO
ALTER TABLE [dbo].[Excepcion] CHECK CONSTRAINT [FK_Excepcion_CierreCaja]
GO
/****** Object:  ForeignKey [FK_ExcepcionRubro_MaxiKiosco]    Script Date: 05/07/2014 23:26:51 ******/
ALTER TABLE [dbo].[ExcepcionRubro]  WITH CHECK ADD  CONSTRAINT [FK_ExcepcionRubro_MaxiKiosco] FOREIGN KEY([MaxiKioscoId])
REFERENCES [dbo].[MaxiKiosco] ([MaxiKioscoId])
GO
ALTER TABLE [dbo].[ExcepcionRubro] CHECK CONSTRAINT [FK_ExcepcionRubro_MaxiKiosco]
GO
/****** Object:  ForeignKey [FK_ExcepcionRubro_Rubro]    Script Date: 05/07/2014 23:26:51 ******/
ALTER TABLE [dbo].[ExcepcionRubro]  WITH CHECK ADD  CONSTRAINT [FK_ExcepcionRubro_Rubro] FOREIGN KEY([RubroId])
REFERENCES [dbo].[Rubro] ([RubroId])
GO
ALTER TABLE [dbo].[ExcepcionRubro] CHECK CONSTRAINT [FK_ExcepcionRubro_Rubro]
GO
/****** Object:  ForeignKey [FK_Exportacion_Cuenta]    Script Date: 05/07/2014 23:26:51 ******/
ALTER TABLE [dbo].[Exportacion]  WITH CHECK ADD  CONSTRAINT [FK_Exportacion_Cuenta] FOREIGN KEY([CuentaId])
REFERENCES [dbo].[Cuenta] ([CuentaId])
GO
ALTER TABLE [dbo].[Exportacion] CHECK CONSTRAINT [FK_Exportacion_Cuenta]
GO
/****** Object:  ForeignKey [FK_Exportacion_Usuario]    Script Date: 05/07/2014 23:26:51 ******/
ALTER TABLE [dbo].[Exportacion]  WITH CHECK ADD  CONSTRAINT [FK_Exportacion_Usuario] FOREIGN KEY([CreadorId])
REFERENCES [dbo].[Usuario] ([UsuarioId])
GO
ALTER TABLE [dbo].[Exportacion] CHECK CONSTRAINT [FK_Exportacion_Usuario]
GO
/****** Object:  ForeignKey [FK_Factura_CierreCaja]    Script Date: 05/07/2014 23:26:51 ******/
ALTER TABLE [dbo].[Factura]  WITH CHECK ADD  CONSTRAINT [FK_Factura_CierreCaja] FOREIGN KEY([CierreCajaId])
REFERENCES [dbo].[CierreCaja] ([CierreCajaId])
GO
ALTER TABLE [dbo].[Factura] CHECK CONSTRAINT [FK_Factura_CierreCaja]
GO
/****** Object:  ForeignKey [FK_Factura_MaxiKiosco]    Script Date: 05/07/2014 23:26:51 ******/
ALTER TABLE [dbo].[Factura]  WITH CHECK ADD  CONSTRAINT [FK_Factura_MaxiKiosco] FOREIGN KEY([MaxiKioscoId])
REFERENCES [dbo].[MaxiKiosco] ([MaxiKioscoId])
GO
ALTER TABLE [dbo].[Factura] CHECK CONSTRAINT [FK_Factura_MaxiKiosco]
GO
/****** Object:  ForeignKey [FK_Factura_Proveedor]    Script Date: 05/07/2014 23:26:51 ******/
ALTER TABLE [dbo].[Factura]  WITH CHECK ADD  CONSTRAINT [FK_Factura_Proveedor] FOREIGN KEY([ProveedorId])
REFERENCES [dbo].[Proveedor] ([ProveedorId])
GO
ALTER TABLE [dbo].[Factura] CHECK CONSTRAINT [FK_Factura_Proveedor]
GO
/****** Object:  ForeignKey [FK_Localidad_Provincia]    Script Date: 05/07/2014 23:26:51 ******/
ALTER TABLE [dbo].[Localidad]  WITH CHECK ADD  CONSTRAINT [FK_Localidad_Provincia] FOREIGN KEY([ProvinciaId])
REFERENCES [dbo].[Provincia] ([ProvinciaId])
GO
ALTER TABLE [dbo].[Localidad] CHECK CONSTRAINT [FK_Localidad_Provincia]
GO
/****** Object:  ForeignKey [FK_Marca_Cuenta]    Script Date: 05/07/2014 23:26:51 ******/
ALTER TABLE [dbo].[Marca]  WITH CHECK ADD  CONSTRAINT [FK_Marca_Cuenta] FOREIGN KEY([CuentaId])
REFERENCES [dbo].[Cuenta] ([CuentaId])
GO
ALTER TABLE [dbo].[Marca] CHECK CONSTRAINT [FK_Marca_Cuenta]
GO
/****** Object:  ForeignKey [FK_MaxiKiosco_Cuenta]    Script Date: 05/07/2014 23:26:51 ******/
ALTER TABLE [dbo].[MaxiKiosco]  WITH CHECK ADD  CONSTRAINT [FK_MaxiKiosco_Cuenta] FOREIGN KEY([CuentaId])
REFERENCES [dbo].[Cuenta] ([CuentaId])
GO
ALTER TABLE [dbo].[MaxiKiosco] CHECK CONSTRAINT [FK_MaxiKiosco_Cuenta]
GO
/****** Object:  ForeignKey [FK_MaxiKioscoTurno_MaxiKiosco]    Script Date: 05/07/2014 23:26:51 ******/
ALTER TABLE [dbo].[MaxiKioscoTurno]  WITH CHECK ADD  CONSTRAINT [FK_MaxiKioscoTurno_MaxiKiosco] FOREIGN KEY([MaxiKioscoId])
REFERENCES [dbo].[MaxiKiosco] ([MaxiKioscoId])
GO
ALTER TABLE [dbo].[MaxiKioscoTurno] CHECK CONSTRAINT [FK_MaxiKioscoTurno_MaxiKiosco]
GO
/****** Object:  ForeignKey [FK_MaxiKioscoTurno_Turno]    Script Date: 05/07/2014 23:26:51 ******/
ALTER TABLE [dbo].[MaxiKioscoTurno]  WITH CHECK ADD  CONSTRAINT [FK_MaxiKioscoTurno_Turno] FOREIGN KEY([TurnoId])
REFERENCES [dbo].[Turno] ([TurnoId])
GO
ALTER TABLE [dbo].[MaxiKioscoTurno] CHECK CONSTRAINT [FK_MaxiKioscoTurno_Turno]
GO
/****** Object:  ForeignKey [FK_OperacionCaja_CierreCaja]    Script Date: 05/07/2014 23:26:51 ******/
ALTER TABLE [dbo].[OperacionCaja]  WITH CHECK ADD  CONSTRAINT [FK_OperacionCaja_CierreCaja] FOREIGN KEY([CierreCajaId])
REFERENCES [dbo].[CierreCaja] ([CierreCajaId])
GO
ALTER TABLE [dbo].[OperacionCaja] CHECK CONSTRAINT [FK_OperacionCaja_CierreCaja]
GO
/****** Object:  ForeignKey [FK_OperacionCaja_MotivoOperacionCaja]    Script Date: 05/07/2014 23:26:51 ******/
ALTER TABLE [dbo].[OperacionCaja]  WITH CHECK ADD  CONSTRAINT [FK_OperacionCaja_MotivoOperacionCaja] FOREIGN KEY([MotivoId])
REFERENCES [dbo].[MotivoOperacionCaja] ([MotivoOperacionCajaId])
GO
ALTER TABLE [dbo].[OperacionCaja] CHECK CONSTRAINT [FK_OperacionCaja_MotivoOperacionCaja]
GO
/****** Object:  ForeignKey [FK_OperacionCaja_UsuarioCreador]    Script Date: 05/07/2014 23:26:51 ******/
ALTER TABLE [dbo].[OperacionCaja]  WITH CHECK ADD  CONSTRAINT [FK_OperacionCaja_UsuarioCreador] FOREIGN KEY([UsuarioCreadorId])
REFERENCES [dbo].[Usuario] ([UsuarioId])
GO
ALTER TABLE [dbo].[OperacionCaja] CHECK CONSTRAINT [FK_OperacionCaja_UsuarioCreador]
GO
/****** Object:  ForeignKey [FK_OperacionCaja_UsuarioModificador]    Script Date: 05/07/2014 23:26:51 ******/
ALTER TABLE [dbo].[OperacionCaja]  WITH CHECK ADD  CONSTRAINT [FK_OperacionCaja_UsuarioModificador] FOREIGN KEY([UltimoUsuarioModificacionId])
REFERENCES [dbo].[Usuario] ([UsuarioId])
GO
ALTER TABLE [dbo].[OperacionCaja] CHECK CONSTRAINT [FK_OperacionCaja_UsuarioModificador]
GO
/****** Object:  ForeignKey [FK_Producto_Cuenta]    Script Date: 05/07/2014 23:26:51 ******/
ALTER TABLE [dbo].[Producto]  WITH CHECK ADD  CONSTRAINT [FK_Producto_Cuenta] FOREIGN KEY([CuentaId])
REFERENCES [dbo].[Cuenta] ([CuentaId])
GO
ALTER TABLE [dbo].[Producto] CHECK CONSTRAINT [FK_Producto_Cuenta]
GO
/****** Object:  ForeignKey [FK_Producto_Marca]    Script Date: 05/07/2014 23:26:51 ******/
ALTER TABLE [dbo].[Producto]  WITH CHECK ADD  CONSTRAINT [FK_Producto_Marca] FOREIGN KEY([MarcaId])
REFERENCES [dbo].[Marca] ([MarcaId])
GO
ALTER TABLE [dbo].[Producto] CHECK CONSTRAINT [FK_Producto_Marca]
GO
/****** Object:  ForeignKey [FK_Producto_Rubro]    Script Date: 05/07/2014 23:26:51 ******/
ALTER TABLE [dbo].[Producto]  WITH CHECK ADD  CONSTRAINT [FK_Producto_Rubro] FOREIGN KEY([RubroId])
REFERENCES [dbo].[Rubro] ([RubroId])
GO
ALTER TABLE [dbo].[Producto] CHECK CONSTRAINT [FK_Producto_Rubro]
GO
/****** Object:  ForeignKey [FK_Proveedor_Cuenta]    Script Date: 05/07/2014 23:26:51 ******/
ALTER TABLE [dbo].[Proveedor]  WITH CHECK ADD  CONSTRAINT [FK_Proveedor_Cuenta] FOREIGN KEY([CuentaId])
REFERENCES [dbo].[Cuenta] ([CuentaId])
GO
ALTER TABLE [dbo].[Proveedor] CHECK CONSTRAINT [FK_Proveedor_Cuenta]
GO
/****** Object:  ForeignKey [FK_Proveedor_Localidad]    Script Date: 05/07/2014 23:26:51 ******/
ALTER TABLE [dbo].[Proveedor]  WITH CHECK ADD  CONSTRAINT [FK_Proveedor_Localidad] FOREIGN KEY([LocalidadId])
REFERENCES [dbo].[Localidad] ([LocalidadId])
GO
ALTER TABLE [dbo].[Proveedor] CHECK CONSTRAINT [FK_Proveedor_Localidad]
GO
/****** Object:  ForeignKey [FK_Proveedor_TipoCuit]    Script Date: 05/07/2014 23:26:51 ******/
ALTER TABLE [dbo].[Proveedor]  WITH CHECK ADD  CONSTRAINT [FK_Proveedor_TipoCuit] FOREIGN KEY([TipoCuitId])
REFERENCES [dbo].[TipoCuit] ([TipoCuitId])
GO
ALTER TABLE [dbo].[Proveedor] CHECK CONSTRAINT [FK_Proveedor_TipoCuit]
GO
/****** Object:  ForeignKey [FK_ProveedorProducto_Producto]    Script Date: 05/07/2014 23:26:51 ******/
ALTER TABLE [dbo].[ProveedorProducto]  WITH CHECK ADD  CONSTRAINT [FK_ProveedorProducto_Producto] FOREIGN KEY([ProductoId])
REFERENCES [dbo].[Producto] ([ProductoId])
GO
ALTER TABLE [dbo].[ProveedorProducto] CHECK CONSTRAINT [FK_ProveedorProducto_Producto]
GO
/****** Object:  ForeignKey [FK_ProveedorProducto_Proveedor]    Script Date: 05/07/2014 23:26:51 ******/
ALTER TABLE [dbo].[ProveedorProducto]  WITH CHECK ADD  CONSTRAINT [FK_ProveedorProducto_Proveedor] FOREIGN KEY([ProveedorId])
REFERENCES [dbo].[Proveedor] ([ProveedorId])
GO
ALTER TABLE [dbo].[ProveedorProducto] CHECK CONSTRAINT [FK_ProveedorProducto_Proveedor]
GO
/****** Object:  ForeignKey [FK_Rubro_Cuenta]    Script Date: 05/07/2014 23:26:51 ******/
ALTER TABLE [dbo].[Rubro]  WITH CHECK ADD  CONSTRAINT [FK_Rubro_Cuenta] FOREIGN KEY([CuentaId])
REFERENCES [dbo].[Cuenta] ([CuentaId])
GO
ALTER TABLE [dbo].[Rubro] CHECK CONSTRAINT [FK_Rubro_Cuenta]
GO
/****** Object:  ForeignKey [FK_ProductoMaxiKiosco_MaxiKiosco]    Script Date: 05/07/2014 23:26:51 ******/
ALTER TABLE [dbo].[Stock]  WITH CHECK ADD  CONSTRAINT [FK_ProductoMaxiKiosco_MaxiKiosco] FOREIGN KEY([MaxiKioscoId])
REFERENCES [dbo].[MaxiKiosco] ([MaxiKioscoId])
GO
ALTER TABLE [dbo].[Stock] CHECK CONSTRAINT [FK_ProductoMaxiKiosco_MaxiKiosco]
GO
/****** Object:  ForeignKey [FK_ProductoMaxiKiosco_Producto]    Script Date: 05/07/2014 23:26:51 ******/
ALTER TABLE [dbo].[Stock]  WITH CHECK ADD  CONSTRAINT [FK_ProductoMaxiKiosco_Producto] FOREIGN KEY([ProductoId])
REFERENCES [dbo].[Producto] ([ProductoId])
GO
ALTER TABLE [dbo].[Stock] CHECK CONSTRAINT [FK_ProductoMaxiKiosco_Producto]
GO
/****** Object:  ForeignKey [FK_StockTransaccion_Stock]    Script Date: 05/07/2014 23:26:51 ******/
ALTER TABLE [dbo].[StockTransaccion]  WITH CHECK ADD  CONSTRAINT [FK_StockTransaccion_Stock] FOREIGN KEY([StockId])
REFERENCES [dbo].[Stock] ([StockId])
GO
ALTER TABLE [dbo].[StockTransaccion] CHECK CONSTRAINT [FK_StockTransaccion_Stock]
GO
/****** Object:  ForeignKey [FK_StockTransaccion_StockTransaccionTipo]    Script Date: 05/07/2014 23:26:51 ******/
ALTER TABLE [dbo].[StockTransaccion]  WITH CHECK ADD  CONSTRAINT [FK_StockTransaccion_StockTransaccionTipo] FOREIGN KEY([StockTransaccionTipoId])
REFERENCES [dbo].[StockTransaccionTipo] ([StockTransaccionTipoId])
GO
ALTER TABLE [dbo].[StockTransaccion] CHECK CONSTRAINT [FK_StockTransaccion_StockTransaccionTipo]
GO
/****** Object:  ForeignKey [FK_Usuario_Cuenta]    Script Date: 05/07/2014 23:26:51 ******/
ALTER TABLE [dbo].[Usuario]  WITH CHECK ADD  CONSTRAINT [FK_Usuario_Cuenta] FOREIGN KEY([CuentaId])
REFERENCES [dbo].[Cuenta] ([CuentaId])
GO
ALTER TABLE [dbo].[Usuario] CHECK CONSTRAINT [FK_Usuario_Cuenta]
GO
/****** Object:  ForeignKey [FK_UsuarioMaxiKiosco_MaxiKiosco]    Script Date: 05/07/2014 23:26:51 ******/
ALTER TABLE [dbo].[UsuarioMaxiKiosco]  WITH CHECK ADD  CONSTRAINT [FK_UsuarioMaxiKiosco_MaxiKiosco] FOREIGN KEY([MaxiKioscoId])
REFERENCES [dbo].[MaxiKiosco] ([MaxiKioscoId])
GO
ALTER TABLE [dbo].[UsuarioMaxiKiosco] CHECK CONSTRAINT [FK_UsuarioMaxiKiosco_MaxiKiosco]
GO
/****** Object:  ForeignKey [FK_UsuarioMaxiKiosco_Usuario]    Script Date: 05/07/2014 23:26:51 ******/
ALTER TABLE [dbo].[UsuarioMaxiKiosco]  WITH CHECK ADD  CONSTRAINT [FK_UsuarioMaxiKiosco_Usuario] FOREIGN KEY([UsuarioId])
REFERENCES [dbo].[Usuario] ([UsuarioId])
GO
ALTER TABLE [dbo].[UsuarioMaxiKiosco] CHECK CONSTRAINT [FK_UsuarioMaxiKiosco_Usuario]
GO
/****** Object:  ForeignKey [FK_UsuarioProveedor_Proveedor]    Script Date: 05/07/2014 23:26:51 ******/
ALTER TABLE [dbo].[UsuarioProveedor]  WITH CHECK ADD  CONSTRAINT [FK_UsuarioProveedor_Proveedor] FOREIGN KEY([ProveedorId])
REFERENCES [dbo].[Proveedor] ([ProveedorId])
GO
ALTER TABLE [dbo].[UsuarioProveedor] CHECK CONSTRAINT [FK_UsuarioProveedor_Proveedor]
GO
/****** Object:  ForeignKey [FK_UsuarioProveedor_Usuario]    Script Date: 05/07/2014 23:26:51 ******/
ALTER TABLE [dbo].[UsuarioProveedor]  WITH CHECK ADD  CONSTRAINT [FK_UsuarioProveedor_Usuario] FOREIGN KEY([UsuarioId])
REFERENCES [dbo].[Usuario] ([UsuarioId])
GO
ALTER TABLE [dbo].[UsuarioProveedor] CHECK CONSTRAINT [FK_UsuarioProveedor_Usuario]
GO
/****** Object:  ForeignKey [FK_Venta_CierreCaja]    Script Date: 05/07/2014 23:26:51 ******/
ALTER TABLE [dbo].[Venta]  WITH CHECK ADD  CONSTRAINT [FK_Venta_CierreCaja] FOREIGN KEY([CierreCajaId])
REFERENCES [dbo].[CierreCaja] ([CierreCajaId])
GO
ALTER TABLE [dbo].[Venta] CHECK CONSTRAINT [FK_Venta_CierreCaja]
GO
/****** Object:  ForeignKey [FK_VentaProducto_Producto]    Script Date: 05/07/2014 23:26:51 ******/
ALTER TABLE [dbo].[VentaProducto]  WITH CHECK ADD  CONSTRAINT [FK_VentaProducto_Producto] FOREIGN KEY([ProductoId])
REFERENCES [dbo].[Producto] ([ProductoId])
GO
ALTER TABLE [dbo].[VentaProducto] CHECK CONSTRAINT [FK_VentaProducto_Producto]
GO
/****** Object:  ForeignKey [FK_VentaProducto_Venta]    Script Date: 05/07/2014 23:26:51 ******/
ALTER TABLE [dbo].[VentaProducto]  WITH CHECK ADD  CONSTRAINT [FK_VentaProducto_Venta] FOREIGN KEY([VentaId])
REFERENCES [dbo].[Venta] ([VentaId])
GO
ALTER TABLE [dbo].[VentaProducto] CHECK CONSTRAINT [FK_VentaProducto_Venta]
GO
/****** Object:  ForeignKey [fk_RoleId]    Script Date: 05/07/2014 23:26:51 ******/
ALTER TABLE [dbo].[webpages_UsersInRoles]  WITH CHECK ADD  CONSTRAINT [fk_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[webpages_Roles] ([RoleId])
GO
ALTER TABLE [dbo].[webpages_UsersInRoles] CHECK CONSTRAINT [fk_RoleId]
GO
/****** Object:  ForeignKey [fk_UserId]    Script Date: 05/07/2014 23:26:51 ******/
ALTER TABLE [dbo].[webpages_UsersInRoles]  WITH CHECK ADD  CONSTRAINT [fk_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[Usuario] ([UsuarioId])
GO
ALTER TABLE [dbo].[webpages_UsersInRoles] CHECK CONSTRAINT [fk_UserId]
GO

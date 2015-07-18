/****** Object:  Table [dbo].[ErrorSincronizacion]    Script Date: 10/04/2014 12:07:12 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ErrorSincronizacion]') AND type in (N'U'))
DROP TABLE [dbo].[ErrorSincronizacion]
GO


CREATE TABLE [dbo].[ErrorSincronizacion](
	[ErrorSincronizacionId] [int] IDENTITY(1,1) NOT NULL,
	[Numero] [int] NOT NULL,
	[Mensaje] [nvarchar](4000) NOT NULL,
 CONSTRAINT [PK_ErrorSincronizacion] PRIMARY KEY CLUSTERED 
(
	[ErrorSincronizacionId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO



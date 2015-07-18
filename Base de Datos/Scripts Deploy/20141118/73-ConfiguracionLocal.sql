/****** Object:  Table [dbo].[ConfiguracionLocal]    Script Date: 11/04/2014 21:28:19 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ConfiguracionLocal]') AND type in (N'U'))
DROP TABLE [dbo].[ConfiguracionLocal]
GO

CREATE TABLE [dbo].[ConfiguracionLocal](
	[ConfiguracionLocalId] [int] NOT NULL,
	[MaxikioscoIdentifier] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_ConfiguracionLocal] PRIMARY KEY CLUSTERED 
(
	[ConfiguracionLocalId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO



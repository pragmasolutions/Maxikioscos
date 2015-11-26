CREATE TABLE [dbo].[ConfiguracionLocal] (
    [ConfiguracionLocalId] INT              NOT NULL,
    [MaxikioscoIdentifier] UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [PK_ConfiguracionLocal] PRIMARY KEY CLUSTERED ([ConfiguracionLocalId] ASC)
);


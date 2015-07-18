/****** Object:  StoredProcedure [dbo].[ActualizarPrincipal]    Script Date: 08/09/2014 15:47:04 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ActualizarPrincipal]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[ActualizarPrincipal]
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



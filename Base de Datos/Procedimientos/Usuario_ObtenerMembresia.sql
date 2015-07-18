
/****** Object:  StoredProcedure [dbo].[Usuario_ObtenerMembresia]    Script Date: 08/09/2014 15:52:02 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Usuario_ObtenerMembresia]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Usuario_ObtenerMembresia]
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



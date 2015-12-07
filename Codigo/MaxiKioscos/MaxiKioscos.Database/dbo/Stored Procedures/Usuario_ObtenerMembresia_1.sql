

CREATE PROCEDURE [dbo].[Usuario_ObtenerMembresia]
	@UsuarioId int
AS
BEGIN
	SELECT *
	FROM dbo.webpages_Membership
	WHERE UserId = @UsuarioId
END



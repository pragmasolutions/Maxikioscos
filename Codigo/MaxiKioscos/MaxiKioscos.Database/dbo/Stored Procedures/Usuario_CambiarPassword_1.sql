
CREATE PROCEDURE [dbo].[Usuario_CambiarPassword]
	@UsuarioId int,
	@Password nvarchar(128),
	@PasswordChangedDate datetime
AS
BEGIN
	UPDATE webpages_Membership
	SET Password = @Password,
		PasswordChangedDate = @PasswordChangedDate
	WHERE UserId = @UsuarioId
	
	UPDATE Usuario
	SET Desincronizado = 1
	WHERE UsuarioId = @UsuarioId
END


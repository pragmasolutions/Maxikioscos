
/****** Object:  StoredProcedure [dbo].[Usuario_CambiarPassword]    Script Date: 08/09/2014 15:51:52 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Usuario_CambiarPassword]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Usuario_CambiarPassword]
GO

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

GO



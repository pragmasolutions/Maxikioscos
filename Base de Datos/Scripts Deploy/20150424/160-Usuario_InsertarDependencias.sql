IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Usuario_InsertarDependencias]') AND type in (N'P', N'PC'))
DROP PROCEDURE[dbo].[Usuario_InsertarDependencias]
GO

CREATE PROCEDURE [dbo].[Usuario_InsertarDependencias]
	@UsuarioId int,
	@RoleId int,
	@ProveedoresIds varchar(5000) = null
AS
BEGIN
	DELETE FROM webpages_UsersInRoles
	WHERE UserId = @UsuarioId
	
	UPDATE UsuarioProveedor
	SET Eliminado = 1
	WHERE UsuarioId = @UsuarioId
	
	INSERT INTO webpages_UsersInRoles (UserId, RoleId) VALUES (@UsuarioId, @RoleId)

	INSERT INTO UsuarioProveedor (UsuarioId, ProveedorId, Desincronizado, Eliminado, 
								FechaUltimaModificacion, Identifier)
	SELECT @UsuarioId, ID, 1, 0, GETDATE(), NEWID()
	FROM dbo.ID_Splitter(@ProveedoresIds)
	
	SELECT @UsuarioId
	
END
GO



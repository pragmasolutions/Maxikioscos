

/****** Object:  StoredProcedure [dbo].[Usuario_InsertarDependencias]    Script Date: 08/09/2014 15:51:57 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Usuario_InsertarDependencias]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Usuario_InsertarDependencias]
GO


CREATE PROCEDURE [dbo].[Usuario_InsertarDependencias]
	@UsuarioId int,
	@RoleId int,
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
	
	INSERT INTO webpages_UsersInRoles (UserId, RoleId) VALUES (@UsuarioId, @RoleId)

	INSERT INTO UsuarioMaxiKiosco (UsuarioId, MaxiKioscoId, Desincronizado, Eliminado, 
									FechaUltimaModificacion, Identifier)
	SELECT @UsuarioId, ID, 1, 0, GETDATE(), NEWID()
	FROM dbo.ID_Splitter(@MaxikioscosIds)
	
	INSERT INTO UsuarioProveedor (UsuarioId, ProveedorId, Desincronizado, Eliminado, 
								FechaUltimaModificacion, Identifier)
	SELECT @UsuarioId, ID, 1, 0, GETDATE(), NEWID()
	FROM dbo.ID_Splitter(@ProveedoresIds)
	
	SELECT @UsuarioId
	
END




GO



DECLARE @UsuarioId INT
SET @UsuarioId = (SELECT TOP 1 UsuarioId FROM Usuario WHERE NombreUsuario = 'admin')

UPDATE Costo
SET UsuarioId = @UsuarioId
WHERE CierreCajaId IS NULL
	AND UsuarioId IS NULL
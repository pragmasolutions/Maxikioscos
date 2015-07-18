/****** Object:  StoredProcedure [dbo].[Factura_ObtenerAbiertasPorUsuario]    Script Date: 10/11/2014 17:02:39 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Factura_ObtenerAbiertasPorUsuario]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Factura_ObtenerAbiertasPorUsuario]
GO



CREATE PROCEDURE [dbo].[Factura_ObtenerAbiertasPorUsuario]
	@UsuarioId int,
	@MaxiKioscoId int
AS
BEGIN
	DECLARE @AdminRoleId int
	SET @AdminRoleId = (SELECT TOP 1 UR.RoleId
						FROM dbo.webpages_UsersInRoles UR
							INNER JOIN  dbo.webpages_Roles R
							ON UR.RoleId = R.RoleId
						WHERE @UsuarioId = UR.UserId
							AND (R.RoleName = 'Administrador'
								OR R.RoleName = 'SuperAdministrador'))
	
	IF @AdminRoleId IS NOT NULL
	
	SELECT F.*,
			NombreCompleto = F.FacturaNro + ' (' + P.Nombre + ')'
	FROM Factura F
		LEFT JOIN Proveedor P ON F.ProveedorId = P.ProveedorId
	WHERE 
		NOT EXISTS (SELECT 1
						 FROM Compra
						 WHERE FacturaId = F.FacturaId)
		AND ((@AdminRoleID IS NOT NULL) 
			  OR (F.ProveedorId IN (SELECT ProveedorId
									FROM UsuarioProveedor
									WHERE UsuarioId = @UsuarioId
								   )
				 )	  
		)
		AND F.MaxiKioscoId = @MaxiKioscoId
END


GO



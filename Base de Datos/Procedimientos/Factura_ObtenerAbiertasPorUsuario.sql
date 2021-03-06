
/****** Object:  StoredProcedure [dbo].[Factura_ObtenerAbiertasPorUsuario]    Script Date: 07/09/2015 20:04:32 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Factura_ObtenerAbiertasPorUsuario]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Factura_ObtenerAbiertasPorUsuario]
GO

/****** Object:  StoredProcedure [dbo].[Factura_ObtenerAbiertasPorUsuario]    Script Date: 07/09/2015 20:04:32 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
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
	
	SELECT F.*,
			NombreCompleto = F.FacturaNro + ' (' + P.Nombre + ')'
	FROM Factura F
		LEFT JOIN Proveedor P ON F.ProveedorId = P.ProveedorId
	WHERE 
		F.Eliminado = 0
		AND NOT EXISTS (SELECT 1
						 FROM Compra
						 WHERE FacturaId = F.FacturaId
							AND Eliminado = 0)
		AND ((@AdminRoleID IS NOT NULL) 
			  OR (F.ProveedorId IN (SELECT ProveedorId
									FROM UsuarioProveedor
									WHERE UsuarioId = @UsuarioId
										AND Eliminado = 0
								   )
				 )	  
		)
		AND F.MaxiKioscoId = @MaxiKioscoId
END




GO




  INSERT INTO Reporte VALUES ('Ventas por Proveedor', 'Por Proveedor', 'Ventas', 'VentasPorProveedor')
  GO
  
  INSERT INTO ReporteRol VALUES (
	(SELECT TOP 1 RoleId FROM webpages_Roles WHERE RoleName = 'Administrador'),
	(SELECT TOP 1 ReporteId FROM Reporte WHERE NombreCompleto = 'Ventas por Proveedor'),
	1,
	0,
	GETDATE(),
	NEWID()
  )
  GO
  
  
  INSERT INTO ReporteRol VALUES (
	(SELECT TOP 1 RoleId FROM webpages_Roles WHERE RoleName = 'SuperAdministrador'),
	(SELECT TOP 1 ReporteId FROM Reporte WHERE NombreCompleto = 'Ventas por Proveedor'),
	1,
	0,
	GETDATE(),
	NEWID()
  )
  GO
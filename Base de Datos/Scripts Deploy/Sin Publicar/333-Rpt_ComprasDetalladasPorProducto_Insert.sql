
  INSERT INTO Reporte VALUES ('Compras Detalladas por Proveedor', 'Detalladas Por Proveedor', 'Compras', 'ComprasDetalladasPorProveedor')
  GO
  
  INSERT INTO ReporteRol VALUES (
	(SELECT TOP 1 RoleId FROM webpages_Roles WHERE RoleName = 'Administrador'),
	(SELECT TOP 1 ReporteId FROM Reporte WHERE NombreCompleto = 'Compras Detalladas por Proveedor'),
	1,
	0,
	GETDATE(),
	NEWID()
  )
  GO
  
  
  INSERT INTO ReporteRol VALUES (
	(SELECT TOP 1 RoleId FROM webpages_Roles WHERE RoleName = 'SuperAdministrador'),
	(SELECT TOP 1 ReporteId FROM Reporte WHERE NombreCompleto = 'Compras Detalladas por Proveedor'),
	1,
	0,
	GETDATE(),
	NEWID()
  )
  GO
  
  
  UPDATE Reporte
  SET Nombre = 'Por Proveedor',
		Padre = 'Compras'
  WHERE NombreCompleto = 'Compras por Proveedor'
  GO
  
  
  
  
  INSERT INTO Reporte VALUES ('Sugerencia Compras por Proveedor', 'Sugerencias Por Proveedor', 'Compras', 'SugerenciaComprasPorProveedor')
  GO
  
  INSERT INTO ReporteRol VALUES (
	(SELECT TOP 1 RoleId FROM webpages_Roles WHERE RoleName = 'Administrador'),
	(SELECT TOP 1 ReporteId FROM Reporte WHERE NombreCompleto = 'Sugerencia Compras por Proveedor'),
	1,
	0,
	GETDATE(),
	NEWID()
  )
  GO
  
  
  INSERT INTO ReporteRol VALUES (
	(SELECT TOP 1 RoleId FROM webpages_Roles WHERE RoleName = 'SuperAdministrador'),
	(SELECT TOP 1 ReporteId FROM Reporte WHERE NombreCompleto = 'Sugerencia Compras por Proveedor'),
	1,
	0,
	GETDATE(),
	NEWID()
  )
  GO
  
  
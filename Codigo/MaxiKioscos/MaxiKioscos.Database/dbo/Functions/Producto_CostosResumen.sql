
CREATE FUNCTION Producto_CostosResumen
(	
	@ProductoId int
)
RETURNS TABLE 
AS
RETURN 
(
	SELECT ProveedorNombre = (CASE WHEN LEN(P.Nombre) > 4 THEN LEFT(P.Nombre, 4)
								ELSE P.Nombre
							  END),
			Costo = '$' + CAST(CAST(CostoConIVA as decimal(18,2)) as varchar)
	FROM ProveedorProducto PP
		LEFT JOIN Proveedor P
			ON PP.ProveedorId = P.ProveedorId
	WHERE PP.ProductoId = @ProductoId
		AND PP.Eliminado = 0
)



CREATE PROCEDURE [dbo].[Proveedor_ObtenerRubros]
	@ProveedorId int
AS
BEGIN
	SELECT DISTINCT R.*
	FROM ProveedorProducto PP
		INNER JOIN Producto P
			ON PP.ProductoId = P.ProductoId
		INNER JOIN Rubro R
			ON P.RubroId = R.RubroId
	WHERE PP.ProveedorId = @ProveedorId
END




/****** Object:  StoredProcedure [dbo].[Proveedor_ObtenerRubros]    Script Date: 08/09/2014 15:47:16 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Proveedor_ObtenerRubros]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Proveedor_ObtenerRubros]
GO


CREATE PROCEDURE Proveedor_ObtenerRubros
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


GO

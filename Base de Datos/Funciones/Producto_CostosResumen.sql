/****** Object:  UserDefinedFunction [dbo].[Producto_CostosResumen]    Script Date: 11/09/2015 10:00:11 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Producto_CostosResumen]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[Producto_CostosResumen]
GO

CREATE FUNCTION [dbo].[Producto_CostosResumen]
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

GO




ALTER FUNCTION [dbo].[UltimosCostos]
(	
	
)
RETURNS TABLE 
AS
RETURN 
(	
	SELECT ProductoId,
	   CostoConIVA,
	   ProveedorId
	FROM (SELECT P.ProductoId,
		  PP.CostoConIVA,
		  PP.ProveedorId,
		  row_number() over(partition by P.ProductoId order by PP.FechaUltimoCambioCosto desc) as rn
		  FROM Producto P
			LEFT JOIN ProveedorProducto PP ON P.ProductoId = PP.ProductoId) as T
	WHERE rn = 1
)




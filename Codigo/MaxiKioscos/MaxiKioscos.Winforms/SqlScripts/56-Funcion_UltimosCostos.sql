
ALTER FUNCTION [dbo].[UltimosCostos]
(	
	
)
RETURNS TABLE 
AS
RETURN 
(	
	SELECT ProductoId,
	   CostoConIVA		
	FROM (SELECT P.ProductoId,
		  PP.CostoConIVA,
		  row_number() over(partition by P.ProductoId order by PP.FechaUltimoCambioCosto, PP.FechaUltimaModificacion desc) as rn
		  FROM Producto P
			LEFT JOIN ProveedorProducto PP ON P.ProductoId = PP.ProductoId) as T
	WHERE rn = 1
)



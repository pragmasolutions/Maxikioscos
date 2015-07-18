CREATE FUNCTION [dbo].[UltimoCosto]
(	
	@ProductoId int
)
RETURNS money 
AS
BEGIN
	RETURN (SELECT CostoConIVA		
	FROM (SELECT PP.CostoConIVA,
		  row_number() over(partition by P.ProductoId order by PP.FechaUltimoCambioCosto, PP.FechaUltimaModificacion desc) as rn
		  FROM Producto P
			LEFT JOIN ProveedorProducto PP ON P.ProductoId = PP.ProductoId
		  WHERE P.ProductoId = @ProductoId) as T
	WHERE rn = 1)

END


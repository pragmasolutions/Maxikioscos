/****** Object:  UserDefinedFunction [dbo].[UltimoCosto]    Script Date: 11/19/2014 22:47:49 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UltimoCosto]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[UltimoCosto]
GO


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
GO



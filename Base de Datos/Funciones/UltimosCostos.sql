/****** Object:  UserDefinedFunction [dbo].[UltimosCostos]    Script Date: 11/19/2014 22:47:49 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UltimosCostos]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[UltimosCostos]
GO


CREATE FUNCTION [dbo].[UltimosCostos]
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
		  row_number() over(partition by P.ProductoId order by PP.FechaUltimoCambioCosto desc) as rn
		  FROM Producto P
			LEFT JOIN ProveedorProducto PP ON P.ProductoId = PP.ProductoId) as T
	WHERE rn = 1
)


GO



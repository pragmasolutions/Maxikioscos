
/****** Object:  UserDefinedFunction [dbo].[UltimosCostos]    Script Date: 10/11/2014 13:59:02 ******/
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
	SELECT PR.ProductoId,
		PP.CostoConIVA
		
	FROM Producto PR
	LEFT JOIN (SELECT PP1.*
				FROM ProveedorProducto PP1
					LEFT JOIN ProveedorProducto PP2 ON PP1.ProductoId = PP2.ProductoId
				WHERE PP1.FechaUltimaModificacion > PP2.FechaUltimaModificacion) PP
		ON PR.ProductoID = PP.ProductoId
)

GO



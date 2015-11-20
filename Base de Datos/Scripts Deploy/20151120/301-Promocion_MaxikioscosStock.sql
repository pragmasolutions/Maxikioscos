/****** Object:  UserDefinedFunction [dbo].[Promocion_MaxikioscosStock]    Script Date: 11/09/2015 10:00:15 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Promocion_MaxikioscosStock]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[Promocion_MaxikioscosStock]
GO

CREATE FUNCTION [dbo].[Promocion_MaxikioscosStock]
(	
	@PromocionId int
)
RETURNS TABLE 
AS
RETURN 
(
	SELECT DISTINCT M.MaxiKioscoId,
		M.Identifier,
		Stock = ISNULL(S.StockActual, 0)
	FROM MaxiKiosco M
		LEFT JOIN Stock S
			ON M.MaxiKioscoId = S.MaxiKioscoId
				AND @PromocionId = S.ProductoId
	WHERE M.Eliminado = 0
		AND S.Eliminado = 0
)

GO



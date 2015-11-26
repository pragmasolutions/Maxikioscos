
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

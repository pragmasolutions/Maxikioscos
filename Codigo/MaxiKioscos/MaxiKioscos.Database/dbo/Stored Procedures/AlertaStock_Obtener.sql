

CREATE PROCEDURE [dbo].[AlertaStock_Obtener]	
AS
BEGIN
	SELECT TOP 5 
		Producto = P.Descripcion,
		MaxiKiosco = M.Nombre,
		Unidades = A.CantidadActual,
		StockReposicion = P.StockReposicion,
		Fecha = A.Fecha,
		Marcada = A.Marcada
	FROM AlertaStock A
		INNER JOIN Stock S
			ON A.StockId = S.StockId
		INNER JOIN Producto P
			ON S.ProductoId = P.ProductoId
		INNER JOIN MaxiKiosco M
			ON S.MaxiKioscoId = M.MaxiKioscoId
	ORDER BY A.Fecha DESC
END

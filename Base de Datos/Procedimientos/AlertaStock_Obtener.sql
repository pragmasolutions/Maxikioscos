/****** Object:  StoredProcedure [dbo].[AlertaStock_Obtener]    Script Date: 08/09/2014 15:47:16 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AlertaStock_Obtener]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[AlertaStock_Obtener]
GO

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

GO



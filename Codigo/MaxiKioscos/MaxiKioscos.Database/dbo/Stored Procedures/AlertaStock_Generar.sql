
CREATE PROCEDURE AlertaStock_Generar 
	
AS
BEGIN
	Declare @Temp table
	(
	   StockId INT, 
	   StockActual decimal(18,2),
	   StockReposicion int
	);
	
	WITH AlertaCTE (StockId, StockActual, StockReposicion)
	AS (
		SELECT S.StockId, S.StockActual, P.StockReposicion
		FROM Stock S
			INNER JOIN Producto P ON S.ProductoId = P.ProductoId
		WHERE P.StockReposicion IS NOT NULL
			AND S.StockActual <= CAST(P.StockReposicion as decimal(18,2))
	 )
	 
	 INSERT INTO @Temp
	 SELECT * FROM AlertaCTE

	 --Primero modifico las alertas que no estan marcadas con los nuevos valores
	 UPDATE A
	 SET CantidadActual = CTE.StockActual
	 FROM @Temp CTE
		INNER JOIN AlertaStock A ON CTE.StockId = A.StockId
	 WHERE A.Marcada = 0
	 
	 --Ahora inserto las nuevas alertas si ya fueron marcadas pero ahora tienen distinto valor
	 INSERT INTO AlertaStock
	 SELECT CTE.StockId,
			CTE.StockActual,
			GETDATE(),
			0
	 FROM AlertaStock A
		LEFT JOIN @Temp CTE ON A.StockId = CTE.StockId
	 WHERE CTE.StockId IS NOT NULL
		  AND A.Marcada = 1 
		  AND CTE.StockActual != A.CantidadActual
		  
	 --Por ultimo inserto todas las alertas que todavia no existan
	 INSERT INTO AlertaStock
	 SELECT CTE.StockId,
			CTE.StockActual,
			GETDATE(),
			0
	 FROM @Temp CTE
		LEFT JOIN AlertaStock A ON CTE.StockId = A.StockId
	 WHERE A.StockId IS NULL
END

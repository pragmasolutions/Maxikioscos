DECLARE @MaxiKioscoId int = 10

DECLARE @PrimerosStockIds TABLE
(
	ProductoIdentifier uniqueidentifier,
	MaxiKioscoIdentifier uniqueidentifier,
	StockIdentifier uniqueidentifier
)


INSERT INTO @PrimerosStockIds (ProductoIdentifier,	MaxiKioscoIdentifier, StockIdentifier)
SELECT ProductoIdentifier,
	   MaxiKioscoIdentifier,
	   StockIdentifier 
	FROM (SELECT P.Identifier ProductoIdentifier,
		  M.Identifier MaxiKioscoIdentifier,
		  S.Identifier StockIdentifier,
		  row_number() over(partition by S.ProductoId, S.MaxiKioscoId order by S.Identifier desc) as rn
		  FROM Stock S
			INNER JOIN MaxiKiosco M
				ON S.MaxiKioscoId = M.MaxiKioscoId
			INNER JOIN Producto P
				ON S.ProductoId = P.ProductoId
		  WHERE S.MaxiKioscoId = @MaxiKioscoId) as T
	WHERE rn = 1
	


DECLARE @Mappings TABLE
(
	Identifier uniqueidentifier,
	Mapping uniqueidentifier
);



WITH CTE (ProductoId, MaxiKioscoId, Cuenta)
AS
(
	SELECT ProductoId, MaxiKioscoId, Count(*)
	FROM Stock
	WHERE MaxiKioscoId = @MaxiKioscoId
	GROUP BY ProductoId, MaxiKioscoId
)

INSERT INTO @Mappings
SELECT S.Identifier,
	T.StockIdentifier
FROM Stock S
	INNER JOIN MaxiKiosco M
		ON S.MaxiKioscoId = M.MaxiKioscoId
	INNER JOIN Producto P
		ON S.ProductoId = P.ProductoId
	INNER JOIN CTE
		ON S.ProductoId = CTE.ProductoId
			AND S.MaxiKioscoId = CTE.MaxiKioscoId
	INNER JOIN @PrimerosStockIds T
		ON P.Identifier = T.ProductoIdentifier
			AND M.Identifier = T.MaxiKioscoIdentifier
WHERE CTE.Cuenta > 1
ORDER BY S.ProductoId, S.MaxiKioscoId

UPDATE ST
SET StockId = S2.StockId
FROM StockTransaccion ST
	INNER JOIN Stock S
		ON ST.StockId = S.StockId
	INNER JOIN @Mappings M
		ON S.Identifier = M.Identifier
	INNER JOIN Stock S2
		ON M.Mapping = S2.Identifier
WHERE M.Identifier <> M.Mapping


DELETE FROM ControlStockDetalle
DELETE FROM ControlStock
WHERE MaxiKioscoId = @MaxiKioscoId

DELETE FROM Stock
WHERE Identifier  IN (SELECT Identifier
					FROM @Mappings
					WHERE Identifier <> Mapping)

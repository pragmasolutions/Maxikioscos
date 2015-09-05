ALTER PROCEDURE [dbo].[Stock_Actualizar] 
	@MaxikioscoIdentifier uniqueidentifier = NULL,
	@ProductoId int = NULL
AS
BEGIN
	Declare @Temp table
	(
	   MaxikioscoId int,
	   ProductoId int,
	   Cantidad DECIMAL(18,2)
	)

	INSERT INTO @Temp
	SELECT S.MaxiKioscoId,
			S.ProductoId,
			ISNULL(SUM(ST.Cantidad), 0)
	FROM StockTransaccion ST
		LEFT JOIN Stock S ON ST.StockId = S.StockId
		LEFT JOIN MaxiKiosco M ON S.MaxiKioscoId = M.MaxiKioscoId
	WHERE (@ProductoId IS NULL OR S.ProductoId = @ProductoId)
			AND (@MaxikioscoIdentifier IS NULL OR M.Identifier = @MaxikioscoIdentifier)
	GROUP BY S.ProductoId, S.MaxikioscoId
	
		
	UPDATE S
	SET StockActual = T.Cantidad
	FROM @Temp T
		LEFT JOIN Stock S 
			ON T.MaxikioscoId = S.MaxiKioscoId
			AND T.ProductoId = S.ProductoId
		
	SELECT 1 as Result
END
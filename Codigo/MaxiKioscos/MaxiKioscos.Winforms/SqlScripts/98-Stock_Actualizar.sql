ALTER PROCEDURE [dbo].[Stock_Actualizar] 
	@StockId int = NULL,
	@MaxikioscoIdentifier uniqueidentifier = NULL
AS
BEGIN
	Declare @Temp table
	(
	   StockId INT, 
	   Cantidad DECIMAL(18,2)
	)

	INSERT INTO @Temp
	SELECT ST.StockId, ISNULL(SUM(ST.Cantidad), 0)
	FROM StockTransaccion ST
		LEFT JOIN Stock S ON ST.StockId = S.StockId
		LEFT JOIN MaxiKiosco M ON S.MaxiKioscoId = M.MaxiKioscoId
	WHERE (@StockId IS NULL OR S.StockId = @StockId) 
		AND (@MaxikioscoIdentifier IS NULL OR M.Identifier = @MaxikioscoIdentifier)
	GROUP BY ST.StockId
	
	
	UPDATE S
	SET StockActual = T.Cantidad
	FROM @Temp T
		LEFT JOIN Stock S ON T.StockId = S.StockId
		
	SELECT 1 as Result
END
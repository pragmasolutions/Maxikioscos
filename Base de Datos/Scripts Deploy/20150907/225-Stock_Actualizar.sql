/****** Object:  StoredProcedure [dbo].[Stock_Actualizar]    Script Date: 02/12/2015 05:24:29 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Stock_Actualizar]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Stock_Actualizar]
GO


CREATE PROCEDURE [dbo].[Stock_Actualizar] 
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
GO



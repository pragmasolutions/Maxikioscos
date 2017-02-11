DROP PROCEDURE [dbo].[Rpt_Stock]
GO


CREATE PROCEDURE [dbo].[Rpt_Stock]
	@Desde datetime2(7),
	@Hasta datetime2(7),
	@MaxiKioscoId int,
	@CuentaId int
AS
BEGIN
	DECLARE @LocDesde datetime2(7) = @Desde,
			@LocHasta datetime2(7) = @Hasta,
			@LocMaxiKioscoId int = @MaxiKioscoId,
			@LocCuentaId int = @CuentaId;

	WITH CTE(MaxiKiosco, Producto, Cantidad, Monto)
	AS
	(
		SELECT
		   MaxiKiosco = M.Nombre,
		   Producto = P.Descripcion,
		   Cantidad = CS.Cantidad,
		   Monto = CS.Precio
		   
		FROM CorreccionStock CS
			INNER JOIN Producto P	
				ON CS.ProductoId = P.ProductoId
			INNER JOIN MaxiKiosco M
				ON CS.MaxiKioscoId = M.MaxiKioscoId
		WHERE 
			(@LocDesde IS NULL OR CS.Fecha >= @LocDesde)
			AND (@LocHasta IS NULL OR CS.Fecha <= @LocHasta)
			AND (@LocMaxiKioscoId IS NULL OR CS.MaxiKioscoId = @LocMaxiKioscoId)
			AND (@LocCuentaId IS NULL OR M.CuentaId = @LocCuentaId)			
		
	)
	
	SELECT MaxiKiosco, 
			Producto, 			
			Cantidad = ISNULL(SUM(Cantidad), 0), 
			Monto = ISNULL(SUM(Monto), 0)
	FROM CTE
	GROUP BY MaxiKiosco, Producto
	ORDER BY MaxiKiosco, Producto
	
END



GO



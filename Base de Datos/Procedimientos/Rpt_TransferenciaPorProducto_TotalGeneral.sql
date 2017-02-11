DROP PROCEDURE [dbo].[Rpt_TransferenciaPorProducto_TotalGeneral]
GO

CREATE PROCEDURE [dbo].[Rpt_TransferenciaPorProducto_TotalGeneral]
	@Desde datetime2(7),
	@Hasta datetime2(7),
	@RubroId int,
	@CuentaId int
AS
BEGIN
	DECLARE @LocDesde datetime2(7) = @Desde,
			@LocHasta datetime2(7) = @Hasta,
			@LocRubroId int = @RubroId,
			@LocCuentaId int = @CuentaId

	SELECT
	   Rubro = R.Descripcion
	  ,Producto = P.Descripcion 
	  ,CostoPromedio = AVG(TP.Costo)
	  ,PrecioPromedio = AVG(TP.PrecioVenta)
	  ,CantidadTotal = SUM(TP.Cantidad) 
	  ,MontoTotalTrasferido = SUM(TP.PrecioVenta * TP.Cantidad) 
	  ,CostoTotal = SUM(TP.Costo * TP.Cantidad) 
	FROM
	  TransferenciaProducto TP
	  INNER JOIN Producto P
		ON TP.ProductoId = P.ProductoId
	  INNER JOIN Rubro R
		ON P.RubroId = R.RubroId
	  INNER JOIN Transferencia T
		ON TP.TransferenciaId = T.TransferenciaId
	  INNER JOIN MaxiKiosco MO
		ON T.OrigenId = MO.MaxiKioscoId
	  INNER JOIN MaxiKiosco MD
		ON T.DestinoId = MD.MaxiKioscoId
	WHERE (@LocDesde IS NULL OR T.FechaCreacion >= @LocDesde)
		AND (@LocHasta IS NULL OR T.FechaCreacion <= @LocHasta)
		AND (@LocRubroId IS NULL OR R.RubroId = @LocRubroId)
		AND (@LocCuentaId IS NULL OR P.CuentaId = @LocCuentaId)
	GROUP BY R.Descripcion,P.Descripcion
	ORDER BY CantidadTotal DESC
END

GO



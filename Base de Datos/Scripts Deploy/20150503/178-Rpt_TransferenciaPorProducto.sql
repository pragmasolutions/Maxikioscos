IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Rpt_TransferenciaPorProducto]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Rpt_TransferenciaPorProducto]
GO

CREATE PROCEDURE [dbo].[Rpt_TransferenciaPorProducto]
	@Desde datetime2(7),
	@Hasta datetime2(7),
	@RubroId int,
	@MaxikioscoOrigenId int,
	@MaxikioscoDestinoId int,
	@CuentaId int
AS
BEGIN
	SELECT
	   MaxiKioscoOrigen = MO.Nombre,
	   MaxiKioscoDestino = MD.Nombre
	  ,Rubro = R.Descripcion
	  ,Producto = P.Descripcion 
	  ,PrecioPromedio = AVG(TP.PrecioVenta)
	  ,CantidadTotal = SUM(TP.Cantidad) 
	  ,MontoTotalTrasferido = SUM(TP.PrecioVenta * TP.Cantidad) 
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
	WHERE 
	        (@Desde IS NULL OR T.FechaCreacion >= @Desde)
		AND (@Hasta IS NULL OR T.FechaCreacion <= @Hasta)
		AND (@RubroId IS NULL OR R.RubroId = @RubroId)
		AND (@MaxikioscoOrigenId IS NULL OR MO.MaxikioscoId = @MaxikioscoOrigenId)
		AND (@MaxikioscoDestinoId IS NULL OR MD.MaxikioscoId = @MaxikioscoDestinoId)
		AND (@CuentaId IS NULL OR P.CuentaId = @CuentaId)
	GROUP BY MO.Nombre,MD.Nombre,R.Descripcion,P.Descripcion
	ORDER BY CantidadTotal DESC
END
GO
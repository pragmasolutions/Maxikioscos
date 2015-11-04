
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ControlStock_VistaPrevia]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[ControlStock_VistaPrevia]
GO

CREATE PROCEDURE [dbo].[ControlStock_VistaPrevia]
	@MaxiKioscoId int, 
	@ProveedorId int = NULL,
	@RubroId int = NULL,
	@MasVendidos bit,
	@SoloStockCero bit,
	@CantidadFilas int
AS
BEGIN

	DECLARE @Productos TABLE
	(
		Fila int,
		Cantidad int,
		ProductoId int,
		Descripcion varchar(200)
	)

	IF @MasVendidos = 0
		BEGIN
			WITH ProdCTE (ProductoId, Descripcion)
			AS 
			(
				SELECT DISTINCT P.ProductoId, 
								P.Descripcion
				FROM Producto P
					LEFT JOIN ProveedorProducto PP
						ON P.ProductoId = PP.ProductoId
				WHERE P.Eliminado = 0
					AND (@RubroId IS NULL OR @RubroId = P.RubroId)
					AND (@ProveedorId IS NULL OR @ProveedorId = PP.ProveedorId)
			)
			INSERT INTO @Productos 
			SELECT ROW_NUMBER () OVER (ORDER BY Descripcion ASC),
										NULL,
										ProductoId, 
										Descripcion
						FROM ProdCTE CTE
			
		END
	ELSE
		BEGIN
			DECLARE @ListadoMasVendidos TABLE
			(
				ProductoId int,
				Descripcion varchar(200),
				Cantidad decimal
			)

			INSERT INTO @ListadoMasVendidos
			SELECT DISTINCT P.ProductoId, P.Descripcion, SUM(VP.Cantidad)
			FROM VentaProducto VP
				INNER JOIN Producto P
					ON VP.ProductoId = P.ProductoId
				INNER JOIN Venta V
					ON VP.VentaId = V.VentaId
				INNER JOIN CierreCaja CC
					ON V.CierreCajaId = CC.CierreCajaId
				LEFT JOIN Rubro R 
					ON P.RubroId = R.RubroId
				LEFT JOIN ProveedorProducto PP 
					ON P.ProductoId = PP.ProductoId
			WHERE V.FechaVenta < GETDATE() 
				AND V.FechaVenta > DATEADD(MONTH, -2, GETDATE())
				AND CC.MaxiKioskoId = @MaxiKioscoId
				AND P.Eliminado = 0
				AND (@RubroId IS NULL OR @RubroId = P.RubroId)
				AND (@ProveedorId IS NULL OR @ProveedorId = PP.ProveedorId)
			GROUP BY P.ProductoId, P.Descripcion

			INSERT INTO @Productos 
			SELECT ROW_NUMBER () OVER (ORDER BY Cantidad DESC),
				Cantidad,
				ProductoId, 
				Descripcion
			FROM @ListadoMasVendidos
			ORDER BY Cantidad DESC

		END


	DECLARE @Intermedia TABLE
	(
		Fila int,
		ProductoId int,
		Codigo varchar(2000),
		Producto varchar(1000),
		Cantidad int,
		Motivo varchar(20),
		Diferencia int
	)

	INSERT INTO @Intermedia
	SELECT DISTINCT P.Fila,
		   P.ProductoId,
		   Codigo = (SELECT SUBSTRING(
			 (SELECT ',' + Codigo
			 FROM CodigoProducto CP 
			 WHERE CP.ProductoId = P.ProductoId
			 FOR XML PATH('')),2,200000)),
		   P.Descripcion Producto,
		   ISNULL(S.StockActual, 0),
		   NULL Motivo,
		   NULL Diferencia
	FROM @Productos P
		LEFT JOIN Stock S
			ON S.ProductoId = P.ProductoId
				AND S.MaxiKioscoId = @MaxiKioscoId

	SELECT  Fila = CAST(ROW_NUMBER () OVER (ORDER BY Fila ASC) AS INT),
			ProductoId,
			Codigo,
			Producto,
			Cantidad,
			Motivo,
			Diferencia
	FROM @Intermedia 
	WHERE (@MasVendidos = 0 OR (@MasVendidos = 1 AND Fila <= @CantidadFilas)) AND 
		  (@SoloStockCero IS NULL OR @SoloStockCero = 0 OR (@SoloStockCero = 1 AND Cantidad = 0))

	ORDER BY Fila
END
GO



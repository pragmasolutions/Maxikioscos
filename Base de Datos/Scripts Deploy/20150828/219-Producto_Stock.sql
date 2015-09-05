/****** Object:  StoredProcedure [dbo].[Producto_Stock]    Script Date: 08/28/2015 12:58:12 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Producto_Stock]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Producto_Stock]
GO


CREATE PROCEDURE [dbo].[Producto_Stock]
	@ProductoId int
AS
BEGIN
		
	DECLARE @All TABLE
	(
		MaxiKisocoId int,
		Nombre varchar(200),
		StockId int,
		StockActual decimal(18, 2),
		Vendido decimal(18, 2)
	)

	INSERT INTO @All (MaxiKisocoId, Nombre)
	SELECT MaxikioscoId, Nombre
	FROM MaxiKiosco
	WHERE Eliminado = 0

	UPDATE A 
	SET StockId = ISNULL((SELECT TOP 1 S.StockId 
					FROM Stock S 
					WHERE A.MaxiKisocoId = S.MaxiKioscoId
							AND S.Eliminado = 0
							AND S.ProductoId = @ProductoId), 0)
	FROM @All A
							
	UPDATE A 
	SET StockActual = ISNULL((SELECT TOP 1 S.StockActual 
					FROM Stock S 
					WHERE A.MaxiKisocoId = S.MaxiKioscoId
							AND S.Eliminado = 0
							AND S.ProductoId = @ProductoId), 0)
	FROM @All A

	DECLARE @Ahora DATETIME
	DECLARE @HaceUnMes DATETIME

	SET @Ahora = GETDATE()
	SET @HaceUnMes = DATEADD(MONTH, -1, @Ahora)

	UPDATE A
	SET Vendido = ISNULL((SELECT SUM(VP.Cantidad)
					FROM VentaProducto VP
						INNER JOIN Venta V
							ON VP.VentaId = V.VentaId
						INNER JOIN CierreCaja CC
							ON V.CierreCajaId = CC.CierreCajaId
					WHERE VP.ProductoId = @ProductoId
						AND VP.Eliminado = 0
						AND CC.MaxiKioskoId = A.MaxiKisocoId
					), 0)
	FROM @All A

	SELECT MaxiKiosco = Nombre,
			StockActual,
			Vendido
	FROM @All
END


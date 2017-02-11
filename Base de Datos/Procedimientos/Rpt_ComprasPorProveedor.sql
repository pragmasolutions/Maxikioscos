DROP PROCEDURE [dbo].[Rpt_ComprasPorProveedor]
GO


CREATE PROCEDURE [dbo].[Rpt_ComprasPorProveedor]
	@Desde datetime2(7) = NULL,
	@Hasta datetime2(7)= NULL,
	@ProveedorId int = NULL,
	@CuentaId int
AS
BEGIN
	DECLARE @LocDesde datetime2(7) = @Desde,
			@LocHasta datetime2(7)= @Hasta,
			@LocProveedorId int = @ProveedorId,
			@LocCuentaId int = @CuentaId

	DECLARE @Results TABLE
	(
		ProveedorId int,
		ProveedorNombre varchar(200),
		DescuentoTotal money,
		DGR money,
		IVA money,
		ImporteTotalA money,
		ImporteTotalX money
	)
	
	DECLARE @A TABLE
	(
		ProveedorId int,
		ImporteTotal money
	)
	
	DECLARE @X TABLE
	(
		ProveedorId int,
		ImporteTotal money
	)

    INSERT INTO @X
	SELECT P.ProveedorId,
		ABS(SUM(ISNULL(F.ImporteTotal, 0)))
	FROM Compra C
		INNER JOIN Factura F
			ON C.FacturaId = F.FacturaId
		INNER JOIN Proveedor P
			ON F.ProveedorId = P.ProveedorId
	WHERE (@LocDesde IS NULL OR F.Fecha >= @LocDesde)
		AND (@LocHasta IS NULL OR F.Fecha <= @LocHasta)
		AND (@LocProveedorId IS NULL OR P.ProveedorId = @LocProveedorId)
		AND (P.CuentaId = @LocCuentaId)
		AND (C.TipoComprobante = 'X')
	GROUP BY P.ProveedorId, P.Nombre
	
	INSERT INTO @A
	SELECT P.ProveedorId,
		ABS(SUM(ISNULL(F.ImporteTotal, 0)))
	FROM Compra C
		INNER JOIN Factura F
			ON C.FacturaId = F.FacturaId
		INNER JOIN Proveedor P
			ON F.ProveedorId = P.ProveedorId
	WHERE (@LocDesde IS NULL OR F.Fecha >= @LocDesde)
		AND (@LocHasta IS NULL OR F.Fecha <= @LocHasta)
		AND (@LocProveedorId IS NULL OR P.ProveedorId = @LocProveedorId)
		AND (P.CuentaId = @LocCuentaId)
		AND (C.TipoComprobante = 'A')
	GROUP BY P.ProveedorId, P.Nombre;
	
	
	SELECT  Proveedor = P.Nombre,
			DescuentoTotal = ABS(SUM(ISNULL(C.Descuento, 0))),
			DRG = ABS(SUM(ISNULL(C.PercepcionDGR, 0))),
			IVA = ABS(SUM(ISNULL(C.PercepcionIVA, 0))),
			ImportaA = ISNULL(A.ImporteTotal, 0),
			ImporteX = ISNULL(X.ImporteTotal, 0)
		FROM Compra C
			INNER JOIN Factura F
				ON C.FacturaId = F.FacturaId
			INNER JOIN Proveedor P
				ON F.ProveedorId = P.ProveedorId
			LEFT JOIN @X X
				ON F.ProveedorId = X.ProveedorId
			LEFT JOIN @A A
				ON F.ProveedorId = A.ProveedorId
		WHERE (@LocDesde IS NULL OR F.Fecha >= @LocDesde)
			AND (@LocHasta IS NULL OR F.Fecha <= @LocHasta)
			AND (@LocProveedorId IS NULL OR P.ProveedorId = @LocProveedorId)
			AND (P.CuentaId = @LocCuentaId)			
		GROUP BY P.ProveedorId, P.Nombre, A.ImporteTotal, X.ImporteTotal
	
END

GO



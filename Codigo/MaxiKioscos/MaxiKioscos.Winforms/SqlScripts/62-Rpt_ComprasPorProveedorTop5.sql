CREATE PROCEDURE [dbo].[Rpt_ComprasPorProveedorTop5]
	@Desde datetime2(7) = NULL,
	@Hasta datetime2(7)= NULL,
	@CuentaId int
AS
BEGIN
    WITH CTE(Proveedor, DescuentoTotal)
    AS
    (
		SELECT P.Nombre,
			ABS(SUM(C.Descuento))
		FROM Compra C
			INNER JOIN Factura F
				ON C.FacturaId = F.FacturaId
			INNER JOIN Proveedor P
				ON F.ProveedorId = P.ProveedorId
		WHERE (@Desde IS NULL OR F.Fecha >= @Desde)
			AND (@Hasta IS NULL OR F.Fecha <= @Hasta)
			AND (P.CuentaId = @CuentaId)
		GROUP BY P.Nombre
    )
    
    SELECT TOP 5 Proveedor, DescuentoTotal = ISNULL(DescuentoTotal, 0)
    FROM CTE
    ORDER BY DescuentoTotal DESC
END



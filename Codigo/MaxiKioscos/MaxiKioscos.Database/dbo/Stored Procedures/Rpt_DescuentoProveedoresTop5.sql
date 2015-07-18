
CREATE PROCEDURE Rpt_DescuentoProveedoresTop5
	@Desde datetime2(7) = NULL,
	@Hasta datetime2(7)= NULL,
	@CuentaId int
AS
BEGIN
    WITH CTE(Proveedor, DescuentoTotal)
    AS
    (
		SELECT P.Nombre,
			SUM(F.DescuentoEnPesos)
		FROM Factura F
			INNER JOIN Proveedor P
				ON F.ProveedorId = P.ProveedorId
		WHERE (@Desde IS NULL OR F.Fecha >= @Desde)
			AND (@Hasta IS NULL OR F.Fecha <= @Hasta)
			AND (P.CuentaId = @CuentaId)
			AND (F.DescuentoEnPesos IS NOT NULL)
		GROUP BY P.Nombre
    )
    
    SELECT TOP 5 Proveedor, DescuentoTotal = ISNULL(DescuentoTotal, 0)
    FROM CTE
    ORDER BY DescuentoTotal DESC
    
	
			
END

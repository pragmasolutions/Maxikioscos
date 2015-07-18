IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Rpt_ComprasPorProveedor]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Rpt_ComprasPorProveedor]
GO

CREATE PROCEDURE [dbo].[Rpt_ComprasPorProveedor]
	@Desde datetime2(7) = NULL,
	@Hasta datetime2(7)= NULL,
	@ProveedorId int = NULL,
	@CuentaId int
AS
BEGIN
    WITH CTE(Proveedor, ImporteTotal, DescuentoTotal)
    AS
    (
		SELECT P.Nombre,
			ABS(SUM(F.ImporteTotal)),
			ABS(SUM(C.Descuento))
		FROM Compra C
			INNER JOIN Factura F
				ON C.FacturaId = F.FacturaId
			INNER JOIN Proveedor P
				ON F.ProveedorId = P.ProveedorId
		WHERE (@Desde IS NULL OR F.Fecha >= @Desde)
			AND (@Hasta IS NULL OR F.Fecha <= @Hasta)
			AND (@ProveedorId IS NULL OR P.ProveedorId = @ProveedorId)
			AND (P.CuentaId = @CuentaId)
		GROUP BY P.Nombre
    )
    
    SELECT Proveedor, 
			ImporteTotal = ISNULL(ImporteTotal, 0),
			DescuentoTotal = ISNULL(DescuentoTotal, 0)
    FROM CTE
    ORDER BY Proveedor ASC
END
GO



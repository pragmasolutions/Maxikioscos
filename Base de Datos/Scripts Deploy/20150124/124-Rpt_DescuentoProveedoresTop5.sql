/****** Object:  StoredProcedure [dbo].[Rpt_DescuentoProveedoresTop5]    Script Date: 01/23/2015 12:38:24 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Rpt_DescuentoProveedoresTop5]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Rpt_DescuentoProveedoresTop5]
GO


CREATE PROCEDURE [dbo].[Rpt_DescuentoProveedoresTop5]
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
			AND (C.Descuento IS NOT NULL AND C.Descuento <> 0)
		GROUP BY P.Nombre
    )
    
    SELECT TOP 5 Proveedor, DescuentoTotal = ISNULL(DescuentoTotal, 0)
    FROM CTE
    ORDER BY DescuentoTotal DESC
    
	
			
END

GO



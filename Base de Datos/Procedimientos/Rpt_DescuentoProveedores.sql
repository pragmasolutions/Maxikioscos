/****** Object:  StoredProcedure [dbo].[Rpt_DescuentoProveedores]    Script Date: 01/23/2015 12:34:54 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Rpt_DescuentoProveedores]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Rpt_DescuentoProveedores]
GO



CREATE PROCEDURE [dbo].[Rpt_DescuentoProveedores]
	@Desde datetime2(7) = NULL,
	@Hasta datetime2(7)= NULL,
	@ProveedorId int = null,
	@CuentaId int
AS
BEGIN
	SELECT P.Nombre,
			F.Fecha,
		    F.ImporteTotal,
		    DescuentoEnPesos = ABS(C.Descuento)
	FROM Compra C
		INNER JOIN Factura F
			ON C.FacturaId = F.FacturaId
		INNER JOIN Proveedor P
			ON F.ProveedorId = P.ProveedorId
	WHERE (@Desde IS NULL OR F.Fecha >= @Desde)
		AND (@Hasta IS NULL OR F.Fecha <= @Hasta)
		AND (P.CuentaId = @CuentaId)
		AND (@ProveedorId IS NULL OR @ProveedorId = P.ProveedorId)
		AND (C.Descuento IS NOT NULL AND C.Descuento <> 0)
	ORDER BY P.Nombre
			
END

GO



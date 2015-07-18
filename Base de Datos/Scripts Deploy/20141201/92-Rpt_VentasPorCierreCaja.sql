
/****** Object:  StoredProcedure [dbo].[Rpt_VentasPorCierreCaja]    Script Date: 11/30/2014 18:53:15 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Rpt_VentasPorCierreCaja]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Rpt_VentasPorCierreCaja]
GO


CREATE PROCEDURE [dbo].[Rpt_VentasPorCierreCaja]
	@CierreCajaId int
AS
BEGIN
	SELECT
	   VP.VentaId,
	   Codigo = (SELECT SUBSTRING(
					(SELECT ',' + Codigo
					FROM CodigoProducto CP WHERE CP.ProductoId = P.ProductoId
					FOR XML PATH('')),2,200000)),
	   P.Descripcion,
	   VP.Cantidad,
	   VP.Precio
	FROM  VentaProducto VP
		INNER JOIN Venta V
			ON VP.VentaId = V.VentaId
		INNER JOIN Producto P
			ON VP.ProductoId = P.ProductoId
	 WHERE 
		V.CierreCajaId = @CierreCajaId
	 ORDER BY VP.VentaId
END

GO



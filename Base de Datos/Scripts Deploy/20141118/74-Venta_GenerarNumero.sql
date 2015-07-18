/****** Object:  StoredProcedure [dbo].[Venta_GenerarNumero]    Script Date: 11/05/2014 17:59:16 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Venta_GenerarNumero]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Venta_GenerarNumero]
GO

CREATE PROCEDURE [dbo].[Venta_GenerarNumero]
	@MaxikioscoId int
AS
BEGIN
	SELECT ISNULL(MAX(V.VentaId), 0) + 1
		FROM Venta V
			INNER JOIN CierreCaja CC
				ON V.CierreCajaId = CC.CierreCajaId
		WHERE CC.MaxikioskoId = @MaxikioscoId
END

GO



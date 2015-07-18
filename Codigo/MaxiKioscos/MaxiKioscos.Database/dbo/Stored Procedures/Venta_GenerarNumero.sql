
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


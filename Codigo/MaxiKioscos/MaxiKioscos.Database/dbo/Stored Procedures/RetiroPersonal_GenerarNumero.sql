
CREATE PROCEDURE [dbo].[RetiroPersonal_GenerarNumero]
	@MaxikioscoId int
AS
BEGIN
	SELECT ISNULL(MAX(RP.RetiroPersonalId), 0) + 1
		FROM RetiroPersonal RP
			INNER JOIN CierreCaja CC
				ON RP.CierreCajaId = CC.CierreCajaId
		WHERE CC.MaxikioskoId = @MaxikioscoId
END


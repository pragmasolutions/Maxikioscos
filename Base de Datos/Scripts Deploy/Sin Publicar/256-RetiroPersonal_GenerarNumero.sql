/****** Object:  StoredProcedure [dbo].[RetiroPersonal_GenerarNumero]    Script Date: 11/05/2014 17:59:16 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[RetiroPersonal_GenerarNumero]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[RetiroPersonal_GenerarNumero]
GO

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

GO



/****** Object:  StoredProcedure [dbo].[CierreCaja_UltimaCajaFinal]    Script Date: 02/08/2015 17:12:20 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CierreCaja_UltimaCajaFinal]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[CierreCaja_UltimaCajaFinal]
GO

CREATE PROCEDURE [dbo].[CierreCaja_UltimaCajaFinal]
	@MaxikioscoId int
AS
	SELECT TOP 1 CajaFinal
	FROM CierreCaja
	WHERE MaxiKioskoId = @MaxikioscoId
		AND CajaFinal IS NOT NULL
	ORDER BY CierreCajaId DESC

GO



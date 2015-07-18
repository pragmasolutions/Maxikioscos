/****** Object:  StoredProcedure [dbo].[CierreCaja_UltimaCajaFinal]    Script Date: 02/08/2015 16:59:50 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CierreCaja_ObtenerUltima]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[CierreCaja_ObtenerUltima]
GO


CREATE PROCEDURE [dbo].[CierreCaja_ObtenerUltima]
	@MaxikioscoId int
AS
	SELECT TOP 1 *
	FROM CierreCaja
	WHERE MaxiKioskoId = @MaxikioscoId
	ORDER BY CierreCajaId DESC
GO




/****** Object:  StoredProcedure [dbo].[ControlStock_DeshabilitarAbiertos]    Script Date: 10/04/2014 10:46:59 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ControlStock_DeshabilitarAbiertos]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[ControlStock_DeshabilitarAbiertos]
GO


CREATE PROCEDURE [dbo].[ControlStock_DeshabilitarAbiertos]
	@StockIds varchar(3000)
AS
BEGIN
	UPDATE CSD
	SET HabilitadoParaCorregir = 0
	FROM ControlStockDetalle CSD
		INNER JOIN ControlStock CS ON CSD.ControlStockId = CS.ControlStockId
	WHERE CS.Cerrado = 0
		AND CSD.StockId IN (SELECT ID FROM dbo.ID_Splitter(@StockIds))
END

GO



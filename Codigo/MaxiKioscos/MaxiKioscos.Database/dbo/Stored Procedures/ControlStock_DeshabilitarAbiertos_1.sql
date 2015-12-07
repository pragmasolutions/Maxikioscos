

CREATE PROCEDURE [dbo].[ControlStock_DeshabilitarAbiertos]
	@ControlStockId int,
	@StockIds varchar(3000)
AS
BEGIN
	UPDATE CSD
	SET HabilitadoParaCorregir = 0,
		ControlStockPrevioId = @ControlStockId
	FROM ControlStockDetalle CSD
		INNER JOIN ControlStock CS ON CSD.ControlStockId = CS.ControlStockId
	WHERE CS.Cerrado = 0
		AND CSD.StockId IN (SELECT ID FROM dbo.ID_Splitter(@StockIds))
END




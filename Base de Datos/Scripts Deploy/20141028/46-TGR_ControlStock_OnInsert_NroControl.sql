/****** Object:  Trigger [TGR_ControlStock_OnInsert_NroControl]    Script Date: 10/04/2014 16:58:00 ******/
IF  EXISTS (SELECT * FROM sys.triggers WHERE object_id = OBJECT_ID(N'[dbo].[TGR_ControlStock_OnInsert_NroControl]'))
DROP TRIGGER [dbo].[TGR_ControlStock_OnInsert_NroControl]
GO

CREATE TRIGGER [dbo].[TGR_ControlStock_OnInsert_NroControl]
	ON [dbo].[ControlStock]
	FOR INSERT
AS
BEGIN
	
	/*------------------------------------------------
	----------- GENERO EL NRO DE CONTROL ---------------		
	--------------------------------------------------*/

	DECLARE @ControlStockId int
	DECLARE @NroControl int
	SELECT @ControlStockId = ControlStockId,
			@NroControl = NroControl
	FROM inserted
	
	IF @NroControl IS NULL
	BEGIN
		UPDATE ControlStock
		SET NroControl = ISNULL(((SELECT MAX(NroControl)
							FROM ControlStock) + 1), 1)
		WHERE ControlStockId = @ControlStockId
	END
	
END

GO



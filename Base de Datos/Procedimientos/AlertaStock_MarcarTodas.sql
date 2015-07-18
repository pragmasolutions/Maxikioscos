
/****** Object:  StoredProcedure [dbo].[AlertaStock_MarcarTodas]    Script Date: 08/09/2014 15:47:13 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AlertaStock_MarcarTodas]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[AlertaStock_MarcarTodas]
GO

CREATE PROCEDURE [dbo].[AlertaStock_MarcarTodas]
AS
BEGIN
	UPDATE AlertaStock
	SET Marcada = 1
	WHERE Marcada = 0
END

GO



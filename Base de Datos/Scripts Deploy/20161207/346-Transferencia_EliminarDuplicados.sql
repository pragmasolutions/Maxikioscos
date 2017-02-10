/****** Object:  StoredProcedure [dbo].[Transferencia_EliminarDuplicados]    Script Date: 10/04/2014 12:55:31 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Transferencia_EliminarDuplicados]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Transferencia_EliminarDuplicados]
GO

CREATE PROCEDURE [dbo].[Transferencia_EliminarDuplicados]	
AS
BEGIN
	DELETE FROM TransferenciaProducto
	WHERE Identifier = '00000000-0000-0000-0000-000000000000'
END

GO



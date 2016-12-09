CREATE PROCEDURE [dbo].[Transferencia_EliminarDuplicados]	
AS
BEGIN
	DELETE FROM TransferenciaProducto
	WHERE Identifier = '00000000-0000-0000-0000-000000000000'
END

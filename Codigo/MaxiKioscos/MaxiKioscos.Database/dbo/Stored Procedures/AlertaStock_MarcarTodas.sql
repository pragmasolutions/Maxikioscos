
CREATE PROCEDURE AlertaStock_MarcarTodas
AS
BEGIN
	UPDATE AlertaStock
	SET Marcada = 1
	WHERE Marcada = 0
END


CREATE PROCEDURE Rubro_ListadoPorKiosco
	@MaxiKioscoId int
AS
BEGIN
	SELECT R.*,
			TieneExcepciones = (CASE 
									WHEN (SELECT TOP 1 1 FROM ExcepcionRubro ER 
									 WHERE ER.RubroId = R.RubroId
									 AND ER.MaxiKioscoId = @MaxiKioscoId) IS NULL THEN 'No'
									ELSE 'Si'
								END)
	FROM Rubro R
	WHERE R.Eliminado = 0
									 
	
END

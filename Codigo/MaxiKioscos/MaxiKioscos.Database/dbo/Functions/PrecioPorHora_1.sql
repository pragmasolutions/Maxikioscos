

CREATE FUNCTION [dbo].[PrecioPorHora]
(	
	@ProductoId int
)
RETURNS @PrecioConIVA TABLE (	PrecioConIVA money)
AS
BEGIN
	INSERT @PrecioConIVA SELECT PrecioConIVA =CASE 
									WHEN (dbo.EntreHorarios(ER.Desde,ER.Hasta)=1)
									THEN (P.PrecioConIVA + ISNULL(ER.RecargoAbsoluto, (PrecioConIVA * (ER.RecargoPorcentaje/100)))) 
									ELSE P.PrecioConIVA
								END
					FROM ExcepcionRubro ER INNER JOIN Producto P
						ON ER.RubroId=P.RubroId
					WHERE P.ProductoId=@ProductoId
						AND ER.Eliminado = 0
						AND  dbo.EntreHorarios(ER.Desde,ER.Hasta)=1
	
	RETURN 
END




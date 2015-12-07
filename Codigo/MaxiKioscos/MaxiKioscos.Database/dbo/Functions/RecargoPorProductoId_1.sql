

CREATE FUNCTION [dbo].[RecargoPorProductoId]
(	
	@ProductoId int
)
RETURNS @Recargo TABLE (	Recargo money NULL)
AS
BEGIN
	INSERT @Recargo SELECT Recargo =CASE 
									WHEN ER.RecargoAbsoluto IS NOT NULL
									THEN ER.RecargoAbsoluto
									ELSE (ISNULL(ER.RecargoPorcentaje,0) * P.PrecioConIVA) / 100
								END
					FROM ExcepcionRubro ER INNER JOIN Producto P
						ON ER.RubroId=P.RubroId
					WHERE P.ProductoId=@ProductoId
					AND  dbo.EntreHorarios(ER.Desde,ER.Hasta)=1
	
	RETURN 
END




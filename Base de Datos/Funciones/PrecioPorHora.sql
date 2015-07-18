/****** Object:  UserDefinedFunction [dbo].[PrecioPorHora]    Script Date: 02/09/2015 20:19:55 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PrecioPorHora]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[PrecioPorHora]
GO


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


GO



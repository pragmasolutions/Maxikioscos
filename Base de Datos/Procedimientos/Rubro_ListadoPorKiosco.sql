/****** Object:  StoredProcedure [dbo].[Rubro_ListadoPorKiosco]    Script Date: 08/09/2014 15:48:58 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Rubro_ListadoPorKiosco]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Rubro_ListadoPorKiosco]
GO

CREATE PROCEDURE [dbo].[Rubro_ListadoPorKiosco]
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

GO



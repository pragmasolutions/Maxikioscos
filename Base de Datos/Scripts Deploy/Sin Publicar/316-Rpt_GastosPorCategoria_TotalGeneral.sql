/****** Object:  StoredProcedure [dbo].[Rpt_GastosPorCategoria_TotalGeneral]    Script Date: 11/14/2015 12:01:52 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Rpt_GastosPorCategoria_TotalGeneral]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Rpt_GastosPorCategoria_TotalGeneral]
GO


CREATE PROCEDURE [dbo].[Rpt_GastosPorCategoria_TotalGeneral]
	@Desde datetime2(7),
	@Hasta datetime2(7)
AS
BEGIN
	SELECT
		Categoria 
		,SubCategoria
		,MaxiKiosco = M.Nombre	 		  	  
		,ImporteTotal = SUM(C.Monto)
	FROM
		(SELECT CategoriaCostoId, Descripcion as Categoria FROM CategoriaCosto WHERE PadreId IS NULL) CC	
	INNER JOIN (SELECT PadreId, CategoriaCostoId, Descripcion as SubCategoria FROM CategoriaCosto WHERE PadreId IS NOT NULL) SC
		ON CC.CategoriaCostoId = SC.PadreId
	INNER JOIN Costo C
		ON SC.CategoriaCostoId = C.CategoriaCostoId	  	  	  	  	  
	LEFT OUTER JOIN MaxiKiosco M
		ON C.MaxikioscoId = M.MaxiKioscoId		
	WHERE 
	        (@Desde IS NULL OR C.Fecha >= @Desde)
		AND (@Hasta IS NULL OR c.Fecha <= @Hasta)				
	GROUP BY Categoria, SubCategoria, M.Nombre
	ORDER BY Categoria, SubCategoria DESC
END



GO



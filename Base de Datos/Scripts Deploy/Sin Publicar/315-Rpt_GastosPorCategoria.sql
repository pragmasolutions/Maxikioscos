/****** Object:  StoredProcedure [dbo].[Rpt_GastosPorCategoria]    Script Date: 11/14/2015 12:00:45 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Rpt_GastosPorCategoria]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Rpt_GastosPorCategoria]
GO


CREATE PROCEDURE [dbo].[Rpt_GastosPorCategoria]
	@Desde datetime2(7),
	@Hasta datetime2(7),	
	@MaxikioscoId int,
	@CategoriaCostoId int,
	@SubCategoriaCostoId int
AS
BEGIN
	SELECT
		Categoria 
		,SubCategoria
		,MaxiKiosco = M.Nombre	 
		,C.Fecha 	  	  
		,ImporteTotal = C.Monto
		,Observaciones
		,C.NroComprobante
	FROM
		(SELECT CategoriaCostoId, Descripcion as Categoria FROM CategoriaCosto WHERE PadreId IS NULL) CC	
	LEFT OUTER JOIN (SELECT PadreId, CategoriaCostoId, Descripcion as SubCategoria FROM CategoriaCosto WHERE PadreId IS NOT NULL) SC
		ON CC.CategoriaCostoId = SC.PadreId
	INNER JOIN Costo C
		ON SC.CategoriaCostoId = C.CategoriaCostoId	  	  	  	  	  
	LEFT OUTER JOIN MaxiKiosco M
		ON C.MaxikioscoId = M.MaxiKioscoId		
	WHERE 
	        (@Desde IS NULL OR C.Fecha >= @Desde)
		AND (@Hasta IS NULL OR c.Fecha <= @Hasta)		
		AND (@MaxikioscoId IS NULL OR M.MaxikioscoId = @MaxikioscoId)		
		AND (@CategoriaCostoId IS NULL OR CC.CategoriaCostoId = @CategoriaCostoId)	
		AND (@SubCategoriaCostoId IS NULL OR SC.CategoriaCostoId = @SubCategoriaCostoId)	
	GROUP BY Categoria, SubCategoria, M.Nombre, C.Fecha, C.Monto, Observaciones, C.NroComprobante
	ORDER BY Categoria, SubCategoria, M.Nombre, C.Monto DESC
END



GO



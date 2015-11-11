USE [MaxiKioscos]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[Rpt_GastosPorCategoria]
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
		,C.NroComprobante
	FROM
		(SELECT CategoriaCostoId, Descripcion as Categoria FROM CategoriaCosto WHERE PadreId IS NULL) CC	
	LEFT OUTER JOIN (SELECT PadreId, CategoriaCostoId, Descripcion as SubCategoria FROM CategoriaCosto WHERE PadreId IS NOT NULL) SC
		ON CC.CategoriaCostoId = SC.PadreId
	INNER JOIN Costo C
		ON SC.CategoriaCostoId = C.CategoriaCostoId	  	  	  	  	  
	INNER JOIN MaxiKiosco M
		ON C.MaxikioscoId = M.MaxiKioscoId		
	WHERE 
	        (@Desde IS NULL OR C.Fecha >= @Desde)
		AND (@Hasta IS NULL OR c.Fecha <= @Hasta)		
		AND (@MaxikioscoId IS NULL OR M.MaxikioscoId = @MaxikioscoId)		
		AND (@CategoriaCostoId IS NULL OR CC.CategoriaCostoId = @CategoriaCostoId)	
		AND (@SubCategoriaCostoId IS NULL OR SC.CategoriaCostoId = @SubCategoriaCostoId)	
	GROUP BY Categoria, SubCategoria, M.Nombre, C.Fecha, C.Monto, C.NroComprobante
	ORDER BY Categoria, SubCategoria, M.Nombre, C.Monto DESC
END



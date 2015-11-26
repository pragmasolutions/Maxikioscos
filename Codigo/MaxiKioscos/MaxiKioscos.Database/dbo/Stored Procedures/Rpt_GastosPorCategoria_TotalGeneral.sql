
CREATE PROCEDURE [dbo].[Rpt_GastosPorCategoria_TotalGeneral]
	@Desde datetime2(7),
	@Hasta datetime2(7),
	@MaxikioscoId int,
	@CategoriaCostoId int,
	@SubCategoriaCostoId int
AS
BEGIN
SELECT 
	T.Categoria 
	,SubCategoria
	,MaxiKiosco
	,ImporteTotal = SUM(Monto)
FROM
	(SELECT
		CC.Categoria 
		,SC.SubCategoria
		,MaxiKiosco = (CASE WHEN C.MaxikioscoId IS NULL THEN M2.Nombre ELSE M.Nombre END)
		,C.Monto
	FROM
		(SELECT CategoriaCostoId, Descripcion as Categoria FROM CategoriaCosto WHERE PadreId IS NULL) CC	
	INNER JOIN (SELECT PadreId, CategoriaCostoId, Descripcion as SubCategoria FROM CategoriaCosto WHERE PadreId IS NOT NULL) SC
		ON CC.CategoriaCostoId = SC.PadreId
	INNER JOIN Costo C
		ON SC.CategoriaCostoId = C.CategoriaCostoId	  	  	  	  	  
	LEFT OUTER JOIN MaxiKiosco M
		ON C.MaxikioscoId = M.MaxiKioscoId		
	LEFT OUTER JOIN CierreCaja CR
		ON CR.CierreCajaId = C.CierreCajaId
	LEFT OUTER JOIN Maxikiosco M2 
		ON M2.MaxikioscoId = CR.MaxikioskoId
	WHERE C.Eliminado = 0
	    AND (@Desde IS NULL OR C.Fecha >= @Desde)
		AND (@Hasta IS NULL OR c.Fecha <= @Hasta)		
		AND (@MaxikioscoId IS NULL OR C.MaxikioscoId = @MaxikioscoId OR @MaxikioscoId = CR.MaxiKioskoId)		
		AND (@CategoriaCostoId IS NULL OR CC.CategoriaCostoId = @CategoriaCostoId)
		AND (@SubCategoriaCostoId IS NULL OR SC.CategoriaCostoId = @SubCategoriaCostoId)) T				
	GROUP BY T.Categoria, SubCategoria, MaxiKiosco
	ORDER BY Categoria, SubCategoria DESC
END


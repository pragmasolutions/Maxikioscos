DROP PROCEDURE [dbo].[Rpt_GastosPorCategoria_TotalGeneral]
GO

CREATE PROCEDURE [dbo].[Rpt_GastosPorCategoria_TotalGeneral]
	@Desde datetime2(7),
	@Hasta datetime2(7),
	@MaxikioscoId int,
	@CategoriaCostoId int,
	@SubCategoriaCostoId int
AS
BEGIN

DECLARE @LocDesde datetime2(7) = @Desde,
		@LocHasta datetime2(7) = @Hasta,
		@LocMaxikioscoId int = @MaxikioscoId,
		@LocCategoriaCostoId int = @CategoriaCostoId,
		@LocSubCategoriaCostoId int = @SubCategoriaCostoId

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
	    AND (@LocDesde IS NULL OR C.Fecha >= @LocDesde)
		AND (@LocHasta IS NULL OR c.Fecha <= @LocHasta)		
		AND (@LocMaxikioscoId IS NULL OR C.MaxikioscoId = @LocMaxikioscoId OR @LocMaxikioscoId = CR.MaxiKioskoId)		
		AND (@LocCategoriaCostoId IS NULL OR CC.CategoriaCostoId = @LocCategoriaCostoId)
		AND (@LocSubCategoriaCostoId IS NULL OR SC.CategoriaCostoId = @LocSubCategoriaCostoId)) T				
	GROUP BY T.Categoria, SubCategoria, MaxiKiosco
	ORDER BY Categoria, SubCategoria DESC
END


GO



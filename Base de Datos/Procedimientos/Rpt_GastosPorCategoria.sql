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

DECLARE @LocDesde datetime2(7) = @Desde,
		@LocHasta datetime2(7) = @Hasta,	
		@LocMaxikioscoId int = @MaxikioscoId,
		@LocCategoriaCostoId int = @CategoriaCostoId,
		@LocSubCategoriaCostoId int = @SubCategoriaCostoId

SELECT 
		Categoria 
		,SubCategoria
		,MaxiKiosco
		,Fecha 	  	  
		,ImporteTotal
		,Observaciones
		,NroComprobante
FROM
	(SELECT
		Categoria 
		,SubCategoria
		,MaxiKiosco = (CASE WHEN C.MaxikioscoId IS NULL THEN M2.Nombre ELSE M.Nombre END)
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
	GROUP BY Categoria, SubCategoria, MaxiKiosco, Fecha, ImporteTotal, Observaciones, NroComprobante
	ORDER BY Categoria, SubCategoria, MaxiKiosco, ImporteTotal DESC
END


GO



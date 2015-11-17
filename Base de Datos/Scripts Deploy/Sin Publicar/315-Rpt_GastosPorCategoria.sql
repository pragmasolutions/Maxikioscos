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
	WHERE 
	        (@Desde IS NULL OR C.Fecha >= @Desde)
		AND (@Hasta IS NULL OR c.Fecha <= @Hasta)		
		AND (@MaxikioscoId IS NULL OR C.MaxikioscoId = @MaxikioscoId OR @MaxikioscoId = CR.MaxiKioskoId)		
		AND (@CategoriaCostoId IS NULL OR CC.CategoriaCostoId = @CategoriaCostoId)
		AND (@SubCategoriaCostoId IS NULL OR SC.CategoriaCostoId = @SubCategoriaCostoId)) T		
	GROUP BY Categoria, SubCategoria, MaxiKiosco, Fecha, ImporteTotal, Observaciones, NroComprobante
	ORDER BY Categoria, SubCategoria, MaxiKiosco, ImporteTotal DESC
END

GO



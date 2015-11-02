/****** Object:  StoredProcedure [dbo].[Rpt_DineroSobranteFaltante]    Script Date: 01/24/2015 16:09:02 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Rpt_DineroSobranteFaltante]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Rpt_DineroSobranteFaltante]
GO


CREATE PROCEDURE [dbo].[Rpt_DineroSobranteFaltante]
	@Desde datetime2(7),
	@Hasta datetime2(7),
	@MaxiKioscoId int,
	@CuentaId int
AS
BEGIN

	WITH ReporteCTE (Maxikiosco, Mes, Anio, CajaDiferencia, StockDiferenciaPositiva, 
					StockDiferenciaNegativa, Diferencia)
	AS
	(
		SELECT
				   Maxikiosco = SobranteFaltante.Maxikiosco,
				   Mes = SobranteFaltante.Mes,
				   Anio = SobranteFaltante.Anio,
				   CajaDiferencia = ISNULL(SUM(SobranteFaltante.CajaDiferencia),0),
				   StockDiferenciaPositiva = ISNULL(SUM(SobranteFaltante.StockDiferenciaPositiva),0),
				   StockDiferenciaNegativa = ISNULL(SUM(SobranteFaltante.StockDiferenciaNegativa),0),
				   Diferencia = ISNULL(SUM(SobranteFaltante.Diferencia),0)
		FROM
		(
			(
				SELECT Maxikiosco = M.Nombre,
					   Mes = DATEPART(MONTH, CC.FechaInicio),
					   Anio = DATEPART(YEAR, CC.FechaInicio),
					   CajaDiferencia = ISNULL(SUM(CC.CajaFinal - CC.CajaEsperada),0),
					   StockDiferenciaPositiva = 0,
					   StockDiferenciaNegativa = 0,
					   Diferencia =  ISNULL(SUM(CC.CajaFinal - CC.CajaEsperada),0)

				FROM CierreCaja CC
						INNER JOIN MaxiKiosco M 
							ON CC.MaxiKioskoId = M.MaxiKioscoId
				WHERE 
					(@Desde IS NULL OR CC.FechaInicio >= @Desde)
					AND (@Hasta IS NULL OR CC.FechaInicio <= @Hasta)
					AND (@MaxiKioscoId IS NULL OR CC.MaxiKioskoId = @MaxiKioscoId)
					AND (@CuentaId IS NULL OR M.CuentaId = @CuentaId)	
					AND CC.CajaFinal - CC.CajaEsperada > 0

				GROUP BY M.Nombre, DATEPART(YEAR, CC.FechaInicio), DATEPART(MONTH, CC.FechaInicio)
			) 
		
		UNION ALL

			(
				SELECT Maxikiosco = M.Nombre,
					   Mes = DATEPART(MONTH, CS.FechaCreacion),
					   Anio = DATEPART(YEAR, CS.FechaCreacion),
					   CajaDiferencia = 0,
					   StockDiferenciaPositiva = 0,
					   StockDiferenciaNegativa = -SUM(CSD.Precio),
					   Diferencia = -SUM(CSD.Precio) 
				FROM ControlStockDetalle CSD
					INNER JOIN ControlStock CS
						ON CSD.ControlStockId = CS.ControlStockId
					INNER JOIN MaxiKiosco M
						ON CS.MaxiKioscoId = M.MaxiKioscoId
				WHERE (@Desde IS NULL OR CS.FechaCreacion >= @Desde) 
					 AND (@Hasta IS NULL OR CS.FechaCreacion <= @Hasta)  
					 AND CSD.MotivoCorreccionId = 6 --SIN MOTIVO
					 AND (@MaxiKioscoId IS NULL OR CS.MaxiKioscoId = @MaxiKioscoId)
					 AND (@CuentaId IS NULL OR M.CuentaId = @CuentaId)	
				GROUP BY M.Nombre, DATEPART(YEAR, CS.FechaCreacion), DATEPART(MONTH, CS.FechaCreacion)
			)
			
		UNION ALL

			(
				SELECT Maxikiosco = M.Nombre,
					   Mes = DATEPART(MONTH, CS.FechaCreacion),
					   Anio = DATEPART(YEAR, CS.FechaCreacion),
					   CajaDiferencia = 0,
					   StockDiferenciaPositiva = SUM(CSD.Precio),
					   StockDiferenciaNegativa = 0,
					   Diferencia = SUM(CSD.Precio) 
				FROM ControlStockDetalle CSD
					INNER JOIN ControlStock CS
						ON CSD.ControlStockId = CS.ControlStockId
					INNER JOIN MaxiKiosco M
						ON CS.MaxiKioscoId = M.MaxiKioscoId
				WHERE (@Desde IS NULL OR CS.FechaCreacion >= @Desde) 
					 AND (@Hasta IS NULL OR CS.FechaCreacion <= @Hasta)  
					 AND CSD.MotivoCorreccionId = 4 --REPOSICION
					 AND (@MaxiKioscoId IS NULL OR CS.MaxiKioscoId = @MaxiKioscoId)
					 AND (@CuentaId IS NULL OR M.CuentaId = @CuentaId)	
				GROUP BY M.Nombre, DATEPART(YEAR, CS.FechaCreacion), DATEPART(MONTH, CS.FechaCreacion)
			)

		UNION ALL

			(
				SELECT Maxikiosco = M.Nombre,
					   Mes = DATEPART(MONTH, E.FechaCarga),
					   Anio = DATEPART(YEAR, E.FechaCarga),
					   CajaDiferencia = E.Importe,
					   StockDiferenciaPositiva = 0,
					   StockDiferenciaNegativa = 0,
					   Diferencia = SUM(E.Importe) 
				FROM Excepcion E
				INNER JOIN CierreCaja CC
					ON E.CierreCajaId = CC.CierreCajaId
				INNER JOIN MaxiKiosco M
					ON CC.MaxiKioskoId = M.MaxiKioscoId
				WHERE (@Desde IS NULL OR E.FechaCarga >= @Desde) 
				 AND (@Hasta IS NULL OR E.FechaCarga <= @Hasta)  
				 AND (@MaxiKioscoId IS NULL OR CC.MaxiKioskoId = @MaxiKioscoId)
				 GROUP BY M.Nombre, DATEPART(YEAR, E.FechaCarga), DATEPART(MONTH, E.FechaCarga), E.Importe
			)

		) SobranteFaltante

		GROUP BY SobranteFaltante.Maxikiosco, SobranteFaltante.Anio, SobranteFaltante.Mes
	)
	
	SELECT *
	FROM ReporteCTE	
END



GO



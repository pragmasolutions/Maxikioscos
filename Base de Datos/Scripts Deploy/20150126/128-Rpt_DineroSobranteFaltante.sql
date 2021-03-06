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

	WITH ReporteCTE (Maxikiosco, Mes, Anio, CajaDiferencia, StockDiferencia, Diferencia)
	AS
	(
		SELECT
				   Maxikiosco = SobranteFaltante.Maxikiosco,
				   Mes = SobranteFaltante.Mes,
				   Anio = SobranteFaltante.Anio,
				   CajaDiferencia = ISNULL(SUM(SobranteFaltante.CajaDiferencia),0),
				   StockDiferencia = ISNULL(SUM(SobranteFaltante.StockDiferencia),0),
				   Diferencia = ISNULL(SUM(SobranteFaltante.Diferencia),0)
		FROM
		(
			(
				SELECT Maxikiosco = M.Nombre,
					   Mes = DATEPART(MONTH, CC.FechaInicio),
					   Anio = DATEPART(YEAR, CC.FechaInicio),
					   CajaDiferencia = ISNULL(SUM(CC.CajaFinal - CC.CajaEsperada),0),
					   StockDiferencia = 0,
					   Diferencia =  ISNULL(SUM(CC.CajaFinal - CC.CajaEsperada),0)

				FROM CierreCaja CC
						INNER JOIN MaxiKiosco M 
							ON CC.MaxiKioskoId = M.MaxiKioscoId

				WHERE 
					(@Desde IS NULL OR CC.FechaInicio >= @Desde)
					AND (@Hasta IS NULL OR CC.FechaInicio <= @Hasta)
					AND (@MaxiKioscoId IS NULL OR CC.MaxiKioskoId = @MaxiKioscoId)
					AND (@CuentaId IS NULL OR M.CuentaId = @CuentaId)	
					

				GROUP BY M.Nombre, DATEPART(YEAR, CC.FechaInicio), DATEPART(MONTH, CC.FechaInicio)
			) 
		
		UNION ALL

			(
				SELECT Maxikiosco = M.Nombre,
					   Mes = DATEPART(MONTH, CS.FechaCreacion),
					   Anio = DATEPART(YEAR, CS.FechaCreacion),
					   CajaDiferencia = 0,
					   StockDiferencia = -SUM(CSD.Precio),
					   Diferencia = -SUM(CSD.Precio) 
				FROM ControlStockDetalle CSD
				INNER JOIN ControlStock CS
					ON CSD.ControlStockId = CS.ControlStockId
				INNER JOIN MaxiKiosco M
					ON CS.MaxiKioscoId = M.MaxiKioscoId
				WHERE (@Desde IS NULL OR CS.FechaCreacion >= @Desde) 
				 AND (@Hasta IS NULL OR CS.FechaCreacion <= @Hasta)  		
					--MotivoCorreccionId = 6 'SIN MOTIVO'
				 AND CSD.MotivoCorreccionId = 6
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
					   StockDiferencia = 0,
					   Diferencia = SUM(E.Importe) 
				FROM Excepcion E
				INNER JOIN CierreCaja CC
					ON E.CierreCajaId = CC.CierreCajaId
				INNER JOIN MaxiKiosco M
					ON CC.MaxiKioskoId = M.MaxiKioscoId
				WHERE (@Desde IS NULL OR E.FechaCarga >= @Desde) 
				 AND (@Hasta IS NULL OR E.FechaCarga <= @Hasta)  		
					--MotivoCorreccionId = 6 'SIN MOTIVO'
				 AND (@MaxiKioscoId IS NULL OR CC.MaxiKioskoId = @MaxiKioscoId)
				 GROUP BY M.Nombre, DATEPART(YEAR, E.FechaCarga), DATEPART(MONTH, E.FechaCarga), E.Importe
			)

		UNION ALL

			(
				SELECT Maxikiosco = M.Nombre,
					   Mes = DATEPART(MONTH, CS.Fecha),
					   Anio = DATEPART(YEAR, CS.Fecha),
					   CajaDiferencia = 0,
					   StockDiferencia = SUM(CS.Precio * CS.Cantidad),
					   Diferencia = SUM(CS.Precio * CS.Cantidad) 
							 FROM CorreccionStock CS
							 INNER JOIN MaxiKiosco M
								ON CS.MaxiKioscoId = M.MaxiKioscoId
							 WHERE (@Desde IS NULL OR CS.Fecha >= @Desde) 
								AND (@Hasta IS NULL OR CS.Fecha <= @Hasta)  		
									--MotivoCorreccionId = 1 'RETIRO'
								AND CS.MotivoCorreccionId = 6
								AND (@MaxiKioscoId IS NULL OR CS.MaxiKioscoId = @MaxiKioscoId)
								AND (@CuentaId IS NULL OR M.CuentaId = @CuentaId)

				GROUP BY M.Nombre, DATEPART(YEAR, CS.Fecha), DATEPART(MONTH, CS.Fecha)
			)

		) SobranteFaltante

		GROUP BY SobranteFaltante.Maxikiosco, SobranteFaltante.Anio, SobranteFaltante.Mes
	)
	
	SELECT *
	FROM ReporteCTE
	WHERE CajaDiferencia > 0
END



GO



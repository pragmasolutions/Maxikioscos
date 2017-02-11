DROP PROCEDURE [dbo].[Rpt_CierresDeCajaDetalle]
GO

CREATE PROCEDURE [dbo].[Rpt_CierresDeCajaDetalle]
	@Desde datetime2(7),
	@Hasta datetime2(7),
	@MaxiKioscoId int,
	@UsuarioId int,
	@CuentaId int
AS
BEGIN
	DECLARE @LocDesde datetime2(7) = @Desde,
			@LocHasta datetime2(7) = @Hasta,
			@LocMaxiKioscoId int = @MaxiKioscoId,
			@LocUsuarioId int = @UsuarioId,
			@LocCuentaId int = @CuentaId

	DECLARE @ReporteCTE TABLE
	(
		MaxiKioscoNombre varchar(100), 
		UsuarioNombre varchar(50), 
		UsuarioApellido varchar(50), 
		FechaInicio datetime, 
		Caja varchar(100),
		Inicial money, 
		Ventas money, 
		Compras money, 
		Ingresos money, 
		Excepciones money, 
		Retiros money, 		
		Costos money,
		RetirosPersonales money,
		Cierre money,
		Diferencia money
	)
	
	
	INSERT INTO @ReporteCTE
	SELECT DISTINCT
	   M.Abreviacion
	   ,U.Nombre 
	   ,U.Apellido
	   ,CC.FechaInicio
	   ,CASE ISNULL(ISNULL(CAST(CC.FechaFin as varchar), ''), '')
		WHEN '' THEN CONVERT(VARCHAR(10), CC.FechaInicio, 103) + ' ' + CONVERT(VARCHAR(8), CC.FechaInicio, 108) + ' - Todavía abierta'
		ELSE CONVERT(VARCHAR(10), CC.FechaInicio, 103) + ' ' + CONVERT(VARCHAR(8), CC.FechaInicio, 108) + ' - ' + CONVERT(VARCHAR(10), CC.FechaFin, 103) + ' ' + CONVERT(VARCHAR(8), CC.FechaFin, 108)
       END
	   ,CC.CajaInicial
	   ,V.Monto
	   ,C.Monto
	   ,OPCR.Monto
	   ,EX.Monto
	   ,OPCE.Monto
	   ,CO.Monto
	   ,RP.ImporteTotal
	   ,CC.CajaFinal
	   ,ISNULL(CC.Diferencia, 0)
	FROM
	  CierreCaja CC
	  LEFT JOIN OperacionCaja OPC
		ON CC.CierreCajaId = OPC.CierreCajaId
	  LEFT JOIN MaxiKiosco M
		ON CC.MaxiKioskoId = M.MaxiKioscoId
	  LEFT JOIN Usuario U 
		ON CC.UsuarioId = U.UsuarioId
	  CROSS APPLY (SELECT Monto = SUM(V.ImporteTotal) 
				   FROM Venta V 
				   WHERE V.CierreCajaId = CC.CierreCajaId) V
	  CROSS APPLY (SELECT Monto = SUM(F.ImporteTotal) 
				   FROM Factura F
					   INNER JOIN Proveedor P
							ON F.ProveedorId = P.ProveedorId								 
				   WHERE (F.CierreCajaId = CC.CierreCajaId
							OR (F.MaxiKioscoId = CC.MaxiKioskoId
								AND F.FechaCreacion >= CC.FechaInicio 
								AND F.FechaCreacion <= ISNULL(CC.FechaFin, GETDATE())))
						AND P.NoReflejarFacturaEnCaja = 0
						AND F.Eliminado = 0) C
	  CROSS APPLY (SELECT Monto = SUM(OPC.Monto) 
				   FROM OperacionCaja OPC 
				   WHERE OPC.CierreCajaId = CC.CierreCajaId
				   --MotivoId = 1 Refuerzo
				   AND OPC.MotivoId = 1
				   AND OPC.Eliminado = 0) OPCR
	  CROSS APPLY (SELECT Monto = SUM(OPC.Monto) 
				   FROM OperacionCaja OPC 
				   WHERE OPC.CierreCajaId = CC.CierreCajaId
				   --MotivoId = 2 Extracción
				   AND OPC.MotivoId = 2
				   AND OPC.Eliminado = 0) OPCE
	  CROSS APPLY (SELECT Monto = SUM(EX.Importe) 
				   FROM Excepcion EX 
				   WHERE EX.CierreCajaId = CC.CierreCajaId
				   AND EX.Eliminado = 0) EX
	  CROSS APPLY (SELECT Monto = SUM(C.Monto) 
				   FROM Costo C	
						LEFT JOIN Turno TU ON C.TurnoId = TU.TurnoId				 
				   WHERE (C.CierreCajaId = CC.CierreCajaId
							OR (TU.TurnoId IS NOT NULL 
								AND (
									C.MaxikioscoId = CC.MaxiKioskoId
									AND C.Fecha + TU.HoraMedia >= CC.FechaInicio 
									AND C.Fecha + TU.HoraMedia <= ISNULL(CC.FechaFin, GETDATE())))
								)
						AND C.Eliminado = 0) CO
	  CROSS APPLY (SELECT ImporteTotal = SUM(RP.ImporteTotal) 
				   FROM RetiroPersonal RP
				   WHERE RP.CierreCajaId = CC.CierreCajaId
				   AND RP.Eliminado = 0) RP
							
	 WHERE 
		(@LocDesde IS NULL OR CC.FechaInicio >= @LocDesde)
		AND (@LocHasta IS NULL OR CC.FechaInicio <= @LocHasta)
		AND (@LocMaxiKioscoId IS NULL OR CC.MaxiKioskoId = @LocMaxiKioscoId)
		AND (@LocUsuarioId IS NULL OR CC.UsuarioId = @LocUsuarioId)
		AND (@LocCuentaId IS NULL OR M.CuentaId = @LocCuentaId)
	 ORDER BY M.Abreviacion, CC.FechaInicio, U.Nombre, U.Apellido

	SELECT CTE.MaxiKioscoNombre, 
			CTE.UsuarioNombre, 
			CTE.UsuarioApellido, 
			CTE.FechaInicio, 
			CTE.Caja,
			CTE.Inicial, 
			CTE.Ventas, 
			CTE.Compras, 
			CTE.Ingresos, 
			CTE.Excepciones, 
			CTE.Retiros,
			CTE.Costos,
			CTE.RetirosPersonales,
			CTE.Cierre,
			Diferencia = (CTE.Diferencia - ISNULL(CTE.Excepciones, 0))
	FROM @ReporteCTE CTE
	
END




GO



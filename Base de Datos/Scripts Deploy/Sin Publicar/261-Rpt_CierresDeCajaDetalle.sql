IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Rpt_CierresDeCajaDetalle]') AND type in (N'P', N'PC'))
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
		RetirosPersonales money,
		Costos money,
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
		WHEN '' THEN CONVERT(VARCHAR(10), CC.FechaInicio, 103) + ' ' + CONVERT(VARCHAR(8), CC.FechaInicio, 108) + ' - Todav�a abierta'
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
				   WHERE V.CierreCajaId = CC.CierreCajaid) V
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
				   WHERE OPC.CierreCajaId = CC.CierreCajaid
				   --MotivoId = 1 Refuerzo
				   AND OPC.MotivoId = 1
				   AND OPC.Eliminado = 0) OPCR
	  CROSS APPLY (SELECT Monto = SUM(OPC.Monto) 
				   FROM OperacionCaja OPC 
				   WHERE OPC.CierreCajaId = CC.CierreCajaid
				   --MotivoId = 2 Extracci�n
				   AND OPC.MotivoId = 2
				   AND OPC.Eliminado = 0) OPCE
	  CROSS APPLY (SELECT Monto = SUM(EX.Importe) 
				   FROM Excepcion EX 
				   WHERE EX.CierreCajaId = CC.CierreCajaid
				   AND EX.Eliminado = 0) EX
	  CROSS APPLY (SELECT Monto = SUM(C.Monto) 
				   FROM Costo C 
				   WHERE C.CierreCajaId = CC.CierreCajaid
				   AND C.Eliminado = 0) CO
	  CROSS APPLY (SELECT ImporteTotal = SUM(RP.ImporteTotal) 
				   FROM RetiroPersonal RP
				   WHERE RP.CierreCajaId = CC.CierreCajaid
				   AND RP.Eliminado = 0) RP
							
	 WHERE 
		(@Desde IS NULL OR CC.FechaInicio >= @Desde)
		AND (@Hasta IS NULL OR CC.FechaInicio <= @Hasta)
		AND (@MaxiKioscoId IS NULL OR CC.MaxiKioskoId = @MaxiKioscoId)
		AND (@UsuarioId IS NULL OR CC.UsuarioId = @UsuarioId)
		AND (@CuentaId IS NULL OR M.CuentaId = @CuentaId)
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


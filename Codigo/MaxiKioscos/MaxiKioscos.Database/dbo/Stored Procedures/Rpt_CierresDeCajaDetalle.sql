
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
		Cierre money,
		Diferencia money
	)

	INSERT INTO @ReporteCTE
	SELECT DISTINCT
	   M.Nombre
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
	  --CROSS APPLY (SELECT Monto = SUM(CP.Cantidad * CP.CostoActualizado) 
			--	   FROM Compra C
			--	   INNER JOIN CompraProducto CP 
			--	   ON C.CompraId = CP.CompraId
			--	   WHERE C.Fecha >= CC.FechaInicio AND C.Fecha <= CC.FechaFin
			--	   AND C.Eliminado = 0) C
	  CROSS APPLY (SELECT Monto = SUM(F.ImporteFinal) 
				   FROM Factura F
				   WHERE (F.CierreCajaId = CC.CierreCajaId
							OR (F.MaxiKioscoId = CC.MaxiKioskoId
								AND F.FechaCreacion >= CC.FechaInicio 
								AND F.FechaCreacion <= ISNULL(CC.FechaFin, GETDATE())))
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
				   --MotivoId = 2 Extracción
				   AND OPC.MotivoId = 2
				   AND OPC.Eliminado = 0) OPCE
	  CROSS APPLY (SELECT Monto = SUM(EX.Importe) 
				   FROM Excepcion EX 
				   WHERE EX.CierreCajaId = CC.CierreCajaid
				   AND EX.Eliminado = 0) EX
							
	 WHERE 
		(@Desde IS NULL OR CC.FechaInicio >= @Desde)
		AND (@Hasta IS NULL OR CC.FechaInicio <= @Hasta)
		AND (@MaxiKioscoId IS NULL OR CC.MaxiKioskoId = @MaxiKioscoId)
		AND (@UsuarioId IS NULL OR CC.UsuarioId = @UsuarioId)
		AND (@CuentaId IS NULL OR M.CuentaId = @CuentaId)
	 ORDER BY M.Nombre, CC.FechaInicio, U.Nombre, U.Apellido

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
			CTE.Cierre,
			Diferencia = (CTE.Diferencia - ISNULL(CTE.Excepciones, 0))
	FROM @ReporteCTE CTE
	
END


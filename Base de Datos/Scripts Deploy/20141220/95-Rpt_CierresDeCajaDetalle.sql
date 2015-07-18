
/****** Object:  StoredProcedure [dbo].[Rpt_CierresDeCajaDetalle]    Script Date: 12/03/2014 18:13:50 ******/
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
	SELECT DISTINCT
	   MaxiKioscoNombre = M.Nombre
	  ,UsuarioNombre = U.Nombre 
	  ,UsuarioApellido = U.Apellido
	  ,Caja = CASE ISNULL(ISNULL(CAST(CC.FechaFin as varchar), ''), '')
				WHEN '' THEN CONVERT(VARCHAR(10), CC.FechaInicio, 103) + ' ' + CONVERT(VARCHAR(8), CC.FechaInicio, 108) + ' - Todavía abierta'
				ELSE CONVERT(VARCHAR(10), CC.FechaInicio, 103) + ' ' + CONVERT(VARCHAR(8), CC.FechaInicio, 108) + ' - ' + CONVERT(VARCHAR(10), CC.FechaFin, 103) + ' ' + CONVERT(VARCHAR(8), CC.FechaFin, 108)
			  END
	  ,Inicial = CC.CajaInicial
	  ,Ventas = V.Monto
	  ,Compras = C.Monto
	  ,Ingresos = OPCR.Monto
	  ,Excepciones = EX.Monto
	  ,Retiros = OPCE.Monto
	  ,Diferencia = ISNULL(CC.Diferencia, 0)
	  ,Cierre = CC.CajaFinal
	 
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
	
END




GO



/****** Object:  StoredProcedure [dbo].[CierreCaja_CantidadDineroActual]    Script Date: 02/05/2015 18:23:51 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CierreCaja_CantidadDineroActual]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[CierreCaja_CantidadDineroActual]
GO


CREATE PROCEDURE [dbo].[CierreCaja_CantidadDineroActual]
	@CierreCajaId int
AS
BEGIN
	SELECT DineroActualEnCaja = (
							(SELECT CajaInicial 
							 FROM CierreCaja
							 WHERE CierreCajaId = @CierreCajaId)
							 
							+ (SELECT ISNULL(SUM(Monto), 0)
							 FROM OperacionCaja
							 WHERE CierreCajaId = @CierreCajaId
							 AND Eliminado = 0
							)
							- (SELECT ISNULL(SUM(ImporteTotal), 0)
							 FROM Factura F
								INNER JOIN Proveedor P
									ON F.ProveedorId = P.ProveedorId
							 WHERE CierreCajaId = @CierreCajaId
								 AND P.NoReflejarFacturaEnCaja = 0
								 AND F.Eliminado = 0
							)
							+ (SELECT ISNULL(SUM(ImporteTotal), 0)
							 FROM Venta
							 WHERE CierreCajaId = @CierreCajaId
							 AND Eliminado = 0
							)
							- (SELECT ISNULL(SUM(Monto), 0)
							 FROM Costo
							 WHERE CierreCajaId = @CierreCajaId
								AND Eliminado = 0
								
							)
						) 
	
END


GO



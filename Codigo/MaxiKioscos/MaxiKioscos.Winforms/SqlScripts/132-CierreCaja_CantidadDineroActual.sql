ALTER PROCEDURE [dbo].[CierreCaja_CantidadDineroActual]
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

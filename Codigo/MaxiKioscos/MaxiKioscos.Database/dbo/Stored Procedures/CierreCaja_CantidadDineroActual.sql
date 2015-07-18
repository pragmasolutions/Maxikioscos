

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
							)
							- (SELECT ISNULL(SUM(ImporteTotal), 0)
							 FROM Factura
							 WHERE CierreCajaId = @CierreCajaId
							)
							+ (SELECT ISNULL(SUM(ImporteTotal), 0)
							 FROM Venta
							 WHERE CierreCajaId = @CierreCajaId
							)
						) 
	
END


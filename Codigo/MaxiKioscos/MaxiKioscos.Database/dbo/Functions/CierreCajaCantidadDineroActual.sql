
CREATE FUNCTION [dbo].[CierreCajaCantidadDineroActual]
(	
	@CierreCajaId int
)
RETURNS TABLE 
AS
RETURN 
(
	SELECT DineroActualEnCaja = (
							(SELECT CajaInicial 
							 FROM CierreCaja
							 WHERE CierreCajaId = @CierreCajaId
							 AND Eliminado = 0)
							 
							+ (SELECT ISNULL(SUM(Monto), 0)
							 FROM OperacionCaja
							 WHERE CierreCajaId = @CierreCajaId
							 AND Eliminado = 0
							)
							- (SELECT ISNULL(SUM(ImporteTotal), 0)
							 FROM Factura
							 WHERE CierreCajaId = @CierreCajaId
							 AND Eliminado = 0
							)
							+ (SELECT ISNULL(SUM(ImporteTotal), 0)
							 FROM Venta
							 WHERE CierreCajaId = @CierreCajaId
							 AND Eliminado = 0
							)
						) 
)


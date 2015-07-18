IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CierreCajaCantidadDineroActual]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[CierreCajaCantidadDineroActual]
GO

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

GO



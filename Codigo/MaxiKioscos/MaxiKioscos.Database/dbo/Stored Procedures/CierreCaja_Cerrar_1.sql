
CREATE PROCEDURE [dbo].[CierreCaja_Cerrar]
	@MaxiKioscoId int,
	@CajaFinal money
AS
BEGIN
	
	DECLARE @CierreCajaId int
	SET @CierreCajaId = (SELECT TOP 1 CierreCajaId 
						 FROM CierreCaja
						 WHERE FechaFin IS NULL AND MaxiKioskoId = @MaxiKioscoId)					
	
	UPDATE CierreCaja
	SET CajaFinal = @CajaFinal,
		Desincronizado = 1,
		FechaUltimaModificacion = GETDATE(),
		FechaFin = GETDATE(),
		CajaEsperada = (
							CajaInicial 
							+ (SELECT ISNULL(SUM(Monto), 0)
							 FROM OperacionCaja
							 WHERE CierreCajaId = @CierreCajaId
							)
							- (SELECT ISNULL(SUM(F.ImporteTotal), 0)
							 FROM Factura F
								 INNER JOIN Proveedor P
										ON F.ProveedorId = P.ProveedorId
							 WHERE CierreCajaId = @CierreCajaId
								 AND P.NoReflejarFacturaEnCaja = 0
							)
							+ (SELECT ISNULL(SUM(Importe), 0)
							 FROM Excepcion
							 WHERE CierreCajaId = @CierreCajaId
							)
							+ (SELECT ISNULL(SUM(ImporteTotal), 0)
							 FROM Venta
							 WHERE CierreCajaId = @CierreCajaId
							)
							- (SELECT ISNULL(SUM(Monto), 0)
							 FROM Costo
							 WHERE CierreCajaId = @CierreCajaId
							)
						)
	WHERE CierreCajaId = @CierreCajaId
	
	SELECT @CierreCajaId as CierreCajaId
	
END



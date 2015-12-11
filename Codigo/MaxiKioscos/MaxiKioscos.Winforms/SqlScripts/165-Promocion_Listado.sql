CREATE PROCEDURE [dbo].[Promocion_Listado]
	@RubroId int = null,
	@Descripcion varchar(1000) = null,
	@Precio money = null,
	@StockReposicion int = null,
	@ConStockMenorA int = null,
	@Codigo varchar(200) = null
AS
BEGIN
	SELECT P.ProductoId,
	    P.Identifier,
		CodigosListado = (SELECT SUBSTRING(
					(SELECT ',' + Codigo
					FROM CodigoProducto CP 
					WHERE CP.ProductoId = P.ProductoId
						AND CP.Eliminado = 0
					FOR XML PATH('')),2,200000)),
		P.Descripcion,
		CostosResumen = (SELECT SUBSTRING(
					(SELECT ',' + '(' + CR.ProveedorNombre + ') ' + CR.Costo
					FROM dbo.Producto_CostosResumen(P.ProductoId) CR 
					FOR XML PATH('')),2,200000)),
		P.PrecioConIVA
	FROM Producto P
	WHERE P.EsPromocion = 1
		AND P.Eliminado = 0
		AND (@RubroId IS NULL OR P.RubroId = @RubroId)
		AND (@Descripcion IS NULL OR UPPER(P.Descripcion) LIKE '%' + UPPER(@Descripcion) + '%')
		AND (@Precio IS NULL OR P.PrecioConIVA = @Precio)
		AND (@StockReposicion IS NULL OR @StockReposicion = p.StockReposicion)
		AND (@ConStockMenorA IS NULL OR EXISTS(SELECT 1 
												FROM dbo.Promocion_MaxikioscosStock(P.ProductoId) PM
												WHERE PM.Stock < @ConStockMenorA))
		AND (@Codigo IS NULL OR EXISTS(SELECT Codigo
										FROM CodigoProducto CP
										WHERE CP.Eliminado = 0
										AND CP.ProductoId = P.ProductoId
										AND UPPER(CP.Codigo) LIKE UPPER(@Codigo) + '%'))
END

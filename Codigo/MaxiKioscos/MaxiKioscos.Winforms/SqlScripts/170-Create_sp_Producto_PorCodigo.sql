CREATE PROCEDURE [dbo].[Producto_PorCodigo]
 @Codigo varchar(30),
 @MaxiKioscoId int
AS
BEGIN

DECLARE @ProductoId int
DECLARE @StockId int

SET @ProductoId = (SELECT ProductoId 
					FROM CodigoProducto CP 
					WHERE CP.Codigo = @Codigo
						AND CP.Eliminado = 0)
	
	IF(@ProductoId IS NULL)
		BEGIN
			SELECT		
					StockId = null
					,Producto = 'No se encontró el Producto'
					,Codigo = @Codigo
				   ,StockActual = CAST(0 as decimal(8,0))
				   ,FechaUltimaModificacion = GETDATE()
				   ,Desincronizado = null
				   ,Eliminado = null
				   ,Identifier = NEWID()
				   ,HabilitadoParaCorregir = null					
		END
	ELSE
	BEGIN
		DECLARE @Temp Table
			(
				ProductoId int
			)
			INSERT INTO @Temp
			SELECT @ProductoId

			INSERT INTO Stock (ProductoId,
								 MaxiKioscoId,
								 Identifier,
								 StockActual,
								 OperacionCreacion,
								 FechaCreacion,
								 Desincronizado,
								 FechaUltimaModificacion,
								 Eliminado)
			SELECT P.ProductoId,
					@MaxiKioscoId,
					NEWID(),
					0,
					'DESKTOP: sproc ControlStock_Crear',
					GETDATE(),
					1,
					GETDATE(),
					0
			FROM @Temp P
				LEFT JOIN Stock S
					ON P.ProductoId = S.ProductoId
						AND @MaxiKioscoId = S.MaxiKioscoId
			WHERE S.StockId IS NULL
			
			   /*-----------------------------------------------------------------------------------
		 ----------------------- REGISTRO LAS CANTIDADES EN STOCK ----------------------------
		 -----------------------------------------------------------------------------------*/
		 DECLARE @Stock TABLE
		 (
		  StockId int, 
		  ProductoId int,  
		  MaxikioscoId int,  
		  StockActual decimal(18, 2)
		 );
		 
		 WITH CTE(StockId, ProductoId, MaxikioscoId, Fila)
		 AS
		 (
		  SELECT  StockId, 
			ProductoId, 
			MaxiKioscoId,
			ROW_NUMBER() OVER(PARTITION BY ProductoId, MaxikioscoId ORDER BY ProductoId ASC)
		  FROM Stock 
		  WHERE ProductoId = @ProductoId AND MaxikioscoId = @MaxikioscoId
		 )
		 INSERT INTO @Stock
		 SELECT  ST.StockId, 
		   ST.ProductoId,
		   ST.MaxiKioscoId,   
		   ST.StockActual
		 FROM CTE
		  INNER JOIN Stock ST
		   ON CTE.StockId = ST.StockId
		 WHERE CTE.Fila = 1 
		 

		 SELECT		
					S.StockId
					,Producto = PR.Descripcion
					,Codigo = CP.Codigo
				   ,S.StockActual
				   ,FechaUltimaModificacion = GETDATE()
				   ,Desincronizado = 1
				   ,Eliminado = 0
				   ,Identifier = NEWID()
				   ,HabilitadoParaCorregir = 1
		 FROM @Temp P
		  LEFT JOIN @Stock S
		   ON P.ProductoId = S.ProductoId LEFT JOIN Producto PR
		   ON  PR.ProductoId = P.ProductoId LEFT JOIN CodigoProducto CP
		   ON P.ProductoId = CP.ProductoId
			AND S.MaxiKioscoId = @MaxiKioscoId
	END
END
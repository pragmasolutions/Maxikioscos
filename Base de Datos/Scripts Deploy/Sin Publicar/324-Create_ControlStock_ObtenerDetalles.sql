CREATE PROCEDURE [dbo].[ControlStock_ObtenerDetalles]
 @MaxiKioscoId int, 
 @ProveedorId int = NULL,
 @RubroId int = NULL,
 @UsuarioId int,
 @MasVendidos bit,
 @ConStockCero bit,
 @CantidadFilas int,
 @LimiteInferior int,
 @LimiteSuperior int
AS
BEGIN
 DECLARE @Productos TABLE
 (
  Fila int,
  Cantidad int,
  ProductoId int,
  Descripcion varchar(200)
 )

 IF @MasVendidos = 0
  BEGIN
   WITH ProdCTE (ProductoId, Descripcion)
   AS 
   (
    SELECT DISTINCT P.ProductoId, 
        P.Descripcion
    FROM Producto P
     LEFT JOIN ProveedorProducto PP
      ON P.ProductoId = PP.ProductoId
    WHERE P.Eliminado = 0
     AND (@RubroId IS NULL OR @RubroId = P.RubroId)
     AND (@ProveedorId IS NULL OR @ProveedorId = PP.ProveedorId)
   )
   INSERT INTO @Productos 
   SELECT ROW_NUMBER () OVER (ORDER BY Descripcion ASC),
          NULL,
          ProductoId, 
          Descripcion
      FROM ProdCTE CTE
  END
 ELSE
  BEGIN
   DECLARE @ListadoMasVendidos TABLE
   (
    ProductoId int,
    Descripcion varchar(200),
    Cantidad decimal
   )

   INSERT INTO @ListadoMasVendidos
   SELECT DISTINCT P.ProductoId, P.Descripcion, SUM(VP.Cantidad)
   FROM VentaProducto VP
    INNER JOIN Producto P
     ON VP.ProductoId = P.ProductoId
    INNER JOIN Venta V
     ON VP.VentaId = V.VentaId
    INNER JOIN CierreCaja CC
     ON V.CierreCajaId = CC.CierreCajaId
    LEFT JOIN Rubro R 
     ON P.RubroId = R.RubroId
    LEFT JOIN ProveedorProducto PP 
     ON P.ProductoId = PP.ProductoId
   WHERE V.FechaVenta < GETDATE() 
    AND V.FechaVenta > DATEADD(MONTH, -2, GETDATE())
    AND CC.MaxiKioskoId = @MaxiKioscoId
    AND P.Eliminado = 0
    AND (@RubroId IS NULL OR @RubroId = P.RubroId)
    AND (@ProveedorId IS NULL OR @ProveedorId = PP.ProveedorId)
   GROUP BY P.ProductoId, P.Descripcion

   INSERT INTO @Productos 
   SELECT ROW_NUMBER () OVER (ORDER BY Cantidad DESC),
    Cantidad,
    ProductoId, 
    Descripcion
   FROM @ListadoMasVendidos
   ORDER BY Cantidad DESC

  END


 DECLARE @Intermedia TABLE
 (
  Fila int,
  ProductoId int,
  Codigo varchar(2000),
  Producto varchar(1000),
  Cantidad int,
  Motivo varchar(20),
  Diferencia int
 )

 INSERT INTO @Intermedia
 SELECT DISTINCT Fila = ROW_NUMBER () OVER (ORDER BY Fila ASC),
     P.ProductoId,
     Codigo = (SELECT SUBSTRING(
     (SELECT ',' + Codigo
      FROM CodigoProducto CP 
      WHERE CP.ProductoId = P.ProductoId
      FOR XML PATH('')),2,200000)),
        P.Descripcion Producto,
        ISNULL(S.StockActual, 0),
        NULL Motivo,
     NULL Diferencia
 FROM @Productos P
  LEFT JOIN Stock S
   ON S.ProductoId = P.ProductoId
    AND S.MaxiKioscoId = @MaxiKioscoId
 WHERE   (@MasVendidos = 0 OR (@MasVendidos = 1 AND Fila <= @CantidadFilas))
  AND (@ConStockCero IS NULL OR @ConStockCero = 0 OR (@ConStockCero = 1 AND ISNULL(S.StockActual, 0) != 0))

 -----------------------------------------------------------------------------------------------
 ----------------------------------------ARRANCA EL CREAR --------------------------------------
 -----------------------------------------------------------------------------------------------


 DECLARE @Temp Table
 (
  ProductoId int
 )
 INSERT INTO @Temp
 SELECT ProductoId
 FROM @Intermedia
 WHERE   Fila <= @LimiteSuperior
  AND Fila >= @LimiteInferior
 ORDER BY Fila
 

 --SELECT * FROM @Temp

 

 /*-----------------------------------------------------------------------------------
 ------- PRIMERO CREO TODOS LOS STOCK PARA ESE KIOSCO SI TODAVIA NO EXISTEN-----------
 -----------------------------------------------------------------------------------*/
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
 
 --[ControlStockId]
 --          ,[StockId]
 --          ,[Cantidad]
 --          ,[FechaUltimaModificacion]
 --          ,[Desincronizado]
 --          ,[Eliminado]
 --          ,[Identifier]
 --          ,[HabilitadoParaCorregir]
 
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
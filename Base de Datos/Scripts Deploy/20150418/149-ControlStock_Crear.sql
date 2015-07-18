/****** Object:  StoredProcedure [dbo].[ControlStock_Crear]    Script Date: 04/16/2015 16:23:10 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ControlStock_Crear]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[ControlStock_Crear]
GO

CREATE PROCEDURE [dbo].[ControlStock_Crear]
	@MaxiKioscoId int, 
	@ProveedorId int = NULL,
	@RubroId int = NULL,
	@UsuarioId int
AS
BEGIN
	DECLARE @Temp Table
	(
		ProductoId int
	)
	
	INSERT INTO @Temp
	SELECT DISTINCT P.ProductoId
	FROM Producto P
		LEFT JOIN Rubro R ON P.RubroId = R.RubroId
		LEFT JOIN ProveedorProducto PP ON P.ProductoId = PP.ProductoId
	WHERE (@RubroId IS NULL OR P.RubroId = @RubroId)
			AND (@ProveedorId IS NULL OR PP.ProveedorId = @ProveedorId)


	/*-----------------------------------------------------------------------------------
	------- PRIMERO CREO TODOS LOS STOCK PARA ESE KIOSCO SI TODAVIA NO EXISTEN-----------
	-----------------------------------------------------------------------------------*/
	INSERT INTO Stock (ProductoId,
						 MaxiKioscoId,
						 Identifier,
						 StockActual,
						 Desincronizado,
						 FechaUltimaModificacion,
						 Eliminado)
	SELECT P.ProductoId,
			@MaxiKioscoId,
			NEWID(),
			0,
			1,
			GETDATE(),
			0
	FROM @Temp P
		LEFT JOIN Stock S
			ON P.ProductoId = S.ProductoId
				AND @MaxiKioscoId = S.MaxiKioscoId
	WHERE S.StockId IS NULL
	
	
	/*-----------------------------------------------------------------------------------
	------------------- CREO EL CONTROL DE STOCK ----------------------------------------
	-----------------------------------------------------------------------------------*/
	INSERT INTO [ControlStock]
           ([FechaCreacion]
           ,[ProveedorId]
           ,[RubroId]
           ,[MaxiKioscoId]
           ,[UsuarioId]
           ,[NroControl]
           ,[FechaUltimaModificacion]
           ,[Desincronizado]
           ,[Eliminado]
           ,[Identifier]
           ,[Cerrado]
           ,[FechaCorreccion])
     VALUES
           (GETDATE()
           ,@ProveedorId
           ,@RubroId
           ,@MaxiKioscoId
           ,@UsuarioId
           ,NULL
           ,GETDATE()
           ,1
           ,0
           ,NEWID()
           ,0
           ,NULL)
           
    DECLARE @ControlStockId int
    SET @ControlStockId = (SELECT @@identity)
    
    
    /*-----------------------------------------------------------------------------------
	----------------------- REGISTRO LAS CANTIDADES EN STOCK ----------------------------
	-----------------------------------------------------------------------------------*/
	INSERT INTO [ControlStockDetalle]
           ([ControlStockId]
           ,[StockId]
           ,[Cantidad]
           ,[FechaUltimaModificacion]
           ,[Desincronizado]
           ,[Eliminado]
           ,[Identifier]
           ,[HabilitadoParaCorregir])
     SELECT @ControlStockId
           ,S.StockId
           ,S.StockActual
           ,GETDATE()
           ,1
           ,0
           ,NEWID()
           ,1
	FROM @Temp P
		INNER JOIN Stock S
			ON P.ProductoId = S.ProductoId
				AND S.MaxiKioscoId = @MaxiKioscoId
				
	SELECT @ControlStockId as ControlStockId
END


GO



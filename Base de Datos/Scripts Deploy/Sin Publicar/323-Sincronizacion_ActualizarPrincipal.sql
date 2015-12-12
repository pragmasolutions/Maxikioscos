/****** Object:  StoredProcedure [dbo].[Sincronizacion_ActualizarPrincipal]    Script Date: 02/11/2015 08:42:46 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Sincronizacion_ActualizarPrincipal]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Sincronizacion_ActualizarPrincipal]
GO


CREATE PROCEDURE [dbo].[Sincronizacion_ActualizarPrincipal]
	@XML XML,
	@MaxikioscoIdentifier uniqueidentifier,
	@Secuencia int,
	@NombreArchivo varchar(200) = NULL
AS
BEGIN
	DECLARE @Result bit
	SET @Result = 1
	BEGIN TRY
    BEGIN TRAN
		print('Sync_Productos')
		EXEC dbo.Sync_Productos @XML, 0
		print('Sync_ProveedorProductos')	
		EXEC dbo.Sync_ProveedorProductos @XML, 0
		print('Sync_Membership')	
		EXEC dbo.Sync_Membership @XML, 0
		print('Sync_MaxiKioscos')
		EXEC dbo.Sync_MaxiKioscos @XML, 0
		print('Sync_CodigosProducto')
		EXEC dbo.Sync_CodigosProducto @XML, 0
		print('Sync_Stock')
		EXEC dbo.Sync_Stock @XML, 0
		print('Sync_StockTransacciones')
		EXEC dbo.Sync_StockTransacciones @XML, 0
		print('Sync_CierresCaja')		
		EXEC dbo.Sync_CierresCaja @XML, 0
		print('Sync_Facturas')
		EXEC dbo.Sync_Facturas @XML, 0
		print('Sync_Compras')
		EXEC dbo.Sync_Compras @XML, 0
		print('Sync_ComprasProductos')
		EXEC dbo.Sync_ComprasProductos @XML, 0		
		print('Sync_ControlesStock')		
		EXEC dbo.Sync_ControlesStock @XML, 0		
		print('Sync_ControlesStockDetalle')		
		EXEC dbo.Sync_ControlesStockDetalle @XML, 0
		print('Sync_CorreccionesStock')		
		EXEC dbo.Sync_CorreccionesStock @XML, 0
		print('Sync_OperacionesCaja')		
		EXEC dbo.Sync_OperacionesCaja @XML, 0
		print('Sync_Ventas')		
		EXEC dbo.Sync_Ventas @XML, 0
		print('Sync_VentasProductos')		
		EXEC dbo.Sync_VentasProductos @XML, 0
		print('Sync_RecuentoBilletes')		
		EXEC dbo.Sync_RecuentoBilletes @XML, 0
		print('Sync_Costos')		
		EXEC dbo.Sync_Costos @XML, 0
		print('Sync_RetiroPersonal')		
		EXEC dbo.Sync_RetirosPersonales @XML, 0
		print('Sync_RetirosPersonalesProductos')		
		EXEC dbo.Sync_RetirosPersonalesProductos @XML, 0
		print('Sync_Transferencias')		
		EXEC dbo.Sync_Transferencias @XML, 0
		print('Sync_TransferenciasProductos')		
		EXEC dbo.Sync_TransferenciasProductos @XML, 0
		
		
		IF @NombreArchivo IS NOT NULL
		BEGIN
		
			print 'INSERT Importacion'
			INSERT INTO Importacion(Fecha, MaxiKioscoID, Nombre, Secuencia)
			VALUES(
				GETDATE(),
				(SELECT TOP 1 MaxiKioscoId FROM MaxiKiosco WHERE Identifier = @MaxikioscoIdentifier),
				@NombreArchivo,
				@Secuencia
			)
			
		END
			
		SET @Result = 1
		
    COMMIT TRAN
	END TRY
		
	BEGIN CATCH
	
		IF @@TRANCOUNT > 0 
			ROLLBACK
			SET @Result = 0
	   
		INSERT INTO ErrorSincronizacion	VALUES (ERROR_NUMBER(),ERROR_MESSAGE())
		
		
	END CATCH
IF @Result IS NULL
BEGIN
	SET @Result = 1
END
SELECT @Result as Result
END


GO



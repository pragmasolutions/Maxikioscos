

CREATE PROCEDURE [dbo].[Sincronizacion_ActualizarKiosco]
	@XML XML,
	@MaxikioscoIdentifier uniqueidentifier,
	@Secuencia int
AS
BEGIN
	DECLARE @Result bit
	SET @Result = 1
	BEGIN TRY
    BEGIN TRAN
		print('Sync_Cuentas')
		EXEC dbo.Sync_Cuentas @XML, 1	
		print('Sync_Marcas')
		EXEC dbo.Sync_Marcas @XML, 1	
		print('Sync_Rubros')
		EXEC dbo.Sync_Rubros @XML, 1	
		print('Sync_ExcepcionesRubros')
		EXEC dbo.Sync_ExcepcionesRubros @XML, 1
		print('Sync_Proveedores')
		EXEC dbo.Sync_Proveedores @XML, 1	
		print('Sync_Productos')
		EXEC dbo.Sync_Productos @XML, 1	
		print('Sync_ProveedorProductos')	
		EXEC dbo.Sync_ProveedorProductos @XML, 1
		print('Sync_Usuarios')	
		EXEC dbo.Sync_Usuarios @XML, 1
		print('Sync_Membership')	
		EXEC dbo.Sync_Membership @XML, 1
		print('Sync_UsuariosRoles')		
		EXEC dbo.Sync_UsuariosRoles @XML, 1	
		print('Sync_UsuarioProveedores')	
		EXEC dbo.Sync_UsuarioProveedores @XML, 1
		print('Sync_MaxiKioscos')
		EXEC dbo.Sync_MaxiKioscos @XML, 1	
		print('Sync_UsuarioMaxiKioscos')			
		EXEC dbo.Sync_UsuarioMaxiKioscos @XML, 1
		print('Sync_MaxiKioscosTurnos')
		EXEC dbo.Sync_MaxiKioscosTurnos @XML, 1	
		print('Sync_CodigosProducto')
		EXEC dbo.Sync_CodigosProducto @XML, 1	
		print('Sync_Stock')
		EXEC dbo.Sync_Stock @XML, 1
		print('Sync_StockTransacciones')
		EXEC dbo.Sync_StockTransacciones @XML, 1	
		print('Sync_Facturas')
		EXEC dbo.Sync_Facturas @XML, 1
		print('Sync_Compras')
		EXEC dbo.Sync_Compras @XML, 1
		print('Sync_Excepciones')		
		EXEC dbo.Sync_Excepciones @XML, 1
		print('Sync_ComprasProductos')
		EXEC dbo.Sync_ComprasProductos @XML, 1	
		print('Sync_CorreccionesStock')		
		EXEC dbo.Sync_CorreccionesStock @XML, 1	
		print('Sync_ControlesStock')		
		EXEC dbo.Sync_ControlesStock @XML, 1		
		print('Sync_ControlesStockDetalle')		
		EXEC dbo.Sync_ControlesStockDetalle @XML, 1
		
		UPDATE MaxiKiosco
		SET UltimaSecuenciaExportacion = @Secuencia
		WHERE Identifier = @MaxikioscoIdentifier
		SET @Result = 1
		
    COMMIT TRAN
	END TRY
		
	BEGIN CATCH
		INSERT INTO ErrorSincronizacion	VALUES (ERROR_NUMBER(),ERROR_MESSAGE())
	    
		IF @@TRANCOUNT > 0 
			ROLLBACK
			SET @Result = 0

	    

	END CATCH
IF @Result IS NULL
BEGIN
	SET @Result = 1
END
SELECT @Result as Result
END


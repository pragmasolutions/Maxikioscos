CREATE PROCEDURE [dbo].[Sync_RetirosPersonalesProductos] 
	@XML XML,
	@SobreescribirLocal bit
AS
BEGIN
	DECLARE @idoc int, @doc nvarchar(MAX);
	SET @doc = (SELECT CAST(@XML as nvarchar(max)));

	--Create an internal representation of the XML document.
	EXEC sp_xml_preparedocument @idoc OUTPUT, @doc;
	-- Execute a SELECT statement that uses the OPENXML rowset provider.
	
	
	Declare @Temp table
	(
	    RetiroPersonalProductoId int,
		Identifier uniqueidentifier,
		Costo money,
		Precio money,
		Cantidad decimal(18,2),
		FechaUltimaModificacion datetime2(7),
		Eliminado bit,
		Desincronizado bit,
		RetiroPersonalIdentifier uniqueidentifier,
		ProductoIdentifier uniqueidentifier,
		AdicionalPorExcepcion money
	);
	
	WITH RetiroPersonalProductoCTE (RetiroPersonalProductoId, Identifier, Costo, Precio, Cantidad, FechaUltimaModificacion,	
					Eliminado, Desincronizado, RetiroPersonalIdentifier, ProductoIdentifier, AdicionalPorExcepcion)
	AS (
		SELECT    *
		FROM     OPENXML (@idoc, '/Exportacion/RetirosPersonalesProductos/RPP/RP/P',3) 
				 WITH (RetiroPersonalProductoId int '../../RetiroPersonalProductoId',
						Identifier uniqueidentifier '../../Identifier',
						Costo money '../../Costo',
						Precio money '../../Precio',
						Cantidad decimal(18,2) '../../Cantidad',
						FechaUltimaModificacion datetime2(7) '../../FechaUltimaModificacion',
						Eliminado bit '../../Eliminado',
						Desincronizado bit '../../Desincronizado',
						RetiroPersonalIdentifier uniqueidentifier '../RetiroPersonalIdentifier',
						ProductoIdentifier uniqueidentifier 'ProductoIdentifier',
						AdicionalPorExcepcion money '../../AdicionalPorExcepcion')
	 )
	 
	 INSERT INTO @Temp
	 SELECT * FROM RetiroPersonalProductoCTE
	 
	 	 	
	 UPDATE RPP
	 SET RetiroPersonalId = (SELECT TOP 1 RetiroPersonalId FROM RetiroPersonal WHERE Identifier = CTE.RetiroPersonalIdentifier),  
		ProductoId = (SELECT TOP 1 ProductoId FROM Producto WHERE Identifier = CTE.ProductoIdentifier),  
	    Costo = CTE.Costo, 
	    Precio = CTE.Precio, 
	    Cantidad = CTE.Cantidad, 
	    FechaUltimaModificacion = CTE.FechaUltimaModificacion,	
		Eliminado = CTE.Eliminado, 
		Desincronizado = CTE.Desincronizado,
		AdicionalPorExcepcion = CTE.AdicionalPorExcepcion
	FROM @Temp CTE
		INNER JOIN RetiroPersonalProducto RPP
			ON CTE.Identifier = RPP.Identifier
	WHERE ((@SobreescribirLocal = 1 AND EXISTS (SELECT 1 FROM RetiroPersonal WHERE Identifier = CTE.RetiroPersonalIdentifier))
			OR (@SobreescribirLocal = 0 AND RPP.Desincronizado = 0))
	;
	 
	 INSERT INTO RetiroPersonalProducto (Identifier, 
								Costo, 
								Precio, 
								Cantidad, 
								FechaUltimaModificacion,	
								Eliminado, 
								Desincronizado, 
								RetiroPersonalId, 
								ProductoId,
								AdicionalPorExcepcion)
	 SELECT Identifier, 
			Costo, 
			Precio, 
			Cantidad, 
			FechaUltimaModificacion,	
			Eliminado, 
			Desincronizado,
			(SELECT TOP 1 RetiroPersonalId FROM RetiroPersonal WHERE Identifier = CTE.RetiroPersonalIdentifier),  
			(SELECT TOP 1 ProductoId FROM Producto WHERE Identifier = CTE.ProductoIdentifier),
			 AdicionalPorExcepcion
	 FROM @Temp CTE
	 WHERE CTE.Identifier NOT IN (SELECT Identifier FROM RetiroPersonalProducto)
		AND (@SobreescribirLocal = 0 OR (@SobreescribirLocal = 1 AND EXISTS (SELECT 1 FROM RetiroPersonal WHERE Identifier = CTE.RetiroPersonalIdentifier)))
	 
	
	IF @SobreescribirLocal = 1
	BEGIN
		UPDATE RPP
		SET Desincronizado = 0
		FROM RetiroPersonalProducto RPP
		WHERE RPP.Identifier IN (SELECT Identifier
								FROM @Temp)
		
	END
	ELSE
		UPDATE RPP
		SET Desincronizado = 1
		FROM RetiroPersonalProducto RPP
		WHERE RPP.Identifier IN (SELECT Identifier
								FROM @Temp)
		
END

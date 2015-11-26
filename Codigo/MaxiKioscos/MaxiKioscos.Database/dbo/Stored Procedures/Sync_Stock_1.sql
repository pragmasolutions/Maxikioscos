
CREATE PROCEDURE [dbo].[Sync_Stock] 
	@XML XML,
	@SobreescribirLocal bit
AS
BEGIN
	DECLARE @idoc int, @doc nvarchar(MAX);
	SET @doc = (SELECT CAST(@XML as nvarchar(max)));

	--Create an internal representation of the XML document.
	EXEC sp_xml_preparedocument @idoc OUTPUT, @doc;
	-- Execute a SELECT statement that uses the OPENXML rowset provider.
	
	
	DECLARE @OperacionCreacion varchar(200)
	SET @OperacionCreacion = (CASE @SobreescribirLocal
								WHEN 1 THEN 'Hacia kiosco.'
								ELSE 'Hacia Web'
							  END)
							  + 'Fecha Sync: ' + CAST(GETDATE() as varchar)
	
	Declare @Temp table
	(
	   StockId INT, 
	   Identifier UNIQUEIDENTIFIER,
	   StockActual decimal(18,2), 
	   OperacionCreacion varchar(1000),
	   FechaCreacion datetime,
	   Desincronizado bit,
	   FechaUltimaModificacion datetime2(7),
	   Eliminado bit,
	   ProductoIdentifier UNIQUEIDENTIFIER,
	   MaxiKioscoIdentifier UNIQUEIDENTIFIER
	);
	
	WITH StockCTE (StockId, Identifier, StockActual, OperacionCreacion, FechaCreacion, Desincronizado, 
		FechaUltimaModificacion, Eliminado, ProductoIdentifier,  MaxiKioscoIdentifier)
	AS (
		SELECT    *
		FROM       OPENXML (@idoc, '/Exportacion/Stock/S/M/P',4) 
				 WITH (StockId INT '../../StockId', 
					   Identifier UNIQUEIDENTIFIER '../../Identifier',
					   StockActual money '../../StockActual', 
					   OperacionCreacion varchar(1000) '../../OperacionCreacion',
					   FechaCreacion datetime '../../FechaCreacion',
					   Desincronizado bit '../../Desincronizado',
					   FechaUltimaModificacion datetime2(7) '../../FechaUltimaModificacion',
					   Eliminado bit '../../Eliminado',
					   ProductoIdentifier UNIQUEIDENTIFIER 'ProductoIdentifier',
					   MaxiKioscoIdentifier UNIQUEIDENTIFIER '../MaxiKioscoIdentifier')
	 )
	 
	 INSERT INTO @Temp
	 SELECT * FROM StockCTE
	 
	 	 
	 UPDATE S
	 SET MaxiKioscoId = (SELECT TOP 1 MaxiKioscoId FROM MaxiKiosco WHERE Identifier = CTE.MaxiKioscoIdentifier),  
	    ProductoId = (SELECT TOP 1 ProductoId FROM Producto WHERE Identifier = CTE.ProductoIdentifier), 
		StockActual = CTE.StockActual, 
		OperacionCreacion = CTE.OperacionCreacion,
	    FechaCreacion = CTE.FechaCreacion,
		Desincronizado = CTE.Desincronizado,
		FechaUltimaModificacion = CTE.FechaUltimaModificacion,
		Eliminado = CTE.Eliminado
	FROM @Temp CTE
		INNER JOIN Stock S
			ON CTE.Identifier = S.Identifier
	WHERE ((@SobreescribirLocal = 1  AND CTE.MaxiKioscoIdentifier IN (SELECT MaxikioscoIdentifier FROM ConfiguracionLocal))
			OR (@SobreescribirLocal = 0 AND S.Desincronizado = 0))
	;
	 
	 INSERT INTO Stock (Identifier, MaxiKioscoId, ProductoId, StockActual, OperacionCreacion,
					FechaCreacion, Desincronizado, FechaUltimaModificacion, Eliminado)
	 SELECT Identifier, 
			(SELECT TOP 1 MaxiKioscoId FROM MaxiKiosco WHERE Identifier = CTE.MaxiKioscoIdentifier), 
			(SELECT TOP 1 ProductoId FROM Producto WHERE Identifier = CTE.ProductoIdentifier), 
			StockActual,
			OperacionCreacion + '. ' + @OperacionCreacion,
			FechaCreacion,
			Desincronizado,
			FechaUltimaModificacion,
			Eliminado
	 FROM @Temp CTE
	 WHERE CTE.Identifier NOT IN (SELECT Identifier FROM Stock)
		AND (@SobreescribirLocal = 0 OR (@SobreescribirLocal = 1  AND CTE.MaxiKioscoIdentifier IN (SELECT MaxikioscoIdentifier FROM ConfiguracionLocal)))
	 
	 
    IF @SobreescribirLocal = 1
	BEGIN
		UPDATE S
		SET Desincronizado = 0
		FROM Stock S
		WHERE S.Identifier IN (SELECT Identifier
								FROM @Temp)
		
	END
	ELSE
		UPDATE S
		SET Desincronizado = 1
		FROM Stock S
		WHERE S.Identifier IN (SELECT Identifier
								FROM @Temp)
		
END



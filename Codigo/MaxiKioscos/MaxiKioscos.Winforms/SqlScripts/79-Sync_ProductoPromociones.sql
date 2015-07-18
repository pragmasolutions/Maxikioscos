
CREATE PROCEDURE [dbo].[Sync_ProductoPromociones] 
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
	   ProductoPromocionId INT, 
	   Identifier UNIQUEIDENTIFIER,
	   HijoId INT, 
	   PadreId INT, 
	   Unidades INT,
	   Desincronizado bit,
	   FechaUltimaModificacion datetime2(7),
	   Eliminado bit,
	   PadreIdentifier UNIQUEIDENTIFIER,
	   HijoIdentifier UNIQUEIDENTIFIER
	);
	
	WITH ProductoPromocionCTE (ProductoPromocionId, Identifier, HijoId, PadreId, Unidades,Desincronizado,
								FechaUltimaModificacion, Eliminado, PadreIdentifier, HijoIdentifier)
	AS (
		SELECT    *
		FROM       OPENXML (@idoc, '/Exportacion/ProductoPromociones/PP/PADRE/HIJO',4) 
				 WITH (ProductoPromocionId INT '../../ProveedorProductoId', 
					   Identifier UNIQUEIDENTIFIER '../../Identifier',
					   HijoId int '../../HijoId', 
					   PadreId int '../../PadreId', 
					   Unidades int '../../Unidades', 
					   Desincronizado bit '../../Desincronizado',
					   FechaUltimaModificacion datetime2(7) '../../FechaUltimaModificacion',
					   Eliminado bit '../../Eliminado',
					   PadreIdentifier UNIQUEIDENTIFIER '../PadreIdentifier',
					   HijoIdentifier UNIQUEIDENTIFIER 'HijoIdentifier')
	 )
	 
	 INSERT INTO @Temp
	 SELECT * FROM ProductoPromocionCTE
	 
	 
	 UPDATE PP
	 SET PadreId = (SELECT TOP 1 ProductoId FROM Producto WHERE Identifier = CTE.PadreIdentifier),  
	    HijoId = (SELECT TOP 1 ProductoId FROM Producto WHERE Identifier = CTE.HijoIdentifier), 
		Unidades = CTE.Unidades,
		Desincronizado = CTE.Desincronizado,
		FechaUltimaModificacion = CTE.FechaUltimaModificacion,
		Eliminado = CTE.Eliminado
	FROM @Temp CTE
		INNER JOIN ProductoPromocion PP
			ON CTE.Identifier = PP.Identifier
	WHERE (@SobreescribirLocal = 1 OR
			(@SobreescribirLocal = 0 AND PP.Desincronizado = 0))
	;
	 
	 INSERT INTO ProductoPromocion (Identifier, PadreId, HijoId, Unidades, Desincronizado,	
								   FechaUltimaModificacion, Eliminado)
	 SELECT Identifier, 
			(SELECT TOP 1 ProductoId FROM Producto WHERE Identifier = CTE.PadreIdentifier), 
			(SELECT TOP 1 ProductoId FROM Producto WHERE Identifier = CTE.HijoIdentifier), 
			Unidades,
			Desincronizado,
			FechaUltimaModificacion,
			Eliminado
	 FROM @Temp CTE
	 WHERE CTE.Identifier NOT IN (SELECT Identifier FROM ProductoPromocion)
	 
	 
    IF @SobreescribirLocal = 1
	BEGIN
		UPDATE PP
		SET Desincronizado = 0
		FROM ProductoPromocion PP
		WHERE PP.Identifier IN (SELECT Identifier
								FROM @Temp)
		
	END
	ELSE
		UPDATE PP
		SET Desincronizado = 1
		FROM ProductoPromocion PP
		WHERE PP.Identifier IN (SELECT Identifier
								FROM @Temp)
		
END


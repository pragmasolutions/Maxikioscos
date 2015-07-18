ALTER PROCEDURE [dbo].[Sync_RecuentoBilletes] 
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
	   RecuentoBilleteId int, 
	   Cantidad int,
	   BilleteId int,
	   Identifier uniqueidentifier,  
	   Desincronizado bit,
	   FechaUltimaModificacion datetime2(7), 
	   Eliminado bit, 
	   CierreCajaIdentifier uniqueidentifier
	);
	
	WITH RecuentoBilleteCTE (RecuentoBilleteId, Cantidad, BilleteId, Identifier, Desincronizado, 
							FechaUltimaModificacion, Eliminado, CierreCajaIdentifier)
	AS (
		SELECT    *
		FROM       OPENXML (@idoc, '/Exportacion/RecuentoBilletes/RB/CC',2) 
				 WITH (RecuentoBilleteId int '../FacturaId',
						Cantidad int '../Cantidad',
						BilleteId int '../BilleteId',
						Identifier uniqueidentifier '../Identifier',
						Desincronizado bit '../Desincronizado',
						FechaUltimaModificacion datetime2(7) '../FechaUltimaModificacion',
						Eliminado bit '../Eliminado',
						CierreCajaIdentifier uniqueidentifier 'CierreCajaIdentifier')
	 )
	 
	 INSERT INTO @Temp
	 SELECT * 
	 FROM RecuentoBilleteCTE
	 
				 
	 UPDATE RB
	 SET CierreCajaId = (SELECT TOP 1 CierreCajaId FROM CierreCaja WHERE Identifier = CTE.CierreCajaIdentifier), 
		Cantidad = CTE.Cantidad, 
		BilleteId = CTE.BilleteId, 
		Identifier = CTE.Identifier, 
		Desincronizado = CTE.Desincronizado, 
		FechaUltimaModificacion = CTE.FechaUltimaModificacion, 
		Eliminado = CTE.Eliminado
	FROM @Temp CTE
		INNER JOIN RecuentoBillete RB
			ON CTE.Identifier = RB.Identifier
	WHERE ((@SobreescribirLocal = 1 AND (SELECT CierreCajaId FROM CierreCaja WHERE Identifier = CTE.CierreCajaIdentifier) IS NOT NULL) OR
			(@SobreescribirLocal = 0 AND RB.Desincronizado = 0))
	 
	 
	 INSERT INTO RecuentoBillete (Identifier, CierreCajaId, Cantidad, BilleteId, 
							Desincronizado,	FechaUltimaModificacion, Eliminado)
							
	 SELECT Identifier, 
			(SELECT TOP 1 CierreCajaId FROM CierreCaja WHERE Identifier = CTE.CierreCajaIdentifier),
			Cantidad, 
			BilleteId, 
			Desincronizado,
			FechaUltimaModificacion,
			Eliminado
	 FROM @Temp CTE
	 WHERE CTE.Identifier NOT IN (SELECT Identifier FROM RecuentoBillete)
		AND (SELECT CierreCajaId FROM CierreCaja WHERE Identifier = CTE.CierreCajaIdentifier) IS NOT NULL
	
	 
	IF @SobreescribirLocal = 1
	BEGIN
		UPDATE RB
		SET Desincronizado = 0
		FROM RecuentoBillete RB
		WHERE RB.Identifier IN (SELECT Identifier
								FROM @Temp)
		
	END
	ELSE
		UPDATE RB
		SET Desincronizado = 1
		FROM RecuentoBillete RB
		WHERE RB.Identifier IN (SELECT Identifier
								FROM @Temp)
		
    
END

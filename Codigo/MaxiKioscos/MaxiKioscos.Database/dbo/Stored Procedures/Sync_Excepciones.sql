
CREATE PROCEDURE [dbo].[Sync_Excepciones] 
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
	    ExcepcionId int,
		Identifier uniqueidentifier,
		Importe money,
		Descripcion varchar(2000),
		FechaCarga datetime2(7),
		Desincronizado bit,
		FechaUltimaModificacion datetime2(7),
		Eliminado bit,
		CierreCajaIdentifier uniqueidentifier
	);
	
	WITH ExcepcionCTE (ExcepcionId, Identifier, Importe, Descripcion, FechaCarga, Desincronizado,
					   FechaUltimaModificacion, Eliminado, CierreCajaIdentifier)
	AS (
		SELECT    *
		FROM       OPENXML (@idoc, '/Exportacion/Excepciones/E/CC',2) 
				 WITH (ExcepcionId int '../ExcepcionId',
						Identifier uniqueidentifier '../Identifier',
						Importe money '../Importe',
						Descripcion varchar(2000) '../Descripcion',
						FechaCarga datetime2(7) '../FechaCarga',
						Desincronizado bit '../Desincronizado',
						FechaUltimaModificacion datetime2(7) '../FechaUltimaModificacion',
						Eliminado bit '../Eliminado',
						CierreCajaIdentifier uniqueidentifier 'CierreCajaIdentifier')
	 )
	 
	 INSERT INTO @Temp
	 SELECT * FROM ExcepcionCTE
	 	 
	 UPDATE E
	 SET CierreCajaId = (SELECT CierreCajaId FROM CierreCaja WHERE Identifier = CTE.CierreCajaIdentifier), 
		Importe = CTE.Importe, 
		Descripcion = CTE.Descripcion, 
		FechaCarga = CTE.FechaCarga, 
		Desincronizado = CTE.Desincronizado,
		FechaUltimaModificacion = CTE.FechaUltimaModificacion, 
		Eliminado = CTE.Eliminado
	FROM @Temp CTE
		INNER JOIN Excepcion E
			ON CTE.Identifier = E.Identifier
	WHERE ((@SobreescribirLocal = 1 AND (SELECT CierreCajaId FROM CierreCaja WHERE Identifier = CTE.CierreCajaIdentifier) IS NOT NULL) OR
			(@SobreescribirLocal = 0 AND CTE.Desincronizado = 0));
	 
	 INSERT INTO Excepcion (Identifier, 
							Importe, 
							Descripcion, 
							FechaCarga, 
							Desincronizado,
							FechaUltimaModificacion, 
							Eliminado, 
							CierreCajaId)
	 SELECT Identifier, 
			Importe, 
			Descripcion, 
			FechaCarga, 
			Desincronizado,
			FechaUltimaModificacion, 
			Eliminado, 
			(SELECT CierreCajaId FROM CierreCaja WHERE Identifier = CTE.CierreCajaIdentifier)
	 FROM @Temp CTE
	 WHERE CTE.Identifier NOT IN (SELECT Identifier FROM Excepcion)
		AND (SELECT CierreCajaId FROM CierreCaja WHERE Identifier = CTE.CierreCajaIdentifier) IS NOT NULL
	 
	 
    IF @SobreescribirLocal = 1
	BEGIN
		UPDATE E
		SET Desincronizado = 0
		FROM Excepcion E
		WHERE E.Identifier IN (SELECT Identifier
								FROM @Temp)
	END
	ELSE
		UPDATE E
		SET Desincronizado = 1
		FROM Excepcion E
		WHERE E.Identifier IN (SELECT Identifier
								FROM @Temp)
	
END




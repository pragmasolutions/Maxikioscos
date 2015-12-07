
CREATE PROCEDURE [dbo].[Sync_MaxiKioscos] 
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
	    MaxiKioscoId int,
		Identifier uniqueidentifier,
		Nombre varchar(100),
		Direccion varchar(200),
		Telefono varchar(20),
		Asignado bit,
		Abreviacion varchar(4),
		Desincronizado bit,
		FechaUltimaModificacion datetime2(7),
		Eliminado bit,
		EstaOnLine bit,
		CuentaIdentifier uniqueidentifier
	);
	
	WITH MaxiKioscoCTE (MaxiKioscoId, Identifier, Nombre, Direccion, Telefono, Asignado, Abreviacion,
		Desincronizado, FechaUltimaModificacion, Eliminado, EstaOnLine, CuentaIdentifier)
	AS (
		SELECT    *
		FROM       OPENXML (@idoc, '/Exportacion/MaxiKioscos/M/C',3) 
				 WITH (MaxiKioscoId int '../MaxiKioscoId',
						Identifier uniqueidentifier '../Identifier',
						Nombre varchar(100) '../Nombre',
						Direccion varchar(200) '../Direccion',
						Telefono varchar(20) '../Telefono',
						Asignado bit '../Asignado',
						Abreviacion varchar(4) '../Abreviacion',
						Desincronizado bit '../Desincronizado',
						FechaUltimaModificacion datetime2(7) '../FechaUltimaModificacion',
						Eliminado bit '../Eliminado',
						EstaOnLine bit '../EstaOnLine',
						CuentaIdentifier uniqueidentifier 'CuentaIdentifier')
	 )
	 
	 INSERT INTO @Temp
	 SELECT * FROM MaxiKioscoCTE
	 
	 	 
	 UPDATE M
	 SET Nombre = CTE.Nombre, 
		Direccion = CTE.Desincronizado,
		Telefono = CTE.Telefono,
		Asignado = CTE.Asignado,
		Abreviacion = CTE.Abreviacion,
		Desincronizado = CTE.Desincronizado,
		FechaUltimaModificacion = CTE.FechaUltimaModificacion, 
		Eliminado = CTE.Eliminado, 
		EstaOnLine = CTE.EstaOnLine,
		CuentaId = (SELECT TOP 1 CuentaId FROM Cuenta WHERE Identifier = CTE.CuentaIdentifier)
	FROM @Temp CTE
		INNER JOIN MaxiKiosco M
			ON CTE.Identifier = M.Identifier
	WHERE (@SobreescribirLocal = 1 OR
			(@SobreescribirLocal = 0 AND M.Desincronizado = 0))
	;
	 
	 INSERT INTO MaxiKiosco (Identifier, Nombre, Direccion, Telefono, Asignado, Abreviacion,
		Desincronizado, FechaUltimaModificacion, Eliminado, EstaOnLine, CuentaId)
	 SELECT Identifier, 
			Nombre, 
			Direccion, 
			Telefono, 
			Asignado,
			Abreviacion,
			Desincronizado, 
			FechaUltimaModificacion,
	 		Eliminado, 
	 		EstaOnLine,
	 		(SELECT TOP 1 CuentaId FROM Cuenta WHERE Identifier = CTE.CuentaIdentifier)
	 FROM @Temp CTE
	 WHERE CTE.Identifier NOT IN (SELECT Identifier FROM MaxiKiosco)
	 
	 
	 
	IF @SobreescribirLocal = 1
	BEGIN
		UPDATE M
		SET Desincronizado = 0
		FROM MaxiKiosco M
		WHERE M.Identifier IN (SELECT Identifier
								FROM @Temp)
		
	END
	ELSE
		UPDATE M
		SET Desincronizado = 1
		FROM MaxiKiosco M
		WHERE M.Identifier IN (SELECT Identifier
								FROM @Temp)
		
END







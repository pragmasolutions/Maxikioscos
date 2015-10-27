
/****** Object:  StoredProcedure [dbo].[Sync_ReporteRoles]    Script Date: 08/09/2014 15:51:31 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Sync_ReporteRoles]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Sync_ReporteRoles]
GO


CREATE PROCEDURE [dbo].[Sync_ReporteRoles] 
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
	   ReporteRolId INT,
	   Identifier UNIQUEIDENTIFIER,
	   FechaUltimaModificacion datetime2(7),
	   Eliminado bit,
	   Desincronizado bit,
	   ReporteId int,
	   RoleId int
	);
	
	WITH ReporteRolCTE (ReporteRolId, Identifier, FechaUltimaModificacion, Eliminado, Desincronizado, 
					ReporteId, RoleId)
	AS (
		SELECT    *
		FROM       OPENXML (@idoc, '/Exportacion/ReporteRoles/RR',1) 
				 WITH (ReporteRolId INT 'ReporteRolId',
					   Identifier UNIQUEIDENTIFIER 'Identifier',
					   FechaUltimaModificacion datetime2(7) 'FechaUltimaModificacion',
					   Eliminado bit 'Eliminado',
					   Desincronizado bit 'Desincronizado',
					   ReporteId INT 'ReporteId',
					   RoleId int 'RoleId')
	 )
	 
	 INSERT INTO @Temp
	 SELECT * FROM ReporteRolCTE
	 
	 	 
	 UPDATE UP
	 SET ReporteId = CTE.ReporteId,
	    RoleId = CTE.RoleId,
		FechaUltimaModificacion = CTE.FechaUltimaModificacion,
		Eliminado = CTE.Eliminado,
		Desincronizado = CTE.Desincronizado
	FROM @Temp CTE
		INNER JOIN ReporteRol RR
			ON CTE.Identifier = RR.Identifier
	WHERE (@SobreescribirLocal = 1 OR
			(@SobreescribirLocal = 0 AND RR.Desincronizado = 0))
	;
	 
	INSERT INTO ReporteRol (ReporteId, RoleId, Identifier,
					FechaUltimaModificacion, Eliminado, Desincronizado)
	SELECT ReporteId,
	        RoleId, 
	        Identifier, 
			FechaUltimaModificacion,
			Eliminado,
			Desincronizado
	FROM @Temp CTE
	WHERE CTE.Identifier NOT IN (SELECT Identifier FROM ReporteRol)
	
	 
    IF @SobreescribirLocal = 1
	BEGIN
		UPDATE RR
		SET Desincronizado = 0
		FROM ReporteRol RR
		WHERE RR.Identifier IN (SELECT Identifier
								FROM @Temp)
		
	END
	ELSE
		UPDATE RR
		SET Desincronizado = 1
		FROM ReporteRol RR
		WHERE RR.Identifier IN (SELECT Identifier
								FROM @Temp)
		
	
END


GO



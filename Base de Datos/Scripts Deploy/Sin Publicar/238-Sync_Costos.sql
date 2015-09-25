/****** Object:  StoredProcedure [dbo].[Costos]    Script Date: 01/19/2015 17:49:51 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Sync_Costos]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Sync_Costos]
GO


CREATE PROCEDURE [dbo].[Sync_Costos] 
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
	    CostoId int, 
	    CierreCajaIdentifier uniqueidentifier, 
	    CategoriaCostoIdentifier uniqueidentifier, 
	    Observaciones varchar(5000), 
	    NroComprobante varchar(50), 
	    Monto money, 
		Fecha datetime, 
		Aprobado bit, 
		Identifier uniqueidentifier, 
		Desincronizado bit, 
		Eliminado bit, 
		FechaUltimaModificacion datetime2(7)
	);
	
	WITH CostoCTE (CostoId, CierreCajaIdentifier, CategoriaCostoIdentifier, Observaciones, NroComprobante, Monto, 
						Fecha, Aprobado, Identifier, Desincronizado, Eliminado, FechaUltimaModificacion)
	AS (
		SELECT    *
		FROM       OPENXML (@idoc, '/Exportacion/Costos/C/CC/CC',3) 
				 WITH (CostoId int '../../CostoId',
						CierreCajaIdentifier uniqueidentifier '../CierreCajaIdentifier', 
						CategoriaCostoIdentifier uniqueidentifier 'CategoriaCostoIdentifier', 
						Observaciones varchar(5000) '../../Observaciones', 
						NroComprobante varchar(50) '../../NroComprobante', 
						Monto money '../../Monto', 
						Fecha datetime '../../Fecha', 
						Aprobado bit '../../Aprobado', 
						Identifier uniqueidentifier '../../Identifier', 
						Desincronizado bit '../../Desincronizado', 
						Eliminado bit '../../Eliminado', 
						FechaUltimaModificacion datetime2(7) '../../FechaUltimaModificacion')
	 )
	 
	 INSERT INTO @Temp
	 SELECT * FROM CostoCTE
	 
	 	 
	 UPDATE C
	 SET CierreCajaId = (SELECT TOP 1 CierreCajaId FROM CierreCaja WHERE Identifier = CTE.CierreCajaIdentifier), 
	    CategoriaCostoId = (SELECT TOP 1 CategoriaCostoId FROM CategoriaCosto WHERE Identifier = CTE.CategoriaCostoIdentifier), 
	    Observaciones = CTE.Observaciones, 
	    NroComprobante = CTE.NroComprobante, 
	    Monto = CTE.Monto, 
		Fecha = CTE.Fecha, 
		Aprobado = CTE.Aprobado, 
		Desincronizado = CTE.Desincronizado, 
		Eliminado = CTE.Eliminado, 
		FechaUltimaModificacion = CTE.FechaUltimaModificacion
	FROM @Temp CTE
		INNER JOIN Costo C
			ON CTE.Identifier = C.Identifier
	WHERE ((@SobreescribirLocal = 1 AND (SELECT CierreCajaId FROM CierreCaja WHERE Identifier = CTE.CierreCajaIdentifier) IS NOT NULL)
			OR (@SobreescribirLocal = 0 AND CTE.Desincronizado = 0))
	;
	 
	 INSERT INTO Costo (CierreCajaId, 
						CategoriaCostoId, 
						Observaciones, 
						NroComprobante, 
						Monto, 
						Fecha, 
						Aprobado, 
						Identifier, 
						Desincronizado, 
						Eliminado, 
						FechaUltimaModificacion)
	 SELECT (SELECT TOP 1 CierreCajaId FROM CierreCaja WHERE Identifier = CTE.CierreCajaIdentifier), 
			(SELECT TOP 1 CategoriaCostoId FROM CategoriaCosto WHERE Identifier = CTE.CategoriaCostoIdentifier), 
			Observaciones, 
			NroComprobante, 
			Monto, 
			Fecha, 
			Aprobado, 
			Identifier, 
			Desincronizado, 
			Eliminado, 
			FechaUltimaModificacion
			
	 FROM @Temp CTE
	 WHERE CTE.Identifier NOT IN (SELECT Identifier FROM Costo)
		AND (SELECT CierreCajaId FROM CierreCaja WHERE Identifier = CTE.CierreCajaIdentifier) IS NOT NULL
	
	 
	IF @SobreescribirLocal = 1
	BEGIN
		UPDATE C
		SET Desincronizado = 0
		FROM Costo C
		WHERE C.Identifier IN (SELECT Identifier
								FROM @Temp)
		
	END
	ELSE
		UPDATE C
		SET Desincronizado = 1
		FROM Costo C
		WHERE C.Identifier IN (SELECT Identifier
								FROM @Temp)
		
    
	
END




GO



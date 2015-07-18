
/****** Object:  StoredProcedure [dbo].[Sync_Productos]    Script Date: 08/09/2014 15:50:12 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Sync_Productos]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Sync_Productos]
GO

CREATE PROCEDURE [dbo].[Sync_Productos] 
	@XML XML,
	@SobreescribirLocal bit
AS
BEGIN
	BEGIN TRY
    BEGIN TRAN

	DECLARE @idoc int, @doc nvarchar(MAX);
	SET @doc = (SELECT CAST(@XML as nvarchar(max)));

	--Create an internal representation of the XML document.
	EXEC sp_xml_preparedocument @idoc OUTPUT, @doc;
	-- Execute a SELECT statement that uses the OPENXML rowset provider.
	
	Declare @Temp table
	(
	    ProductoId int, 
	    Identifier uniqueidentifier,  
	    Descripcion varchar(300), 
	    PrecioSinIVA money, 
	    PrecioConIVA money, 
	    StockReposicion int, 
	    Desincronizado bit,
		FechaUltimaModificacion datetime2(7), 
		Eliminado bit, 
		AceptaCantidadesDecimales bit,
		RubroIdentifier uniqueidentifier, 
		MarcaIdentifier uniqueidentifier,
		CuentaIdentifier uniqueidentifier
	);
	
	WITH ProductoCTE (ProductoId, Identifier, Descripcion, PrecioSinIVA, PrecioConIVA,
			StockReposicion, Desincronizado,FechaUltimaModificacion, Eliminado, 
			AceptaCantidadesDecimales, RubroIdentifier, MarcaIdentifier, CuentaIdentifier)
	AS (
		SELECT    *
		FROM       OPENXML (@idoc, '/Exportacion/Productos/Producto',1) 
				 WITH (ProductoId INT	'ProductoId', 
					   Identifier UNIQUEIDENTIFIER   'Identifier',
					   Descripcion varchar(300) 'Descripcion', 
					   PrecioSinIVA money	 'PrecioSinIVA', 
					   PrecioConIVA money	 'PrecioConIVA', 
					   StockReposicion decimal 'StockReposicion', 
					   Desincronizado bit 'Desincronizado', 
					   FechaUltimaModificacion datetime2(7)  'FechaUltimaModificacion', 
					   Eliminado bit 'Eliminado', 
					   AceptaCantidadesDecimales bit 'AceptaCantidadesDecimales',
					   RubroIdentifier UNIQUEIDENTIFIER 'RubroIdentifier',
					   MarcaIdentifier UNIQUEIDENTIFIER 'MarcaIdentifier',
					   CuentaIdentifier UNIQUEIDENTIFIER 'CuentaIdentifier')
	 )
	 
	 INSERT INTO @Temp
	 SELECT * FROM ProductoCTE
	 
	 UPDATE P
	 SET RubroId = (SELECT RubroId FROM Rubro WHERE Identifier = CTE.RubroIdentifier), 
		MarcaId = (SELECT MarcaId FROM Marca WHERE Identifier = CTE.MarcaIdentifier), 
		CuentaId = (SELECT CuentaId FROM Cuenta WHERE Identifier = CTE.CuentaIdentifier), 
		Descripcion = CTE.Descripcion, 
		PrecioSinIVA = CTE.PrecioSinIVA, 
		PrecioConIVA = CTE.PrecioConIVA, 
		StockReposicion = CTE.StockReposicion, 
		Desincronizado = CTE.Desincronizado,
		FechaUltimaModificacion = CTE.FechaUltimaModificacion, 
		Eliminado = CTE.Eliminado, 
		AceptaCantidadesDecimales = CTE.AceptaCantidadesDecimales
	FROM @Temp CTE
		INNER JOIN Producto P
			ON CTE.Identifier = P.Identifier
	WHERE (@SobreescribirLocal = 1 OR
			(@SobreescribirLocal = 0 AND P.Desincronizado = 0))
			
			
	INSERT INTO Producto (Identifier, RubroId, MarcaId, CuentaId, Descripcion, 
			PrecioSinIVA, PrecioConIVA, StockReposicion, Desincronizado,FechaUltimaModificacion, Eliminado, 
			AceptaCantidadesDecimales)
	SELECT Identifier, 
			(SELECT RubroId FROM Rubro WHERE Identifier = CTE.RubroIdentifier), 
			(SELECT MarcaId FROM Marca WHERE Identifier = CTE.MarcaIdentifier),
			(SELECT CuentaId FROM Cuenta WHERE Identifier = CTE.CuentaIdentifier),
			Descripcion, 
			PrecioSinIVA,
			PrecioConIVA, 
			StockReposicion, 
			Desincronizado,
			FechaUltimaModificacion, 
			Eliminado, 
			AceptaCantidadesDecimales
	FROM @Temp CTE
	WHERE CTE.Identifier NOT IN (SELECT Identifier FROM Producto)
	
	IF @SobreescribirLocal = 1
	BEGIN
		UPDATE P
		SET Desincronizado = 0
		FROM Producto P
		WHERE P.Identifier IN (SELECT Identifier
								FROM @Temp)
	END
	ELSE
		UPDATE P
		SET Desincronizado = 1
		FROM Producto P
		WHERE P.Identifier IN (SELECT Identifier
								FROM @Temp)
	COMMIT TRAN
	END TRY
		
	BEGIN CATCH
   
    IF @@TRANCOUNT > 0 
		declare @error int, @message varchar(4000), @xstate int;
        select @error = ERROR_NUMBER(), @message = ERROR_MESSAGE(), @xstate = XACT_STATE();
		print @message
	END CATCH
END


GO



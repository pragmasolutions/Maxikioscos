
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Sync_ControlesStock]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Sync_ControlesStock]
GO

CREATE PROCEDURE [dbo].[Sync_ControlesStock] 
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
	   ControlStockId INT, 
	   FechaCreacion datetime,
	   NroControl int,
	   Cerrado bit,
	   FechaCorreccion datetime,
	   ConStockCero bit,
	   MasVendidos bit,
	   CantidadFilas int,
	   LimiteInferior int,
	   LimiteSuperior int,
	   FechaUltimaModificacion datetime2(7),
	   Eliminado bit,
	   Desincronizado bit,
	   Identifier UNIQUEIDENTIFIER,
	   ProveedorIdentifier UNIQUEIDENTIFIER,
	   RubroIdentifier UNIQUEIDENTIFIER,
	   MaxiKioscoIdentifier UNIQUEIDENTIFIER,
	   UsuarioIdentifier UNIQUEIDENTIFIER
	);
		
	WITH ControlStockCTE (ControlStockId, FechaCreacion, NroControl, Cerrado,
		FechaCorreccion, ConStockCero, MasVendidos, CantidadFilas, LimiteInferior, LimiteSuperior,
		FechaUltimaModificacion, Eliminado, Desincronizado, Identifier, 
		ProveedorIdentifier, RubroIdentifier, MaxiKioscoIdentifier, 
		UsuarioIdentifier)
	AS (
		SELECT    *
		FROM     OPENXML (@idoc, '/Exportacion/ControlesStock/CS/P/R/M/U',5) 
				 WITH (ControlStockId INT '../../../../ControlStockId', 
					   FechaCreacion datetime '../../../../FechaCreacion',
					   NroControl int '../../../../NroControl',
					   Cerrado bit '../../../../Cerrado',
					   FechaCorreccion datetime '../../../../FechaCorreccion',
					   ConStockCero bit '../../../../ConStockCero',
					   MasVendidos bit '../../../../MasVendidos',
					   CantidadFilas int '../../../../CantidadFilas',
					   LimiteInferior int '../../../../LimiteInferior',
					   LimiteSuperior int '../../../../LimiteSuperior',
					   FechaUltimaModificacion datetime2(7) '../../../../FechaUltimaModificacion',
					   Eliminado bit '../../../../Eliminado',
					   Desincronizado bit '../../../../Desincronizado',
					   Identifier UNIQUEIDENTIFIER '../../../../Identifier',
					   ProveedorIdentifier UNIQUEIDENTIFIER '../../../ProveedorIdentifier',
					   RubroIdentifier UNIQUEIDENTIFIER '../../RubroIdentifier',
					   MaxiKioscoIdentifier UNIQUEIDENTIFIER '../MaxiKioscoIdentifier',
					   UsuarioIdentifier UNIQUEIDENTIFIER 'UsuarioIdentifier')
	 )
	 
	 INSERT INTO @Temp
	 SELECT * FROM ControlStockCTE
	 
	
	 --SELECT * FROM @Temp
		 
	 UPDATE CS
	 SET ProveedorId = (SELECT TOP 1 ProveedorId FROM Proveedor WHERE Identifier = CTE.ProveedorIdentifier), 
		RubroId = (SELECT TOP 1 RubroId FROM Rubro WHERE Identifier = CTE.RubroIdentifier), 
		MaxiKioscoId = (SELECT TOP 1 MaxiKioscoId FROM MaxiKiosco WHERE Identifier = CTE.MaxiKioscoIdentifier), 
		UsuarioId = (SELECT TOP 1 UsuarioId FROM Usuario WHERE Identifier = CTE.UsuarioIdentifier), 
		FechaCreacion = CTE.FechaCreacion, 
		NroControl = CTE.NroControl, 
		Cerrado = CTE.Cerrado,
		FechaCorreccion = CTE.FechaCorreccion,
		ConStockCero = ISNULL(CTE.ConStockCero, 0), 
		MasVendidos = ISNULL(CTE.MasVendidos, 0), 
		CantidadFilas = ISNULL(CTE.CantidadFilas, 1000),
		LimiteInferior = ISNULL(CTE.LimiteInferior, 1),
		LimiteSuperior = ISNULL(CTE.LimiteSuperior, 1000),
		FechaUltimaModificacion = CTE.FechaUltimaModificacion, 
		Eliminado = CTE.Eliminado, 
		Desincronizado = CTE.Desincronizado
	FROM @Temp CTE
		INNER JOIN ControlStock CS
			ON CTE.Identifier = CS.Identifier
	WHERE ((@SobreescribirLocal = 1  AND CTE.MaxiKioscoIdentifier IN (SELECT MaxikioscoIdentifier FROM ConfiguracionLocal))
			OR (@SobreescribirLocal = 0 AND CS.Desincronizado = 0))
	;
	 
	 
	 INSERT INTO ControlStock (FechaCreacion, NroControl, Cerrado, FechaCorreccion,ConStockCero,
		MasVendidos, CantidadFilas, LimiteInferior, LimiteSuperior,
		FechaUltimaModificacion, Eliminado, Desincronizado, Identifier, 
		ProveedorId, RubroId, MaxiKioscoId, UsuarioId)
	 SELECT FechaCreacion, 
			NroControl,
			Cerrado,
			FechaCorreccion,
			ISNULL(CTE.ConStockCero, 0),
			MasVendidos, 
			CantidadFilas, 
			LimiteInferior, 
			LimiteSuperior,
			FechaUltimaModificacion, 
			Eliminado, 
			Desincronizado,
			Identifier,
			(SELECT TOP 1 ProveedorId FROM Proveedor WHERE Identifier = CTE.ProveedorIdentifier), 
			(SELECT TOP 1 RubroId FROM Rubro WHERE Identifier = CTE.RubroIdentifier), 
			(SELECT TOP 1 MaxiKioscoId FROM MaxiKiosco WHERE Identifier = CTE.MaxiKioscoIdentifier), 
			(SELECT TOP 1 UsuarioId FROM Usuario WHERE Identifier = CTE.UsuarioIdentifier)
	 FROM @Temp CTE
	 WHERE CTE.Identifier NOT IN (SELECT Identifier FROM ControlStock)
		AND (@SobreescribirLocal = 0 OR (@SobreescribirLocal = 1  AND CTE.MaxiKioscoIdentifier IN (SELECT MaxikioscoIdentifier FROM ConfiguracionLocal)))
	 
	 
    IF @SobreescribirLocal = 1
	BEGIN
		UPDATE CS
		SET Desincronizado = 0
		FROM ControlStock CS
		WHERE CS.Identifier IN (SELECT Identifier
								FROM @Temp)
		
	END
	ELSE
		UPDATE CS
		SET Desincronizado = 1
		FROM ControlStock CS
		WHERE CS.Identifier IN (SELECT Identifier
								FROM @Temp)
		
    
END
GO



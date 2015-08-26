ALTER PROCEDURE [dbo].[Sync_Proveedores] 
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
	   ProveedorId INT, 
	   Identifier UNIQUEIDENTIFIER,
	   Nombre varchar(100),
	   Contacto varchar(100),
	   Direccion varchar(200),
	   LocalidadId int,
	   Telefono varchar(16),
	   Celular varchar(18),
	   TipoCuitId int,
	   CuitNro varchar(14),
	   Email varchar(200),
	   PaginaWeb varchar(200),
	   Observaciones varchar(max),
	   PercepcionDGR DECIMAL(5,2) NULL,
	   AplicaPercepcionIVA BIT NULL,
	   NoReflejarFacturaEnCaja BIT,
	   TipoComprobante varchar(3) NULL,
	   Desincronizado bit,
	   FechaUltimaModificacion datetime2(7),
	   Eliminado bit,
	   CuentaIdentifier UNIQUEIDENTIFIER
	);
	
	
	WITH ProveedorCTE (ProveedorId, Identifier, Nombre, Contacto, Direccion, LocalidadId,
	   Telefono, Celular, TipoCuitId, CuitNro, Email, PaginaWeb, Observaciones,
	   PercepcionDGR, AplicaPercepcionIVA, NoReflejarFacturaEnCaja, TipoComprobante,
	   Desincronizado, FechaUltimaModificacion, Eliminado, CuentaIdentifier)
	AS (
		SELECT    *
		FROM       OPENXML (@idoc, '/Exportacion/Proveedores/P/C',2) 
				 WITH (ProveedorId INT '../ProveedorId', 
					   Identifier UNIQUEIDENTIFIER '../Identifier',
					   Nombre varchar(100) '../Nombre',
					   Contacto varchar(100) '../Contacto',
					   Direccion varchar(200) '../Direccion',
					   LocalidadId int '../LocalidadId',
					   Telefono varchar(16) '../Telefono',
					   Celular varchar(18) '../Celular',
					   TipoCuitId int '../TipoCuitId',
					   CuitNro varchar(14) '../CuitNro',
					   Email varchar(200) '../Email',
					   PaginaWeb varchar(200) '../PaginaWeb',
					   Observaciones varchar(max) '../Observaciones',
					   PercepcionDGR DECIMAL(5,2) '../PercepcionDGR',
					   AplicaPercepcionIVA BIT '../AplicaPercepcionIVA',
					   NoReflejarFacturaEnCaja BIT '../NoReflejarFacturaEnCaja',
					   TipoComprobante varchar(3) '../TipoComprobante',
					   Desincronizado BIT '../Desincronizado',
					   FechaUltimaModificacion datetime2(7) '../FechaUltimaModificacion',
					   Eliminado bit '../Eliminado',
					   CuentaIdentifier UNIQUEIDENTIFIER 'CuentaIdentifier')
	 )
	 
	 INSERT INTO @Temp
	 SELECT * FROM ProveedorCTE
	 
	 	 
	 UPDATE P
	 SET CuentaId = (SELECT TOP 1 CuentaId FROM Cuenta WHERE Identifier = CTE.CuentaIdentifier), 
		Nombre = CTE.Nombre, 
		Contacto = CTE.Contacto, 
		Direccion = CTE.Direccion, 
		LocalidadId = CTE.LocalidadId,
	    Telefono = CTE.Telefono, 
	    Celular = CTE.Celular, 
	    TipoCuitId = CTE.TipoCuitId, 
	    CuitNro = CTE.CuitNro, 
	    Email = CTE.Email, 
	    PaginaWeb = CTE.PaginaWeb, 
	    Observaciones = CTE.Observaciones,
	    PercepcionDGR = CTE.PercepcionDGR,
	    AplicaPercepcionIVA = CTE.AplicaPercepcionIVA,
	    NoReflejarFacturaEnCaja = ISNULL(CTE.NoReflejarFacturaEnCaja, 0),
	    TipoComprobante = CTE.TipoComprobante,
	    Desincronizado = CTE.Desincronizado, 
	    FechaUltimaModificacion = CTE.FechaUltimaModificacion, 
	    Eliminado = CTE.Eliminado
	FROM @Temp CTE
		INNER JOIN Proveedor P
			ON CTE.Identifier = P.Identifier
	WHERE (@SobreescribirLocal = 1 OR
			(@SobreescribirLocal = 0 AND P.Desincronizado = 0))
	;
	 
	 INSERT INTO Proveedor (Identifier, Nombre, Contacto, Direccion, LocalidadId,
	   Telefono, Celular, TipoCuitId, CuitNro, Email, PaginaWeb, Observaciones,
	   PercepcionDGR, AplicaPercepcionIVA, NoReflejarFacturaEnCaja, TipoComprobante,
	   Desincronizado, FechaUltimaModificacion, Eliminado, CuentaId)
	 SELECT Identifier, 
			Nombre, 
			Contacto, 
			Direccion, 
			LocalidadId,
			Telefono, 
			Celular, 
			TipoCuitId, 
			CuitNro, 
			Email, 
			PaginaWeb, 
			Observaciones,
			PercepcionDGR,
			AplicaPercepcionIVA,
			ISNULL(NoReflejarFacturaEnCaja, 0),
			TipoComprobante,
			Desincronizado, 
			FechaUltimaModificacion, 
			Eliminado, 
			(SELECT TOP 1 CuentaId FROM Cuenta WHERE Identifier = CTE.CuentaIdentifier)			
	 FROM @Temp CTE
	 WHERE CTE.Identifier NOT IN (SELECT Identifier FROM Proveedor)
	 
	 
    IF @SobreescribirLocal = 1
	BEGIN
		UPDATE P
		SET Desincronizado = 0
		FROM Proveedor P
		WHERE P.Identifier IN (SELECT Identifier
								FROM @Temp)
		
	END
	ELSE
		UPDATE P
		SET Desincronizado = 1
		FROM Proveedor P
		WHERE P.Identifier IN (SELECT Identifier
								FROM @Temp)
		
END
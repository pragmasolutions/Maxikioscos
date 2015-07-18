
BEGIN TRAN Tran2;	
	CREATE TABLE #TablasMaxi (
		Id INT IDENTITY(1,1),
		Nombre VARCHAR(250)
	)
	INSERT INTO #TablasMaxi
			( Nombre )
	SELECT TABLE_NAME
	FROM INFORMATION_SCHEMA.TABLES
	WHERE TABLE_SCHEMA='dbo' AND SUBSTRING(TABLE_NAME,1,1)<>'w'

	CREATE TABLE #ColumnasMaxi (	
		Nombre VARCHAR(250)
	)
	DECLARE @LineaUpDate VARCHAR(250)
	SET @LineaUpDate='UPDATE @NombreTable SET @NombreColumna = UPPER(@NombreColumna)'
	DECLARE @Contador INT
	SET @Contador = 1   
	DECLARE @Regs INT               -- Variable para el Numero de Registros a procesar
	SET @Regs = (SELECT COUNT(*) FROM #TablasMaxi)
	DECLARE @NombreTable VARCHAR(100)
	DECLARE @NombreColumna VARCHAR(100)
	DECLARE @ExecuteUpdate VARCHAR(1000)

	WHILE @Contador <= @Regs
	BEGIN
		SELECT @NombreTable= t.Nombre
		FROM #TablasMaxi t
		WHERE t.Id = @Contador
		
		--Selecciono las columnas de tipo varchar de cada tabla
		INSERT INTO #ColumnasMaxi (	
			Nombre
		)
		SELECT COLUMN_NAME
		FROM INFORMATION_SCHEMA.COLUMNS
		WHERE TABLE_NAME =@NombreTable  AND DATA_TYPE='varchar' AND COLUMN_NAME NOT IN (SELECT COLUMN_NAME FROM sys.columns WHERE is_computed=1 AND object_id=OBJECT_ID(@NombreTable))
		
		WHILE(Exists(SELECT * FROM #ColumnasMaxi))
		  BEGIN
				SET @ExecuteUpdate=''
				--Selecciono siempre la primer fila
				select top(1) @NombreColumna=Nombre from #ColumnasMaxi
				PRINT @NombreTable + ' - ' + @NombreColumna
				SET @ExecuteUpdate=REPLACE(REPLACE(@LineaUpDate,'@NombreColumna',@NombreColumna),'@NombreTable',@NombreTable)
				EXECUTE(@ExecuteUpdate);
				IF @@ERROR<>0
					ROLLBACK TRAN Tran2
				
				--Elimino la primer fila que ya fue actualizada
				DELETE top(1) FROM #ColumnasMaxi;
		  END

		SET @Contador = @Contador + 1 
	END
	DROP TABLE #TablasMaxi
	DROP TABLE #ColumnasMaxi
IF @@ERROR=0
COMMIT TRAN Tran2;

GO

SELECT * FROM Producto
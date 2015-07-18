
CREATE PROCEDURE VetnasDummy
	@FechaDesde datetime = null,
	@FechaHasta datetime = null,
	@CuentaId int = 1
AS
BEGIN
	DECLARE @Temp TABLE
	(
		Codigo int,
		Cant int,
		Descripcion varchar(200),
		PrecioUnitario money,
		Importe money
	)
	
	INSERT INTO @Temp VALUES (10,1, 'Prod1', 10, 10)
	INSERT INTO @Temp VALUES (32,2, 'Prod1', 10, 20)
	INSERT INTO @Temp VALUES (564,3, 'Prod1', 15, 45)
	
	SELECT * FROM @Temp
END

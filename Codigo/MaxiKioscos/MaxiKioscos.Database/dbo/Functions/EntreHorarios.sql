
CREATE FUNCTION dbo.EntreHorarios
(
	@Desde time(7),
	@Hasta time(7)
)
RETURNS bit
AS
BEGIN
	
	DECLARE @EstaEntre bit
	DECLARE @FechaDesde datetime2(7)
	DECLARE @FechaHasta datetime2(7)
	SET @FechaDesde=CAST((CONVERT(varchar(10),GETDATE(),120) + ' ' + CAST(@Desde as varchar(30))) as datetime2(7))
	SET @FechaHasta=CAST((CONVERT(varchar(10),GETDATE(),120) + ' ' + CAST(@Hasta as varchar(30))) as datetime2(7))
	IF (@FechaDesde>@FechaHasta)
	BEGIN	
			IF (@FechaDesde<=GETDATE() AND GETDATE()>@FechaHasta)
				SET @fechahasta=DATEADD(day,1,@fechahasta)
			ELSE
				BEGIN 
					IF (@FechaDesde>GETDATE() AND GETDATE()<=@FechaHasta)
						SET @FechaDesde=DATEADD(day,-1,@FechaDesde)
				END
	END	
	SET @EstaEntre=CASE
						WHEN (GETDATE() >= @FechaDesde AND GETDATE()<= @FechaHasta) THEN 1
						ELSE 0
					END	
	-- Return the result of the function
	RETURN (@EstaEntre)

END

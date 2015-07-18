


CREATE PROCEDURE [dbo].[Sincronizacion_EstadoKioscos]
	@CuentaId int
AS
BEGIN
	SET NOCOUNT ON;

    SELECT M.MaxiKioscoId,
		   M.Identifier,
		   M.Nombre,
		   M.UltimaSecuenciaExportacion,
		   E.ExportacionId,
		   E.Fecha
	FROM MaxiKiosco M
		LEFT JOIN (SELECT ExportacionId, Fecha, Secuencia FROM Exportacion) E
			ON M.UltimaSecuenciaExportacion = E.Secuencia
	WHERE M.Eliminado = 0
		AND M.CuentaId = @CuentaId
END


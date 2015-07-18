/****** Object:  StoredProcedure [dbo].[Sincronizacion_EstadoKioscos]    Script Date: 05/14/2014 23:29:39 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Sincronizacion_EstadoKioscos]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Sincronizacion_EstadoKioscos]
GO


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
		   Fecha = M.UltimaSincronizacionExitosa
	FROM MaxiKiosco M
		LEFT JOIN (SELECT ExportacionId, Fecha, Secuencia FROM Exportacion) E
			ON M.UltimaSecuenciaExportacion = E.Secuencia
	WHERE M.Eliminado = 0
		AND M.CuentaId = @CuentaId
END

GO



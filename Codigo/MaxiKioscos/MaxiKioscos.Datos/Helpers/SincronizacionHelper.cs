using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaxiKioscos.Datos.Repositorio;
using MaxiKioscos.Entidades;

namespace MaxiKioscos.Datos.Helpers
{
    public static class SincronizacionHelper
    {
        public static List<Exportacion> ObtenerDatosSinExportar(Guid maxikioscoIdentifier, int usuarioId, int ultimaSecuenciaAcusada)
        {
            var repository = new ExportacionRepository();
            var puedeExportar = repository.PuedeExportarKiosco();
            if (puedeExportar)
            {
                //Generamos la exportacion para usuario que realizo la solicitud.
                repository.ExportarKiosco(maxikioscoIdentifier, usuarioId);
            }
            
            var pendientes = repository.ListadoConArchivos(e => e.Secuencia > ultimaSecuenciaAcusada);
            return pendientes.ToList();
        }
    }
}

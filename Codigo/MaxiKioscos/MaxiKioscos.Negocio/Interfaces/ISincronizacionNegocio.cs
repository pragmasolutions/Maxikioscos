using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using MaxiKioscos.Entidades;

namespace MaxiKioscos.Negocio
{
    public interface ISincronizacionNegocio
    {
        bool ExportarPrincipal(int usuarioId);
        IQueryable<SyncExportacion> ListadoExportaciones(params Expression<Func<SyncExportacion, object>>[] includes);
        bool ActualizarPrincipal(string archivo, Guid maxiKioscoIdentifier, int secuencia, string nombreArchivo);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using MaxiKioscos.Entidades;

namespace MaxiKioscos.Datos.Interfaces
{
    public interface IExportacionRepository : IRepository<Exportacion>
    {
        /// <summary>
        /// Get <see cref="Speaker"/>s at sessions.
        /// </summary>
        /// <remarks>
        /// <see cref="Speaker"/> is a subset of  
        /// <see cref="Person"/> properties suitable for 
        /// quick client-side filtering and presentation.
        /// </remarks>
        IQueryable<Exportacion> ListadoPorCuenta(int cuentaId, params Expression<Func<Exportacion, object>>[] includes);

        bool PuedeExportarPrincipal();

        int ExportarPrincipal(int usuarioId, int? secuencia = null);

        int ExportarKiosco(Guid maxikioscoIdentifier, int usuarioId);

        bool SincronizarPrincipal(int maxiKioscoId, string xml, int secuenciaId);

        bool ActualizarKiosco(string xml, Guid maxikioscoIdentifier, int secuencia);

        bool ActualizarPrincipal(string xml, Guid maxikioscoIdentifier, int secuencia, string nombreArchivo);

        void Resetear();
    }
}

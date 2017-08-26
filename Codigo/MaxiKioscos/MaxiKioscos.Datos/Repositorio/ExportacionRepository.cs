using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using MaxiKioscos.Datos.Interfaces;
using MaxiKioscos.Entidades;

namespace MaxiKioscos.Datos.Sync
{
    public class ExportacionRepository : EFRepository<Exportacion>, IExportacionRepository
    {
        public ExportacionRepository(){}

        public ExportacionRepository(DbContext context) : base(context) { }

        public IQueryable<Exportacion> ListadoPorCuenta(int cuentaId, params Expression<Func<Exportacion, object>>[] includes)
        {
            var dbset = DbContext.Set<Exportacion>().AsQueryable();
            dbset = includes.Aggregate(dbset, (current, include) => current.Include(include));

            return dbset.Where(u => u.CuentaId == cuentaId);
        }

        public IQueryable<Exportacion> ListadoConArchivos(Expression<Func<Entidades.Exportacion, bool>> whereClause = null)
        {
            if (whereClause != null)
                return MaxiKioscosEntities.Exportaciones.Include(e => e.ExportacionArchivo).Where(whereClause);
            return MaxiKioscosEntities.Exportaciones.Include(e => e.ExportacionArchivo);
        }


        #region IExportacionRepository Members


        public bool PuedeExportarPrincipal()
        {
            var cuentaDesincronizados = MaxiKioscosEntities.ExportacionPuedeExportarPrincipal().FirstOrDefault();
            return cuentaDesincronizados > 0;
        }

        public bool PuedeExportarKiosco()
        {
            var cuentaDesincronizados = MaxiKioscosEntities.ExportacionPuedeExportarKiosco().FirstOrDefault();
            return cuentaDesincronizados > 0;
        }
        

        public string ExportarPrincipal(int usuarioId)
        {
            return MaxiKioscosEntities.ExportacionNuevoXmlPrincipal(usuarioId).FirstOrDefault();
        }

        public int ExportarKiosco(Guid maxikioscoIdentifier, int usuarioId)
        {
            return MaxiKioscosEntities.ExportacionNuevoXmlKiosco(maxikioscoIdentifier, usuarioId).FirstOrDefault().GetValueOrDefault();
        }

        public bool SincronizarPrincipal(int maxiKioscoId, string xml, int secuenciaId)
        {
            return true;
            //return MaxiKioscosEntities.ActualizarPrincipal(maxiKioscoId, xml, secuenciaId);
        }

        public bool ActualizarKiosco(string xml, Guid maxikioscoIdentifier, int secuencia)
        {
            try
            {
                MaxiKioscosEntities.SincronizacionActualizarKiosco(xml, maxikioscoIdentifier,  secuencia);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool ActualizarPrincipal(string xml, Guid maxikioscoIdentifier, int secuencia, string nombreArchivo)
        {
            var result = MaxiKioscosEntities.SincronizacionActualizarPrincipal(xml, maxikioscoIdentifier, secuencia, nombreArchivo).FirstOrDefault();
            return result.GetValueOrDefault();
        }

        public void Resetear()
        {
            MaxiKioscosEntities.ExportacionResetear();
        }

        #endregion


        public void Dispose()
        {
            MaxiKioscosEntities.Dispose();
        }
    }
}

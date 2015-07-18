using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using MaxiKioscos.Datos.Interfaces;
using MaxiKioscos.Entidades;

namespace MaxiKioscos.Datos.Repositorio
{
    public class MaxiKioscoRepository : EFRepository<Entidades.MaxiKiosco>, IMaxiKioscoRepository
    {
        public MaxiKioscoRepository() { }

        public MaxiKioscoRepository(DbContext dbContext)
            : base(dbContext)
        {
        }


        #region IMaxiKioscoRepository Members

        public IQueryable<EstadoKiosco> EstadoMaxiKioscos(int? cuentaId)
        {
            return MaxiKioscosEntities.SincronizacionEstadoKioscos(cuentaId).AsQueryable();
        }

        public IQueryable<Entidades.MaxiKiosco> Listado(params Expression<Func<Entidades.MaxiKiosco, object>>[] includes)
        {
            return base.Listado(includes);
        }

        public Entidades.MaxiKiosco Obtener(int id)
        {
            return base.Obtener(id);
        }

        public Entidades.MaxiKiosco Obtener(Expression<Func<Entidades.MaxiKiosco, bool>> whereClause, params Expression<Func<Entidades.MaxiKiosco, object>>[] includes)
        {
            return base.Obtener(whereClause, includes);
        }

        public void Agregar(Entidades.MaxiKiosco maxiKiosco)
        {
            base.Agregar(maxiKiosco);
        }

        public void Eliminar(Entidades.MaxiKiosco maxiKiosco)
        {
            base.Eliminar(maxiKiosco);
        }

        public void Modificar(Entidades.MaxiKiosco maxiKiosco)
        {
            base.Modificar(maxiKiosco);
        }

        #endregion
    }
}

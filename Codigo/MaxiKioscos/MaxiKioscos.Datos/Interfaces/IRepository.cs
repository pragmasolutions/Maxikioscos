using System;
using System.Linq;
using System.Linq.Expressions;
using MaxiKioscos.Entidades;

namespace MaxiKioscos.Datos.Interfaces
{
    public interface IRepository<T> where T : class , IEntity
    {
        IQueryable<T> Listado();
        IQueryable<T> Listado(params Expression<Func<T, object>>[] includes);
        int Max(Func<T, int> field);
        T Obtener(int id);
        T Obtener(Expression<Func<T, bool>> whereClause, params Expression<Func<T, object>>[] includes);
        void Agregar(T entity);
        void Modificar(T entity);
        void Eliminar(T entity);
        void Eliminar(int id);
    }
}

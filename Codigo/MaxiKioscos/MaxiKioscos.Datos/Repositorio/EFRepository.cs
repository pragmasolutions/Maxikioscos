using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using MaxiKioscos.Datos.Interfaces;
using MaxiKioscos.Entidades;

namespace MaxiKioscos.Datos.Sync
{
    /// <summary>
    /// The EF-dependent, generic repository for data access
    /// </summary>
    /// <typeparam name="T">Type of entity for this Repository.</typeparam>
    public class EFRepository<T> : EFBaseRepository, IRepository<T> where T : class , IEntity
    {
        public EFRepository()
            : base()
        {
            DbSet = DbContext.Set<T>();
        }

        public EFRepository(DbContext dbContext)
            : base(dbContext)
        {
            DbSet = DbContext.Set<T>();
        }

        protected DbSet<T> DbSet { get; set; }

        public virtual IQueryable<T> Listado()
        {
            return DbSet.Where(e => !e.Eliminado);
        }

        public IQueryable<T> Listado(params Expression<Func<T, object>>[] includes)
        {
            var dbset = DbSet.Where(e => !e.Eliminado).AsQueryable();
            foreach (var include in includes)
            {
                dbset = dbset.Include(include);
            }

            return dbset;
        }

        public int Max(Func<T, int> field)
        {
            var dbset = DbSet.Where(e => !e.Eliminado).AsQueryable();
            return dbset.Any() ? dbset.Max(field) : 0;
        }


        public virtual T Obtener(int id)
        {
            //return DbSet.FirstOrDefault(PredicateBuilder.GetByIdPredicate<T>(id));
            T entity = DbSet.Find(id);
            return entity != null && !entity.Eliminado ? entity : null;
        }

        public virtual T Obtener(Expression<Func<T, bool>> whereClause, params Expression<Func<T, object>>[] includes)
        {   
            var dbset = DbSet.Where(e => !e.Eliminado).AsQueryable();
            foreach (var include in includes)
            {
                dbset = dbset.Include(include);
            }
            return dbset.FirstOrDefault(whereClause);
        }

        public virtual void Agregar(T entity)
        {
            entity.FechaUltimaModificacion = DateTime.Now;
            entity.Desincronizado = true;
            entity.Eliminado = false;
            
            DbEntityEntry dbEntityEntry = DbContext.Entry(entity);
            if (dbEntityEntry.State != EntityState.Detached)
            {
                dbEntityEntry.State = EntityState.Added;
            }
            else
            {
                DbSet.Add(entity);
            }
        }

        public virtual void Modificar(T entity)
        {
            entity.FechaUltimaModificacion = DateTime.Now;
            entity.Desincronizado = true;
            DbEntityEntry dbEntityEntry = DbContext.Entry(entity);
            if (dbEntityEntry.State == EntityState.Detached)
            {
                DbSet.Attach(entity);
            }
            dbEntityEntry.State = EntityState.Modified;
        }

        public virtual void Eliminar(T entity)
        {
            entity.Eliminado = true;
            entity.FechaUltimaModificacion = DateTime.Now;
            entity.Desincronizado = true;
            Modificar(entity);
        }

        public virtual void Eliminar(int id)
        {
            var entity = Obtener(id);
            if (entity == null) return; // not found; assume already deleted.
            Eliminar(entity);
        }

        //private void SetCommonProperties(T entity)
        //{
        //    entity.FechaUltimaModificacion = DateTime.Now;

        //    ////Set syncronization flag
        //    var synchronizableEntity = entity as ISynchronizableEntity;
        //    if (synchronizableEntity != null)
        //        synchronizableEntity.Desincronizado = true;
        //}


        public void Commit()
        {
            DbContext.SaveChanges();
        }
    }
}

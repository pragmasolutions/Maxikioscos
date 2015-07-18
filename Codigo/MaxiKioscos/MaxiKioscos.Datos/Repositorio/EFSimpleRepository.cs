using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using MaxiKioscos.Datos.Interfaces;
using MaxiKioscos.Entidades;

namespace MaxiKioscos.Datos.Repositorio
{
    /// <summary>
    /// The EF-dependent, generic repository for data access
    /// </summary>
    /// <typeparam name="T">Type of entity for this Repository.</typeparam>
    public class EFSimpleRepository<T> : EFBaseRepository, ISimpleRepository<T> where T : class
    {
        public EFSimpleRepository()
            :base()
        {
            DbSet = DbContext.Set<T>();
        }

        public EFSimpleRepository(DbContext dbContext)
            :base(dbContext)
        {
            DbSet = DbContext.Set<T>();
        }

        protected DbSet<T> DbSet { get; set; }

        public virtual IQueryable<T> Listado()
        {
            return DbSet;
        }

        public IQueryable<T> Listado(params Expression<Func<T, object>>[] includes)
        {
            var dbset = DbSet.AsQueryable();
            foreach (var include in includes)
            {
                dbset = dbset.Include(include);
            }
            return dbset;
        }

        public virtual T Obtener(int id)
        {
            //return DbSet.FirstOrDefault(PredicateBuilder.GetByIdPredicate<T>(id));
            T entity = DbSet.Find(id);
            return entity;
        }

        public virtual T Obtener(Expression<Func<T, bool>> whereClause, params Expression<Func<T, object>>[] includes)
        {
            var dbset = DbSet.AsQueryable();
            foreach (var include in includes)
            {
                dbset = dbset.Include(include);
            }
            return dbset.FirstOrDefault(whereClause);
        }

        public virtual void Agregar(T entity)
        {
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
            DbEntityEntry dbEntityEntry = DbContext.Entry(entity);
            if (dbEntityEntry.State == EntityState.Detached)
            {
                DbSet.Attach(entity);
            }  
            dbEntityEntry.State = EntityState.Modified;
        }

        public virtual void Eliminar(T entity)
        {
            DbEntityEntry dbEntityEntry = DbContext.Entry(entity);
            if (dbEntityEntry.State != EntityState.Deleted)
            {
                dbEntityEntry.State = EntityState.Deleted;
            }
            else
            {
                DbSet.Attach(entity);
                DbSet.Remove(entity);
            }
        }

        public virtual void Eliminar(int id)
        {
            var entity = Obtener(id);
            if (entity == null) return; // not found; assume already deleted.
            Eliminar(entity);
        }

        public bool Commit()
        {
            try
            {
                DbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
    }
}

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
    /// The EF-dependent, base repository for data access
    /// </summary>
    public class EFBaseRepository
    {
        public EFBaseRepository()
        {
            CreateDbContext();
        }

        public EFBaseRepository(DbContext dbContext)
        {
            if (dbContext == null) 
                throw new ArgumentNullException("dbContext");
            DbContext = dbContext;
            MaxiKioscosEntities = dbContext as MaxiKioscosEntities;
            MaxiKioscosEntities.Database.CommandTimeout = 1000;
        }

        protected void CreateDbContext()
        {
            DbContext = new MaxiKioscosEntities();
            DbContext.Configuration.ProxyCreationEnabled = false;
            DbContext.Configuration.LazyLoadingEnabled = false;
            DbContext.Configuration.ValidateOnSaveEnabled = false;

            MaxiKioscosEntities = DbContext as MaxiKioscosEntities;
            MaxiKioscosEntities.Database.CommandTimeout = 1000;
        }
        
        protected DbContext DbContext { get; set; }

        public MaxiKioscosEntities MaxiKioscosEntities { get; set; }
    }
}

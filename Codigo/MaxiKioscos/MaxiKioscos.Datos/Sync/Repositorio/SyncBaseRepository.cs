using System;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using MaxiKioscos.Datos.Interfaces;
using MaxiKioscos.Entidades;

namespace MaxiKioscos.Datos.Sync.Repositorio
{
    /// <summary>
    /// The EF-dependent, base repository for data access
    /// </summary>
    public class SyncBaseRepository
    {
        public SyncBaseRepository()
        {
            CreateDbContext();
        }

        public SyncBaseRepository(DbConnection existingConnection, bool contextOwnsConnection)
        {
            CreateDbContext(existingConnection, contextOwnsConnection);
        }

        public SyncBaseRepository(DbContext dbContext)
        {
            if (dbContext == null)
                throw new ArgumentNullException("dbContext");
            DbContext = dbContext;
            SincronizacionEntities = dbContext as SincronizacionEntities;
            SincronizacionEntities.Database.CommandTimeout = 1000;
        }


        protected void CreateDbContext()
        {
            DbContext = new SincronizacionEntities();

            InitializeRepo();
        }

        protected void CreateDbContext(DbConnection existingConnection, bool contextOwnsConnection)
        {
            DbContext = new SincronizacionEntities(existingConnection, contextOwnsConnection);

            InitializeRepo();
        }

        private void InitializeRepo()
        {
            DbContext.Configuration.ProxyCreationEnabled = false;
            DbContext.Configuration.LazyLoadingEnabled = false;
            DbContext.Configuration.ValidateOnSaveEnabled = false;

            SincronizacionEntities = DbContext as SincronizacionEntities;
            if (SincronizacionEntities != null) SincronizacionEntities.Database.CommandTimeout = 1000;
        }

        protected DbContext DbContext { get; set; }

        public SincronizacionEntities SincronizacionEntities { get; set; }
    }
}

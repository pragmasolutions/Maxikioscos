using System;
using MaxiKioscos.Datos.Helpers;
using MaxiKioscos.Datos.Interfaces;
using MaxiKioscos.Entidades;

namespace MaxiKioscos.Datos
{
    /// <summary>
    /// The Code Camper "Unit of Work"
    ///     1) decouples the repos from the controllers
    ///     2) decouples the DbContext and EF from the controllers
    ///     3) manages the UoW
    /// </summary>
    /// <remarks>
    /// This class implements the "Unit of Work" pattern in which
    /// the "UoW" serves as a facade for querying and saving to the database.
    /// Querying is delegated to "repositories".
    /// Each repository serves as a container dedicated to a particular
    /// root entity type such as a <see cref="Facturas"/>.
    /// A repository typically exposes "Get" methods for querying and
    /// will offer add, update, and delete methods if those features are supported.
    /// The repositories rely on their parent UoW to provide the interface to the
    /// data layer (which is the EF DbContext in Code Camper).
    /// </remarks>
    public class MaxiKioscosUow : IMaxiKioscosUow, IDisposable
    {
        public MaxiKioscosUow(IRepositoryProvider repositoryProvider)
        {
            CreateDbContext();

            repositoryProvider.DbContext = DbContext;
            RepositoryProvider = repositoryProvider;       
        }

        // Repositorios

        public IUsuarioRepository Usuarios { get { return GetRepo<IUsuarioRepository>(); } }
        public IProductoRepository Productos { get { return GetRepo<IProductoRepository>(); } }
        public IStockRepository Stocks { get { return GetRepo<IStockRepository>(); } }
        public IRepository<Proveedor> Proveedores { get { return GetStandardRepo<Proveedor>(); } }
        public IRepository<CierreCaja> CierresDeCaja { get { return GetStandardRepo<CierreCaja>(); } }
        public IRepository<CodigoProducto> CodigosDeProducto { get { return GetStandardRepo<CodigoProducto>(); } }
        public IRepository<Cuenta> Cuentas { get { return GetStandardRepo<Cuenta>(); } }
        public IRepository<ExcepcionRubro> ExcepcionesRubros { get { return GetStandardRepo<ExcepcionRubro>(); } }
        public IRepository<Factura> Facturas { get { return GetStandardRepo<Factura>(); } }
        public ISimpleRepository<Localidad> Localidades { get { return GetSimpleRepo<Localidad>(); } }
        public ISimpleRepository<Importacion> Importaciones { get { return GetSimpleRepo<Importacion>(); } }
        public IRepository<Marca> Marcas { get { return GetStandardRepo<Marca>(); } }
        public IMaxiKioscoRepository MaxiKioscos { get { return GetRepo<IMaxiKioscoRepository>(); } }
        public IRepository<Entidades.MaxiKioscoTurno> MaxiKioscoTurnos { get { return GetStandardRepo<Entidades.MaxiKioscoTurno>(); } }
        public ISimpleRepository<Turno> Turnos { get { return GetSimpleRepo<Turno>(); } }
        public ISimpleRepository<MotivoOperacionCaja> MotivosOperacionCaja { get { return GetSimpleRepo<MotivoOperacionCaja>(); } }
        public ISimpleRepository<OperacionCaja> OperacionesDeCaja { get { return GetSimpleRepo<OperacionCaja>(); } }
        public IRepository<ProveedorProducto> ProveedorProductos { get { return GetStandardRepo<ProveedorProducto>(); } }
        public ISimpleRepository<Provincia> Provincias { get { return GetSimpleRepo<Provincia>(); } }
        public IRepository<Rubro> Rubros { get { return GetStandardRepo<Rubro>(); } }
        public ISimpleRepository<TipoCuit> TiposDeCuit { get { return GetSimpleRepo<TipoCuit>(); } }
        public IRepository<Venta> Ventas { get { return GetStandardRepo<Venta>(); } }
        public IRepository<VentaProducto> VentasProductos { get { return GetStandardRepo<VentaProducto>(); } }
        public IRepository<StockTransaccion> StockTransacciones { get { return GetStandardRepo<StockTransaccion>(); } }
        public ISimpleRepository<CorreccionStock> CorreccionesDeStock { get { return GetSimpleRepo<CorreccionStock>(); } }
        public IRepository<Compra> Compras { get { return GetStandardRepo<Compra>(); } }
        public IRepository<CompraProducto> ComprasProductos { get { return GetStandardRepo<CompraProducto>(); } }
        public IExportacionRepository Exportaciones { get { return GetRepo<IExportacionRepository>(); } }
        public IDatabaseRepository Database { get { return GetRepo<IDatabaseRepository>(); } }
        public IReporteRepository Reportes { get { return GetRepo<IReporteRepository>(); } }
        public ISimpleRepository<RecuentoBillete> RecuentoBilletes { get { return GetSimpleRepo<RecuentoBillete>(); } }
        public ISimpleRepository<TicketError> TicketErrores { get { return GetSimpleRepo<TicketError>(); } }
        public ISimpleRepository<MensajeTicketError> MensajesTicketError { get { return GetSimpleRepo<MensajeTicketError>(); } }
        public ISimpleRepository<EstadoTicket> EstadosTicket { get { return GetSimpleRepo<EstadoTicket>(); } }
        public IControlStockRepository ControlesStock { get { return GetRepo<IControlStockRepository>(); } }
        public IRepository<ControlStockDetalle> ControlStockDetalles { get { return GetStandardRepo<ControlStockDetalle>(); } }
        public ISimpleRepository<MotivoCorreccion> MotivosCorreccion { get { return GetSimpleRepo<MotivoCorreccion>(); } }
        public IRepository<Excepcion> Excepciones { get { return GetStandardRepo<Excepcion>(); } }
        public IRepository<Transferencia> Transferencias { get { return GetStandardRepo<Transferencia>(); } }
        public IRepository<TransferenciaProducto> TransferenciaProductos { get { return GetStandardRepo<TransferenciaProducto>(); } }
        public IRepository<ProductoPromocion> ProductoPromociones { get { return GetStandardRepo<ProductoPromocion>(); } }
        /// <summary>
        /// Save pending changes to the database
        /// </summary>
        public void Commit()
        {
            DbContext.SaveChanges();
        }

        protected void CreateDbContext()
        {
            DbContext = new MaxiKioscosEntities();

            // Do NOT enable proxied entities, else serialization fails
            DbContext.Configuration.ProxyCreationEnabled = false;

            // Load navigation properties explicitly (avoid serialization trouble)
            DbContext.Configuration.LazyLoadingEnabled = false;

            // Because Web API will perform validation, we don't need/want EF to do so
            DbContext.Configuration.ValidateOnSaveEnabled = false;

            //DbContext.Configuration.AutoDetectChangesEnabled = false;
            // We won't use this performance tweak because we don't need 
            // the extra performance and, when autodetect is false,
            // we'd have to be careful. We're not being that careful.
        }

        protected IRepositoryProvider RepositoryProvider { get; set; }

        private IRepository<T> GetStandardRepo<T>() where T : class , IEntity
        {
            return RepositoryProvider.GetRepositoryForEntityType<T>();
        }

        private ISimpleRepository<T> GetSimpleRepo<T>() where T : class
        {
            return RepositoryProvider.GetSimpleRepositoryForEntityType<T>();
        }

        private T GetRepo<T>() where T : class
        {
            return RepositoryProvider.GetRepository<T>();
        }

        private MaxiKioscosEntities DbContext { get; set; }

        #region IDisposable

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (DbContext != null)
                {
                    DbContext.Dispose();
                }
            }
        }

        #endregion
    }
}
using MaxiKioscos.Entidades;

namespace MaxiKioscos.Datos.Interfaces
{
    /// <summary>
    /// Interface for the Code Camper "Unit of Work"
    /// </summary>
    public interface IMaxiKioscosUow
    {
        // Save pending changes to the data store.
        void Commit();

        // Repositories
        IUsuarioRepository Usuarios { get; }
        IProductoRepository Productos { get; }
        IRepository<Proveedor> Proveedores { get; }
        IRepository<CierreCaja> CierresDeCaja { get; }
        IRepository<CodigoProducto> CodigosDeProducto { get; }
        IRepository<Cuenta> Cuentas { get; }
        IRepository<ExcepcionRubro> ExcepcionesRubros { get; }
        IRepository<Factura> Facturas { get; }
        ISimpleRepository<Localidad> Localidades { get; }
        ISimpleRepository<Importacion> Importaciones { get; }
        IRepository<Marca> Marcas { get; }
        IMaxiKioscoRepository MaxiKioscos { get; }
        IRepository<Entidades.MaxiKioscoTurno> MaxiKioscoTurnos { get; }
        ISimpleRepository<Turno> Turnos { get; }
        ISimpleRepository<MotivoOperacionCaja> MotivosOperacionCaja { get; }
        ISimpleRepository<OperacionCaja> OperacionesDeCaja { get; }
        IRepository<ProveedorProducto> ProveedorProductos { get; }
        ISimpleRepository<Provincia> Provincias { get; }
        IRepository<Rubro> Rubros { get; }
        ISimpleRepository<TipoCuit> TiposDeCuit { get; }
        IRepository<Venta> Ventas { get; }
        IRepository<VentaProducto> VentasProductos { get; }
        IStockRepository Stocks { get; }
        IRepository<StockTransaccion> StockTransacciones { get; }
        ISimpleRepository<CorreccionStock> CorreccionesDeStock { get; }
        IRepository<Compra> Compras { get; }
        IRepository<CompraProducto> ComprasProductos { get; }
        IExportacionRepository Exportaciones { get; }
        IReporteRepository Reportes { get; }
        ISimpleRepository<TicketError> TicketErrores { get; }
        ISimpleRepository<MensajeTicketError> MensajesTicketError { get; }
        ISimpleRepository<EstadoTicket> EstadosTicket { get; }
        IControlStockRepository ControlesStock { get; }
        IRepository<ControlStockDetalle> ControlStockDetalles { get; }
        ISimpleRepository<MotivoCorreccion> MotivosCorreccion { get; }
        IRepository<Excepcion> Excepciones { get; }
        IRepository<Transferencia> Transferencias { get; }
        IRepository<TransferenciaProducto> TransferenciaProductos { get; }
        IRepository<ProductoPromocion> ProductoPromociones { get; }
        IRepository<CategoriaCosto> CategoriasCostos { get; }
        IRepository<Costo> Costos { get; }
        IRepository<RetiroPersonal> RetirosPersonales { get; }
        IRepository<RetiroPersonalProducto> RetiroPersonalProductos { get; }
    }
}
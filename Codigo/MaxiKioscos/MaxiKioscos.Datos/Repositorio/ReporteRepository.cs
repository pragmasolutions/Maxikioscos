using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using MaxiKioscos.Datos.Interfaces;
using MaxiKioscos.Entidades;

namespace MaxiKioscos.Datos.Repositorio
{
    public class ReporteRepository : EFBaseRepository, IReporteRepository
    {
        public ReporteRepository()
        {
        }

        public ReporteRepository(DbContext dbContext)
            : base(dbContext)
        {
        }

        public IQueryable<RptVentasPorCierreCaja> VentasPorCierreCaja(int cierreCajaId)
        {
            return MaxiKioscosEntities.RptVentasPorCierreCaja(cierreCajaId).AsQueryable();
        }

        public IQueryable<RptVentaPorMaxikiosco> VentasPorMaxikiosco(DateTime? desde, DateTime? hasta, int? cuentaId)
        {
            return MaxiKioscosEntities.RptVentasPorMaxikiosco(desde, hasta, cuentaId).AsQueryable();
        }

        public IQueryable<RptVentaPorProducto> VentasPorProducto(DateTime? desde, DateTime? hasta, int? rubroId, int? maxikioscoId, int? cuentaId)
        {
            return MaxiKioscosEntities.RptVentasPorProducto(desde, hasta, rubroId, maxikioscoId, cuentaId).AsQueryable();
        }

        public IQueryable<RptVentasPorProductoTotalGeneral> VentasPorProductoTotalGeneral(DateTime? desde, DateTime? hasta, int? rubroId, int? cuentaId)
        {
            return MaxiKioscosEntities.RptVentasPorProductoTotalGeneral(desde, hasta, rubroId, cuentaId).AsQueryable();
        }

        public IQueryable<RptVentaPorProductoRanking> VentasPorProductoRanking(DateTime? desde, DateTime? hasta, int? rubroId, int? maxikioscoId, int? cuentaId, int? cierreCajaId)
        {
            return MaxiKioscosEntities.RptVentasPorProductoRanking(desde, hasta, rubroId, maxikioscoId, cuentaId, cierreCajaId).AsQueryable();
        }

        public IQueryable<RptTransferenciaPorProducto> TransferenciasPorProducto(DateTime? desde, DateTime? hasta, int? rubroId, int? maxikioscoOrigenId, int? maxikioscoDestinoId, int? cuentaId)
        {
            return MaxiKioscosEntities.RptTransferenciaPorProducto(desde, hasta, rubroId, maxikioscoOrigenId, maxikioscoDestinoId, cuentaId).AsQueryable();
        }

        public IQueryable<RptTransferenciaPorProductoTotalGeneral> TransferenciasPorProductoTotalGeneral(DateTime? desde, DateTime? hasta, int? rubroId, int? cuentaId)
        {
            return MaxiKioscosEntities.RptTransferenciaPorProductoTotalGeneral(desde, hasta, rubroId, cuentaId).AsQueryable();
        }

        public IQueryable<RptCierreDeCaja> CierresDeCaja(DateTime? desde, DateTime? hasta, int? maxikioscoId, int? usuarioId, int? cuentaId)
        {
            return MaxiKioscosEntities.RptCierresDeCaja(desde, hasta, maxikioscoId, usuarioId, cuentaId).AsQueryable();
        }

        public IQueryable<RptCierreDeCajaDetalle> CierresDeCajaDetalle(DateTime? desde, DateTime? hasta, int? maxikioscoId, int? usuarioId, int? cuentaId)
        {
            return MaxiKioscosEntities.RptCierresDeCajaDetalle(desde, hasta, maxikioscoId, usuarioId, cuentaId).AsQueryable();
        }

        public IQueryable<RptStock> Stock(DateTime? desde, DateTime? hasta, int? maxikioscoId, int? cuentaId)
        {
            return MaxiKioscosEntities.RptStock(desde, hasta, maxikioscoId, cuentaId).AsQueryable();
        }

        public decimal StockDiferencia(DateTime? desde, DateTime? hasta, int? maxikioscoId, int cuentaId)
        {
            return MaxiKioscosEntities.RptStockDiferenciaCierres(desde, hasta, maxikioscoId, cuentaId).FirstOrDefault().GetValueOrDefault();
        }

        public IQueryable<RptComprasPorProveedor> ComprasPorProveedor(DateTime? desde, DateTime? hasta, int? proveedorId, int? cuentaId)
        {
            return MaxiKioscosEntities.RptComprasPorProveedor(desde, hasta, proveedorId, cuentaId).AsQueryable();
        }
        
        public IQueryable<RptDineroPorMaxikiosco> DineroPorMaxikiosco()
        {
            return MaxiKioscosEntities.RptDineroPorMaxikiosco().AsQueryable();
        }

        public IQueryable<RptDineroSobranteFaltante> DineroSobranteFaltante(DateTime? desde, DateTime? hasta, int? maxikioscoId, int? cuentaId)
        {
            return MaxiKioscosEntities.RptDineroSobranteFaltante(desde, hasta, maxikioscoId, cuentaId).AsQueryable();
        }

        public IQueryable<RptGanaciaAdicionalExcepcionRubro> GanaciaAdicionalExcepcionRubro(DateTime? desde, DateTime? hasta, int? maxikioscoId, int? rubroId, int? cuentaId)
        {
            return MaxiKioscosEntities.RptGanaciaAdicionalExcepcionRubro(desde, hasta, maxikioscoId, rubroId, cuentaId).AsQueryable();
        }

        public IQueryable<ReponerStock> StockParaReponer(int? productoId, int? proveedorId, int? maxiKioscoId)
        {
            return MaxiKioscosEntities.RptReponerStock(productoId, proveedorId, maxiKioscoId).AsQueryable();
        }

        public IQueryable<StockValorizadoDetalladoRow> StockValorizadoDetallado(int? rubroId, int? maxiKioscoId)
        {
            return MaxiKioscosEntities.RptStockValorizadoDetallado(rubroId, maxiKioscoId).AsQueryable();
        }

        public IQueryable<StockValorizadoRow> StockValorizado(int? rubroId, int? maxiKioscoId)
        {
            return MaxiKioscosEntities.RptStockValorizado(rubroId, maxiKioscoId).AsQueryable();
        }

        public IQueryable<StockValorizadoGeneralRow> StockValorizadoGeneral(int? rubroId)
        {
            return MaxiKioscosEntities.RptStockValorizadoGeneral(rubroId).AsQueryable();
        }

        public IQueryable<TransferenciaDetalleRow> TransferenciaDetalle(int transferenciaId)
        {
            return MaxiKioscosEntities.TransferenciaDetalle(transferenciaId).AsQueryable();
        }

        public IQueryable<StockValorizadoDetalladoGeneralRow> StockValorizadoDetalladoGeneral(int? rubroId)
        {
            return MaxiKioscosEntities.RptStockValorizadoDetalladoGeneral(rubroId).AsQueryable();
        }


        public IQueryable<RptAuditoriaProductosRow> AuditoriaProductos()
        {
            return MaxiKioscosEntities.RptAuditoriaProductos().AsQueryable();
        }


        public IQueryable<RptVentaPorTicketRow> VentasPorTicket(int cierreCajaId)
        {
            return MaxiKioscosEntities.RptVentasPorTicket(cierreCajaId).AsQueryable();
        }
    }
}

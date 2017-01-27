using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.ExceptionServices;
using MaxiKioscos.Datos.Interfaces;
using MaxiKioscos.Entidades;

namespace MaxiKioscos.Datos.Sync
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

        public IQueryable<RptProductosEnDeposito> ProductosEnDesposito(int? rubroId)
        {
            return MaxiKioscosEntities.RptProductosEnDeposito(rubroId).AsQueryable();
        }


        public IQueryable<RptVentaPorProductoRanking> VentasPorProductoRanking(DateTime? desde, DateTime? hasta, int? rubroId, int? maxikioscoId, int? cuentaId, int? cierreCajaId)
        {
            return MaxiKioscosEntities.RptVentasPorProductoRanking(desde, hasta, rubroId, maxikioscoId, cuentaId, cierreCajaId).AsQueryable();
        }

        public IQueryable<RptVentasPorProveedorTotalGeneral> VentasPorProveedorTotalGeneral(DateTime? desde, DateTime? hasta, int? rubroId, int? proveedorId, int? cuentaId)
        {
            return MaxiKioscosEntities.RptVentasPorProveedorTotalGeneral(desde, hasta, rubroId, proveedorId, cuentaId).AsQueryable();
        }
        
        public IQueryable<RptVentasPorProveedor> VentasPorProveedor(DateTime? desde, DateTime? hasta, int? rubroId, int? maxikioscoId, int? proveedorId, int? cuentaId)
        {
            return MaxiKioscosEntities.RptVentasPorProveedor(desde, hasta, rubroId, maxikioscoId, proveedorId, cuentaId).AsQueryable();
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


        public IQueryable<RptRetirosPersonalesRow> RetirosPersonales(DateTime? desde, DateTime? hasta, int? usuarioId)
        {
            return MaxiKioscosEntities.RptRetirosPersonales(desde, hasta, usuarioId).AsQueryable();
        }


        public IQueryable<RptRetirosPersonalesPorTicketRow> RetirosPersonalesPorTicket(DateTime? desde, DateTime? hasta, int? usuarioId)
        {
            return MaxiKioscosEntities.RptRetirosPersonalesPorTicket(usuarioId, desde, hasta).AsQueryable();
        }


        public IQueryable<RptVentasNegativasPorTicketRow> VentasNegativasPorTicket(DateTime? desde, DateTime? hasta, int? usuarioId)
        {
            return MaxiKioscosEntities.RptVentasNegativasPorTicket(usuarioId, desde, hasta).AsQueryable();
        }


        public IQueryable<RptGastosPorCategoria> GastosPorCategoria(DateTime? desde, DateTime? hasta, int? maxikioscoId, int? categoriaId, int? subcategoriaId)
        {
            return MaxiKioscosEntities.RptGastosPorCategoria(desde, hasta, maxikioscoId, categoriaId, subcategoriaId).AsQueryable();
        }

        public IQueryable<RptGastosPorCategoriaTotalGeneral> GastosPorCategoriaTotalGeneral(DateTime? desde, DateTime? hasta, int? maxikioscoId, int? categoriaId, int? subcategoriaId)
        {
            return MaxiKioscosEntities.RptGastosPorCategoriaTotalGeneral(desde, hasta, maxikioscoId, categoriaId, subcategoriaId).AsQueryable();
        }

        public IList<Reporte> Listado()
        {
            return MaxiKioscosEntities.Reportes.ToList();
        }

        public IQueryable<RptComprasDetalladasPorProveedorTotalGeneral> ComprasDetalladasPorProveedorTotalGeneral(DateTime? desde, DateTime? hasta, int? rubroId, int? proveedorId, int? cuentaId)
        {
            return MaxiKioscosEntities.RptComprasDetalladasPorProveedorTotalGeneral(desde, hasta, rubroId, proveedorId, cuentaId).AsQueryable();
        }

        public IQueryable<RptComprasDetalladasPorProveedor> ComprasDetalladasPorProveedor(DateTime? desde, DateTime? hasta, int? rubroId, int? maxikioscoId, int? proveedorId, int? cuentaId)
        {
            return MaxiKioscosEntities.RptComprasDetalladasPorProveedor(desde, hasta, rubroId, maxikioscoId, proveedorId, cuentaId).AsQueryable();
        }

        public List<ProductoSugerenciaCompra> ProductoSugerenciaCompras(int proveedorId, int dias, int maxiKioscoId)
        {
            return MaxiKioscosEntities.ProductoSugerenciaCompras(proveedorId, dias, maxiKioscoId).ToList();
        }

        public List<ProductoExportacion> ProductoExportar()
        {
            return MaxiKioscosEntities.ProductoExportar().ToList();
        }
    }
}

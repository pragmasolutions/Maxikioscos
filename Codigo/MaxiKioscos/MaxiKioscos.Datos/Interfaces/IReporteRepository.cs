using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using MaxiKioscos.Entidades;

namespace MaxiKioscos.Datos.Interfaces
{
    public interface IReporteRepository
    {
        IQueryable<RptVentasPorCierreCaja> VentasPorCierreCaja(int cierreCajaId);

        IQueryable<RptVentaPorMaxikiosco> VentasPorMaxikiosco(DateTime? desde, DateTime? hasta, int? cuentaId);

        IQueryable<RptVentaPorProducto> VentasPorProducto(DateTime? desde, DateTime? hasta, int? rubroId, int? maxikioscoId, int? cuentaId);

        IQueryable<RptVentasPorProductoTotalGeneral> VentasPorProductoTotalGeneral(DateTime? desde, DateTime? hasta, int? rubroId, int? cuentaId);

        IQueryable<RptProductosEnDeposito> ProductosEnDesposito(int? rubroId);

        IQueryable<RptVentasPorProveedor> VentasPorProveedor(DateTime? desde, DateTime? hasta, int? rubroId, int? maxikioscoId, int? proveedorId, int? cuentaId);

        IQueryable<RptVentasPorProveedorTotalGeneral> VentasPorProveedorTotalGeneral(DateTime? desde, DateTime? hasta, int? rubroId, int? proveedor, int? cuentaId);

        IQueryable<RptVentaPorProductoRanking> VentasPorProductoRanking(DateTime? desde, DateTime? hasta, int? rubroId, int? maxikioscoId, int? cuentaId, int? cierreCajaId);

        IQueryable<RptTransferenciaPorProducto> TransferenciasPorProducto(DateTime? desde, DateTime? hasta, int? rubroId,
            int? maxikioscoOrigenId, int? maxikioscoDestinoId, int? cuentaId);

        IQueryable<RptTransferenciaPorProductoTotalGeneral> TransferenciasPorProductoTotalGeneral(DateTime? desde, DateTime? hasta, int? rubroId,int? cuentaId);

        IQueryable<RptCierreDeCaja> CierresDeCaja(DateTime? desde, DateTime? hasta, int? maxikioscoId, int? usuarioId, int? cuentaId);

        IQueryable<RptCierreDeCajaDetalle> CierresDeCajaDetalle(DateTime? desde, DateTime? hasta, int? maxikioscoId,
                                                                int? usuarioId, int? cuentaId);

        IQueryable<RptStock> Stock(DateTime? desde, DateTime? hasta, int? maxikioscoId, int? cuentaId);

        decimal StockDiferencia(DateTime? desde, DateTime? hasta, int? maxikioscoId, int cuentaId);

        IQueryable<RptComprasPorProveedor> ComprasPorProveedor(DateTime? desde, DateTime? hasta, int? proveedorId,
            int? cuentaId);

        IQueryable<RptDineroPorMaxikiosco> DineroPorMaxikiosco();

        IQueryable<RptDineroSobranteFaltante> DineroSobranteFaltante(DateTime? desde, DateTime? hasta,
                                                                         int? maxikioscoId, int? cuentaId);

        IQueryable<RptGanaciaAdicionalExcepcionRubro> GanaciaAdicionalExcepcionRubro(DateTime? desde, DateTime? hasta,
                                                                                     int? maxikioscoId, int? rubroId,
                                                                                     int? cuentaId);

        IQueryable<ReponerStock> StockParaReponer(int? productoId, int? proveedorId, int? maxiKioscoId);

        IQueryable<StockValorizadoDetalladoRow> StockValorizadoDetallado(int? rubroId, int? maxiKioscoId);

        IQueryable<StockValorizadoRow> StockValorizado(int? rubroId, int? maxiKioscoId);

        IQueryable<StockValorizadoGeneralRow> StockValorizadoGeneral(int? rubroId);

        IQueryable<TransferenciaDetalleRow> TransferenciaDetalle(int transferenciaId);

        IQueryable<StockValorizadoDetalladoGeneralRow> StockValorizadoDetalladoGeneral(int? rubroId);

        IQueryable<RptAuditoriaProductosRow> AuditoriaProductos();

        IQueryable<RptVentaPorTicketRow> VentasPorTicket(int cierreCajaId);

        IQueryable<RptRetirosPersonalesRow> RetirosPersonales(DateTime? desde, DateTime? hasta, int? usuarioId);

        IQueryable<RptRetirosPersonalesPorTicketRow> RetirosPersonalesPorTicket(DateTime? desde, DateTime? hasta, int? usuarioId);

        IQueryable<RptVentasNegativasPorTicketRow> VentasNegativasPorTicket(DateTime? desde, DateTime? hasta, int? usuarioId);

        IQueryable<RptGastosPorCategoria> GastosPorCategoria(DateTime? desde, DateTime? hasta, int? maxikioscoId,
            int? categoriaId, int? subcategoriaId);

        IQueryable<RptGastosPorCategoriaTotalGeneral> GastosPorCategoriaTotalGeneral(DateTime? desde, DateTime? hasta, int? maxikioscoId, int? categoriaId, int? subcategoriaId);
       
        IList<Reporte> Listado();

        IQueryable<RptComprasDetalladasPorProveedor> ComprasDetalladasPorProveedor(DateTime? desde, DateTime? hasta, int? rubroId, int? maxikioscoId, int? proveedorId, int? cuentaId);

        IQueryable<RptComprasDetalladasPorProveedorTotalGeneral> ComprasDetalladasPorProveedorTotalGeneral(DateTime? desde, DateTime? hasta, int? rubroId, int? proveedor, int? cuentaId);

        List<ProductoSugerenciaCompra> ProductoSugerenciaCompras(int proveedorId, int dias, int maxiKioscoId);
    }
}

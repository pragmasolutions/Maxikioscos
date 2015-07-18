using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.UI;
using MaxiKioscos.Datos.Interfaces;
using MaxiKioscos.Reportes;
using MaxiKioscos.Web.Configuration;
using MaxiKioscos.Web.Models;
using Maxikioscos.Comun.Logger;
using System.Linq;
using Maxikioscos.Comun.Extensions;

namespace MaxiKioscos.Web.Controllers
{
    [OutputCache(Location = OutputCacheLocation.None, NoStore = true)]
    public class ReportesController : BaseController
    {
        private const string TodosText = "TODOS";

        public ReportesController(IMaxiKioscosUow uow)
        {
            Uow = uow;
        }

        public ActionResult VentasPorCierreCaja(ReporteVentasCierreCajaFiltrosModel model)
        {
            return PartialOrView(model);
        }

        public ActionResult VentasPorMaxikioscos(ReporteVentasFiltrosModel reporteVentasFiltrosModel)
        {
            return PartialOrView(reporteVentasFiltrosModel);
        }

        public ActionResult VentasPorProductos(ReporteVentasFiltrosModel reporteVentasFiltrosModel)
        {
            return PartialOrView(reporteVentasFiltrosModel);
        }

        public ActionResult TransferenciasPorProducto(ReporteTransferenciasPorProductosFiltrosModel filtros)
        {
            return PartialOrView(filtros);
        }

        public ActionResult ProductosParaReponer(ReporteReposicionFiltrosModel reporteReposicionFiltrosModel)
        {
            return PartialOrView(reporteReposicionFiltrosModel);
        }

        public ActionResult CierresDeCaja(ReporteCierresDeCajaFiltrosModel reporteCierresDeCajaFiltrosModel)
        {
            return PartialOrView(reporteCierresDeCajaFiltrosModel);
        }

        public ActionResult CierresDeCajaDetalle(ReporteCierresDeCajaFiltrosModel reporteCierresDeCajaDetalleFiltrosModel)
        {
            return PartialOrView(reporteCierresDeCajaDetalleFiltrosModel);
        }

        public ActionResult Stock(ReporteStockFiltrosModel stockFiltrosModel)
        {
            return PartialOrView(stockFiltrosModel);
        }

        public ActionResult StockValorizado(ReporteStockValorizadoFiltrosModel model)
        {
            return PartialOrView(model);
        }

        public ActionResult StockValorizadoDetallado(ReporteStockValorizadoFiltrosModel model)
        {
            return PartialOrView(model);
        }

        public ActionResult ComprasPorProveedor(ReporteComprasPorProveedorFiltrosModel filtros)
        {
            return PartialOrView(filtros);
        }

        public ActionResult DineroPorMaxikiosco(ReporteModelBase filtros)
        {
            return PartialOrView(filtros);
        }

        public ActionResult AuditoriaProductos(ReporteModelBase filtros)
        {
            return PartialOrView(filtros);
        }

        public ActionResult GanaciaAdicionalExcepcionRubro(GanaciaAdicionalExcepcionRubroFiltrosModel ganaciaAdicionalExcepcionRubroFiltrosModel)
        {
            return PartialOrView(ganaciaAdicionalExcepcionRubroFiltrosModel);
        }

        public ActionResult DineroSobranteFaltante(ReporteDineroSobranteFaltanteFiltrosModel reporteCierresDeCajaFiltrosModel)
        {
            return PartialOrView(reporteCierresDeCajaFiltrosModel);
        }

        public ActionResult GenerarVentasPorCierreCaja(ReporteVentasCierreCajaFiltrosModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {

                    var ventasPorProductoDataSource = Uow.Reportes.VentasPorCierreCaja(model.CierreCajaId).ToList();

                    var ventasPorProductoRankingDataSource = Uow.Reportes.VentasPorProductoRanking(null, null, null, null, null, model.CierreCajaId).ToList();
                    var reporteFactory = new ReporteFactory();

                    var cierreCaja = Uow.CierresDeCaja.Obtener(c => c.CierreCajaId == model.CierreCajaId,
                                                                c => c.Usuario, c => c.MaxiKiosco);
                    var parameters = new Dictionary<string, string>
                                  {
                                      {"CierreCajaId", model.CierreCajaId.ToString()},
                                      {"Desde", cierreCaja.FechaInicioFormateada},
                                      {"Hasta", string.IsNullOrEmpty(cierreCaja.FechaFinFormateada) ? "TODAVIA ABIERTA" : cierreCaja.FechaFinFormateada},
                                      {"Usuario", cierreCaja.Usuario.NombreUsuario},
                                      {"Maxikiosco", cierreCaja.MaxiKiosco.Nombre}
                                  };

                    reporteFactory.SetPathCompleto(Server.MapPath("~/Reportes/VentasPorCierreCaja.rdl"))
                        .SetDataSource("VentasPorProductoDataSet", ventasPorProductoDataSource)
                        .SetDataSource("VentasPorProductoRankingDataSet", ventasPorProductoRankingDataSource)
                        .SetParametro(parameters); ;

                    byte[] archivo = reporteFactory.Renderizar(model.ReporteTipo);

                    return File(archivo, reporteFactory.MimeType);

                }
                catch (Exception ex)
                {
                    EventLogger.Log(ex);
                    return null;
                }
            }
            return null;
        }

        public ActionResult GenerarVentasPorMaxikiosco(ReporteVentasFiltrosModel reporteVentasFiltrosModel)
        {
            try
            {
                DateTime? hasta = reporteVentasFiltrosModel.Hasta == null
                                    ? (DateTime?)null
                                    : reporteVentasFiltrosModel.Hasta.GetValueOrDefault().AddDays(1);

                var ventasPorMaxikiosoDataSource =
                    Uow.Reportes.VentasPorMaxikiosco(reporteVentasFiltrosModel.Desde,
                        hasta,
                        UsuarioActual.CuentaId);

                var reporteFactory = new ReporteFactory();

                reporteFactory
                    .SetParametro("Desde", reporteVentasFiltrosModel.Desde.ToShortDateString())
                    .SetParametro("Hasta", reporteVentasFiltrosModel.Hasta.ToShortDateString())
                    .SetPathCompleto(Server.MapPath("~/Reportes/VentasPorMaxikiosco.rdl"))
                    .SetDataSource("VentasPorMaxikioscoDataSet", ventasPorMaxikiosoDataSource);

                byte[] archivo = reporteFactory.Renderizar(reporteVentasFiltrosModel.ReporteTipo);

                return File(archivo, reporteFactory.MimeType);
            }
            catch (Exception ex)
            {
                EventLogger.Log(ex);
                return null;
            }
        }

        public ActionResult GenerarVentasPorProducto(ReporteVentasFiltrosModel reporteVentasFiltrosModel)
        {
            DateTime? hasta = reporteVentasFiltrosModel.Hasta == null
                ? (DateTime?)null
                : reporteVentasFiltrosModel.Hasta.GetValueOrDefault().AddDays(1);

            var reporteFactory = new ReporteFactory();

            var rubro = Uow.Rubros.Obtener(r => r.RubroId == reporteVentasFiltrosModel.RubroId);
            var rubroDescripcion = rubro != null ? rubro.Descripcion : TodosText;

            var rubroId = reporteVentasFiltrosModel.RubroId.HasValue
                ? reporteVentasFiltrosModel.RubroId.Value.ToString()
                : null;

            reporteFactory
                .SetParametro("Desde", reporteVentasFiltrosModel.Desde.ToShortDateString(null))
                .SetParametro("Hasta", reporteVentasFiltrosModel.Hasta.ToShortDateString(null))
                .SetParametro("CuentaId", UsuarioActual.CuentaId.ToString())
                .SetParametro("RubroId", rubroId)
                .SetParametro("RubroDescripcion", rubroDescripcion);

            if (reporteVentasFiltrosModel.MostrarTotalGeneral)
            {
                var ventasPorProductoTotalGeneralDataSource =
                    Uow.Reportes.VentasPorProductoTotalGeneral(reporteVentasFiltrosModel.Desde,
                        hasta,
                        reporteVentasFiltrosModel.RubroId,
                        UsuarioActual.CuentaId);

                reporteFactory.SetPathCompleto(Server.MapPath("~/Reportes/VentasPorProductoTotalGeneral.rdl"))
                    .SetDataSource("VentasPorProductoTotalGeneralDataSet", ventasPorProductoTotalGeneralDataSource);
            }
            else
            {
                var ventasPorProductoDataSource = Uow.Reportes.VentasPorProducto(reporteVentasFiltrosModel.Desde,
                    hasta,
                    reporteVentasFiltrosModel.RubroId,
                    reporteVentasFiltrosModel.MaxiKioscoId,
                    UsuarioActual.CuentaId);

                var maxikiosco = Uow.MaxiKioscos.Obtener(m => m.MaxiKioscoId == reporteVentasFiltrosModel.MaxiKioscoId);
                var maxikioscoNombre = maxikiosco != null ? maxikiosco.Nombre : TodosText;

                reporteFactory
                    .SetParametro("MaxikioscoId", reporteVentasFiltrosModel.MaxiKioscoId.HasValue ? reporteVentasFiltrosModel.MaxiKioscoId.Value.ToString() : null)
                    .SetParametro("MaxikioscoNombre", maxikioscoNombre);

                reporteFactory.SetPathCompleto(Server.MapPath("~/Reportes/VentasPorProducto.rdl"))
                    .SetDataSource("VentasPorProductoDataSet", ventasPorProductoDataSource);

            }

            var ventasPorProductoRankingDataSource =
                Uow.Reportes.VentasPorProductoRanking(reporteVentasFiltrosModel.Desde,
                    hasta,
                    reporteVentasFiltrosModel.RubroId,
                    reporteVentasFiltrosModel.MaxiKioscoId,
                    UsuarioActual.CuentaId,
                    null);

            reporteFactory.SetDataSource("VentasPorProductoRankingDataSet", ventasPorProductoRankingDataSource);

            byte[] archivo = reporteFactory.Renderizar(reporteVentasFiltrosModel.ReporteTipo);

            return File(archivo, reporteFactory.MimeType);
        }

        public ActionResult GenerarTransferenciasPorProducto(ReporteTransferenciasPorProductosFiltrosModel filtros)
        {
            var reporteFactory = new ReporteFactory();

            var rubro = Uow.Rubros.Obtener(r => r.RubroId == filtros.RubroId);
            var rubroDescripcion = rubro != null ? rubro.Descripcion : TodosText;

            var rubroId = filtros.RubroId.HasValue
                ? filtros.RubroId.Value.ToString()
                : null;

            reporteFactory
                .SetParametro("Desde", filtros.Desde.ToShortDateString(null))
                .SetParametro("Hasta", filtros.Hasta.ToShortDateString(null))
                .SetParametro("CuentaId", UsuarioActual.CuentaId.ToString())
                .SetParametro("RubroId", rubroId)
                .SetParametro("RubroDescripcion", rubroDescripcion);

            if (filtros.MostrarTotalGeneral)
            {
                var transferenciasPorProductoTotalGeneralDataSource =
                    Uow.Reportes.TransferenciasPorProductoTotalGeneral(filtros.Desde,
                        filtros.HastaDiaSiguiente,
                        filtros.RubroId,
                        UsuarioActual.CuentaId);

                reporteFactory.SetPathCompleto(Server.MapPath("~/Reportes/TransferenciaPorProductoTotalGeneral.rdl"))
                    .SetDataSource("TransferenciasPorProductoTotalGeneralDataSet", transferenciasPorProductoTotalGeneralDataSource);
            }
            else
            {
                var transferenciasPorProductoDataSource = Uow.Reportes.TransferenciasPorProducto(filtros.Desde,
                    filtros.HastaDiaSiguiente,
                    filtros.RubroId,
                    filtros.MaxiKioscoOrigenId,
                    filtros.MaxiKioscoDestinoId,
                    UsuarioActual.CuentaId);

                var maxikioscoOrigen = Uow.MaxiKioscos.Obtener(m => m.MaxiKioscoId == filtros.MaxiKioscoOrigenId);
                var maxikioscoOrigenNombre = maxikioscoOrigen != null ? maxikioscoOrigen.Nombre : TodosText;

                var maxikioscoDestino = Uow.MaxiKioscos.Obtener(m => m.MaxiKioscoId == filtros.MaxiKioscoDestinoId);
                var maxikioscoDestinoNombre = maxikioscoDestino != null ? maxikioscoDestino.Nombre : TodosText;

                reporteFactory
                    .SetParametro("MaxikioscoOrigenNombre", maxikioscoOrigenNombre)
                    .SetParametro("MaxikisocoDestinoNombre", maxikioscoDestinoNombre);

                reporteFactory.SetPathCompleto(Server.MapPath("~/Reportes/TransferenciaPorProducto.rdl"))
                    .SetDataSource("TransferenciasPorProductoDataSet", transferenciasPorProductoDataSource);

            }

            byte[] archivo = reporteFactory.Renderizar(filtros.ReporteTipo);

            return File(archivo, reporteFactory.MimeType);
        }

        public ActionResult GenerarCierresDeCaja(ReporteCierresDeCajaFiltrosModel reporteCierresDeCajaFiltrosModel)
        {
            DateTime? hasta = reporteCierresDeCajaFiltrosModel.Hasta == null
                                    ? (DateTime?)null
                                    : reporteCierresDeCajaFiltrosModel.Hasta.GetValueOrDefault().AddDays(1);

            var cierreDeCajaDataSource = Uow.Reportes.CierresDeCaja(reporteCierresDeCajaFiltrosModel.Desde,
                                                                         hasta,
                                                                         reporteCierresDeCajaFiltrosModel.MaxiKioscoId,
                                                                         reporteCierresDeCajaFiltrosModel.UsuarioId,
                                                                         UsuarioActual.CuentaId);

            var usuarioNombre = (reporteCierresDeCajaFiltrosModel.UsuarioId == null)
                                   ? TodosText
                                   : Uow.Usuarios.Obtener(reporteCierresDeCajaFiltrosModel.UsuarioId.GetValueOrDefault()).NombreUsuario;

            var maxikiosco = Uow.MaxiKioscos.Obtener(m => m.MaxiKioscoId == reporteCierresDeCajaFiltrosModel.MaxiKioscoId);
            var maxikioscoNombre = maxikiosco != null ? maxikiosco.Nombre : TodosText;

            var reporteFactory = new ReporteFactory();

            reporteFactory
                .SetParametro("Desde", reporteCierresDeCajaFiltrosModel.Desde.ToShortDateString(null))
                .SetParametro("Hasta", reporteCierresDeCajaFiltrosModel.Hasta.ToShortDateString(null))
                .SetParametro("UsuarioNombre", usuarioNombre)
                .SetParametro("MaxikioscoNombre", maxikioscoNombre)
                .SetPathCompleto(Server.MapPath("~/Reportes/CierresDeCaja.rdl"))
                .SetDataSource("CierresDeCajaDataSet", cierreDeCajaDataSource);

            byte[] archivo = reporteFactory.Renderizar(reporteCierresDeCajaFiltrosModel.ReporteTipo);

            return File(archivo, reporteFactory.MimeType);
        }

        public ActionResult GenerarStock(ReporteStockFiltrosModel model)
        {
            DateTime? hasta = model.Hasta == null
                                    ? (DateTime?)null
                                    : model.Hasta.GetValueOrDefault().AddDays(1);

            var stockDataSource = Uow.Reportes.Stock(model.Desde, hasta, model.MaxiKioscoId, UsuarioActual.CuentaId);
            var stockDiferenciaDataSource = Uow.Reportes.StockDiferencia(model.Desde, hasta, model.MaxiKioscoId, UsuarioActual.CuentaId);

            var reporteFactory = new ReporteFactory();

            var datasources = new Dictionary<string, object>
                                  {
                                      {"StockDataSet", stockDataSource},
                                      {"StockDiferenciaDataSet", 
                                          new List<object> { new { Diferencia = stockDiferenciaDataSource}}}
                                  };

            var parameters = new Dictionary<string, string>
                                  {
                                      {"MaxiKioscoId", model.MaxiKioscoId.GetValueOrDefault().ToString()},
                                      {"CuentaId", UsuarioActual.CuentaId.ToString()},
                                      {"DesdeString", model.Desde == null ? "-" : model.Desde.GetValueOrDefault().ToShortDateString()},
                                      {"HastaString", model.Hasta == null ? "-" : model.Hasta.GetValueOrDefault().ToShortDateString()}
                                  };
            reporteFactory
                .SetPathCompleto(Server.MapPath("~/Reportes/Stock.rdl"))
                .SetDataSource(datasources)
                .SetParametro(parameters);

            byte[] archivo = reporteFactory.Renderizar(model.ReporteTipo);

            return File(archivo, reporteFactory.MimeType);
        }

        public ActionResult GenerarStockValorizadoDetallado(ReporteStockValorizadoFiltrosModel model)
        {
            var reporteFactory = new ReporteFactory();
            IQueryable<object> dataset;

            var rubro = Uow.Rubros.Obtener(r => r.RubroId == model.RubroId);
            var rubroDescripcion = rubro != null ? rubro.Descripcion : TodosText;

            if (model.MostrarTotalGeneral)
            {
                dataset = Uow.Reportes.StockValorizadoDetalladoGeneral(model.RubroId);
                reporteFactory
                    .SetParametro("RubroDescripcion", rubroDescripcion)
                    .SetPathCompleto(Server.MapPath("~/Reportes/StockValorizadoDetalladoGeneral.rdl"))
                    .SetDataSource("dataset", dataset);
            }
            else
            {
                var maxikiosco = Uow.MaxiKioscos.Obtener(m => m.MaxiKioscoId == model.MaxiKioscoId);
                var maxikioscoNombre = maxikiosco != null ? maxikiosco.Nombre : TodosText;

                dataset = Uow.Reportes.StockValorizadoDetallado(model.RubroId, model.MaxiKioscoId);
                reporteFactory
                    .SetParametro("RubroDescripcion", rubroDescripcion)
                    .SetParametro("MaxikioscoNombre", maxikioscoNombre)
                    .SetPathCompleto(Server.MapPath("~/Reportes/StockValorizadoDetallado.rdl"))
                    .SetDataSource("dataset", dataset);
            }

            byte[] archivo = reporteFactory.Renderizar(model.ReporteTipo);
            return File(archivo, reporteFactory.MimeType);
        }

        public ActionResult GenerarStockValorizado(ReporteStockValorizadoFiltrosModel model)
        {
            var reporteFactory = new ReporteFactory();
            IQueryable<object> dataset;

            var rubro = Uow.Rubros.Obtener(r => r.RubroId == model.RubroId);
            var rubroDescripcion = rubro != null ? rubro.Descripcion : TodosText;

            if (model.MostrarTotalGeneral)
            {
                dataset = Uow.Reportes.StockValorizadoGeneral(model.RubroId);
                reporteFactory
                    .SetParametro("RubroDescripcion", rubroDescripcion)
                    .SetPathCompleto(Server.MapPath("~/Reportes/StockValorizadoGeneral.rdl"))
                    .SetDataSource("dataset", dataset);
            }
            else
            {
                var maxikiosco = Uow.MaxiKioscos.Obtener(m => m.MaxiKioscoId == model.MaxiKioscoId);
                var maxikioscoNombre = maxikiosco != null ? maxikiosco.Nombre : TodosText;

                dataset = Uow.Reportes.StockValorizado(model.RubroId, model.MaxiKioscoId);
                reporteFactory
                    .SetParametro("RubroDescripcion", rubroDescripcion)
                    .SetParametro("MaxikioscoNombre", maxikioscoNombre)
                    .SetPathCompleto(Server.MapPath("~/Reportes/StockValorizado.rdl"))
                    .SetDataSource("dataset", dataset);
            }

            byte[] archivo = reporteFactory.Renderizar(model.ReporteTipo);
            return File(archivo, reporteFactory.MimeType);
        }

        public ActionResult GenerarComprasPorProveedor(ReporteComprasPorProveedorFiltrosModel model)
        {
            DateTime? hasta = model.Hasta == null
                                    ? (DateTime?)null
                                    : model.Hasta.GetValueOrDefault().AddDays(1);

            var proveedoresDataSource = Uow.Reportes.ComprasPorProveedor(model.Desde, hasta, model.ProveedorId, UsuarioActual.CuentaId);
            var top5DataSource = Uow.Reportes.ComprasPorProveedor(model.Desde, hasta, null, UsuarioActual.CuentaId)
                                            .OrderByDescending(p => p.DescuentoTotal).Take(5).ToList();

            var reporteFactory = new ReporteFactory();

            var datasources = new Dictionary<string, object>
                                  {
                                      {"ComprasPorProveedorDataSet", proveedoresDataSource},
                                      {"Top5", top5DataSource }
                                  };

            var parameters = new Dictionary<string, string>
                                  {
                                      {"ProveedorId", model.ProveedorId.GetValueOrDefault().ToString()},
                                      {"CuentaId", UsuarioActual.CuentaId.ToString()}
                                  };

            var proveedor = Uow.Proveedores.Obtener(m => m.ProveedorId == model.ProveedorId);
            var proveedorNombre = proveedor != null ? proveedor.Nombre : TodosText;

            reporteFactory
                .SetParametro("Desde", model.Desde.ToShortDateString(null))
                .SetParametro("Hasta", model.Hasta.ToShortDateString(null))
                .SetParametro("ProveedorNombre", proveedorNombre)
                .SetPathCompleto(Server.MapPath("~/Reportes/ComprasPorProveedor.rdl"))
                .SetDataSource(datasources)
                .SetParametro(parameters);

            byte[] archivo = reporteFactory.Renderizar(model.ReporteTipo);

            return File(archivo, reporteFactory.MimeType);
        }

        public ActionResult GenerarCierresDeCajaDetalle(ReporteCierresDeCajaFiltrosModel model)
        {
            DateTime? hasta = model.Hasta == null
                                    ? (DateTime?)null
                                    : model.Hasta.GetValueOrDefault().AddDays(1);
            var cierreDeCajaDetalleDataSource = Uow.Reportes.CierresDeCajaDetalle(model.Desde,
                                                                         hasta,
                                                                         model.MaxiKioscoId,
                                                                         model.UsuarioId,
                                                                         UsuarioActual.CuentaId);

            var maxikiosco = (model.MaxiKioscoId == null)
                                    ? TodosText
                                    : Uow.MaxiKioscos.Obtener(model.MaxiKioscoId.GetValueOrDefault()).Nombre;

            var usuario = (model.UsuarioId == null)
                                    ? TodosText
                                    : Uow.Usuarios.Obtener(model.UsuarioId.GetValueOrDefault()).NombreUsuario;

            var desdeString = model.Desde == null
                                    ? "-"
                                    : model.Desde.GetValueOrDefault().ToShortDateString();

            var hastaString = model.Hasta == null
                                    ? "-"
                                    : model.Hasta.GetValueOrDefault().ToShortDateString();

            var parameters = new Dictionary<string, string>
                                  {
                                      {"NombreUsuario", usuario},
                                      {"MaxikioscoNombre",  maxikiosco},
                                      {"DesdeString",  desdeString},
                                      {"HastaString", hastaString}
                                  };

            var reporteFactory = new ReporteFactory();

            reporteFactory
                .SetPathCompleto(Server.MapPath("~/Reportes/CierresDeCajaDetalle.rdl"))
                .SetDataSource("CierresDeCajaDetalleDataSet", cierreDeCajaDetalleDataSource)
                .SetParametro(parameters);

            byte[] archivo = reporteFactory.Renderizar(model.ReporteTipo);

            return File(archivo, reporteFactory.MimeType);
        }

        public ActionResult GenerarDineroPorMaxikiosco(ReporteModelBase filtros)
        {
            var dineroPorMaxikioscoDataSource = Uow.Reportes.DineroPorMaxikiosco();

            var reporteFactory = new ReporteFactory();

            reporteFactory
                .SetPathCompleto(Server.MapPath("~/Reportes/DineroEnCajasPorMaxikiosco.rdl"))
                .SetDataSource("DineroPorMaxikioscoDataSet", dineroPorMaxikioscoDataSource);

            byte[] archivo = reporteFactory.Renderizar(filtros.ReporteTipo);

            return File(archivo, reporteFactory.MimeType);
        }

        public ActionResult GenerarAuditoriaProductos(ReporteModelBase filtros)
        {
            var datasource = Uow.Reportes.AuditoriaProductos();

            var reporteFactory = new ReporteFactory();

            reporteFactory
                .SetPathCompleto(Server.MapPath("~/Reportes/AuditoriaProductos.rdl"))
                .SetDataSource("DataSet", datasource);

            byte[] archivo = reporteFactory.Renderizar(filtros.ReporteTipo);

            return File(archivo, reporteFactory.MimeType);
        }

        public ActionResult GenerarDineroSobranteFaltante(ReporteDineroSobranteFaltanteFiltrosModel reporteDineroSobranteFaltanteFiltros)
        {
            DateTime? hasta = reporteDineroSobranteFaltanteFiltros.Hasta == null
                                    ? (DateTime?)null
                                    : reporteDineroSobranteFaltanteFiltros.Hasta.GetValueOrDefault().AddDays(1);

            var dineroSobranteFaltanteDataSource = Uow.Reportes.DineroSobranteFaltante(reporteDineroSobranteFaltanteFiltros.Desde,
                                                                         hasta,
                                                                         reporteDineroSobranteFaltanteFiltros.MaxiKioscoId,
                                                                         UsuarioActual.CuentaId);

            var maxikiosco = Uow.MaxiKioscos.Obtener(m => m.MaxiKioscoId == reporteDineroSobranteFaltanteFiltros.MaxiKioscoId);
            var maxikioscoNombre = maxikiosco != null ? maxikiosco.Nombre : TodosText;

            var reporteFactory = new ReporteFactory();

            reporteFactory
                .SetParametro("Desde", reporteDineroSobranteFaltanteFiltros.Desde.ToShortDateString(null))
                .SetParametro("Hasta", reporteDineroSobranteFaltanteFiltros.Hasta.ToShortDateString(null))
                .SetParametro("MaxikioscoNombre", maxikioscoNombre)
                .SetPathCompleto(Server.MapPath("~/Reportes/DineroSobranteFaltante.rdl"))
                .SetDataSource("DiferenciaFaltanteSobranteDataSet", dineroSobranteFaltanteDataSource);

            byte[] archivo = reporteFactory.Renderizar(reporteDineroSobranteFaltanteFiltros.ReporteTipo);

            return File(archivo, reporteFactory.MimeType);
        }

        public ActionResult GenerarGanaciaAdicionalExcepcionRubro(GanaciaAdicionalExcepcionRubroFiltrosModel ganaciaAdicionalExcepcionRubroFiltrosModel)
        {
            DateTime? hasta = ganaciaAdicionalExcepcionRubroFiltrosModel.Hasta == null
                                    ? (DateTime?)null
                                    : ganaciaAdicionalExcepcionRubroFiltrosModel.Hasta.GetValueOrDefault().AddDays(1);

            var ganaciaAdicionalExcepcionRubroDataSource = Uow.Reportes.GanaciaAdicionalExcepcionRubro(ganaciaAdicionalExcepcionRubroFiltrosModel.Desde,
                                                                            hasta,
                                                                            ganaciaAdicionalExcepcionRubroFiltrosModel.MaxiKioscoId,
                                                                            ganaciaAdicionalExcepcionRubroFiltrosModel.RubroId,
                                                                            UsuarioActual.CuentaId).ToList();

            var rubro = Uow.Rubros.Obtener(r => r.RubroId == ganaciaAdicionalExcepcionRubroFiltrosModel.RubroId);
            var rubroDescripcion = rubro != null ? rubro.Descripcion : TodosText;

            var maxikiosco = Uow.MaxiKioscos.Obtener(m => m.MaxiKioscoId == ganaciaAdicionalExcepcionRubroFiltrosModel.MaxiKioscoId);
            var maxikioscoNombre = maxikiosco != null ? maxikiosco.Nombre : TodosText;

            var reporteFactory = new ReporteFactory();

            reporteFactory
                .SetParametro("Desde", ganaciaAdicionalExcepcionRubroFiltrosModel.Desde.ToShortDateString(null))
                .SetParametro("Hasta", ganaciaAdicionalExcepcionRubroFiltrosModel.Hasta.ToShortDateString(null))
                .SetParametro("RubroDescripcion", rubroDescripcion)
                .SetParametro("MaxikioscoNombre", maxikioscoNombre)
                .SetPathCompleto(Server.MapPath("~/Reportes/GanaciaAdicionalExcepcionRubro.rdl"))
                .SetDataSource("GanaciaAdicionalExcepcionRubroDataSet", ganaciaAdicionalExcepcionRubroDataSource);

            byte[] archivo = reporteFactory.Renderizar(ganaciaAdicionalExcepcionRubroFiltrosModel.ReporteTipo);

            return File(archivo, reporteFactory.MimeType);
        }

        public ActionResult GenerarProductosParaReponer(ReporteReposicionFiltrosModel model)
        {
            var reposicionDataSource = Uow.Reportes.StockParaReponer(model.ProductoId, model.ProveedorId, model.MaxiKioscoId);

            var producto = TodosText;
            if (model.ProductoId != null)
                producto = Uow.Productos.Obtener(model.ProductoId.GetValueOrDefault()).Descripcion;

            var proveedor = TodosText;
            if (model.ProveedorId != null)
                proveedor = Uow.Proveedores.Obtener(model.ProveedorId.GetValueOrDefault()).Nombre;

            var maxikiosco = string.Empty;
            if (model.MaxiKioscoId != null)
                maxikiosco = Uow.MaxiKioscos.Obtener(model.MaxiKioscoId.GetValueOrDefault()).Nombre;

            var parameters = new Dictionary<string, string>
                                  {
                                      {"Producto", producto},
                                      {"Proveedor", proveedor},
                                      {"Maxikiosco",  maxikiosco},
                                      {"MaxiKioscoId",  model.MaxiKioscoId.GetValueOrDefault().ToString()},
                                      {"Fecha", DateTime.Now.ToShortDateString()}
                                  };
            var reporteFactory = new ReporteFactory();

            reporteFactory
                .SetPathCompleto(Server.MapPath("~/Reportes/ReponerStock.rdl"))
                .SetDataSource("dsReponerStock", reposicionDataSource)
                .SetParametro(parameters);

            byte[] archivo = reporteFactory.Renderizar(model.ReporteTipo);

            return File(archivo, reporteFactory.MimeType);
        }
    }
}

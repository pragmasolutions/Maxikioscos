using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MaxiKioscos.Datos.Interfaces;
using MaxiKioscos.Entidades;
using MaxiKioscos.Negocio;
using MaxiKioscos.Reportes;
using MaxiKioscos.Reportes.Enumeraciones;
using MaxiKioscos.Seguridad;
using MaxiKioscos.Web.Comun.Helpers;
using MaxiKioscos.Web.Configuration;
using MaxiKioscos.Web.Filters;
using MaxiKioscos.Web.Models;
using PagedList;

namespace MaxiKioscos.Web.Controllers
{
    [ActivityAuthorize(Actions = MaxikioscoPermisos.TRANSFERENCIAS)]
    public class TransferenciasController : BaseController
    {
        private ITransferenciasNegocio TransferenciasNegocio { get; set; }

        public TransferenciasController(IMaxiKioscosUow uow,ITransferenciasNegocio transferenciasNegocio)
        {
            Uow = uow;
            TransferenciasNegocio = transferenciasNegocio;
        }

        public ActionResult Index(TransferenciasListadoModel model, int? page)
        {
            model.Filtros = model.Filtros ?? new TransferenciasFiltrosModel()
            {
                Desde = model.Desde,
                Nro = model.Nro,
                Hasta = model.Hasta,
                Aprobadas = model.Aprobadas,
                DestinoId = model.DestinoId,
                OrigenId = model.OrigenId
            };

            var transferencias = Uow.Transferencias.Listado(c => c.TransferenciaProductos,
                                                            c => c.Origen,
                                                            c => c.Destino,
                                                            c => c.Usuario)
                .Where(model.Filtros.GetFilterExpression())
                .OrderByDescending(c => c.TransferenciaId).ToList();


            var pageNumber = page ?? 1;
            var pageSize = AppSettings.DefaultPageSize;
            IPagedList<Transferencia> lista = transferencias.ToPagedList(pageNumber, pageSize);

            var listadoModel = new TransferenciasListadoModel
            {
                List = lista,
                Filtros = model.Filtros
            };
            return PartialOrView(listadoModel);
        }

        public ActionResult Listado(TransferenciasFiltrosModel filtros, int? page)
        {
            var transferencias = Uow.Transferencias.Listado(c => c.TransferenciaProductos,
                                                            c => c.Origen,
                                                            c => c.Destino,
                                                            c => c.Usuario)
                .Where(filtros.GetFilterExpression())
                .OrderByDescending(c => c.TransferenciaId);

            var lista = transferencias.ToPagedList(page ?? 1, AppSettings.DefaultPageSize);
            var listadoModel = new TransferenciasListadoModel
            {
                List = lista,
                Filtros = filtros,
                Desde = filtros.Desde,
                Nro = filtros.Nro,
                Hasta = filtros.Hasta,
                OrigenId = filtros.OrigenId,
                DestinoId = filtros.DestinoId
            };


            return PartialView("_Listado", listadoModel);
        }


        public ActionResult Detalle(int id)
        {
            var transferencia = ObtenerTransferencia(id);

            if (transferencia == null)
            {
                return HttpNotFound();
            }
            transferencia.TransferenciaProductos = transferencia.TransferenciaProductos.OrderBy(t => t.Orden).ToList();

            return PartialView(transferencia);
        }

        public ActionResult Crear()
        {
            var ultima = Uow.Transferencias.Listado().Where(x => x.AutoNumero.StartsWith("WEB_")).OrderByDescending(x => x.TransferenciaId).FirstOrDefault();
            var numero = ultima == null
                ? 1
                : Convert.ToInt32(ultima.AutoNumero.Replace("WEB_", "")) + 1;
            var transferencia = new Transferencia()
                                {
                                    FechaCreacion = DateTime.UtcNow,
                                    AutoNumero = String.Format("WEB_{0}", numero),
                                    UsuarioId = UsuarioActual.Usuario.UsuarioId
                                };

            if (UsuarioActual.Cuenta.MaxiKioscoIdentifierPredeterminadoTransferencias != null)
            {
                var maxi = Uow.MaxiKioscos.Obtener(m => m.Identifier == UsuarioActual.Cuenta.MaxiKioscoIdentifierPredeterminadoTransferencias);
                transferencia.OrigenId = maxi.MaxiKioscoId;
            }
            ViewBag.CantidadIngresada = null;
            return PartialView(transferencia);
        }

        public ActionResult CargarProducto(int productoId, int origenId, int destinoId)
        {
            var productoCompleto = Uow.Productos.ObtenerParaTransferencia(productoId, origenId, destinoId);

            var transferenciaProducto = new TransferenciaProducto
                                     {
                                         ProductoId = productoId,
                                         Cantidad = 1,
                                         Producto = new Producto {Descripcion = productoCompleto.Descripcion},
                                         PrecioVenta = productoCompleto.PrecioConIVA,
                                         Identifier = Guid.NewGuid(),
                                         PrimerCodigoProducto = productoCompleto.Codigo,
                                         ProductoMarca = productoCompleto.Marca,
                                         StockOrigen = productoCompleto.StockOrigen,
                                         StockDestino = productoCompleto.StockDestino,
                                         Costo = productoCompleto.CostoConIVA
                                     };

            return PartialView(transferenciaProducto);
        }

        [HttpPost]
        public ActionResult Crear(Transferencia transferencia)
        {
            if (!ModelState.IsValid)
            {
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError);
            }

            int ultima = Uow.Transferencias.Listado().Where(x => x.AutoNumero.StartsWith("WEB_")).Max(t => t.TransferenciaId);
            transferencia.AutoNumero = String.Format("WEB_{0}", ultima + 1);
            TransferenciasNegocio.Crear(transferencia);

            return Json(new { exito = true, transferencia.TransferenciaId });
        }

        public ActionResult Editar(int id)
        {
            var transferencia = ObtenerTransferencia(id);

            if (transferencia == null)
            {
                return HttpNotFound();
            }
            transferencia.TransferenciaProductos = transferencia.TransferenciaProductos.OrderBy(t => t.Orden).ToList();
            return PartialView(transferencia);
        }

        [HttpPost]
        public ActionResult Editar(Transferencia transferencia, FormCollection collection)
        {
            if (!ModelState.IsValid)
            {
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError);
            }

            var aprobar = Convert.ToBoolean(collection["aprobar"]);

            TransferenciasNegocio.Editar(transferencia, aprobar);

            return Json(new { exito = true, transferencia.TransferenciaId });
        }

        [HttpPost]
        public ActionResult Aprobar(int id)
        {
            TransferenciasNegocio.Aprobar(id);

            return Json(new { exito = true });
        }

        public ActionResult Eliminar(int id)
        {
            var transferencia = ObtenerTransferencia(id);

            if (transferencia == null)
            {
                return HttpNotFound();
            }
            transferencia.TransferenciaProductos = transferencia.TransferenciaProductos.OrderBy(t => t.Orden).ToList();
            return PartialView(transferencia);
        }

        [HttpPost]
        public ActionResult Eliminar(int id, FormCollection collection)
        {
            Entidades.Transferencia transferencia = Uow.Transferencias.Obtener(t => t.TransferenciaId == id);

            if (transferencia == null)
            {
                return HttpNotFound();
            }

            Uow.Transferencias.Eliminar(transferencia);
            Uow.Commit();

            return new JsonResult() { Data = new { exito = true }, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        public ActionResult Imprimir(int id)
        {
            var transferencia = Uow.Transferencias.Obtener(t => t.TransferenciaId == id,
                                    t => t.Usuario,
                                    t => t.Origen,
                                    t => t.Destino);

            var stockDataSource = Uow.Reportes.TransferenciaDetalle(id);

            var reporteFactory = new ReporteFactory();

            var datasources = new Dictionary<string, object> { {"Dataset", stockDataSource}};
            var parameters = new Dictionary<string, string>
                                  {
                                      {"AutoNumero", transferencia.AutoNumero },
                                      {"Destino", transferencia.Destino.Nombre},
                                      {"Origen", transferencia.Origen.Nombre},
                                      {"Usuario", transferencia.Usuario.NombreUsuario},
                                      {"Creado", transferencia.FechaCreacion.ToShortDateString()},
                                      {"Aprobacion", transferencia.FechaAprobacion == null 
                                            ? "-" 
                                            : transferencia.FechaAprobacion.GetValueOrDefault().ToShortDateString()}
                                  };
            reporteFactory
                .SetPathCompleto(Server.MapPath("~/Reportes/TransferenciaComprobante.rdl"))
                .SetDataSource(datasources)
                .SetParametro(parameters);

            byte[] archivo = reporteFactory.Renderizar(ReporteTipoEnum.Pdf);

            return File(archivo, reporteFactory.MimeType);
        }

        #region Helpers

        private Transferencia ObtenerTransferencia(int transferenciaId)
        {
            Transferencia transferencia = Uow.Transferencias.Obtener(c => c.TransferenciaId == transferenciaId,
                c => c.TransferenciaProductos.Select(cp => cp.Producto.Marca),
                c => c.TransferenciaProductos.Select(tp => tp.Producto),
                c => c.TransferenciaProductos.Select(tp => tp.Producto.CodigosProductos),
                c => c.Origen,
                c => c.Destino,
                c => c.Usuario);

            //Filtramos las transferencia productos eliminadas
            foreach (var prod in transferencia.TransferenciaProductos)
            {
                prod.PrimerCodigoProducto = prod.Producto.CodigosProductos.First().Codigo;
            }
            transferencia.TransferenciaProductos = transferencia.TransferenciaProductos.Where(cp => !cp.Eliminado).ToList();

            return transferencia;
        }

        #endregion
    }
}

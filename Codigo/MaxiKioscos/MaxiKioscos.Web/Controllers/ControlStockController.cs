using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Text.RegularExpressions;
using System.Web.Mvc;
using System.Web.UI;
using MaxiKioscos.Datos.Interfaces;
using MaxiKioscos.Entidades;
using MaxiKioscos.Negocio;
using MaxiKioscos.Seguridad;
using MaxiKioscos.Web.Comun.Atributos;
using MaxiKioscos.Web.Comun.Helpers;
using MaxiKioscos.Web.Configuration;
using MaxiKioscos.Web.Filters;
using MaxiKioscos.Web.Models;
using PagedList;

namespace MaxiKioscos.Web.Controllers
{
    [ActivityAuthorize(Actions = MaxikioscoPermisos.CONTROLDESTOCK)]
    public class ControlStockController : BaseController
    {
        private IControlStockNegocio ControlStockNegocio { get; set; }

        public ControlStockController(IMaxiKioscosUow uow, IControlStockNegocio controlStockNegocio)
        {
            Uow = uow;
            ControlStockNegocio = controlStockNegocio;
        }

        public ActionResult Index(ControlStockListadoModel model, int? page)
        {
            model.Filtros = model.Filtros ?? new ControlStockFiltrosModel()
                                                        {
                                                            Desde = model.Desde,
                                                            Hasta = model.Hasta,
                                                            MaxiKioscoId = model.MaxiKioscoId,
                                                            NroControl = model.NroControl,
                                                            ProveedorId = model.ProveedorId,
                                                            Page = page,
                                                            RubroId = model.RubroId,
                                                            Estado = model.Estado
                                                        };

            IQueryable<ControlStock> controles = Listado(model.Filtros);

            var pageNumber = page ?? 1;
            var pageSize = AppSettings.DefaultPageSize;

            IPagedList<ControlStock> lista = controles.OrderByDescending(cs => cs.FechaCreacion).ToPagedList(pageNumber, pageSize);

            var listadoModel = new ControlStockListadoModel
                                   {
                                       List = lista,
                                       Filtros = model.Filtros
                                   };

            return PartialOrView(listadoModel);
        }

        public ActionResult Listado(ControlStockFiltrosModel filtros, int? page)
        {
            var controles = Listado(filtros);

            var lista = controles.ToPagedList(page ?? 1, AppSettings.DefaultPageSize);
            var listadoModel = new ControlStockListadoModel
            {
                List = lista,
                Filtros = filtros,
                Desde = filtros.Desde,
                Hasta = filtros.Hasta,
                MaxiKioscoId = filtros.MaxiKioscoId,
                NroControl = filtros.NroControl,
                ProveedorId = filtros.ProveedorId,
                RubroId = filtros.RubroId,
                Estado = filtros.Estado
            };

            return PartialView("_Listado", listadoModel);
        }

        private IQueryable<ControlStock> Listado(ControlStockFiltrosModel filtros)
        {
            if (string.IsNullOrEmpty(filtros.NroControl))
            {
                return Uow.ControlesStock
                    .Listado(p => p.Rubro, p => p.Proveedor, p => p.MaxiKiosco, p => p.Usuario)
                    .Where(filtros.GetFilterExpression())
                    .Where(cs => !cs.Eliminado)
                    .OrderBy(p => p.FechaCreacion);
            }

            var digits = new[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            var abrev = filtros.NroControl.Split(digits)[0];

            var prefriltrados = Uow.ControlesStock
                .Listado(cs => cs.Rubro, cs => cs.Proveedor, cs => cs.MaxiKiosco, cs => cs.Usuario)
                .Where(cs => cs.MaxiKiosco.Abreviacion.Equals(abrev, StringComparison.InvariantCultureIgnoreCase))
                .Where(cs => !cs.Eliminado);

            return prefriltrados.Where(
                    cs => cs.NroControlFormateado.Equals(filtros.NroControl, StringComparison.InvariantCultureIgnoreCase));
        }

        public ActionResult Detalle(int id, ControlStockDetalleListadoModel model, int? page)
        {
            model.Filtros = model.Filtros ?? new ControlStockDetalleFiltrosModel()
            {
                Descripcion = model.Descripcion,
                ControlStockId = id,
                Page = page
            };
            model.ControlStockId = id;
            IEnumerable<ControlStockDetalle> detalles = ListadoDetalle(model);


            var lista = detalles.OrderBy(s => s.Stock.Producto.Descripcion).ToList();

            model.List = lista;
            model.Filtros = model.Filtros;
            model.ControlStock = Uow.ControlesStock.Obtener(c => c.ControlStockId == model.ControlStockId,
                                                            c => c.MaxiKiosco, c => c.Rubro, c => c.Proveedor,
                                                            c => c.Usuario);


            return PartialOrView(model);
        }

        private IEnumerable<ControlStockDetalle> ListadoDetalle(ControlStockDetalleListadoModel model)
        {
            var control = Uow.ControlesStock.Obtener(cs => cs.ControlStockId == model.ControlStockId, cs => cs.ControlStockDetalles,
                                              cs => cs.ControlStockDetalles.Select(d => d.Stock),
                                              cs => cs.ControlStockDetalles.Select(d => d.Stock.Producto),
                                              cs => cs.MaxiKiosco, cs => cs.ControlStockDetalles.Select(c => c.MotivoCorreccion),
                                              cs => cs.ControlStockDetalles.Select(c => c.ControlStockPrevio),
                                              cs => cs.ControlStockDetalles.Select(c => c.ControlStockPrevio.MaxiKiosco));
            return control.ControlStockDetalles.OrderBy(csd => csd.Stock.Producto.Descripcion).ToList();
        }

        [HttpPost]
        public ActionResult Cerrar(int controlStockId, List<ControlStockDetalle> list)
        {
            var result = ControlStockNegocio.Cerrar(controlStockId, list);
            return Json(new { success = result }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Eliminar(int id)
        {
            var control = Uow.ControlesStock.Obtener(cs => cs.ControlStockId == id, cs => cs.MaxiKiosco);

            if (control == null)
            {
                return HttpNotFound();
            }
            
            return PartialView(control);
        }

        [HttpPost]
        public ActionResult Eliminar(int id, FormCollection formCollection)
        {
            var result = ControlStockNegocio.Eliminar(id);
            return Json(new { success = result }, JsonRequestBehavior.AllowGet);
        }
    }
}

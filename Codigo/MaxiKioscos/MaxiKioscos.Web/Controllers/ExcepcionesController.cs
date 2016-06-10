using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using MaxiKioscos.Datos.Interfaces;
using MaxiKioscos.Entidades;
using MaxiKioscos.Seguridad;
using MaxiKioscos.Web.Comun.Helpers;
using MaxiKioscos.Web.Configuration;
using MaxiKioscos.Web.Filters;
using MaxiKioscos.Web.Models;
using PagedList;
using WebMatrix.WebData;

namespace MaxiKioscos.Web.Controllers
{
    [ActivityAuthorize(Actions = MaxikioscoPermisos.EXCEPCIONES)]
    public class ExcepcionesController : BaseController
    {
        public ExcepcionesController(IMaxiKioscosUow uow)
        {
            Uow = uow;
        }

        public ActionResult Index(ExcepcionesListadoModel model, int? page)
        {
            model.Filtros = model.Filtros ?? new ExcepcionesFiltrosModel()
            {
                Desde = model.Desde,
                Hasta = model.Hasta,
                MaxiKioscoId = model.MaxiKioscoId,
                Page = page
            };
            var pageNumber = page ?? 1;

            var pageSize =  AppSettings.DefaultPageSize;

            
            var excepciones = Listado(model.Filtros);
            IPagedList<Excepcion> list = excepciones.ToPagedList(pageNumber, pageSize);

            model.List = list;

            return PartialOrView(model);
        }

        public ActionResult Listado(ExcepcionesFiltrosModel filtros, int? page)
        {
            var excepciones = Listado(filtros);
            var pageSize = 30;
            var lista = excepciones.ToPagedList(page ?? 1, pageSize);

            var listadoModel = new ExcepcionesListadoModel
            {
                List = lista,
                Filtros = filtros,
                Desde = filtros.Desde,
                Hasta = filtros.Hasta,
                MaxiKioscoId = filtros.MaxiKioscoId
            };

            return PartialView("_Listado", listadoModel);
        }

        private IQueryable<Excepcion> Listado(ExcepcionesFiltrosModel filtros)
        {
            var cuentaId = UsuarioActual.CuentaId;
            return Uow.Excepciones.Listado(c => c.CierreCaja, c => c.CierreCaja.MaxiKiosco, c => c.CierreCaja.Usuario)
                .Where(m => m.CierreCaja.MaxiKiosco.CuentaId == cuentaId)
                .Where(filtros.GetFilterExpression())
                .OrderBy(m => m.CierreCaja.FechaInicio); 
        }

        public ActionResult Detalle(int id)
        {
            Excepcion excepcion = Uow.Excepciones.Obtener(e => e.ExcepcionId == id, e => e.CierreCaja,
                                                    e => e.CierreCaja.Usuario, e => e.CierreCaja.MaxiKiosco);
            var model = new ExcepcionModel()
            {
                Excepcion = excepcion,
                Fecha = excepcion.CierreCaja.FechaInicio,
                MaxikioscoId = excepcion.CierreCaja.MaxiKioskoId
            };
            return PartialView(model);
        }

        public ActionResult Crear()
        {
            ViewBag.CierresCaja = new List<CierreCaja>();
            var model = new ExcepcionModel()
                            {
                                Fecha = DateTime.UtcNow,
                                Excepcion = new Excepcion()
                            };
            return PartialView(model);
        }

        [HttpPost]
        public ActionResult Crear(ExcepcionModel model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.CierresCaja = ListadoCierres(model.MaxikioscoId, model.Fecha);
                return PartialView(model);
            }
            model.Excepcion.Identifier = Guid.NewGuid();
            model.Excepcion.FechaCarga = DateTime.UtcNow;
            Uow.Excepciones.Agregar(model.Excepcion);
            Uow.Commit();
            
            return new JsonResult(){ Data = new { exito = true }, JsonRequestBehavior = JsonRequestBehavior.AllowGet};
        }

        public ActionResult Editar(int id)
        {
            Excepcion excepcion = Uow.Excepciones.Obtener(e => e.ExcepcionId == id, e => e.CierreCaja);
            var model = new ExcepcionModel()
                            {
                                Excepcion = excepcion,
                                Fecha = excepcion.CierreCaja.FechaInicio,
                                MaxikioscoId = excepcion.CierreCaja.MaxiKioskoId
                            };
            ViewBag.CierresCaja = ListadoCierres(model.MaxikioscoId, model.Fecha);
            return PartialView(model);
        }

        [HttpPost]
        public ActionResult Editar(ExcepcionModel model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.CierresCaja = ListadoCierres(model.MaxikioscoId, model.Fecha);
                return PartialView(model);
            }

            Uow.Excepciones.Modificar(model.Excepcion);
            Uow.Commit();
            return new JsonResult() { Data = new { exito = true }, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        public ActionResult Eliminar(int id)
        {
            Excepcion excepcion = Uow.Excepciones.Obtener(e => e.ExcepcionId == id, e => e.CierreCaja,
                                                    e => e.CierreCaja.Usuario, e => e.CierreCaja.MaxiKiosco);
            var model = new ExcepcionModel()
            {
                Excepcion = excepcion,
                Fecha = excepcion.CierreCaja.FechaInicio,
                MaxikioscoId = excepcion.CierreCaja.MaxiKioskoId
            };
            return PartialView(model);
        }

        [HttpPost]
        public ActionResult Eliminar(ExcepcionModel model)
        {
            Uow.Excepciones.Eliminar(model.Excepcion.ExcepcionId);
            Uow.Commit();
            return new JsonResult() { Data = new { exito = true }, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        [HttpGet]
        public ActionResult ObtenerCierresCaja(int maxikioscoId, DateTime fecha)
        {
            var cierres = ListadoCierres(maxikioscoId, fecha);
            var resultados = cierres.Select(cc => new
                                                      {
                                                          cc.CierreCajaId,
                                                          Nombre = cc.CierreCajaDetalle
                                                      }).ToList();
            return Json(resultados, JsonRequestBehavior.AllowGet);
        }

        private List<CierreCaja> ListadoCierres(int maxikioscoId, DateTime fecha)
        {
            var tope = fecha.AddDays(1);
            return Uow.CierresDeCaja.Listado(cc => cc.Usuario).Where(cc => cc.MaxiKioskoId == maxikioscoId
                                                                                  && ((fecha <= cc.FechaInicio &&tope >= cc.FechaInicio) 
                                                                                  || (fecha <= cc.FechaFin &&tope >= cc.FechaFin))).ToList();
            
        }
    }
}

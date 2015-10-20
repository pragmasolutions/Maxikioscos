using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.WebPages;
using MaxiKioscos.Datos.Interfaces;
using MaxiKioscos.Entidades;
using MaxiKioscos.Negocio;
using MaxiKioscos.Web.Comun.Helpers;
using MaxiKioscos.Web.Configuration;
using MaxiKioscos.Web.Models;
using PagedList;

namespace MaxiKioscos.Web.Controllers
{
    public class CostosController : BaseController
    {
        public CostosController(IMaxiKioscosUow uow)
        {
            Uow = uow;
        }

        public ActionResult Index(CostosListadoModel model,int? page)
        {
            model.Filtros = model.Filtros ?? new CostosFiltrosModel()
            {
                Desde = model.Desde,
                NroComprobante = model.NroComprobante,
                Hasta = model.Hasta,
                MaxiKioscoId = model.MaxiKioscoId,
                UsuarioId = model.UsuarioId,
                Estado = model.Estado,
                CategoriaCostoId = model.CategoriaCostoId
            };

            IQueryable<Costo> costos = Uow.Costos.Listado(c => c.CategoriaCosto, c => c.CierreCaja,
                                            c => c.CierreCaja.Usuario, c => c.CierreCaja.MaxiKiosco, c => c.Turno)
                .Where(model.Filtros.GetFilterExpression())
                .OrderBy(c => c.Aprobado).ThenByDescending(f => f.Fecha);

            var pageNumber = page ?? 1;
            var pageSize = AppSettings.DefaultPageSize;
            IPagedList<Costo> lista = costos.ToPagedList(pageNumber, pageSize);

            var listadoModel = new CostosListadoModel
            {
                List = lista,
                Filtros = model.Filtros
            };
            return PartialOrView(listadoModel);
        }

        public ActionResult Listado(CostosFiltrosModel filtros, int? page)
        {
            var costos = Uow.Costos.Listado(c => c.CategoriaCosto, c => c.CierreCaja,
                                            c => c.CierreCaja.Usuario, c => c.CierreCaja.MaxiKiosco)
                .Where(filtros.GetFilterExpression())
                .OrderBy(c => c.Aprobado).ThenByDescending(f => f.Fecha);

            var lista = costos.ToPagedList(page ?? 1, AppSettings.DefaultPageSize);
            var listadoModel = new CostosListadoModel
            {
                List = lista,
                Filtros = filtros,
                Desde = filtros.Desde,
                NroComprobante = filtros.NroComprobante,
                Hasta = filtros.Hasta,
                MaxiKioscoId = filtros.MaxiKioscoId,
                UsuarioId = filtros.UsuarioId,
                Estado = filtros.Estado,
                CategoriaCostoId = filtros.CategoriaCostoId
            };


            return PartialView("_Listado", listadoModel);
        }

        public ActionResult Detalle(int id)
        {
            Costo costo = Uow.Costos.Obtener(c => c.CostoId == id, c => c.CategoriaCosto, c => c.CierreCaja,
                                            c => c.CierreCaja.Usuario, c => c.CierreCaja.MaxiKiosco, c => c.Turno);
            costo.EsGastoGeneral = costo.CierreCaja == null && costo.UsuarioId == null;
            return PartialView(costo);
        }
        
        public ActionResult Eliminar(int id)
        {
            Costo costo = Uow.Costos.Obtener(c => c.CostoId == id, c => c.CategoriaCosto, c => c.CierreCaja,
                                            c => c.CierreCaja.Usuario, c => c.CierreCaja.MaxiKiosco, c => c.Turno);
            costo.EsGastoGeneral = costo.CierreCaja == null && costo.UsuarioId == null;
            return PartialView(costo);
        }

        [HttpPost]
        public ActionResult Eliminar(int id, FormCollection collection)
        {
            Costo costo = Uow.Costos.Obtener(f => f.CostoId == id);
            if (costo == null)
            {
                return HttpNotFound();
            }

            if (costo.Aprobado)
            {
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError);
            }

            Uow.Costos.Eliminar(costo);
            Uow.Commit();
            return new JsonResult() { Data = new { exito = true }, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        [HttpPost]
        public ActionResult Aprobar(int id)
        {
            Costo costo = Uow.Costos.Obtener(id);
            if (costo == null)
            {
                return HttpNotFound();
            }
            costo.Aprobado = true;
            costo.Desincronizado = true;
            Uow.Costos.Modificar(costo);
            Uow.Commit();
            return new JsonResult() { Data = new { exito = true }, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        public ActionResult Crear()
        {
            return PartialView(new Costo()
            {
                Fecha = DateTime.Now,
                EsGastoGeneral = true,
                Aprobado = true
            });
        }

        [HttpPost]
        public ActionResult Crear(Costo costo)
        {
            if (!costo.EsGastoGeneral)
            {
                if (costo.UsuarioId == null)
                {
                    ModelState.AddModelError("UsuarioId", "Debe seleccionar un usuario");
                }
                if (costo.TurnoId == null)
                {
                    ModelState.AddModelError("TurnoId", "Debe seleccionar un turno");
                }
            }
            if (!ModelState.IsValid)
            {
                return PartialView(costo);
            }

            costo.Identifier = Guid.NewGuid();
            costo.Desincronizado = true;
            costo.Eliminado = false;
            Uow.Costos.Agregar(costo);
            Uow.Commit();

            return new JsonResult() { Data = new { exito = true }, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        public ActionResult Editar(int id)
        {
            var costo = Uow.Costos.Obtener(c => c.CostoId == id, c => c.CierreCaja, 
                                                    c => c.CierreCaja.MaxiKiosco,
                                                    c => c.CierreCaja.Usuario,
                                                    c => c.Usuario,
                                                    c => c.Turno);
            costo.EsGastoGeneral = costo.CierreCaja == null && costo.UsuarioId == null;
            return PartialView(costo);
        }

        [HttpPost]
        public ActionResult Editar(Costo costo)
        {
            if (!costo.EsGastoGeneral && costo.CierreCajaId == null)
            {
                if (costo.UsuarioId == null)
                {
                    ModelState.AddModelError("UsuarioId", "Debe seleccionar un usuario");
                }
                if (costo.TurnoId == null)
                {
                    ModelState.AddModelError("TurnoId", "Debe seleccionar un turno");
                }
                
            }
            if (!ModelState.IsValid)
            {
                return PartialView(costo);
            }

            costo.Desincronizado = true;
            costo.Eliminado = false;
            Uow.Costos.Modificar(costo);
            Uow.Commit();

            return new JsonResult() { Data = new { exito = true }, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
    }
}

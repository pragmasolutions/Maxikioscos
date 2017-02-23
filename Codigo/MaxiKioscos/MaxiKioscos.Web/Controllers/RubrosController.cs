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
    [ActivityAuthorize(Actions = MaxikioscoPermisos.RUBROS)]
    public class RubrosController : BaseController
    {
        public RubrosController(IMaxiKioscosUow uow)
        {
            Uow = uow;
        }

        public ActionResult Index(RubrosListadoModel model, int? page)
        {
            model.Filtros = model.Filtros ?? new RubrosFiltrosModel()
            {
                Descripcion = model.Descripcion,
                Page = page
            };
            var pageNumber = page ?? 1;
            var pageSize = AppSettings.DefaultPageSize;

            var rubros = Uow.Rubros.Listado(r => r.ExcepcionRubros).Where(r => r.CuentaId == UsuarioActual.CuentaId)
                .Where(model.Filtros.GetFilterExpression())
                                .OrderBy(m => m.Descripcion).ToList();
            IPagedList<Rubro> list = rubros.ToPagedList(pageNumber, pageSize);

            model.List = list;

            return PartialOrView(model);
        }

        public ActionResult Detalle(int id)
        {
            Rubro rubro = Uow.Rubros.Obtener(u => u.RubroId == id);
            return PartialView(rubro);
        }

        public ActionResult Crear()
        {
            return PartialView(new Rubro());
        }

        [HttpPost]
        public ActionResult Crear(Rubro rubro)
        {
            if (!ModelState.IsValid || !EsDescripcionValida(rubro.Descripcion, rubro.RubroId))
            {
                return PartialView(rubro);
            }
            rubro.Identifier = Guid.NewGuid();
            rubro.CuentaId = UsuarioActual.CuentaId;
            Uow.Rubros.Agregar(rubro);
            Uow.Commit();
            
            return new JsonResult(){ Data = new { exito = true, rubro = rubro}, JsonRequestBehavior = JsonRequestBehavior.AllowGet};
        }

        public ActionResult Editar(int id)
        {
            Rubro rubro = Uow.Rubros.Obtener(id);
            return PartialView(rubro);
        }

        [HttpPost]
        public ActionResult Editar(Rubro rubro)
        {
            if (!ModelState.IsValid)
            {
                return PartialView(rubro);
            }

            Uow.Rubros.Modificar(rubro);
            Uow.Commit();
            return new JsonResult() { Data = new { exito = true }, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        public ActionResult Eliminar(int id)
        {
            Rubro rubro = Uow.Rubros.Obtener(id);
            return PartialView(rubro);
        }

        [HttpPost]
        public ActionResult Eliminar(Rubro rubro)
        {
            var productos = Uow.Productos.Listado().Where(p => p.RubroId == rubro.RubroId).ToList();
            if (productos.Count > 0)
            {
                ModelState.AddModelError("ProductosAsociados", "No puede elimiarse el rubro porque tiene productos asociados");
                return PartialView(rubro);
            }
            Uow.Rubros.Eliminar(rubro);
            Uow.Commit();
            return new JsonResult() { Data = new { exito = true }, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        [OutputCache(Location = OutputCacheLocation.None, NoStore = true)]
        public JsonResult EsDescripcionRubroUnica(string descripcion, int? rubroId)
        {
            if (rubroId == null)
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            return EsDescripcionValida(descripcion, rubroId.GetValueOrDefault())
                ? Json(true, JsonRequestBehavior.AllowGet)
                : Json(false, JsonRequestBehavior.AllowGet);
        }

        private bool EsDescripcionValida(string descripcion, int rubroId)
        {
            return !Uow.Rubros.Listado().Any(r => r.Descripcion == descripcion && r.RubroId != rubroId);
        }
    }
}

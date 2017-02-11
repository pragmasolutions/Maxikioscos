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
    [ActivityAuthorize(Actions = MaxikioscoPermisos.MARCAS)]
    public class MarcasController : BaseController
    {
        public MarcasController(IMaxiKioscosUow uow)
        {
            Uow = uow;
        }

        public ActionResult Index(MarcasListadoModel model, int? page)
        {
            model.Filtros = model.Filtros ?? new MarcasFiltrosModel()
            {
                Descripcion = model.Descripcion,
                Page = page
            };
            var pageNumber = page ?? 1;

            var pageSize =  AppSettings.DefaultPageSize;

            var marcas = Uow.Marcas.Listado().Where(m => m.CuentaId == UsuarioActual.CuentaId)
                .Where(model.Filtros.GetFilterExpression())
                                .OrderBy(m => m.Descripcion).ToList(); 
            IPagedList<Marca> list = marcas.ToPagedList(pageNumber, pageSize);

            model.List = list;

            return PartialOrView(model);
        }

        public ActionResult Detalle(int id)
        {
            Marca marca = Uow.Marcas.Obtener(u => u.MarcaId == id);
            return PartialView(marca);
        }

        public ActionResult Crear()
        {
            return PartialView(new Marca());
        }

        [HttpPost]
        public ActionResult Crear(Marca marca)
        {
            if (!ModelState.IsValid || !EsDescripcionvalida(marca.Descripcion, marca.MarcaId))
            {
                return PartialView(marca);
            }
            marca.Identifier = Guid.NewGuid();
            marca.CuentaId = UsuarioActual.CuentaId;
            Uow.Marcas.Agregar(marca);
            Uow.Commit();
            
            return new JsonResult(){ Data = new { exito = true , marca = marca}, JsonRequestBehavior = JsonRequestBehavior.AllowGet};
        }

        public ActionResult Editar(int id)
        {
            Marca marca = Uow.Marcas.Obtener(id);
            return PartialView(marca);
        }

        [HttpPost]
        public ActionResult Editar(Marca marca)
        {
            if (!ModelState.IsValid)
            {
                return PartialView(marca);
            }

            Uow.Marcas.Modificar(marca);
            Uow.Commit();
            return new JsonResult() { Data = new { exito = true }, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        public ActionResult Eliminar(int id)
        {
            Marca marca = Uow.Marcas.Obtener(id);
            return PartialView(marca);
        }

        [HttpPost]
        public ActionResult Eliminar(int id, FormCollection collection)
        {
            var productos = Uow.Productos.Listado().Where(p => p.MarcaId == id).ToList();
            if (productos.Count > 0)
            {
                ModelState.AddModelError("ProductosAsociados", "No puede elimiarse la marca porque tiene productos asociados");
                Marca marca = Uow.Marcas.Obtener(id);
                return PartialView(marca);
            }
            Uow.Marcas.Eliminar(id);
            Uow.Commit();
            return new JsonResult() { Data = new { exito = true }, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        [OutputCache(Location = OutputCacheLocation.None, NoStore = true)]
        public JsonResult EsDescripcionMarcaUnica(string descripcion, int marcaId)
        {
            return EsDescripcionvalida(descripcion, marcaId)
                ? Json(true, JsonRequestBehavior.AllowGet)
                : Json(false, JsonRequestBehavior.AllowGet);
        }

        private bool EsDescripcionvalida(string descripcion, int marcaId)
        {
            return !Uow.Marcas.Listado().Any(m => m.Descripcion == descripcion && m.MarcaId != marcaId);
        }
    }
}

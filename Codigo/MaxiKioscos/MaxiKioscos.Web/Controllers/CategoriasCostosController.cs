using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using MaxiKioscos.Datos.Interfaces;
using MaxiKioscos.Entidades;
using MaxiKioscos.Web.Comun.Helpers;
using MaxiKioscos.Web.Configuration;
using MaxiKioscos.Web.Models;
using PagedList;
using WebMatrix.WebData;

namespace MaxiKioscos.Web.Controllers
{
    public class CategoriasCostosController : BaseController
    {
        public CategoriasCostosController(IMaxiKioscosUow uow)
        {
            Uow = uow;
        }

        public ActionResult Index(CategoriasCostosListadoModel model, int? page)
        {
            model.Filtros = model.Filtros ?? new CategoriasCostosFiltrosModel()
            {
                Descripcion = model.Descripcion,
                Page = page
            };
            var pageNumber = page ?? 1;

            var pageSize =  AppSettings.DefaultPageSize;

            var categforiasCosto = Uow.CategoriasCostos.Listado()
                .Where(model.Filtros.GetFilterExpression())
                                .OrderBy(m => m.Descripcion).ToList(); 
            IPagedList<CategoriaCosto> list = categforiasCosto.ToPagedList(pageNumber, pageSize);

            model.List = list;

            return PartialOrView(model);
        }

        public ActionResult Detalle(int id)
        {
            CategoriaCosto categoriaCosto = Uow.CategoriasCostos.Obtener(u => u.CategoriaCostoId == id);
            return PartialView(categoriaCosto);
        }

        public ActionResult Crear()
        {
            return PartialView(new CategoriaCosto());
        }

        [HttpPost]
        public ActionResult Crear(CategoriaCosto categoriaCosto)
        {
            var yaExiste = Uow.CategoriasCostos.Listado().Any(cc => cc.Descripcion == categoriaCosto.Descripcion);
            if (yaExiste)
                ModelState.AddModelError("Descripcion", "Ya existe una categoría con el mismo nombre");

            if (!ModelState.IsValid)
            {
                return PartialView(categoriaCosto);
            }
            categoriaCosto.Identifier = Guid.NewGuid();
            Uow.CategoriasCostos.Agregar(categoriaCosto);
            Uow.Commit();
            
            return new JsonResult(){ Data = new { exito = true , categoriaCosto = categoriaCosto}, JsonRequestBehavior = JsonRequestBehavior.AllowGet};
        }

        public ActionResult Editar(int id)
        {
            CategoriaCosto categoriaCosto = Uow.CategoriasCostos.Obtener(id);
            return PartialView(categoriaCosto);
        }

        [HttpPost]
        public ActionResult Editar(CategoriaCosto categoriaCosto)
        {
            var yaExiste = Uow.CategoriasCostos.Listado().Any(cc => cc.Descripcion == categoriaCosto.Descripcion
                                                                    &&
                                                                    cc.CategoriaCostoId !=
                                                                    categoriaCosto.CategoriaCostoId);
            if (yaExiste)
                ModelState.AddModelError("Descripcion", "Ya existe una categoría con el mismo nombre");
            
            if (!ModelState.IsValid)
            {
                return PartialView(categoriaCosto);
            }

            

            Uow.CategoriasCostos.Modificar(categoriaCosto);
            Uow.Commit();
            return new JsonResult() { Data = new { exito = true }, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        public ActionResult Eliminar(int id)
        {
            CategoriaCosto categoriaCosto = Uow.CategoriasCostos.Obtener(id);
            return PartialView(categoriaCosto);
        }

        [HttpPost]
        public ActionResult Eliminar(CategoriaCosto categoriaCosto)
        {
            Uow.CategoriasCostos.Eliminar(categoriaCosto);
            Uow.Commit();
            return new JsonResult() { Data = new { exito = true }, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

    }
}

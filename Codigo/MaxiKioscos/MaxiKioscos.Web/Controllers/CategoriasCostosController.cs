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
    [ActivityAuthorize(Actions = MaxikioscoPermisos.CATEGORIASDEGASTOS)]
    public class CategoriasCostosController : BaseController
    {
        public CategoriasCostosController(IMaxiKioscosUow uow)
        {
            Uow = uow;
        }

        public ActionResult Index(CategoriasCostosListadoModel model, int? page)
        {
           // var asd = new SelectList(new List<CategoriaCosto>(), "Id", "Name","Category",1);
            model.Filtros = model.Filtros ?? new CategoriasCostosFiltrosModel()
            {
                Descripcion = model.Descripcion,
                PadreId = model.PadreId,
                Page = page
            };
            var pageNumber = page ?? 1;

            var pageSize =  AppSettings.DefaultPageSize;

            var categoriasCosto = Uow.CategoriasCostos.Listado(x => x.Padre)
                .Where(model.Filtros.GetFilterExpression())
                                .OrderBy(m => m.PadreId)
                                .ThenBy(c => c.Descripcion); 
            IPagedList<CategoriaCosto> list = categoriasCosto.ToPagedList(pageNumber, pageSize);

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

            if (categoriaCosto.PadreId != null)
            {
                var padre = Uow.CategoriasCostos.Obtener(categoriaCosto.PadreId.Value);
                if (padre.PadreId != null)
                    ModelState.AddModelError("PadreId", "El padre seleccionado ya es a su vez hijo de otra categoría");
            }

            if (!ModelState.IsValid)
            {
                return PartialView(categoriaCosto);
            }
            categoriaCosto.Identifier = Guid.NewGuid();
            Uow.CategoriasCostos.Agregar(categoriaCosto);
            Uow.Commit();
            
            return new JsonResult(){ Data = new { exito = true }, JsonRequestBehavior = JsonRequestBehavior.AllowGet};
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

            if (categoriaCosto.PadreId != null)
            {
                if (categoriaCosto.CategoriaCostoId == categoriaCosto.PadreId)
                {
                    ModelState.AddModelError("PadreId", "El padre seleccionado debe ser diferente de la categoría que se está editando");
                }
                else
                {
                    var padre = Uow.CategoriasCostos.Obtener(categoriaCosto.PadreId.Value);
                    if (padre.PadreId != null)
                        ModelState.AddModelError("PadreId", "El padre seleccionado ya es a su vez hijo de otra categoría");
                }
                
            }
            
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
            var hijas = Uow.CategoriasCostos.Listado().Where(x => !x.Eliminado && x.PadreId == categoriaCosto.CategoriaCostoId).ToList();
            foreach (var hija in hijas)
            {
                Uow.CategoriasCostos.Eliminar(hija);
            }
            Uow.CategoriasCostos.Eliminar(categoriaCosto);
            Uow.Commit();
            return new JsonResult() { Data = new { exito = true }, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

    }
}

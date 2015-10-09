using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MaxiKioscos.Datos.Interfaces;
using MaxiKioscos.Entidades;
using MaxiKioscos.Web.Comun.Helpers;
using MaxiKioscos.Web.Configuration;
using MaxiKioscos.Web.Models;
using PagedList;

namespace MaxiKioscos.Web.Controllers
{
    public class ExcepcionesRubrosController : BaseController
    {
        public ExcepcionesRubrosController(IMaxiKioscosUow uow)
        {
            Uow = uow;
        }

        public ActionResult Index(ExcepcionRubrosListadoModel model, int? page)
        {
            model.Filtros = model.Filtros ?? new ExcepcionRubrosFiltrosModel()
            {
                MaxiKioscoId = model.MaxiKioscoId,
                Rubro = model.Rubro
            };
            List<ExcepcionRubro> excepcionesRubros = Uow.ExcepcionesRubros.Listado(e => e.Rubro, e => e.MaxiKiosco)
                .Where(e => e.MaxiKiosco.CuentaId == UsuarioActual.CuentaId)
                .Where(model.Filtros.GetFilterExpression())
                .ToList();

            var pageNumber = page ?? 1;
            var pageSize = AppSettings.DefaultPageSize;
            IPagedList<ExcepcionRubro> lista = excepcionesRubros.OrderBy(s => s.Rubro.Descripcion).ToPagedList(pageNumber, pageSize);
            model.List = lista;
            return PartialOrView(model);
        }

        public ActionResult Listado(ExcepcionRubrosFiltrosModel filtros, int? page)
        {
            var excepcionesRubros = Uow.ExcepcionesRubros.Listado(e => e.Rubro, e => e.MaxiKiosco)
                .Where(e => e.MaxiKiosco.CuentaId == UsuarioActual.CuentaId)
                .Where(filtros.GetFilterExpression());

            var lista = excepcionesRubros.ToPagedList(page ?? 1, AppSettings.DefaultPageSize);
            var listadoModel = new ExcepcionRubrosListadoModel
            {
                List = lista,
                Filtros = filtros,
                MaxiKioscoId = filtros.MaxiKioscoId,
                Rubro = filtros.Rubro
            };

            return PartialView("_Listado", listadoModel);
        }

        public ActionResult Detalle(int id)
        {
            ExcepcionRubro excepcionRubro = Uow.ExcepcionesRubros.Obtener(e => e.ExcepcionRubroId == id, e => e.Rubro, e => e.MaxiKiosco);

            if (excepcionRubro == null)
            {
                return HttpNotFound();
            }

            return PartialView(excepcionRubro);
        }

        public ActionResult Crear()
        {
            var excepcionRubro = new ExcepcionRubro();
            excepcionRubro.RecargoPorcentaje = 0;
            return PartialView(excepcionRubro);
        }

        [HttpPost]
        public ActionResult Crear(ExcepcionRubro excepcionRubro)
        {
            if (!ModelState.IsValid)
            {
                return PartialView(excepcionRubro);
            }

            if (ExistenPeriodosSolapados(excepcionRubro))
            {
                //Verificamos que nos se solapen los rangos ningun existente.
                ModelState.AddModelError("PeriodosSolapados", "El período ingresado coincide con uno o más cargados previamente");
                return PartialView(excepcionRubro);
            }

            excepcionRubro.Identifier = Guid.NewGuid();
            Uow.ExcepcionesRubros.Agregar(excepcionRubro);
            Uow.Commit();

            return Json(new {exito = true});
        }

        public ActionResult Editar(int id)
        {
            ExcepcionRubro excepcionRubro = Uow.ExcepcionesRubros.Obtener(id);

            if (excepcionRubro == null)
            {
                return HttpNotFound();
            }

            return PartialView(excepcionRubro);
        }

        [HttpPost]
        public ActionResult Editar(ExcepcionRubro excepcionRubro)
        {
            if (!ModelState.IsValid)
            {
                return PartialView();
            }

            if (ExistenPeriodosSolapados(excepcionRubro))
            {
                //Verificamos que nos se solapen los rangos ningun existente.
                ModelState.AddModelError("PeriodosSolapados", "El período ingresado coincide con uno o más cargados previamente");
                return PartialView(excepcionRubro);
            }

            Uow.ExcepcionesRubros.Modificar(excepcionRubro);
            Uow.Commit();

            return Json(new { exito = true });
        }

        public ActionResult Eliminar(int id)
        {
            ExcepcionRubro excepcionRubro = Uow.ExcepcionesRubros.Obtener(e => e.ExcepcionRubroId == id, e => e.Rubro, e => e.MaxiKiosco);

            if (excepcionRubro == null)
            {
                return HttpNotFound();
            }

            return PartialView(excepcionRubro);
        }

        [HttpPost]
        public ActionResult Eliminar(int id, FormCollection collection)
        {
            ExcepcionRubro excepcionRubro = Uow.ExcepcionesRubros.Obtener(id);
            if (excepcionRubro == null)
            {
                return HttpNotFound();
            }
            Uow.ExcepcionesRubros.Eliminar(excepcionRubro);
            Uow.Commit();
            return Json(new { exito = true });
        }


        #region Helpers

        private bool ExistenPeriodosSolapados(ExcepcionRubro excepcionRubro)
        {
            //Validate solapamiento para el rubro y el kiosco
            var excepcionesRubro = Uow.ExcepcionesRubros.Listado()
                .Where(ex => ex.MaxiKioscoId == excepcionRubro.MaxiKioscoId &&
                             ex.RubroId == excepcionRubro.RubroId &&
                             ex.ExcepcionRubroId != excepcionRubro.ExcepcionRubroId).ToList();

            return excepcionesRubro.Any(ex => TimeSpanHelper
                                                  .TimePeriodOverlap(excepcionRubro.Desde, excepcionRubro.Hasta,
                                                                     ex.Desde, ex.Hasta));
        }

        #endregion
    }
}

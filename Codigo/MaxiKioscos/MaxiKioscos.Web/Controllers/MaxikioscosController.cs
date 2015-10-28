using System;
using System.Linq;
using System.Web.Mvc;
using MaxiKioscos.Datos.Interfaces;
using MaxiKioscos.Entidades;
using MaxiKioscos.Seguridad;
using MaxiKioscos.Web.Comun.Atributos;
using MaxiKioscos.Web.Comun.Helpers;
using MaxiKioscos.Web.Configuration;
using MaxiKioscos.Web.Filters;
using PagedList;

namespace MaxiKioscos.Web.Controllers
{
    [ActivityAuthorize(Actions = MaxikioscoPermisos.MAXIKIOSCOS)]
    public class MaxiKioscosController : BaseController
    {
        public MaxiKioscosController(IMaxiKioscosUow uow)
        {
            Uow = uow;
        }

        public ActionResult Index(int? page)
        {
            var maxiKioscos = Uow.MaxiKioscos.Listado().ToList()
                .Where(m => m.CuentaId == UsuarioActual.CuentaId);

            var lista = maxiKioscos.ToPagedList(page ?? 1, AppSettings.DefaultPageSize);
            return PartialOrView(lista);
        }

        public ActionResult Detalle(int id)
        {
            Entidades.MaxiKiosco maxikiosco = Uow.MaxiKioscos.Obtener(m => m.MaxiKioscoId == id,
                m => m.MaxiKioscoTurnos.Select(mt => mt.Turno));

            if (maxikiosco == null)
            {
                return HttpNotFound();
            }

            return PartialView(maxikiosco);
        }

        [AjaxAuthorize(Roles = MaxikioscoRoles.SuperAdminRole)]
        public ActionResult Crear()
        {
            var maxikiosco = new Entidades.MaxiKiosco() { EstaOnLine = true };

            CargarTurnos(maxikiosco);

            return PartialView(maxikiosco);
        }

        [HttpPost]
        [AjaxAuthorize(Roles = MaxikioscoRoles.SuperAdminRole)]
        public ActionResult Crear(Entidades.MaxiKiosco maxikiosco)
        {
            if (!ModelState.IsValid)
            {
                return PartialView();
            }

            ActualizarTurnos(maxikiosco);

            maxikiosco.Identifier = Guid.NewGuid();
            maxikiosco.CuentaId = UsuarioActual.CuentaId;
            maxikiosco.Desincronizado = true;
            Uow.MaxiKioscos.Agregar(maxikiosco);
            Uow.Commit();

            return Json(new { exito = true });
        }

        public ActionResult Editar(int id)
        {
            Entidades.MaxiKiosco maxikiosco = Uow.MaxiKioscos
                .Obtener(m => m.MaxiKioscoId == id,
                m => m.MaxiKioscoTurnos.Select(mt => mt.Turno));

            CargarTurnos(maxikiosco);

            if (maxikiosco == null)
            {
                return HttpNotFound();
            }

            return PartialView(maxikiosco);
        }

        [HttpPost]
        public ActionResult Editar(Entidades.MaxiKiosco maxikiosco)
        {
            if (!ModelState.IsValid)
            {
                return PartialView(maxikiosco);
            }

            ActualizarTurnos(maxikiosco);

            maxikiosco.Desincronizado = true;
            Uow.MaxiKioscos.Modificar(maxikiosco);
            Uow.Commit();

            return Json(new { exito = true });
        }

        public ActionResult Eliminar(int id)
        {
            Entidades.MaxiKiosco maxikiosco = Uow.MaxiKioscos
                 .Obtener(m => m.MaxiKioscoId == id,
                 m => m.MaxiKioscoTurnos.Select(mt => mt.Turno));

            if (maxikiosco == null)
            {
                return HttpNotFound();
            }

            return PartialView(maxikiosco);
        }

        [HttpPost]
        [Authorize(Roles = MaxikioscoRoles.SuperAdminRole)]
        public ActionResult Eliminar(int id, FormCollection collection)
        {
            Entidades.MaxiKiosco maxikiosco = Uow.MaxiKioscos
                .Obtener(m => m.MaxiKioscoId == id);

            if (maxikiosco == null)
            {
                return HttpNotFound();
            }

            Uow.MaxiKioscos.Eliminar(maxikiosco);
            Uow.Commit();

            return Json(new { exito = true });
        }

        #region Helpers

        private void CargarTurnos(Entidades.MaxiKiosco maxiKiosco)
        {
            //Obtener los turnos y crear maxikiscos turnos cuando el kiosco no los tenga.
            var turnos = Uow.Turnos.Listado().ToList();

            foreach (var turno in turnos)
            {
                var maxkioscoTurno = maxiKiosco.MaxiKioscoTurnos
                    .FirstOrDefault(mt => mt.TurnoId == turno.TurnoId);

                if (maxkioscoTurno == null)
                {
                    maxkioscoTurno = new MaxiKioscoTurno();
                    maxkioscoTurno.MaxiKioscoId = maxiKiosco.MaxiKioscoId;
                    maxkioscoTurno.MaxiKiosco = maxiKiosco;
                    maxkioscoTurno.TurnoId = turno.TurnoId;
                    maxkioscoTurno.Turno = turno;
                    //maxkioscoTurno.MontoMaximoVentaConTickets = null;
                    maxiKiosco.MaxiKioscoTurnos.Add(maxkioscoTurno);
                }
            }
        }

        private void ActualizarTurnos(Entidades.MaxiKiosco maxiKiosco)
        {
            foreach (var maxikisocoTurno in maxiKiosco.MaxiKioscoTurnos)
            {
                if (maxikisocoTurno.MaxiKioscoTurnoId == 0)
                {
                    Uow.MaxiKioscoTurnos.Agregar(maxikisocoTurno);
                }
                else
                {
                    Uow.MaxiKioscoTurnos.Modificar(maxikisocoTurno);
                }
            }

            maxiKiosco.MaxiKioscoTurnos.Clear();
        }

        #endregion
    }
}

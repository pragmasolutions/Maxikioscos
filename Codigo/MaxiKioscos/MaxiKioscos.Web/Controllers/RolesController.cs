using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using MaxiKioscos.Datos.Interfaces;
using MaxiKioscos.Entidades;
using MaxiKioscos.Web.Comun.Helpers;
using MaxiKioscos.Web.Configuration;
using MaxiKioscos.Web.Filters;
using MaxiKioscos.Web.Models;
using PagedList;
using WebMatrix.WebData;

namespace MaxiKioscos.Web.Controllers
{
    public class RolesController : BaseController
    {
        public RolesController(IMaxiKioscosUow uow)
        {
            Uow = uow;
        }
        
        public ActionResult Index()
        {
            List<Role> roles = Uow.Roles.Listado().OrderBy(r => r.RoleName).ToList();
            return PartialOrView(roles);
        }

        public ActionResult Reportes(int id)
        {
            Role rol = Uow.Roles.Obtener(id);
            ViewBag.RoleName = rol.RoleName;
            ViewBag.RoleId = rol.RoleId;
            return PartialOrView(rol.ReporteRoles.Where(x => !x.Eliminado).ToList());
        }

        public ActionResult Agregar(int id)
        {
            Role rol = Uow.Roles.Obtener(id);
            var reportesListado = Uow.Reportes.Listado();
            var list = rol.ReporteRoles.Where(rr => !rr.Eliminado).Select(r => r.ReporteId).ToList();

            var sobrantes = reportesListado.Where(r => !list.Contains(r.ReporteId))
                    .OrderBy(r => r.Padre).ThenBy(r => r.NombreCompleto).ToList();

            ViewBag.RoleId = id;
            ViewBag.ListadoSobrantes = sobrantes;
            return PartialOrView(null);
        }

        [HttpPost]
        public ActionResult Agregar(int roleId, int? reporteId)
        {
            if (reporteId == null)
            {
                ModelState.AddModelError("ReporteId", "Por favor seleccione un reporte");
            }
            Role rol = Uow.Roles.Obtener(roleId);
            var cuenta = rol.ReporteRoles.Count(rr => !rr.Eliminado && rr.ReporteId == reporteId);

            if (cuenta > 0)
            {
                ModelState.AddModelError("ReporteId", "El reporte seleccionado ya existe para este rol");
            }

            if (!ModelState.IsValid)
            {
                var reportesListado = Uow.Reportes.Listado();
                var list = rol.ReporteRoles.Where(rr => !rr.Eliminado).Select(r => r.ReporteId).ToList();

                var sobrantes = reportesListado.Where(r => !list.Contains(r.ReporteId))
                        .OrderBy(r => r.Padre).ThenBy(r => r.NombreCompleto).ToList();

                ViewBag.RoleId = roleId;
                ViewBag.ListadoSobrantes = sobrantes;
                return PartialOrView(reporteId);
            }

            rol.ReporteRoles.Add(new ReporteRol()
            {
                RoleId = roleId,
                Identifier = Guid.NewGuid(),
                Desincronizado = true,
                ReporteId = reporteId.GetValueOrDefault()
            });
            Uow.Commit();

            return Json(new { exito = true });
        }

        [HttpPost]
        public ActionResult Eliminar(int id)
        {
            Uow.ReporteRoles.Eliminar(id);
            Uow.Commit();

            return Json(new { exito = true });
        }
    }
}

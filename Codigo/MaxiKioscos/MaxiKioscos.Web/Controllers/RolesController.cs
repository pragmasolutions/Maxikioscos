using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
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
    [ActivityAuthorize(Actions = MaxikioscoPermisos.ROLES)]
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
            ViewBag.ListAction = "Reportes";
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


        public ActionResult Permisos(int id)
        {
            Role rol = Uow.Roles.Obtener(id);
            ViewBag.RoleName = rol.RoleName;
            ViewBag.RoleId = rol.RoleId;
            ViewBag.ListAction = "Permisos";
            return PartialOrView(rol.PermisoRoles.Where(x => !x.Eliminado).ToList());
        }

        public ActionResult AgregarPermiso(int id)
        {
            Role rol = Uow.Roles.Obtener(id);
            var permisosListado = Uow.Permisos.Listado();
            var list = rol.PermisoRoles.Where(rr => !rr.Eliminado).Select(r => r.PermisoId).ToList();

            var sobrantes = permisosListado.Where(r => !list.Contains(r.PermisoId))
                    .OrderBy(r => r.Nombre).ToList();

            ViewBag.RoleId = id;
            ViewBag.ListadoSobrantes = sobrantes;
            return PartialOrView(null);
        }

        [HttpPost]
        public ActionResult AgregarPermiso(int roleId, int? permisoId)
        {
            if (permisoId == null)
            {
                ModelState.AddModelError("PermisoId", "Por favor seleccione un permiso");
            }

            Role rol = Uow.Roles.Obtener(roleId);

            var cuenta = rol.PermisoRoles.Count(x => !x.Eliminado && x.PermisoId == permisoId);

            if (cuenta > 0)
            {
                ModelState.AddModelError("ReporteId", "El permiso seleccionado ya existe para este rol");
            }

            if (!ModelState.IsValid)
            {
                var permisosListado = Uow.Permisos.Listado();
                var list = rol.PermisoRoles.Where(x => !x.Eliminado).Select(x => x.PermisoId).ToList();

                var sobrantes = permisosListado.Where(x => !list.Contains(x.PermisoId))
                        .OrderBy(r => r.Nombre)
                        .ToList();

                ViewBag.RoleId = roleId;
                ViewBag.ListadoSobrantes = sobrantes;

                return PartialOrView(permisoId);
            }

            rol.PermisoRoles.Add(new PermisoRol()
            {
                RoleId = roleId,
                Identifier = Guid.NewGuid(),
                Desincronizado = true,
                PermisoId = permisoId.GetValueOrDefault()
            });

            Uow.Commit();

            return Json(new { exito = true });
        }

        [HttpPost]
        public ActionResult EliminarPermiso(int id)
        {
            Uow.PermisoRoles.Eliminar(id);
            Uow.Commit();

            return Json(new { exito = true });
        }
    }
}

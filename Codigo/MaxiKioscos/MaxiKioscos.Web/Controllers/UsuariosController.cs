using System;
using System.Collections.Generic;
using System.Linq;
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
    //[InitializeSimpleMembership]
    [Authorize]
    [ActivityAuthorize(Actions = MaxikioscoPermisos.USUARIOS)]
    public class UsuariosController : BaseController
    {
        private const string NombreRoleAdministrador = "Administrador";

        public UsuariosController(IMaxiKioscosUow uow)
        {
            Uow = uow;
        }

        [HttpPost]
        public ActionResult SetearMaxikioscoDefaultId(int? maxiKioscoDefaultId)
        {
            UsuarioActual.MaxikiosoDefaultId = maxiKioscoDefaultId;
            return new JsonResult() { Data = true, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        public ActionResult Index(UsuariosListadoModel model, int? page)
        {
            model.Filtros = model.Filtros ?? new UsuariosFiltrosModel()
            {
                PalabrasABuscar = model.PalabrasABuscar,
                RolId = model.RolId
            };
            List<Usuario> usuarios = Uow.Usuarios.ListadoPorCuenta(UsuarioActual.CuentaId, u => u.Roles)
                .Where(u => !u.Eliminado)
                .Where(model.Filtros.GetFilterExpression())
                .ToList();

            var pageNumber = page ?? 1;
            var pageSize = AppSettings.DefaultPageSize;
            IPagedList<Usuario> lista = usuarios.OrderBy(s => s.NombreUsuario).ToPagedList(pageNumber, pageSize);
            model.List = lista;
            return PartialOrView(model);
        }

        public ActionResult Listado(UsuariosFiltrosModel filtros, int? page)
        {
            var usuarios = Uow.Usuarios.ListadoPorCuenta(UsuarioActual.CuentaId, u => u.Roles)
                .Where(u => !u.Eliminado)
                .Where(filtros.GetFilterExpression()).ToList();

            var lista = usuarios.ToPagedList(page ?? 1, AppSettings.DefaultPageSize);
            var listadoModel = new UsuariosListadoModel
            {
                List = lista,
                Filtros = filtros,
                PalabrasABuscar = filtros.PalabrasABuscar,
                RolId = filtros.RolId
            };

            return PartialView("_Listado", listadoModel);


        }

        public ActionResult Detalle(int id)
        {
            Usuario usuario = Uow.Usuarios.Obtener(u => u.UsuarioId == id, u => u.Roles,
                        u => u.UsuarioProveedores, u => u.UsuarioProveedores.Select(m => m.Proveedor));
            var model = new UsuarioModel()
            {
                Usuario = usuario,
                RoleId = usuario.Rol.RoleId
            };
            LlenarControles(model);
            return PartialView(model);
        }

        public ActionResult Crear()
        {
            var model = new UsuarioConPasswordModel { Usuario = new Usuario() };
            LlenarControles(model);
            return PartialView(model);
        }

        private void LlenarControles(UsuarioModel model)
        {
            var proveedores = Uow.Proveedores.Listado().Where(p => p.CuentaId == UsuarioActual.CuentaId).ToList();
            model.Proveedores = proveedores.Select(r => new SelectListItem()
            {
                Text = r.Nombre,
                Value = r.ProveedorId.ToString()
            }).ToList();

            var listado = Uow.Usuarios.RolesListado().ToList();
            listado.RemoveAt(3);
            var roles = new SelectList(listado, "RoleId", "RoleName").ToList();
            roles.Insert(0, new SelectListItem());
            ViewBag.Roles = new SelectList(roles, "Value", "Text");
        }

        [HttpPost]
        public ActionResult Crear(UsuarioConPasswordModel model)
        {
            CustomValidation(model);
            if (!ModelState.IsValid)
            {
                LlenarControles(model);
                return PartialView(model);
            }


            WebSecurity.CreateUserAndAccount(model.Usuario.NombreUsuario, model.Password, new
             {
                 model.Usuario.Apellido,
                 model.Usuario.Nombre,
                 UsuarioActual.CuentaId,
                 Desincronizado = true,
                 Eliminado = false,
                 Identifier = Guid.NewGuid()
             });

            var usuario = Uow.Usuarios.Obtener(model.Usuario.NombreUsuario);
            if (model.ProveedoresIds != null)
                usuario.UsuarioProveedores = model.ProveedoresIds.Select(r => new UsuarioProveedor() { ProveedorId = r }).ToList();

            Uow.Usuarios.InsertarDependencias(usuario, model.RoleId);

            return new JsonResult() { Data = new { exito = true }, JsonRequestBehavior = JsonRequestBehavior.AllowGet };


        }

        private void CustomValidation(UsuarioModel model)
        {
            if (WebSecurity.UserExists(model.Usuario.NombreUsuario))
            {
                ModelState.AddModelError("NombreUsuario", "El nombre de usuario ya esta en uso");

            }
        }

        public ActionResult Editar(int id)
        {
            Usuario usuario = Uow.Usuarios.Obtener(u => u.UsuarioId == id, u => u.Roles,
                        u => u.UsuarioProveedores, u => u.UsuarioProveedores.Select(m => m.Proveedor));
            var model = new UsuarioConPasswordOpcionalModel()
                            {
                                Usuario = usuario,
                                RoleId = usuario.Roles.FirstOrDefault().RoleId
                            };
            LlenarControles(model);
            return PartialView(model);
        }

        [HttpPost]
        public ActionResult Editar(UsuarioConPasswordOpcionalModel model)
        {
            if (!ModelState.IsValid)
            {
                LlenarControles(model);
                return PartialView(model);
            }

            if (!string.IsNullOrEmpty(model.Password))
            {
                var encondedPassword = Crypto.HashPassword(model.Password);
                Uow.Usuarios.CambiarPassword(model.Usuario.UsuarioId, encondedPassword, DateTime.Now);
            }

            model.Usuario.Desincronizado = true;
            Uow.Usuarios.Modificar(model.Usuario);
            Uow.Commit();

            if (model.ProveedoresIds != null)
            {
                model.Usuario.UsuarioProveedores = model.ProveedoresIds.Select(p =>
                    new UsuarioProveedor
                    {
                        ProveedorId = p,
                        UsuarioId = model.Usuario.UsuarioId
                    }).ToList();
            }

            Uow.Usuarios.InsertarDependencias(model.Usuario, model.RoleId);



            return new JsonResult() { Data = new { exito = true }, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        public ActionResult Eliminar(int id)
        {
            Usuario usuario = Uow.Usuarios.Obtener(u => u.UsuarioId == id, u => u.Roles,
                        u => u.UsuarioProveedores, u => u.UsuarioProveedores.Select(m => m.Proveedor));
            var model = new UsuarioModel()
            {
                Usuario = usuario,
                RoleId = usuario.Rol.RoleId
            };
            LlenarControles(model);
            return PartialView(model);
        }

        [HttpPost]
        public ActionResult Eliminar(UsuarioModel usuarioModel)
        {
            Usuario usuario = Uow.Usuarios.Obtener(u => u.UsuarioId == usuarioModel.Usuario.UsuarioId,
                u => u.Roles);

            if (usuario == null)
            {
                return HttpNotFound();
            }

            //Verificamos que no sea el ultimo usuario admin.
            if (usuario.UsuarioId == UsuarioActual.Usuario.UsuarioId)
                return PartialView("EliminarError", "No se puede eliminar el usuario ya que el mismo está logueado actualmente");

            Uow.Usuarios.Eliminar(usuario);
            Uow.Commit();
            return new JsonResult() { Data = new { exito = true }, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
    }
}

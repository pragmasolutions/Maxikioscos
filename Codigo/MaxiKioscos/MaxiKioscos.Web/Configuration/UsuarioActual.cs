using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MaxiKioscos.Datos.Helpers;
using MaxiKioscos.Datos.Repositorio;
using MaxiKioscos.Entidades;
using WebMatrix.WebData;

namespace MaxiKioscos.Web.Configuration
{
    public static class UsuarioActual
    {
        public static Usuario Usuario
        {
            get
            {
                if (WebSecurity.IsAuthenticated)
                {
                    if (HttpContext.Current.Session["Usuario"] == null)
                    {
                        var usuarioRepository = new UsuarioRepository();
                        var usuario = usuarioRepository.Obtener(WebSecurity.CurrentUserName);
                        HttpContext.Current.Session["Usuario"] = usuario;
                    }
                    return HttpContext.Current.Session["Usuario"] as Usuario;
                }
                return null;
            }
            set { HttpContext.Current.Session["Usuario"] = value; }
        }

        public static int CuentaId
        {
            get
            {
                return (Usuario != null) ? Usuario.CuentaId : 0;
            }
        }

        private static Cuenta _cuenta;
        public static Cuenta Cuenta
        {
            get
            {
                if (Usuario == null)
                    return null;

                if (_cuenta == null)
                {
                    var cuentaRepository = new EFSimpleRepository<Cuenta>();
                    _cuenta = cuentaRepository.Obtener(Usuario.CuentaId);
                }
                return _cuenta;
            }
        }

        public static int? MaxikiosoDefaultId
        {
            get
            {
                return (int?) HttpContext.Current.Session["MaxikiosoDefaultId"];
            }
            set { HttpContext.Current.Session["MaxikiosoDefaultId"] = value; }
        }

        public static SelectList MaxikioscosSelectList
        {
            get
            {
                var kioscos = new SelectList(Usuario.Cuenta.MaxiKioscos, "MaxiKioscoId", "Nombre").ToList();
                kioscos.Insert(0, new SelectListItem());
                return new SelectList(kioscos, "Value", "Text", MaxikiosoDefaultId);
            }
        }

        public static List<Entidades.MaxiKiosco> MaxiKioscos
        {
            get { return Usuario.Cuenta.MaxiKioscos.ToList(); }
        }


        public static bool EsRol(string roleName)
        {
            return Usuario.Rol.RoleName == roleName;
        }

        public static void ResetearValoresCacheados()
        {
            _cuenta = null;
        }
    }
}
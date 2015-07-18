using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;
using System.Web.Helpers;
using MaxiKioscos.Datos.Repositorio;
using MaxiKioscos.Winforms.Configuracion;

namespace MaxiKioscos.Winforms.Membership
{
    public class MembershipProvider
    {
        public static bool Login(string username, string password, bool loginTemporal, out string error)
        {
            error = string.Empty;

            var repo = new UsuarioRepository();
            var usuario = repo.Obtener(u => u.NombreUsuario == username,
                                        u => u.Roles);

            //Verifico que el usuario existe
            if (usuario == null)
            {
                error = "El nombre de usuario es inválido";
                return false;
            }

            //Verifico que la contraseña sea correcta
            var membresia = repo.ObtenerMembresia(usuario.UsuarioId);
            var valido = Crypto.VerifyHashedPassword(membresia.Password, password);
            if (!valido)
            {
                error = "La contraseña ingresada es inválida";
                return false;
            }

            //var rolesAceptados = new []{ "Administrador","Encargado","SuperAdministrador"};
            //var esAdminOEncargado = usuario.Roles.Any(r => rolesAceptados.Contains(r.RoleName));
            //if (esAdminOEncargado || usuario.UsuarioMaxiKioscos.Any(m => m.MaxiKiosco.Identifier == AppSettings.MaxiKioscoIdentifier))
            //{
            //    if (loginTemporal)
            //        UsuarioActual.UsuarioTemporal = usuario;
            //    else
            //        UsuarioActual.Usuario = usuario;
            //    return true;
            //}

            //error = "El usuario ingresado no puede loguearse en este maxikiosco";
            //return false;

            if (loginTemporal)
                UsuarioActual.UsuarioTemporal = usuario;
            else
                UsuarioActual.Usuario = usuario;
            return true;
        }

        public static void Logoff()
        {
            UsuarioActual.UsuarioTemporal = null;
            UsuarioActual.Usuario = null;
        }

        public static bool VerificarPassword(string username, string password)
        {
            var repo = new UsuarioRepository();
            var usuario = repo.Obtener(u => u.NombreUsuario == username,
                                        u => u.Roles);

            //Verifico que la contraseña sea correcta
            var membresia = repo.ObtenerMembresia(usuario.UsuarioId);
            var valido = Crypto.VerifyHashedPassword(membresia.Password, password);
            return valido;
        }

        private static string EncodePassword(string password)
        {
            return Crypto.HashPassword(password);
        }
        
        public static bool ResetPassword(int usuarioId, string password)
        {
            try
            {
                var usuarioRepository = new UsuarioRepository();
                var encondedPassword = EncodePassword(password);
                usuarioRepository.CambiarPassword(usuarioId, encondedPassword, DateTime.Now);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}

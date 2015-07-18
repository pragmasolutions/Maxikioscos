using System.Linq;
using MaxiKioscos.Datos.Repositorio;
using MaxiKioscos.Entidades;

namespace MaxiKioscos.Winforms
{
    public class UsuarioActual
    {
        public static Usuario Usuario { get; set;}

        public static int UsuarioId
        {
            get
            {
                if (Usuario == null)
                    return 0;
                return Usuario.UsuarioId;
            }
        }


        public static Usuario UsuarioTemporal { get; set; }
        public static int UsuarioTemporalId
        {
            get
            {
                if (UsuarioTemporal == null)
                    return 0;
                return UsuarioTemporal.UsuarioId;
            }
        }

        public static int CuentaId
        {
            get
            {
                if (Usuario == null)
                    return 0;
                return Usuario.CuentaId;
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
            //set { _cuenta = value; }
        }

        public static int CierreCajaIdActual { get; set; }

        public static bool TieneRol(string rol)
        {
            return Usuario.Roles.Any(r => r.RoleName == rol);
        }

        public static bool TieneRolTemporal(string rol)
        {
            return UsuarioTemporal.Roles.Any(r => r.RoleName == rol);
        }

        public static bool EstaAutenticado
        {
            get
            {
                return Usuario != null || UsuarioTemporal != null;
            }
        }

        public static void ResetearValoresCacheados()
        {
            _cuenta = null;
        }

        public static bool ValidacionMargenes { get; set; }
    }
}

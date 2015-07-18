using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaxiKioscos.Seguridad
{
    public class MaxikioscoRoles
    {
        public const string SuperAdminRole = "SuperAdministrador";
        public const string EncargadoRole = "Encargado";
        public const string AdministradorRole = "Administrador";

        public const string AnyAdminRoles = SuperAdminRole + "," + AdministradorRole + "," + EncargadoRole;
    }
}

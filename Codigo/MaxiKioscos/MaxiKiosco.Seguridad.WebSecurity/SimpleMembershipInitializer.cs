using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaxiKioscos.Seguridad;

namespace MaxiKiosco.Seguridad.WebSecurity
{
    public class SimpleMembershipInitializer
    {
        public SimpleMembershipInitializer()
        {   
            if (!WebMatrix.WebData.WebSecurity.Initialized)
                WebMatrix.WebData.WebSecurity.InitializeDatabaseConnection("SimpleMembership", "Usuario", "UsuarioId", "NombreUsuario", autoCreateTables: true);
        }
    }
}

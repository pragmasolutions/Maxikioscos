using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaxiKioscos.Winforms.Login;

namespace MaxiKioscos.Winforms.Helpers
{
    public static class SeguridadHelper
    {
        public static int SolicitarPermisosUsuario(List<string> roles)
        {
            if (roles.Any(UsuarioActual.TieneRol))
                return UsuarioActual.UsuarioId;
            
            using (var loginForm = new frmLogin(roles))
            {
                var loginResult = loginForm.ShowDialog();
                if (loginResult == DialogResult.OK)
                    return UsuarioActual.UsuarioTemporalId;
            }
            return 0;
        }
        
    }
}

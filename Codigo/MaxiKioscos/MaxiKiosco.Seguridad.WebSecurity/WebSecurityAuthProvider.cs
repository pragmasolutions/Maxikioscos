using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaxiKioscos.Seguridad;

namespace MaxiKiosco.Seguridad.WebSecurity
{
    public class WebSecurityAuthService : IAuthService
    {
        public bool Login(string username, string password, bool rememberMe = false)
        {
            return WebMatrix.WebData.WebSecurity.Login(username, password, persistCookie: rememberMe);
        }
        
        public void LogOff()
        {
            WebMatrix.WebData.WebSecurity.Logout();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaxiKioscos.Seguridad
{
    public interface IAuthService
    {
        bool Login(string username, string password, bool rememberMe = false);
        void LogOff();
    }
}

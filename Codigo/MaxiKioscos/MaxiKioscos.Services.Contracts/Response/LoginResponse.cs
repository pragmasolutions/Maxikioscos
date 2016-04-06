using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaxiKioscos.Services.Contracts
{
    public class LoginResponse
    {
        public int? UserId { get; set; }
        public string Nombre { get; set; }
        public string Error { get; set; }
    }
}

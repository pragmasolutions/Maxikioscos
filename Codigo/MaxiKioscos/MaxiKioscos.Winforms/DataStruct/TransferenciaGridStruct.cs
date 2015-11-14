using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaxiKioscos.Winforms.DataStruct
{
    public class TransferenciaGridStruct
    {
        public int TransferenciaId { get; set; }
        public DateTime Fecha { get; set; }
        public string AutoNumero { get; set; }
        public string Estado { get; set; }
        public string Origen { get; set; }
    }
}

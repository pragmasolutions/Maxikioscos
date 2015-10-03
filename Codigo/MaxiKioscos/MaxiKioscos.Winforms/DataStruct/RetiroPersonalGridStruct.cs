using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaxiKioscos.Winforms.DataStruct
{
    public class RetiroPersonalGridStruct
    {
        public int RetiroPersonalId { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Importe { get; set; }
        public int CierreCajaId { get; set; }
    }
}

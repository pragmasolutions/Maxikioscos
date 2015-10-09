using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaxiKioscos.Winforms.DataStruct
{
    public class CostoGridStruct
    {
        public int CostoId { get; set; }
        public DateTime Fecha { get; set; }
        public bool CajaCerrada { get; set; }
        public string Estado { get; set; }
        public decimal Importe { get; set; }
        public string CategoriaCosto { get; set; }
        public string NroComprobante { get; set; }
    }
}

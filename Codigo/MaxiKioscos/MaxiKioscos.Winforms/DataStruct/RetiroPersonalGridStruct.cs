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

        public string ImporteFormateado
        {
            get
            {
                string importe;
                importe = (Importe % 1) == 0
                                ? Importe.ToString().Replace(",000000", "").Replace(",00000", "").Replace(",0000", "").Replace(".00", "").Replace(",00", "")
                                : Importe.ToString("N2");
                return String.Format("${0}", importe);
            }
        }
    }
}

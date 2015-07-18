using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaxiKioscos.Winforms.DataStruct
{
    public class ControlStockDetalleGridStruct
    {
        public int ControlStockDetalleId { get; set; }
        public string Codigo { get; set; }
        public string Producto { get; set; }
        public decimal Cantidad { get; set; }
        public decimal? Correccion { get; set; }
        public string Motivo { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaxiKioscos.Winforms.ControlStock.DTO
{
    public class ControlStockDTO
    {
        public int ControlStockId { get; set; }
        public string Rubro { get; set; }
        public string Proveedor { get; set; }
        public string Parametros { get; set; }
        public string FechaCorreccion { get; set; }
        public string Fecha { get; set; }
        public string Estado { get; set; }
        public string NroControl { get; set; }
    }
}

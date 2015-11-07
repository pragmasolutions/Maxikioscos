using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Maxikioscos.Comun.Helpers;

namespace MaxiKioscos.Entidades
{
    public partial class ReporteStock
    {
        public string MesDescripcion
        {
            get
            {
                switch (Mes)
                {
                    case 1: return "Enero";
                    case 2: return "Febrero";
                    case 3: return "Marzo";
                    case 4: return "Abril";
                    case 5: return "Mayo";
                    case 6: return "Junio";
                    case 7: return "Julio";
                    case 8: return "Agosto";
                    case 9: return "Septiembre";
                    case 10: return "Octubre";
                    case 11: return "Noviembre";
                    default: return "Diciembre";
                }
            }
        }
    }
}

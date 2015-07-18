using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaxiKioscos.Winforms.Configuracion
{
    public static class EventosFlags
    {
        public static CierreCajaEstadoEnum CierreCajaEstado { get; set; }

        public static bool CerrarCajaConfirmacion { get; set; }
    }

    public enum CierreCajaEstadoEnum
    {
        Abierto,
        Cerrado
    }
}

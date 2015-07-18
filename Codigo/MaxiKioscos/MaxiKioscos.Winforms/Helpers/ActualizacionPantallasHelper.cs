using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaxiKioscos.Winforms.Configuracion;

namespace MaxiKioscos.Winforms.Helpers
{
    public static class ActualizacionPantallasHelper
    {
        public static void ActualizarPantallaVentas()
        {
            if (AppSettings.MainForm != null)
            {
                var frmVentas = AppSettings.MainForm.MdiChildren.FirstOrDefault(f => f.Name == "Ventas");
                if (frmVentas != null)
                {
                    var frm = frmVentas as MaxiKioscos.Winforms.Ventas.Ventas;
                    frm.ForzarSincronizacion = true;
                }
            }
        }
    }
}

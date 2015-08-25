using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaxiKioscos.Winforms.Configuracion;
using MaxiKioscos.Winforms.Principal;
using MaxiKioscos.Winforms.SincronizationService;

namespace MaxiKioscos.Winforms.Sincronizacion
{
    public interface ISincronizacionManager
    {
        bool IsConnected { get; }

        Task PingServer();

        Task SincronizacionSecuencial();

        Task SincronizarEnSegundoPlano(mdiPrincipal form, BackgroundWorker worker, ToolStripStatusLabel label);

        void ActualizarKioscoDesdeArchivo(OpenFileDialog openFileDialogSincronizacion);
        
        Task InicializarKiosco();

        event SincronizacionManager.SyncExitosaEventHandler SyncExitosa;

        void ExportarDatosDesincronizados();


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaxiKioscos.Winforms.Configuracion;
using Microsoft.AspNet.SignalR.Client;

namespace MaxiKioscos.Winforms.Sincronizacion
{
    public interface IForzarSincronizacionHandler
    {
        event EventHandler Disconnected;
        void Init();
        bool IsConnected { get; }
        void Connect();
        void AutoConnect();
        void Disconect();
    }
}

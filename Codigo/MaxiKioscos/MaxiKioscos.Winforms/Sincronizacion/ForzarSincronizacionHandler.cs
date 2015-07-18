using System;
using System.Windows.Forms;
using MaxiKioscos.Winforms.Configuracion;
using MaxiKioscos.Winforms.Properties;
using Maxikioscos.Comun;
using Microsoft.AspNet.SignalR.Client;

namespace MaxiKioscos.Winforms.Sincronizacion
{
    public class ForzarSincronizacionHandler : IForzarSincronizacionHandler
    {
        private ISincronizacionManager _sincronizacionManager;
        HubConnection _hubConnection;
        IHubProxy _hubProxy;

        public ForzarSincronizacionHandler(ISincronizacionManager sincronizacionManager)
        {
            _sincronizacionManager = sincronizacionManager;
        }

        public event EventHandler Disconnected;

        public void Init()
        {
            var url = AppSettings.HubServiceUrl;

             _hubConnection = new HubConnection(url);
            _hubConnection.Headers.Add(Conecciones.MaxikioscoIdentifierHeader,AppSettings.MaxiKioscoIdentifier.ToString());
            _hubProxy = _hubConnection.CreateHubProxy(Conecciones.ForzarSincronizacionHubName);
            _hubConnection.StateChanged += HubConnection_StateChanged;

            Connect();
        }

        private void HubConnection_StateChanged(StateChange obj)
        {
            if (obj.NewState == ConnectionState.Disconnected)
            {
                OnDisconnected();
            }
        }

        private void OnDisconnected()
        {
            if (Disconnected != null)
            {
                Disconnected(this,new EventArgs());
            }
        }

        public bool IsConnected
        { 
            get { return _hubConnection.State == ConnectionState.Connected; }
        }

        public void Connect()
        {
            try
            {
                _hubConnection.Start().Wait();
            }
            catch (Exception ex)
            {
                ////Retry connection.
                MessageBox.Show(
                    Resources.ErrorAlConectarConServicioForzarSincronizacion);
            }
        }

        public void AutoConnect()
        {
            try
            {
                if (!IsConnected)
                {
                    _hubConnection.Start().Wait();
                }
            }
            catch (Exception ex)
            {
                
            }
        }

        public void Disconect()
        {
            try
            {
                _hubConnection.Stop();
            }
            catch (Exception ex)
            {
            }
        }
    }
}

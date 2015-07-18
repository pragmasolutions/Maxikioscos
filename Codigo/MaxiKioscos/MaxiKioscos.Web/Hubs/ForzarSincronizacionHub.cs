using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Maxikioscos.Comun;
using Microsoft.AspNet.SignalR;

namespace MaxiKioscos.Web.Hubs
{
    public class ForzarSincronizacionHub : Hub
    {
        public readonly static ConnectionMapping<string> Connections =
            new ConnectionMapping<string>();

        public override Task OnConnected()
        {
            string maxikioscoIdentifier = Context.Headers[Conecciones.MaxikioscoIdentifierHeader];

            Connections.Add(maxikioscoIdentifier, Context.ConnectionId);

            return base.OnConnected();
        }

        public override Task OnDisconnected()
        {
            string maxikioscoIdentifier = Context.Headers[Conecciones.MaxikioscoIdentifierHeader];

            Connections.Remove(maxikioscoIdentifier, Context.ConnectionId);

            return base.OnDisconnected();
        }

        public override Task OnReconnected()
        {
            string maxikioscoIdentifier = Context.Headers[Conecciones.MaxikioscoIdentifierHeader];

            if (!Connections.GetConnections(maxikioscoIdentifier).Contains(Context.ConnectionId))
            {
                Connections.Add(maxikioscoIdentifier, Context.ConnectionId);
            }

            return base.OnReconnected();
        }
    }
}
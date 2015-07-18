using System;
using System.ServiceModel;
using MaxiKioscos.Winforms.SincronizationService;

namespace MaxiKioscos.Winforms.Host
{
    /// <summary>
    /// Escucha senales de sincronizacion enviadas desde la web y dispara una
    /// Sincronización.
    /// </summary>
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class ForzarSincronizacionService : IForzarSincronizacionService
    {
        public ObtenerDatosResponse Sincronizar()
        {
            ////TODO: Iniciar proceso de sincronizacion.
            throw new NotImplementedException();
        }
    }
}

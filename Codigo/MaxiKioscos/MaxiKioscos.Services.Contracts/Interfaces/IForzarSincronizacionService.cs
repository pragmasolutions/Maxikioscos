using System.ServiceModel;

namespace MaxiKioscos.Services.Contracts
{
    [ServiceContract]
    public interface IForzarSincronizacionService
    {
        [OperationContract]
        ObtenerDatosResponse Sincronizar();
    }
}

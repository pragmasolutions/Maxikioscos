using System.ServiceModel;

namespace MaxiKioscos.Services.Contracts
{
    [ServiceContract]
    public interface INotificacionService
    {
        [OperationContract]
        bool ReportarError(ReportarErrorRequest request);
    }
}

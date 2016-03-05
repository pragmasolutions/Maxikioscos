using System.Collections.Generic;
using System.ServiceModel;

namespace MaxiKioscos.Services.Contracts
{
    [ServiceContract]
    public interface IMaxiKioscoService
    {
        [OperationContract]
        IList<KioscoApiResponse> GetMaxiKioscos();
    }
}

using System.Collections.Generic;
using System.ServiceModel;
using MaxiKioscos.Services.Contracts;

namespace MaxiKioscos.Services.Contracts
{
    [ServiceContract]
    public interface IMaxiKioscoService
    {
        [OperationContract]
        LoginResponse Login(LoginRequest login);

        [OperationContract]
        void LogOff();
    }
}

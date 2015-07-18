using MaxiKioscos.Datos.Interfaces;

namespace MaxiKioscos.Services
{
    public class BaseService
    {
        protected IMaxiKioscosUow Uow { get; set; }
    }
}
using System.Runtime.Serialization;

namespace MaxiKioscos.Services.Contracts
{
    [DataContract]
    public class InicializarKioscoResponse
    {
        [DataMember]
        public MaxiKioscoData[] Kioscos { get; set; }
    }
}
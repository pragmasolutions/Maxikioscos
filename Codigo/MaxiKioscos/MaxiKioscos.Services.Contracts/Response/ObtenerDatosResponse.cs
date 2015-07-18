using System.Runtime.Serialization;

namespace MaxiKioscos.Services.Contracts
{
    [DataContract]
    public class ObtenerDatosResponse
    {
        [DataMember]
        public ExportacionData[] Exportaciones { get; set; }
    }
}
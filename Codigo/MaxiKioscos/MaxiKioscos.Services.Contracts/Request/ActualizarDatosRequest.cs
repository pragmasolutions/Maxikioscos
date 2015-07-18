using System;
using System.Runtime.Serialization;

namespace MaxiKioscos.Services.Contracts
{
    [DataContract]
    public class ActualizarDatosRequest
    {
        [DataMember]
        public Guid MaxiKioscoIdentifier { get; set; }

        [DataMember]
        public ExportacionData[] Exportaciones { get; set; }
    }
}
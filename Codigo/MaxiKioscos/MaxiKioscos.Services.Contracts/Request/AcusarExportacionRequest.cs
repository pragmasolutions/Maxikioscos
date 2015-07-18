using System;
using System.Runtime.Serialization;

namespace MaxiKioscos.Services.Contracts
{
    [DataContract]
    public class AcusarExportacionRequest
    {
        [DataMember]
        public Guid MaxiKioscoIdentifier { get; set; }

        [DataMember]
        public int UltimaSecuenciaExportacion { get; set; }

        [DataMember]
        public string HoraLocalISO { get; set; }
    }
}
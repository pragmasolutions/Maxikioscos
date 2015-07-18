using System.Runtime.Serialization;

namespace MaxiKioscos.Services.Contracts
{
    [DataContract]
    public class ObtenerDatosSecuencialResponse
    {
        [DataMember]
        public ExportacionData Exportacion { get; set; }

        [DataMember]
        public int ArchivosRestantes { get; set; }
    }
}
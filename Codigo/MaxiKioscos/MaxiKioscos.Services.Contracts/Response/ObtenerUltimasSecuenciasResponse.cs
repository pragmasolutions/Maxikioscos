using System.Runtime.Serialization;

namespace MaxiKioscos.Services.Contracts
{
    [DataContract]
    public class ObtenerSecuenciasResponse
    {
        [DataMember]
        public int UltimaSecuenciaAcusada { get; set; }

        [DataMember]
        public int UltimaSecuenciaExportacion { get; set; }
    }
}
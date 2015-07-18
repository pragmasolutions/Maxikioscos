using System;
using System.Runtime.Serialization;

namespace MaxiKioscos.Services.Contracts
{
    [DataContract]
    public class ObtenerDatosRequest
    {
        [DataMember]
        public Guid UsuarioIdentifier { get; set; }

        [DataMember]
        public Guid MaxiKioscoIdentifier { get; set; }

        [DataMember]
        public int? UltimaSecuenciaExportacion { get; set; }
    }
}
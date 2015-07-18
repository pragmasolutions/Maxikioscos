using System;
using System.Runtime.Serialization;

namespace MaxiKioscos.Services.Contracts
{
    [DataContract]
    public class ReportarErrorRequest
    {
        [DataMember]
        public string Nombre { get; set; }

        [DataMember]
        public string Apellido { get; set; }

        [DataMember]
        public string Mensaje { get; set; }

        [DataMember]
        public Guid UsuarioIdentifier { get; set; }

        [DataMember]
        public string Titulo { get; set; }

        [DataMember]
        public string Email { get; set; }

        [DataMember]
        public string WebUrl { get; set; }
    }
}
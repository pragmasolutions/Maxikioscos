using System;
using System.Runtime.Serialization;

namespace MaxiKioscos.Services.Contracts
{
    [DataContract]
    public class KioscoAsignadoResponse
    {
        [DataMember]
        public System.Guid Identifier { get; set; }

        [DataMember]
        public string Nombre { get; set; }

        [DataMember]
        public string Direccion { get; set; }

        [DataMember]
        public string Telefono { get; set; }
        
        [DataMember]
        public string Abreviacion { get; set; }
    }
}
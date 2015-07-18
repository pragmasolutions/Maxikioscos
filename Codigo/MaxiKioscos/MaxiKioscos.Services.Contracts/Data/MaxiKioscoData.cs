using System;
using System.Runtime.Serialization;

namespace MaxiKioscos.Services.Contracts
{
    [DataContract]
    public class MaxiKioscoData
    {
        [DataMember]
        public Guid Guid { get; set; }

        [DataMember]
        public string Nombre { get; set; }

        [DataMember]
        public bool Asignado { get; set; }
    }
}
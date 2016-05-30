using System;
using System.Runtime.Serialization;

namespace MaxiKioscos.Services.Contracts
{
    [DataContract]
    public class UsuarioApiResponse
    {

        [DataMember]
        public int UsuarioId { get; set; }
        
        [DataMember]
        public string Usuario { get; set; }
    }
}
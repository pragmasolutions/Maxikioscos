using System;
using System.Runtime.Serialization;

namespace MaxiKioscos.Services.Contracts
{
    [DataContract]
    public class KioscoApiResponse
    {
        [DataMember]
        public System.Guid Identifier { get; set; }

        [DataMember]
        public string MachineName { get; set; }
    }
}
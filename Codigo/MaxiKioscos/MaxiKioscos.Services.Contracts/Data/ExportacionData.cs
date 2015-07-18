using System.Runtime.Serialization;

namespace MaxiKioscos.Services.Contracts
{
    [DataContract]
    public class ExportacionData
    {
        [DataMember]
        public int Secuencia { get; set; }

        [DataMember]
        public string Archivo { get; set; }
    }
}
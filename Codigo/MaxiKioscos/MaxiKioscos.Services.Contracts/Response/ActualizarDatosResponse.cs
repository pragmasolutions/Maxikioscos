using System.Runtime.Serialization;

namespace MaxiKioscos.Services.Contracts
{
    [DataContract]
    public class ActualizarDatosResponse
    {
        [DataMember]
        public bool Exito { get; set; }

        [DataMember]
        public string MensageError { get; set; }

        [DataMember]
        public int UltimaSecuenciaExitosa { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaxiKioscos.Web.Models.DTO
{
    public class ArchivoKioscoDTO
    {
        public Guid MaxiKioscoIdentifier { get; set; }
        public int Secuencia { get; set; }
        public string NombreCompleto { get; set; }

        public ArchivoKioscoDTO(string filename)
        {
            //formato: {GUID} EXP-{SECUENCIA} {Fecha}
            var partes = filename.Split(' ');
            MaxiKioscoIdentifier = Guid.Parse(partes[0]);
            Secuencia = int.Parse(partes[1].Split('-')[1]);
            NombreCompleto = filename;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaxiKioscos.Winforms.DataStruct
{
    public class ArchivoPrincipalStruct
    {
        public string NombreArchivo { get; set; }
        public int Secuencia { get; set; }

        public ArchivoPrincipalStruct(string filename)
        {
            //formato: EXP-{SECUENCIA} {Fecha}
            NombreArchivo = filename;
            Secuencia = int.Parse(filename.Split(' ')[0].Split('-')[1]);
        }
    }
}

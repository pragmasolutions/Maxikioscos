using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MaxiKioscos.Web.Models.DTO
{
    [Serializable]
    public class ImportacionDTO
    {
        public XmlDTO[] Xmls { get; set; }
        public int MaxiKioscoId { get; set; }
        public int? UltimaSecuencia { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MaxiKioscos.Web.Models.DTO
{
    [Serializable]
    public class XmlDTO
    {
        public int ExportacionId { get; set; }
        public string Content { get; set; }
    }
}
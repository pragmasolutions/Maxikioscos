using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MaxiKioscos.Mobile.Api.Models.Response
{
    public class StockControlResumeResponse
    {
        public int NroControl { get; set; }
        public string Proveedor { get; set; }
        public string Rubro { get; set; }
        public bool Cerrado { get; set; }
    }
}
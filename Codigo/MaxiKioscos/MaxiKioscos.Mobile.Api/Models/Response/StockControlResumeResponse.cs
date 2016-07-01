using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MaxiKioscos.Mobile.Api.Models.Response
{
    public class StockControlResumeResponse
    {
        public int StockControlId { get; set; }
        public int? NroControl { get; set; }
        public string Proveedor { get; set; }
        public string Rubro { get; set; }
        public int LimiteInferior { get; set; }
        public int LimiteSuperior { get; set; }
        public string Fecha { get; set; }
    }
}
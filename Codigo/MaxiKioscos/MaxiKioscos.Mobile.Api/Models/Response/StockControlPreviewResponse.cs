using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MaxiKioscos.Entidades;

namespace MaxiKioscos.Mobile.Api.Models.Response
{
    public class StockControlPreviewResponse
    {
        public string WarningMessage { get; set; }

        public ControlStockVistaPreviaRow[] List { get; set; }
    }
}
using MaxiKioscos.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
 
namespace MaxiKioscos.Mobile.Api.Models.Request
{
    public class StockControlDetailRequest : StockControlPreviewRequest
    {
        public int UserId { get; set; }
        public int LowerLimit { get; set; }
        public int UpperLimit { get; set; }
    }
}
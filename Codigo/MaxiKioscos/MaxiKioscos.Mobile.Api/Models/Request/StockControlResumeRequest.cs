using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MaxiKioscos.Mobile.Api.Models.Request
{
    public class StockControlResumeRequest
    {
        public Guid MaxikioscoIdentifier { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
    }
}
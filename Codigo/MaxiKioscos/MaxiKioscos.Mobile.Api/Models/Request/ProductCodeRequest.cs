using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MaxiKioscos.Mobile.Api.Models.Request
{
    public class ProductCodeRequest
    {
        public string Code { get; set; }
        public Guid MaxikioscoId { get; set; }
    }
}
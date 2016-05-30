﻿using MaxiKioscos.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
 
namespace MaxiKioscos.Mobile.Api.Models.Request
{
    public class StockControlCreateRequest : StockControlDetailRequest 
    {
        public List<StockControlDetalleRowRequest> ControlStockDetalle { get; set; }
    }
}
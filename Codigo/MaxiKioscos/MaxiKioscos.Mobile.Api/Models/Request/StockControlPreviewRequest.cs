using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MaxiKioscos.Mobile.Api.Models.Request
{
    public class StockControlPreviewRequest
    {
        public Guid ShopIdentifier { get; set; }
        public int? ProviderId { get; set; }
        public int? ProductCategoryId { get; set; }
        public bool ExcludeZeroStock { get; set; }
        public bool OnlyBestSellers { get; set; }
        public int? RowsAmount { get; set; }
    }
}
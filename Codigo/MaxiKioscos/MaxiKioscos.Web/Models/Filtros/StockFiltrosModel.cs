using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Routing;
using MaxiKioscos.Entidades;
using MaxiKioscos.Reportes.Enumeraciones;
using MaxiKioscos.Web.Models.Filtros;

namespace MaxiKioscos.Web.Models
{
    public class StockFiltrosModel : FilterBaseModel<Stock>
    {
        [DisplayName("Producto")]
        public string ProductoDescripcion { get; set; }
        
        [DisplayName("MaxiKiosco")]
        [UIHint("MaxiKiosco")]
        public int? MaxiKioscoId { get; set; }

        [DisplayName("Necesita Reposicion")]
        [UIHint("NecesitaReposicion")]
        public bool? NecesitaReposicion { get; set; }

        [DisplayName("Proveedor")]
        [UIHint("Proveedor")]
        public int? ProveedorId { get; set; }

        
        public override Expression<Func<Stock, bool>> GetFilterExpression()
        {
            return null;
        }

        public override RouteValueDictionary GetRouteValues(int page = 1)
        {
            var routeValues = base.GetRouteValues(page);
            routeValues.Add("MaxiKioscoId", this.MaxiKioscoId);
            routeValues.Add("ProductoDescripcion", this.ProductoDescripcion);
            routeValues.Add("NecesitaReposicion", this.NecesitaReposicion);
            routeValues.Add("ProveedorId", this.ProveedorId);
            return routeValues;
        }
    }
}
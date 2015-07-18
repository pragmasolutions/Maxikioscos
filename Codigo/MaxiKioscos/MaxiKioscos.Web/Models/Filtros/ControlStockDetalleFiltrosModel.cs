using System;
using System.Collections.Generic;
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
    public class ControlStockDetalleFiltrosModel : FilterBaseModel<ControlStockDetalle>
    {
        public Guid CurrentRowId { get; set; } 

        [Display(Name = "Producto")]
        public string Descripcion { get; set; }

        public int ControlStockId { get; set; }

        public override Expression<Func<ControlStockDetalle, bool>> GetFilterExpression()
        {
            return p => p.ControlStockId == this.ControlStockId
                && (string.IsNullOrEmpty(this.Descripcion) || p.Stock.Producto.Descripcion.Contains(this.Descripcion));
        }

        public override RouteValueDictionary GetRouteValues(int page = 1)
        {
            var routeValues = base.GetRouteValues(page);
            routeValues.Add("Descripcion", this.Descripcion);
            routeValues.Add("ControlStockId", this.ControlStockId);
            return routeValues;
        }
    }
}
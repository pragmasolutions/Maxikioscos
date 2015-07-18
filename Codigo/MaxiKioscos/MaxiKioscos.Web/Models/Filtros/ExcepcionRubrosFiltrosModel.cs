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
    public class ExcepcionRubrosFiltrosModel : FilterBaseModel<ExcepcionRubro>
    {
        [Display(Name = "Rubro")]
        public string Rubro { get; set; }

        [DisplayName("MaxiKiosco")]
        [UIHint("MaxiKiosco")]
        public int? MaxiKioscoId { get; set; }

        public override Expression<Func<ExcepcionRubro, bool>> GetFilterExpression()
        {
            return p => (string.IsNullOrEmpty(this.Rubro)|| p.Rubro.Descripcion.Contains(this.Rubro))
                        && (!this.MaxiKioscoId.HasValue || p.MaxiKioscoId == this.MaxiKioscoId);
        }

        public override RouteValueDictionary GetRouteValues(int page = 1)
        {
            var routeValues = base.GetRouteValues(page);
            routeValues.Add("MaxiKioscoId", this.MaxiKioscoId);
            routeValues.Add("Rubro", this.Rubro);
            return routeValues;
        }
    }
}
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
    public class ExcepcionesFiltrosModel : FilterBaseModel<Excepcion>
    {
        [DisplayName("Desde")]
        [UIHint("Date")]
        public DateTime? Desde { get; set; }

        [DisplayName("Hasta")]
        [UIHint("Date")]
        public DateTime? Hasta { get; set; }

        [DisplayName("MaxiKiosco")]
        [UIHint("MaxiKiosco")]
        public int? MaxiKioscoId { get; set; }

        public override Expression<Func<Excepcion, bool>> GetFilterExpression()
        {
            DateTime? fin = this.Hasta.HasValue ? this.Hasta.Value.AddDays(1) : (DateTime?)null;
            return f => (!this.Desde.HasValue || this.Desde.Value <= f.CierreCaja.FechaInicio)
                        && (!this.Hasta.HasValue || fin >= f.CierreCaja.FechaInicio)
                        && (!this.MaxiKioscoId.HasValue || this.MaxiKioscoId == f.CierreCaja.MaxiKioskoId);
        }

        public override RouteValueDictionary GetRouteValues(int page = 1)
        {
            var routeValues = base.GetRouteValues(page);
            routeValues.Add("Desde", this.Desde == null ? (string)null : this.Desde.GetValueOrDefault().ToShortDateString());
            routeValues.Add("Hasta", this.Hasta == null ? (string)null : this.Hasta.GetValueOrDefault().ToShortDateString());
            routeValues.Add("MaxiKioscoId", this.MaxiKioscoId);
            return routeValues;
        }
    }
}
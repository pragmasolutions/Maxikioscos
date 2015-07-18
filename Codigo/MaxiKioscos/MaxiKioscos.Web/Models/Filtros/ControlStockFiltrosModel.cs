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
    public class ControlStockFiltrosModel : FilterBaseModel<ControlStock>
    {
        [DisplayName("Nro Control")]
        public string NroControl { get; set; }
        
        [DisplayName("MaxiKiosco")]
        [UIHint("MaxiKiosco")]
        public int? MaxiKioscoId { get; set; }

        [DisplayName("Rubro")]
        [UIHint("Rubro")]
        public int? RubroId { get; set; }

        [DisplayName("Proveedor")]
        [UIHint("Proveedor")]
        public int? ProveedorId { get; set; }

        [DisplayName("Estado")]
        [UIHint("EstadoControlStock")]
        public int? Estado { get; set; }

        [DisplayName("Desde")]
        [UIHint("Date")]
        public DateTime? Desde { get; set; }

        [DisplayName("Hasta")]
        [UIHint("Date")]
        public DateTime? Hasta { get; set; }


        public override Expression<Func<ControlStock, bool>> GetFilterExpression()
        {
            return cs => (!this.RubroId.HasValue || this.RubroId.Value == cs.RubroId)
                                && (!this.MaxiKioscoId.HasValue || this.MaxiKioscoId.Value == cs.MaxiKioscoId)
                                && (!this.ProveedorId.HasValue || this.ProveedorId.Value == cs.ProveedorId)
                                && (!this.Desde.HasValue || this.Desde.Value <= cs.FechaCreacion)
                                && (!this.Hasta.HasValue || this.Hasta.Value >= cs.FechaCreacion)
                                && (!this.Estado.HasValue ||
                                    ((this.Estado.Value == 1 && cs.Cerrado) || (this.Estado.Value == 0 && !cs.Cerrado)));
        }

        public override RouteValueDictionary GetRouteValues(int page = 1)
        {
            var routeValues = base.GetRouteValues(page);
            routeValues.Add("MaxiKioscoId", this.MaxiKioscoId);
            routeValues.Add("NroControl", this.NroControl);
            routeValues.Add("RubroId", this.RubroId);
            routeValues.Add("ProveedorId", this.ProveedorId);
            routeValues.Add("Desde", this.Desde == null ? (string)null : this.Desde.GetValueOrDefault().ToShortDateString());
            routeValues.Add("Hasta", this.Hasta == null ? (string)null : this.Hasta.GetValueOrDefault().ToShortDateString());
            routeValues.Add("Estado", this.Estado);
            return routeValues;
        }
    }
}
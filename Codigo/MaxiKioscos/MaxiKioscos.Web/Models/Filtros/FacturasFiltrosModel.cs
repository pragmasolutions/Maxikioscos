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
    public class FacturasFiltrosModel : FilterBaseModel<Factura>
    {
        [DisplayName("Desde")]
        [UIHint("Date")]
        public DateTime? Desde { get; set; }

        [DisplayName("Hasta")]
        [UIHint("Date")]
        public DateTime? Hasta { get; set; }

        [DisplayName("Proveedor")]
        [UIHint("Proveedor")]
        public int? ProveedorId { get; set; }

        [DisplayName("Factura Nro")]
        public string FacturaNro { get; set; }

        [DisplayName("MaxiKiosco")]
        [UIHint("MaxiKiosco")]
        public int? MaxiKioscoId { get; set; }

        [DisplayName("Tiene Compra")]
        [UIHint("TieneCompra")]
        public bool? TieneCompra { get; set; }

        [DisplayName("Finalizada")]
        [UIHint("FacturaFinalizada")]
        public bool? Finalizada { get; set; }
        
        public override Expression<Func<Factura, bool>> GetFilterExpression()
        {
            return f => (!this.Desde.HasValue || this.Desde.Value <= f.Fecha)
                        && (!this.Hasta.HasValue || this.Hasta.Value >= f.Fecha)
                        && (!this.ProveedorId.HasValue || this.ProveedorId.Value == f.ProveedorId)
                        && (!this.MaxiKioscoId.HasValue || this.MaxiKioscoId == f.MaxiKioscoId)
                        && (!this.TieneCompra.HasValue || this.TieneCompra == f.Compras.Any())
                        && (!this.Finalizada.HasValue || this.Finalizada == f.Finalizada);
        }

        public override RouteValueDictionary GetRouteValues(int page = 1)
        {
            var routeValues = base.GetRouteValues(page);
            routeValues.Add("Desde", this.Desde == null ? (string)null : this.Desde.GetValueOrDefault().ToShortDateString());
            routeValues.Add("FacturaNro", this.FacturaNro);
            routeValues.Add("Hasta", this.Hasta == null ? (string)null : this.Hasta.GetValueOrDefault().ToShortDateString());
            routeValues.Add("MaxiKioscoId", this.MaxiKioscoId);
            routeValues.Add("ProveedorId", this.ProveedorId);
            routeValues.Add("TieneCompra", this.TieneCompra);
            return routeValues;
        }
    }
}
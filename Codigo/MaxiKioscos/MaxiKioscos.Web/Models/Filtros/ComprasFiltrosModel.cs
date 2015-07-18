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
    public class ComprasFiltrosModel : FilterBaseModel<Compra>
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

        [DisplayName("Factura Nro, Autonúmero")]
        public string Nro { get; set; }
        
        public override Expression<Func<Compra, bool>> GetFilterExpression()
        {
            return c => (!this.Desde.HasValue || this.Desde.Value <= c.Fecha)
                        && (!this.Hasta.HasValue || this.Hasta.Value >= c.Fecha)
                        && (!this.ProveedorId.HasValue || this.ProveedorId.Value == c.Factura.ProveedorId)
                        && (string.IsNullOrEmpty(this.Nro) || c.Factura.FacturaNro.StartsWith(this.Nro)
                            || c.Numero.StartsWith(this.Nro));
        }

        public override RouteValueDictionary GetRouteValues(int page = 1)
        {
            var routeValues = base.GetRouteValues(page);
            routeValues.Add("Desde", this.Desde == null ? (string)null : this.Desde.GetValueOrDefault().ToShortDateString());
            routeValues.Add("Nro", this.Nro);
            routeValues.Add("Hasta", this.Hasta == null ? (string)null : this.Hasta.GetValueOrDefault().ToShortDateString());
            routeValues.Add("ProveedorId", this.ProveedorId);
            return routeValues;
        }
    }
}
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
    public class TransferenciasFiltrosModel : FilterBaseModel<Transferencia>
    {
        [DisplayName("Desde")]
        [UIHint("Date")]
        public DateTime? Desde { get; set; }

        [DisplayName("Hasta")]
        [UIHint("Date")]
        public DateTime? Hasta { get; set; }

        [DisplayName("Origen")]
        [UIHint("MaxiKiosco")]
        public int? OrigenId { get; set; }

        [DisplayName("Destino")]
        [UIHint("MaxiKiosco")]
        public int? DestinoId { get; set; }

        [DisplayName("Número")]
        public string Nro { get; set; }

        [DisplayName("Estado")]
        [UIHint("TransferenciaEstado")]
        public bool? Aprobadas { get; set; }
        
        public override Expression<Func<Transferencia, bool>> GetFilterExpression()
        {
            int nro = 0;
            var hayNro = int.TryParse(this.Nro, out nro);

            return c => (!this.Desde.HasValue || this.Desde.Value <= c.FechaCreacion)
                        && (!this.Hasta.HasValue || this.Hasta.Value >= c.FechaCreacion)
                        && (!this.OrigenId.HasValue || this.OrigenId.Value == c.OrigenId)
                        && (!this.DestinoId.HasValue || this.DestinoId.Value == c.DestinoId)
                        && (!this.Aprobadas.HasValue || ((!this.Aprobadas.Value && c.FechaAprobacion == null) || (this.Aprobadas.Value && c.FechaAprobacion != null)))
                        && (string.IsNullOrEmpty(this.Nro) || (hayNro && c.TransferenciaId == nro));
        }

        public override RouteValueDictionary GetRouteValues(int page = 1)
        {
            var routeValues = base.GetRouteValues(page);
            routeValues.Add("Desde", this.Desde == null ? (string)null : this.Desde.GetValueOrDefault().ToShortDateString());
            routeValues.Add("Nro", this.Nro);
            routeValues.Add("Hasta", this.Hasta == null ? (string)null : this.Hasta.GetValueOrDefault().ToShortDateString());
            routeValues.Add("OrigenId", this.OrigenId);
            routeValues.Add("DestinoId", this.DestinoId);
            routeValues.Add("Aprobadas", this.Aprobadas);
            return routeValues;
        }
    }
}
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
    public class TicketErrorFiltrosModel : FilterBaseModel<TicketError>
    {
        [DisplayName("Ticket Nro")]
        public string TicketNro { get; set; }

        [DisplayName("Estado")]
        [UIHint("TicketErrorEstado")]
        public EstadoTicketEnum? EstadoId { get; set; }

        [DisplayName("Título")]
        public string Titulo { get; set; }
        
        public override Expression<Func<TicketError, bool>> GetFilterExpression()
        {
            int id = string.IsNullOrEmpty(this.TicketNro) ? 0 : Convert.ToInt32(this.TicketNro);
            return t => (!this.EstadoId.HasValue || this.EstadoId.Value == t.EstadoTicketId)
                        && (string.IsNullOrEmpty(this.Titulo) || t.Titulo.Contains(this.Titulo))
                        && (string.IsNullOrEmpty(this.TicketNro) || t.TicketErrorId.Equals(id));
        }

        public override RouteValueDictionary GetRouteValues(int page = 1)
        {
            var routeValues = base.GetRouteValues(page);
            routeValues.Add("EstadoId", this.EstadoId);
            routeValues.Add("TicketNro", this.TicketNro);
            routeValues.Add("Descripcion", this.Titulo);
            return routeValues;
        }
    }
}
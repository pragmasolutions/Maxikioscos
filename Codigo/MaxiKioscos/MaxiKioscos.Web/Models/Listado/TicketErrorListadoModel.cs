using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using MaxiKioscos.Entidades;
using PagedList;

namespace MaxiKioscos.Web.Models
{
    public class TicketErrorListadoModel
    {
        [DisplayName("Ticket Nro")]
        public string TicketNro { get; set; }

        [DisplayName("Título")]
        public string Titulo { get; set; }

        [DisplayName("Estado")]
        [UIHint("TicketErrorEstado")]
        public EstadoTicketEnum? EstadoId { get; set; }

        public IPagedList<TicketError> List { get; set; }
        
        public TicketErrorFiltrosModel Filtros { get; set; }
    }
}
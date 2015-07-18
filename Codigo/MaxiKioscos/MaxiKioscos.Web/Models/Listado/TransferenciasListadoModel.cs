using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using MaxiKioscos.Entidades;
using PagedList;

namespace MaxiKioscos.Web.Models
{
    public class TransferenciasListadoModel
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

        [DisplayName("Autonúmero")]
        public string Nro { get; set; }

        [DisplayName("Estado")]
        public bool? Aprobadas { get; set; }

        public IPagedList<Transferencia> List { get; set; }
        
        public TransferenciasFiltrosModel Filtros { get; set; }
    }
}
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using MaxiKioscos.Entidades;
using PagedList;

namespace MaxiKioscos.Web.Models
{
    public class ControlStockListadoModel
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

        [DisplayName("Desde")]
        [UIHint("Date")]
        public DateTime? Desde { get; set; }

        [DisplayName("Hasta")]
        [UIHint("Date")]
        public DateTime? Hasta { get; set; }

        [DisplayName("Estado")]
        [UIHint("EstadoControlStock")]
        public int? Estado { get; set; }

        public IPagedList<ControlStock> List { get; set; }

        public ControlStockFiltrosModel Filtros { get; set; }
    }
}
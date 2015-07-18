using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using MaxiKioscos.Entidades;
using PagedList;

namespace MaxiKioscos.Web.Models
{
    public class ComprasListadoModel
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

        public IPagedList<Compra> List { get; set; }
        
        public ComprasFiltrosModel Filtros { get; set; }
    }
}
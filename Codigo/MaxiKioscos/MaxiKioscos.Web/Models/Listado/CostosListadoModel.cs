using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using MaxiKioscos.Entidades;
using PagedList;

namespace MaxiKioscos.Web.Models
{
    public class CostosListadoModel
    {
        [DisplayName("Desde")]
        [UIHint("Date")]
        public DateTime? Desde { get; set; }

        [DisplayName("Hasta")]
        [UIHint("Date")]
        public DateTime? Hasta { get; set; }

        [DisplayName("Usuario")]
        [UIHint("Usuario")]
        public int? UsuarioId { get; set; }

        [DisplayName("Nro Comprobante")]
        public string NroComprobante { get; set; }

        [DisplayName("MaxiKiosco")]
        [UIHint("MaxiKiosco")]
        public int? MaxiKioscoId { get; set; }

        [DisplayName("Estado")]
        [UIHint("CostoEstado")]
        public bool? Estado { get; set; }

        [DisplayName("Categoría")]
        [UIHint("CategoriaCostoId")]
        public int? CategoriaCostoId { get; set; }

        public IPagedList<Costo> List { get; set; }
        
        public CostosFiltrosModel Filtros { get; set; }
    }
}
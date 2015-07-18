using System;
using System.ComponentModel.DataAnnotations;
using MaxiKioscos.Entidades;
using PagedList;

namespace MaxiKioscos.Web.Models
{
    public class PromocionesListadoModel
    {
        [Display(Name = "Rubro")]
        [UIHint("Rubro")]
        public int? RubroId { get; set; }

        [Display(Name = "Descripcion")]
        public string Descripcion { get; set; }

        [Display(Name = "Precio")]
        [DataType(DataType.Currency)]
        public decimal? Precio { get; set; }

        [Display(Name = "Stock reposicion")]
        public int? StockReposicion { get; set; }

        [Display(Name = "Código")]
        public string Codigo { get; set; }

        public IPagedList<Producto> List { get; set; }

        public PromocionesFiltrosModel Filtros { get; set; }
    }
}
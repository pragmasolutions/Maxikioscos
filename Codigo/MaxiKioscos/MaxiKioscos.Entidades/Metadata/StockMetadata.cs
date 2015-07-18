using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MaxiKioscos.Entidades
{
    [MetadataType(typeof(ProductoMaxiKioscoMetadata))]
    public partial class Stock : IEntity ,ISynchronizableEntity
    {
    }

    public class ProductoMaxiKioscoMetadata
    {
        [Display(Name = "Producto")]
        public int ProductoId { get; set; }

        [Display(Name = "Maxikiosco")]
        [UIHint("MaxiKiosco")]
        public int MaxiKioscoId { get; set; }

        //[Display(Name = "Stock reposición")]
        //public int? StockReposicion { get; set; }

        [Display(Name = "Stock actual")]
        [Required(ErrorMessage = "Debe ingresar un valor para el stock")]
        public decimal StockActual { get; set; }
    }
}

using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace MaxiKioscos.Entidades
{
    [MetadataType(typeof(ProductoPromocionMetadata))]
    public partial class ProductoPromocion : IEntity, ISynchronizableEntity
    {
        
    }

    public class ProductoPromocionMetadata
    {
        [Display(Name = "Unidades")]
        [Required(ErrorMessage = "Debe ingresar las unidades")]
        [Range(1, int.MaxValue, ErrorMessage = "Debe ingresar una cantidad mayor a 0")]
        public int Unidades { get; set; }

        [Display(Name = "Producto")]
        [Required(ErrorMessage = "Debe selecccionar un producto")]
        [UIHint("ProductoSinPromociones")]
        public int HijoId { get; set; }
    }
}

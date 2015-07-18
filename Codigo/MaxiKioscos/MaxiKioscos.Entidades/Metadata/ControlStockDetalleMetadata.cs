using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MaxiKioscos.Entidades
{
    [MetadataType(typeof(ControlStockDetalleMetadata))]
    public partial class ControlStockDetalle : IEntity
    {
        public string ProductoNombre
        {
            get { return Stock.Producto.Descripcion; }
        }

        public string MotivoCorreccionNombre
        {
            get
            {
                if (MotivoCorreccionId == null)
                    return string.Empty;
                return MotivoCorreccion.Descripcion;
            }
        }
    }

    public class ControlStockDetalleMetadata 
    {
        [Display(Name = "Motivo")]
        [Required(ErrorMessage = "Debe ingresar un motivo")]
        [UIHint("MotivoCorreccion")]
        public int? MotivoCorreccionId { get; set; }

        [Display(Name = "Diferencia")]
        [Required(ErrorMessage = "Debe ingresar la cantidad faltante/sobrante")]
        [UIHint("PositiveDecimal")]
        public decimal? Correccion { get; set; }
    }
}

using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace MaxiKioscos.Entidades
{
    [MetadataType(typeof(CompraMetadata))]
    public partial class Compra : IEntity, ISynchronizableEntity
    {
        public decimal Total
        {
            get { return this.ComprasProductos.Sum(cp => cp.Cantidad * cp.CostoActualizado) ?? 0; }
        }

        public decimal TotalConDescuento
        {
            get { return this.Total + this.Descuento; }
        }

        public decimal TotalGeneral
        {
            get { return this.TotalConDescuento + this.PercepcionDGR + this.PercepcionIVA; }
        }
    }

    public class CompraMetadata
    {
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Debe ingresar la fecha de compra")]
        public DateTime Fecha { get; set; }

        [Display(Name = "Número")]
        [Required(ErrorMessage = "Debe ingresar el número de compra")]
        [StringLength(25,MinimumLength = 1,ErrorMessage = "El número de compra no puede ser menor a 25 caracteres")]
        [UIHint("NumeroFactura")]
        public string Numero { get; set; }

        [Display(Name = "Factura")]
        [UIHint("FacturaCompra")]
        [Required(ErrorMessage = "Debe ingresar una factura")]
        public int FacturaId { get; set; }

        [Display(Name = "Percepción IVA")]
        [DataType(DataType.Currency)]
        public decimal PercepcionIVA { get; set; }

        [Display(Name = "Percepción DGR")]
        [DataType(DataType.Currency)]
        public decimal PercepcionDGR { get; set; }
    }
}

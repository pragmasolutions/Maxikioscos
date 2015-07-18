using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace MaxiKioscos.Entidades
{
    [MetadataType(typeof(FacturaMetadata))]
    public partial class Factura : IEntity
    {
        public string NombreCompleto
        {
            get
            {
                if (string.IsNullOrEmpty(FacturaNro))
                    return string.Empty;
                return String.Format("{0} - {1} ({2})", FacturaNro, ProveedorNombre, NombreUsuario);
            }
        }

        public string ProveedorNombre
        {
            get
            {
                if (Proveedor == null)
                    return string.Empty;
                return Proveedor.Nombre;
            }
        }


        public bool TieneCompra
        {
            get { return this.Compras.Any(); }
        }

        public string NombreUsuario
        {
            get
            {
                if (UsuarioCreador == null)
                    return string.Empty;
                return UsuarioCreador.NombreUsuario;
            }
        }

        
        public decimal? DescuentoPorcentaje { get; set; }
        public decimal? DescuentoEnPesos { get; set; }
    }

    public class FacturaMetadata
    {
        [DisplayName("Fecha")]
        [UIHint("Date")]
        [Required(ErrorMessage = "Debe ingresar una fecha de factura")]
        public DateTime Fecha { get; set; }

        [DisplayName("Proveedor")]
        [Required(ErrorMessage = "Debe ingresar un proveedor")]
        public int ProveedorId { get; set; }

        [DisplayName("Factura Nro")]
        [Required(ErrorMessage = "Debe ingresar un número de factura")]
        public string FacturaNro { get; set; }

        [DisplayName("Importe Total")]
        [UIHint("Currency")]
        [Required(ErrorMessage = "Debe ingresar un importe")]
        [Range(1, double.MaxValue, ErrorMessage = "Debe ingresar un importe")]
        public decimal ImporteTotal { get; set; }

        [DisplayName("MaxiKiosco")]
        [Required(ErrorMessage = "Debe ingresar un maxikiosco")]
        public int MaxiKioscoId { get; set; }

        [Display(Name = "Descuento porcentaje")]
        [DisplayFormat(DataFormatString = "{0:N2}")]
        [UIHint("Percentage")]
        [Range(0, 100, ErrorMessage = "El descuento debe se un valor entre 0 y 100")]
        public decimal? DescuentoPorcentaje { get; set; }

        [Display(Name = "Descuento en pesos")]
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal? DescuentoEnPesos { get; set; }
    }
}

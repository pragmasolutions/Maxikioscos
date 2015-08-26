using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using MaxiKiosco.Win.Util;

namespace MaxiKioscos.Entidades
{
    [MetadataType(typeof(ProveedorMetadata))]
    public partial class Proveedor : IEntity, IComboBoxDataSourceItem
    {
        public string LocalidadString {
            get 
            {
                if (this.Localidad == null)
                {
                    return "";
                }
                else
                {
                    return this.Localidad.Descripcion;
                }
            }
        }
        public string TipoCuitString
        {
            get
            {
                if (this.TipoCuit == null)
                {
                    return "";
                }
                else
                {
                    return this.TipoCuit.Descripcion;
                }
            }
        }

        #region IComboBoxDataSourceItem Members

        public int GetValue()
        {
            return ProveedorId;
        }

        public string GetText()
        {
            return Nombre;
        }

        #endregion
    }

    public class ProveedorMetadata
    {
        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "Debe ingresar una nombre")]
        public string Nombre { get; set; }

        [Display(Name = "Contacto")]
        public string Contacto { get; set; }

        [Display(Name = "Dirección")]
        [Required(ErrorMessage = "Debe ingresar una dirección")]
        public string Direccion { get; set; }

        [Display(Name = "Localidad")]
        [UIHint("Localidad")]
        public int? LocalidadId { get; set; }

        [Display(Name = "Teléfono")]
        [Required(ErrorMessage = "Debe ingresar un teléfono")]
        public string Telefono { get; set; }

        [Display(Name = "Celular")]
        public string Celular { get; set; }

        [Display(Name = "Tipo de Cuit")]
        [UIHint("TipoCuit")]
        [Required(ErrorMessage = "Debe ingresar un tipo de cuit")]
        public int? TipoCuitId { get; set; }

        [Display(Name = "Nro Cuit")]
        [Required(ErrorMessage = "Debe ingresar un nro cuit")]
        [RegularExpression(@"^(20|23|27|30|33)-[0-9]{8}-[0-9]$", ErrorMessage = "El número de cuit no es válido")]
        public string CuitNro { get; set; }

        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name = "Página Web")]
        [DataType(DataType.Url,ErrorMessage = "La pagina web ingresada no es válida")]
        public string PaginaWeb { get; set; }

        [Display(Name = "Observaciones")]
        [DataType(DataType.MultilineText)]
        public string Observaciones { get; set; }

        [Display(Name = "Percepción DGR")]
        [UIHint("Percentage")]
        public decimal? PercepcionDGR { get; set; }

        [Display(Name = "Aplica percepción IVA")]
        public bool AplicaPercepcionIVA { get; set; }

        [Display(Name = "No reflejar facturas en caja")]
        public bool NoReflejarFacturaEnCaja { get; set; }

        [Display(Name = "Tipo de Comprobante")]
        [UIHint("TipoComprobante")]
        public string TipoComprobante { get; set; }
    }
}

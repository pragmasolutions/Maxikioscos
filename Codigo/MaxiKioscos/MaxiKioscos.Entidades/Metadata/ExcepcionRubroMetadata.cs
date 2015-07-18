using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MaxiKioscos.Entidades
{
    [MetadataType(typeof(ExcepcionRubroMetadata))]
    public partial class ExcepcionRubro : IEntity
    {
        public string DesdeHora
        {
            get { return new DateTime(1,1,1,0,0,0).Add(Desde).ToShortTimeString(); }
        }

        public string HastaHora
        {
            get { return new DateTime(1, 1, 1, 0, 0, 0).Add(Hasta).ToShortTimeString(); }
        }
    }

    public class ExcepcionRubroMetadata 
    {
        [Display(Name = "Rubro")]
        [UIHint("Rubro")]
        [Required(ErrorMessage = "Debe ingresar un rubro")]
        public int RubroId { get; set; }

        [Display(Name = "Maxikiosco")]
        [Required(ErrorMessage = "Debe ingresar un maxikiosco")]
        [UIHint("MaxiKiosco")]
        public int MaxiKioscoId { get; set; }

        [Display(Name = "Desde")]
        [Required(ErrorMessage = "Debe ingresar una hora desde")]
        [DataType(DataType.Time)]
        public TimeSpan Desde { get; set; }

        [Display(Name = "Hasta")]
        [Required(ErrorMessage = "Debe ingresar una hora hasta")]
        [DataType(DataType.Time)]
        public TimeSpan Hasta { get; set; }

        [Display(Name = "Recargo absoluto")]
        [DataType(DataType.Currency)]
        [UIHint("NegativeCurrency")]
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal? RecargoAbsoluto { get; set; }

        [Display(Name = "Recargo porcentaje")]
        [UIHint("NegativePercentage")]
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal? RecargoPorcentaje { get; set; }
    }
}

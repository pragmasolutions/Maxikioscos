using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace MaxiKioscos.Entidades
{
    [MetadataType(typeof(PromocionMaxikioscoMetadata))]
    public partial class PromocionMaxikiosco
    {
        public int MaxiKioscoId { get; set; }
        public string MaxiKioscoNombre { get; set; }
        public int StockAnterior { get; set; }
        public int StockActual { get; set; }
    }

    public class PromocionMaxikioscoMetadata
    {
        [Display(Name = "Stock Actual")]
        [Required(ErrorMessage = "Debe ingresar el stock")]
        [Range(0, int.MaxValue, ErrorMessage = "Debe ingresar una cantidad mayor o igual a 0")]
        public int StockActual { get; set; }
    }
}

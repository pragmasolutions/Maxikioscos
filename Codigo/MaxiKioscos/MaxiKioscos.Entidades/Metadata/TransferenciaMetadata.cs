using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace MaxiKioscos.Entidades
{
    [MetadataType(typeof(TransferenciaMetadata))]
    public partial class Transferencia : IEntity, ISynchronizableEntity
    {
        
    }

    public class TransferenciaMetadata
    {
        [Display(Name = "Número")]
        public int TransferenciaId { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Fecha Creación")]
        public DateTime FechaCreacion { get; set; }

        [Display(Name = "Origen")]
        [UIHint("MaxiKiosco")]
        [Required(ErrorMessage = "Debe ingresar un origen")]
        public int OrigenId { get; set; }

        [Display(Name = "Destino")]
        [UIHint("MaxiKiosco")]
        [Required(ErrorMessage = "Debe ingresar un destino")]
        public int DestinoId { get; set; }
    }
}

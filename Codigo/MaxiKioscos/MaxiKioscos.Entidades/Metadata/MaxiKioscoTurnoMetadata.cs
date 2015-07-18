using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using MaxiKioscos.Entidades;

namespace MaxiKioscos.Entidades
{
    [MetadataType(typeof(MaxiKioscoTurnoMetadata))]
    public partial class MaxiKioscoTurno : IEntity
    {
    }

    public class MaxiKioscoTurnoMetadata
    {
        [Display(Name = "Monto máximo de venta con tickets")]
        [DataType(DataType.Currency)]
        public decimal? MontoMaximoVentaConTickets { get; set; }
    }
}

using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using MaxiKiosco.Win.Util;

namespace MaxiKioscos.Entidades
{
    [MetadataType(typeof(CostoMetadata))]
    public partial class Costo : IEntity
    {
        public string Estado
        {
            get { return Aprobado ? "Aprobado" : "No aprobado"; }
        }
    }

    public class CostoMetadata
    {
        [DisplayName("Fecha")]
        [UIHint("Date")]
        public DateTime Fecha { get; set; }

        [DisplayName("Importe Total")]
        [UIHint("Currency")]
        [Required(ErrorMessage = "Debe ingresar un monto")]
        [Range(1, double.MaxValue, ErrorMessage = "Debe ingresar un monto")]
        public decimal Monto { get; set; }

    }
}

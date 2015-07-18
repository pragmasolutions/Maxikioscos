using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MaxiKioscos.Entidades
{
    [MetadataType(typeof(MaxiKioscoMetadata))]
    public partial class MaxiKiosco : IEntity
    {
    }

    public class MaxiKioscoMetadata
    {
        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "Debe ingresar un nombre")]
        public string Nombre { get; set; }

        [Display(Name = "Abreviación")]
        [Required(ErrorMessage = "Debe ingresar una abreviación")]
        public string Abreviacion { get; set; }

        [Display(Name = "Direccion")]
        [Required(ErrorMessage = "Debe ingresar una direccion")]
        public string Direccion { get; set; }

        [Display(Name = "Telefono")]
        public string Telefono { get; set; }

        [UIHint("BooleanSiNo")]
        [Display(Name = "Tiene Conexión")]
        public bool EstaOnLine { get; set; }
    }
}

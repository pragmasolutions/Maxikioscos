using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using MaxiKiosco.Win.Util;

namespace MaxiKioscos.Entidades
{
    [MetadataType(typeof(CategoriaCostoMetadata))]
    public partial class CategoriaCosto : IEntity
    {
       
    }

    public class CategoriaCostoMetadata
    {
        [Display(Name = "Descripción")]
        [Required(ErrorMessage = "Debe ingresar una descripción")]
        public string Descripcion { get; set; }

        [Display(Name = "Ocultar en Kiosco")]
        [Required(ErrorMessage = "Debe ingresar un valor")]
        public bool OcultarEnDesktop { get; set; }
    }
}

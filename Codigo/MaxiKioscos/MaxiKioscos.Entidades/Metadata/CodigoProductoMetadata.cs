using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace MaxiKioscos.Entidades
{
    [MetadataType(typeof(CodigoProductoMetadata))]
    public partial class CodigoProducto : IEntity
    {
        
    }

    public class CodigoProductoMetadata
    {
        [Display(Name = "Código")]
        [Required(ErrorMessage = "Debe ingresar un código")]
        [UIHint("Codigo")]
        public string Codigo { get; set; }
    }
}

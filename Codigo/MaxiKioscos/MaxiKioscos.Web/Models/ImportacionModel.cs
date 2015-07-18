using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MaxiKioscos.Web.Models
{
    public class ImportacionModel
    {
        [DisplayName("Seleccione Archivo")]
        [Required(ErrorMessage = "Debe seleccionar un archivo")]
        public string NombreArchivo { get; set; }
    }
}
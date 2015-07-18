using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using MaxiKioscos.Entidades;

namespace MaxiKioscos.Web.Models
{
    public class ExcepcionModel
    {
        [DisplayName("Fecha")]
        [Required(ErrorMessage = "Debe seleccionar una fecha")]
        [UIHint("Date")]
        public DateTime Fecha { get; set; }

        [DisplayName("Maxikiosco")]
        [Required(ErrorMessage = "Debe seleccionar un maxikiosco")]
        [UIHint("Maxikiosco")]
        public int MaxikioscoId { get; set; }

        public Excepcion Excepcion { get; set; }
    }
}
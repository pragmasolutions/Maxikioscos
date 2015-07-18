using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using MaxiKioscos.Entidades;

namespace MaxiKioscos.Web.Models
{
    public class TicketErrorModel
    {
        [DataType(DataType.MultilineText)]
        [DisplayName("Escribe un nuevo mensaje")]
        [Required(ErrorMessage = "Debes ingresar un mensaje")]
        public string NuevoMensaje { get; set; }
        
        public TicketError Ticket { get; set; }
    }
}
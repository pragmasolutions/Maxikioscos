using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using MaxiKioscos.Entidades;

namespace MaxiKioscos.Web.Models
{
    public class TransferirStockModel
    {
        public Stock Stock { get; set; }

        [Display(Name = "MaxiKiosco Destino")]
        [UIHint("MaxiKiosco")]
        [Required(ErrorMessage = "Debe seleccionar un destino")]
        public int DestinoId { get; set; }

        [Display(Name = "Unidades a transferir")]
        [Required(ErrorMessage = "Debe ingresar la cantidad de unidades a transferir")]
        [Range((double)0.01, Double.MaxValue, ErrorMessage = "Debe ingresar un valor mayor a cero")]
        public int Unidades { get; set; }
    }
}
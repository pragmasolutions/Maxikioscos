using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MaxiKioscos.Entidades;

namespace MaxiKioscos.Web.Models
{
    public class EstadoKioscosModel
    {
        public List<EstadoKiosco> Estados { get; set; }
        public int UltimaSecuenciaPrincipal { get; set; }
    }
}
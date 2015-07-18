using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MaxiKioscos.Entidades;
using MaxiKioscos.Reportes.Enumeraciones;
using PagedList;

namespace MaxiKioscos.Web.Models
{
    public class ReporteModel
    {
        public string Nombre { get; set; }

        public Dictionary<string, string> Parametros { get; set; }

        public Dictionary<string,object> DataSource { get; set; }

        public ReporteTipoEnum ReporteTipo { get; set; }
    }
}
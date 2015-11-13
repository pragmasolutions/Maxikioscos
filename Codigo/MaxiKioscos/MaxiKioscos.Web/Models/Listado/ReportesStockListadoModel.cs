using System.ComponentModel.DataAnnotations;
using MaxiKioscos.Entidades;
using PagedList;

namespace MaxiKioscos.Web.Models
{
    public class ReportesStockListadoModel
    {
        public IPagedList<ReporteStock> List { get; set; }
    }
}
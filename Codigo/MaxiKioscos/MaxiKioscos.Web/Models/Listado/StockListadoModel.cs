using System.ComponentModel.DataAnnotations;
using MaxiKioscos.Entidades;
using PagedList;

namespace MaxiKioscos.Web.Models
{
    public class StockListadoModel
    {
        public IPagedList<StockDto> List { get; set; }

        public StockFiltrosModel Filtros { get; set; }
    }
}
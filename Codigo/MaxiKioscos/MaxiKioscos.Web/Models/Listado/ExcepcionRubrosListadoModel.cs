using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using MaxiKioscos.Entidades;
using PagedList;

namespace MaxiKioscos.Web.Models
{
    public class ExcepcionRubrosListadoModel
    {
        [Display(Name = "Rubro")]
        public string Rubro { get; set; }

        [DisplayName("MaxiKiosco")]
        [UIHint("MaxiKiosco")]
        public int? MaxiKioscoId { get; set; }

        public IPagedList<ExcepcionRubro> List { get; set; }

        public ExcepcionRubrosFiltrosModel Filtros { get; set; }
    }
}
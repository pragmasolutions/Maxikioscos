using System.ComponentModel.DataAnnotations;
using MaxiKioscos.Entidades;
using PagedList;

namespace MaxiKioscos.Web.Models
{
    public class RubrosListadoModel
    {
        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }

        public IPagedList<Rubro> List { get; set; }

        public RubrosFiltrosModel Filtros { get; set; }
    }
}
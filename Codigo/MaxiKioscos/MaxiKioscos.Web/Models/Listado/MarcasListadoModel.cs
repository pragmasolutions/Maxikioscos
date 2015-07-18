using System.ComponentModel.DataAnnotations;
using MaxiKioscos.Entidades;
using PagedList;

namespace MaxiKioscos.Web.Models
{
    public class MarcasListadoModel
    {
        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }

        public IPagedList<Marca> List { get; set; }

        public MarcasFiltrosModel Filtros { get; set; }
    }
}
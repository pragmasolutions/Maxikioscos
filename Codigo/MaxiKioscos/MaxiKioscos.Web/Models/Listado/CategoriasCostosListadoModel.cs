using System.ComponentModel.DataAnnotations;
using MaxiKioscos.Entidades;
using PagedList;

namespace MaxiKioscos.Web.Models
{
    public class CategoriasCostosListadoModel
    {
        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }

        public IPagedList<CategoriaCosto> List { get; set; }

        public CategoriasCostosFiltrosModel Filtros { get; set; }
    }
}
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using MaxiKioscos.Entidades;
using PagedList;

namespace MaxiKioscos.Web.Models
{
    public class UsuariosListadoModel
    {
        [Display(Name = "Nombre de usuario, Nombre, Apellido")]
        public string PalabrasABuscar { get; set; }

        [DisplayName("Rol")]
        [UIHint("Rol")]
        public int? RolId { get; set; }

        public IPagedList<Usuario> List { get; set; }

        public UsuariosFiltrosModel Filtros { get; set; }
    }
}
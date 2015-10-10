using System.ComponentModel.DataAnnotations;
using MaxiKioscos.Entidades;
using PagedList;

namespace MaxiKioscos.Web.Models
{
    public class ProductoSeleccionarModel
    {
        public ProductoSeleccionarModel()
        {
            BuscarPorDescripcion = true;
        }

        [Display(Name = "Rubro")]
        [UIHint("Rubro")]
        public int RubroId { get; set; }

        [Display(Name = "Marca")]
        [UIHint("Marca")]
        public int MarcaId { get; set; }

        [Display(Name = "Descripcion")]
        public string Descripcion { get; set; }

        [Display(Name = "Por descripcion?")]
        [UIHint("TipoBusquedaProducto")]
        public bool BuscarPorDescripcion { get; set; }

        public int? MostrarStockMaxikioscoId { get; set; }
    }
}
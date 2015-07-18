using System.ComponentModel.DataAnnotations;
using MaxiKioscos.Entidades;
using PagedList;

namespace MaxiKioscos.Web.Models
{
    public class ProveedoresListadoModel
    {
        [Display(Name = "Buscar por Nombre, Contacto, Direccion")]
        public string PalabrasABuscar { get; set; }

        [Display(Name = "Localidad")]
        [UIHint("Localidad")]
        public int? LocalidadId { get; set; }

        [Display(Name = "Tipo de Cuit")]
        [UIHint("TipoCuit")]
        public int? TipoCuitId { get; set; }

        [Display(Name = "Nro Cuit")]
        public string CuitNro { get; set; }

        public IPagedList<Proveedor> List { get; set; }

        public ProveedoresFiltrosModel Filtros { get; set; }
    }
}
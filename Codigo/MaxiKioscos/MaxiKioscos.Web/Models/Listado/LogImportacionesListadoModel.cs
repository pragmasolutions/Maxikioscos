using MaxiKioscos.Entidades;

namespace MaxiKioscos.Web.Models
{
    public class LogImportacionesListadoModel : ListadoModel<Importacion>
    {
        public LogImportacionesFiltrosModel Filtros { get; set; }
    }
}
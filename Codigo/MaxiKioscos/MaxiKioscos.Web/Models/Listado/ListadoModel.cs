using PagedList;

namespace MaxiKioscos.Web.Models
{
    public class ListadoModel<T>
    {
        public IPagedList<T> PagedList { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PagedList;

namespace MaxiKioscos.Web.Comun.Helpers
{
    public class PagedListHelper<T> where T : class 
    {
        public static IPagedList<T> Crear(List<T> lista, int pSize, int? page)
        {
            var pageNumber = page ?? 1;
            var pageSize = pSize;
            if (pageSize > lista.Count && lista.Any())
                pageSize = lista.Count;

            return lista.ToPagedList(pageNumber, pageSize);
        }
    }
}

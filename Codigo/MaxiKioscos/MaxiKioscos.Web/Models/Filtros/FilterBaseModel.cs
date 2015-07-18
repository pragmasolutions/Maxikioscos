using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;

namespace MaxiKioscos.Web.Models.Filtros
{
    public abstract class FilterBaseModel<T> : IFilter<T>
    {
        protected FilterBaseModel()
        {
            Page = 1;
        }

        public int? Page { get; set; }

        public virtual RouteValueDictionary GetRouteValues(int page = 1)
        {
            return new RouteValueDictionary(new
            {
                Page = page
            });
        }

        #region IFilter<T> Members

        public abstract System.Linq.Expressions.Expression<Func<T, bool>> GetFilterExpression();

        #endregion
    }
}
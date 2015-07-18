using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using MaxiKioscos.Entidades;

namespace MaxiKioscos.Web.Models
{
    public interface IFilter<T>
    {
        Expression<Func<T, bool>> GetFilterExpression();
    }
}

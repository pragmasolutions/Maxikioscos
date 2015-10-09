using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Routing;
using MaxiKioscos.Entidades;
using MaxiKioscos.Reportes.Enumeraciones;
using MaxiKioscos.Web.Models.Filtros;

namespace MaxiKioscos.Web.Models
{
    public class CategoriasCostosFiltrosModel : FilterBaseModel<CategoriaCosto>
    {
        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }

        public override Expression<Func<CategoriaCosto, bool>> GetFilterExpression()
        {
            return p => (string.IsNullOrEmpty(this.Descripcion) || p.Descripcion.Contains(this.Descripcion));
        }

        public override RouteValueDictionary GetRouteValues(int page = 1)
        {
            var routeValues = base.GetRouteValues(page);
            routeValues.Add("Descripcion", this.Descripcion);
            return routeValues;
        }
    }
}
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
    public class PromocionesFiltrosModel : FilterBaseModel<Producto>
    {
        public Guid CurrentRowId { get; set; } 

        [Display(Name = "Rubro")]
        [UIHint("Rubro")]
        public int? RubroId { get; set; }

        [Display(Name = "Descripcion")]
        public string Descripcion { get; set; }

        [Display(Name = "Precio")]
        [DataType(DataType.Currency)]
        public decimal? Precio { get; set; }

        [Display(Name = "Stock reposicion")]
        public int? StockReposicion { get; set; }

        //[Display(Name = "Acepta Stock decimal")]
        //public bool? AceptaCantidadesDecimales { get; set; }

        [Display(Name = "Código")]
        public string Codigo { get; set; }

        public override Expression<Func<Producto, bool>> GetFilterExpression()
        {
            return p => (!this.RubroId.HasValue || this.RubroId.Value == p.RubroId)
                        && (string.IsNullOrEmpty(this.Descripcion) || p.Descripcion.Contains(this.Descripcion))
                        && (!this.Precio.HasValue || this.Precio.Value == p.PrecioConIVA)
                        && (!this.StockReposicion.HasValue || this.StockReposicion.Value == p.StockReposicion)
                        && (string.IsNullOrEmpty(this.Codigo) || p.CodigosProductos.Any(c => !c.Eliminado && c.Codigo.StartsWith(this.Codigo)));
        }

        public override RouteValueDictionary GetRouteValues(int page = 1)
        {
            var routeValues = base.GetRouteValues(page);
            routeValues.Add("RubroId", this.RubroId);
            routeValues.Add("Descripcion", this.Descripcion);
            routeValues.Add("Precio", this.Precio);
            routeValues.Add("StockReposicion", this.StockReposicion);
            routeValues.Add("Codigo", this.Codigo);
            return routeValues;
        }
    }
}
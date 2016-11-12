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
    public class ProductosFiltrosModel : FilterBaseModel<Producto>
    {
        public Guid CurrentRowId { get; set; } 

        [Display(Name = "Rubro")]
        [UIHint("Rubro")]
        public int? RubroId { get; set; }

        [Display(Name = "Marca")]
        [UIHint("Marca")]
        public int? MarcaId { get; set; }

        [Display(Name = "Descripcion")]
        public string Descripcion { get; set; }

        [Display(Name = "Precio")]
        [DataType(DataType.Currency)]
        public decimal? Precio { get; set; }

        [Display(Name = "Stock reposicion")]
        public int? StockReposicion { get; set; }

        [Display(Name = "Disponible en Depósito")]
        [UIHint("DisponibleEnDeposito")]
        public bool? DisponibleEnDeposito { get; set; }

        [Display(Name = "Código")]
        public string Codigo { get; set; }

        [Display(Name = "Proveedor")]
        [UIHint("Proveedor")]
        public int? ProveedorId { get; set; }

        public override Expression<Func<Producto, bool>> GetFilterExpression()
        {
            return p => (!this.RubroId.HasValue || this.RubroId.Value == p.RubroId)
                        && (!this.MarcaId.HasValue || this.MarcaId.Value == p.MarcaId)
                        && (string.IsNullOrEmpty(this.Descripcion) || p.Descripcion.Contains(this.Descripcion))
                        && (!this.Precio.HasValue || this.Precio.Value == p.PrecioConIVA)
                        && (!this.DisponibleEnDeposito.HasValue || this.DisponibleEnDeposito.Value == p.DisponibleEnDeposito)
                        && (!this.StockReposicion.HasValue || this.StockReposicion.Value == p.StockReposicion)
                        && (string.IsNullOrEmpty(this.Codigo) || p.CodigosProductos.Any(c => !c.Eliminado && c.Codigo.StartsWith(this.Codigo)))
                        && (!this.ProveedorId.HasValue || p.ProveedorProductos.Any(pp => !pp.Eliminado && pp.ProveedorId == this.ProveedorId));
        }

        public override RouteValueDictionary GetRouteValues(int page = 1)
        {
            var routeValues = base.GetRouteValues(page);
            routeValues.Add("RubroId", this.RubroId);
            routeValues.Add("MarcaId", this.MarcaId);
            routeValues.Add("DisponibleEnDeposito", this.DisponibleEnDeposito);
            routeValues.Add("Descripcion", this.Descripcion);
            routeValues.Add("Precio", this.Precio);
            routeValues.Add("StockReposicion", this.StockReposicion);
            routeValues.Add("Codigo", this.Codigo);
            routeValues.Add("ProveedorId", this.ProveedorId);
            return routeValues;
        }
    }
}
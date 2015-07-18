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
    public class ProveedoresFiltrosModel : FilterBaseModel<Proveedor>
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

        public override Expression<Func<Proveedor, bool>> GetFilterExpression()
        {
            return p => (!this.LocalidadId.HasValue || this.LocalidadId.Value == p.LocalidadId)
                        && (string.IsNullOrEmpty(this.PalabrasABuscar)
                            || p.Nombre.Contains(this.PalabrasABuscar)
                            || p.Contacto.Contains(this.PalabrasABuscar)
                            || p.Direccion.Contains(this.PalabrasABuscar))
                        && (string.IsNullOrEmpty(this.CuitNro) || p.CuitNro.Contains(this.CuitNro))
                        && (!this.TipoCuitId.HasValue || this.TipoCuitId.Value == p.TipoCuitId);
        }

        public override RouteValueDictionary GetRouteValues(int page = 1)
        {
            var routeValues = base.GetRouteValues(page);
            routeValues.Add("CuitNro", this.CuitNro);
            routeValues.Add("LocalidadId", this.LocalidadId);
            routeValues.Add("PalabrasABuscar", this.PalabrasABuscar);
            routeValues.Add("TipoCuitId", this.TipoCuitId);
            return routeValues;
        }
    }
}
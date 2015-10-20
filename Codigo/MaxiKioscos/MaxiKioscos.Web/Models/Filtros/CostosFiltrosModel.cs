using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    public class CostosFiltrosModel : FilterBaseModel<Costo>
    {
        [DisplayName("Desde")]
        [UIHint("Date")]
        public DateTime? Desde { get; set; }

        [DisplayName("Hasta")]
        [UIHint("Date")]
        public DateTime? Hasta { get; set; }

        [DisplayName("Usuario")]
        [UIHint("Usuario")]
        public int? UsuarioId { get; set; }

        [DisplayName("Nro Comprobante")]
        public string NroComprobante { get; set; }

        [DisplayName("MaxiKiosco")]
        [UIHint("MaxiKiosco")]
        public int? MaxiKioscoId { get; set; }

        [DisplayName("Estado")]
        [UIHint("CostoEstado")]
        public bool? Estado { get; set; }

        [DisplayName("Categoría")]
        [UIHint("CategoriaCostoId")]
        public int? CategoriaCostoId { get; set; }

        [DisplayName("Mostrar solo Gastos Generales")]
        public bool SoloGastosGenerales { get; set; }
        
        public override Expression<Func<Costo, bool>> GetFilterExpression()
        {
            return c => (!this.Desde.HasValue || this.Desde.Value <= c.Fecha)
                        && (!this.Hasta.HasValue || this.Hasta.Value >= c.Fecha)
                        && (!this.UsuarioId.HasValue 
                                || (c.CierreCaja != null && c.CierreCaja.UsuarioId == this.UsuarioId)
                                || c.UsuarioId == this.UsuarioId)
                        && (!this.MaxiKioscoId.HasValue || this.MaxiKioscoId == c.CierreCaja.MaxiKioskoId)
                        && (!this.CategoriaCostoId.HasValue || this.CategoriaCostoId == c.CategoriaCostoId)
                        && (string.IsNullOrEmpty(this.NroComprobante) || c.NroComprobante.ToLower().StartsWith(this.NroComprobante.ToLower()))
                        && (!SoloGastosGenerales || (SoloGastosGenerales && c.CierreCajaId == null && c.UsuarioId == null))
                        && (this.Estado == null || (this.Estado == true && c.Aprobado) || (this.Estado == false && !c.Aprobado));
        }

        public override RouteValueDictionary GetRouteValues(int page = 1)
        {
            var routeValues = base.GetRouteValues(page);
            routeValues.Add("Desde", this.Desde == null ? (string)null : this.Desde.GetValueOrDefault().ToShortDateString());
            routeValues.Add("NroComprobante", this.NroComprobante);
            routeValues.Add("Hasta", this.Hasta == null ? (string)null : this.Hasta.GetValueOrDefault().ToShortDateString());
            routeValues.Add("MaxiKioscoId", this.MaxiKioscoId);
            routeValues.Add("UsuarioId", this.UsuarioId);
            routeValues.Add("CostoEstado", this.Estado);
            return routeValues;
        }
    }
}
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
    public class UsuariosFiltrosModel : FilterBaseModel<Usuario>
    {
        [Display(Name = "Nombre de usuario, Nombre, Apellido")]
        public string PalabrasABuscar { get; set; }

        [DisplayName("Rol")]
        [UIHint("Rol")]
        public int? RolId { get; set; }

        public override Expression<Func<Usuario, bool>> GetFilterExpression()
        {
            return u => (string.IsNullOrEmpty(this.PalabrasABuscar)|| 
                            (u.NombreUsuario.Contains(this.PalabrasABuscar)
                            || u.Nombre.Contains(this.PalabrasABuscar)
                            || u.Apellido.Contains(this.PalabrasABuscar)))
                        && (!this.RolId.HasValue || u.Roles.Any(rol => rol.RoleId ==this.RolId));
        }

        public override RouteValueDictionary GetRouteValues(int page = 1)
        {
            var routeValues = base.GetRouteValues(page);
            routeValues.Add("RolId", this.RolId);
            routeValues.Add("PalabrasABuscar", this.PalabrasABuscar);
            return routeValues;
        }
    }
}
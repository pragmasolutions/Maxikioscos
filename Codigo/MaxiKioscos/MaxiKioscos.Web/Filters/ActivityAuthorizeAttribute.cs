using System;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using MaxiKioscos.Datos.Interfaces;
using MaxiKioscos.Web.Comun.Atributos;
using MaxiKioscos.Web.Ioc;
using Ninject;

namespace MaxiKioscos.Web.Filters
{
    public class ActivityAuthorizeAttribute : AjaxAuthorizeAttribute
    {
        private readonly IMaxiKioscosUow _uow;
        private string _actions;
        private string[] _actionsSplit = new string[0];

        public ActivityAuthorizeAttribute()
        {
            _uow = NinjectServiceHelper.Kernel.Get<IMaxiKioscosUow>();
        }

        public string Actions
        {
            get { return _actions ?? String.Empty; }
            set
            {
                _actions = value;
                _actionsSplit = SplitString(value);
            }
        }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (httpContext == null)
            {
                throw new ArgumentNullException("httpContext");
            }

            IPrincipal user = httpContext.User;
            if (!user.Identity.IsAuthenticated)
            {
                return false;
            }

            if (Actions.Length > 0)
            {
                var roles = GetRolesForActions(_actionsSplit);
                if (!roles.Any(user.IsInRole))
                {
                    return false;
                }
            }

            return base.AuthorizeCore(httpContext);
        }

        private string[] GetRolesForActions(string[] actions)
        {
            return _uow.ReporteRoles.Listado(x => x.Roles,x => x.Reporte)
                    .Where(x => actions.Any(y => y.Equals(x.Reporte.NombreCompleto)))
                    .Select(x => x.Roles.RoleName)
                    .ToArray();
        }

        internal static string[] SplitString(string original)
        {
            if (String.IsNullOrEmpty(original))
            {
                return new string[0];
            }

            var split = from piece in original.Split(',')
                        let trimmed = piece.Trim()
                        where !String.IsNullOrEmpty(trimmed)
                        select trimmed;
            return split.ToArray();
        }
    }
}

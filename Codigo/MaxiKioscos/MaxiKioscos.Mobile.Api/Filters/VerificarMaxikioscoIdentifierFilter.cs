using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using MaxiKioscos.Datos.Interfaces;

namespace MaxiKioscos.Mobile.Api.Filters
{

    public class VerificarMaxikioscoIdentifierFilter : ActionFilterAttribute
    {
        public IMaxiKioscosUow Uow { get; set; }

        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            IEnumerable<string> values = new List<string>();

            if (!actionContext.Request.Headers.TryGetValues("MaxikioscoIdentifier", out values))
            {
                throw new HttpResponseException(HttpStatusCode.Conflict);
            }

            if (!values.Any())
            {
                throw new HttpResponseException(HttpStatusCode.Conflict);
            }

            Uow = IocContainer.GetContainer().Get<IMaxiKioscosUow>();

            var conf = Uow.DbContext.ConfiguracionesLocales.FirstOrDefault();

            if (conf == null)
            {
                return;
            }

            if (conf.MaxikioscoIdentifier.ToString() != values.First())
            {
                throw new HttpResponseException(HttpStatusCode.Conflict);
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Mvc;
using MaxiKioscos.Datos.Interfaces;
using MaxiKioscos.Mobile.Api.Models.Request;
using MaxiKioscos.Mobile.Api.Models.Response;

namespace MaxiKioscos.Mobile.Api.Controllers
{
    
    public class MaxikioscoController : ApiController
    {
        protected IMaxiKioscosUow _uow { get; set; }

        public MaxikioscoController(IMaxiKioscosUow uow)
        {
            _uow = uow;
        }

        public MaxikioscoResponse GetIdentifier()
        {
            var config = _uow.DbContext.ConfiguracionesLocales.FirstOrDefault();
            if (config != null)
            {
                return new MaxikioscoResponse {Identifier = config.MaxikioscoIdentifier};
            }
            else
            {
                return null;
            }
            
        }
    }
}

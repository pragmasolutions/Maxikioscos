using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using MaxiKioscos.Datos.Interfaces;
using MaxiKioscos.Mobile.Api.Models.Request;
using MaxiKioscos.Mobile.Api.Models.Response;

namespace MaxiKioscos.Mobile.Api.Controllers
{
    [System.Web.Mvc.Authorize]
    public class ProductController : ApiController
    {
        protected IMaxiKioscosUow _uow { get; set; }

        public ProductController(IMaxiKioscosUow uow)
        {
            _uow = uow;
        }


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using MaxiKioscos.Datos.Interfaces;
using MaxiKioscos.Datos.Repositorio;
using MaxiKioscos.Entidades;
using MaxiKioscos.Mobile.Api.Models.Request;
using MaxiKioscos.Mobile.Api.Models.Response;

namespace MaxiKioscos.Mobile.Api.Controllers
{

    public class MotivoController : ApiController
    {
        protected IMaxiKioscosUow _uow { get; set; }

        public MotivoController(IMaxiKioscosUow uow)
        {
            _uow = uow;
        }

        public SimpleListItem[] Get()
        {
            return _uow.MotivosCorreccion.Listado().OrderBy(x => x.Descripcion).Select(x => new SimpleListItem
            {
                Id = x.MotivoCorreccionId,
                Description = x.Descripcion
            }).ToArray();
        }
    }
}

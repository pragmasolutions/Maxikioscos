using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Mvc;
using MaxiKioscos.Datos.Interfaces;
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
            try
            {
                return _uow.MotivosCorreccion.Listado().OrderBy(x => x.Descripcion).Select(x => new SimpleListItem
                {
                    Id = x.MotivoCorreccionId,
                    Description = x.Descripcion
                }).ToArray();
            }
            catch (Exception ex)
            {
                throw new ApplicationException(string.Format("Se produjo el siguiente error: {0}", ex.Message));
            }
            
        }
    }
}

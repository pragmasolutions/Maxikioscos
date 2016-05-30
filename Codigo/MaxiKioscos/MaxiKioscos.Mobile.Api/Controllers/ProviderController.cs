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
    
    public class ProviderController : ApiController
    {
        protected IMaxiKioscosUow _uow { get; set; }

        public ProviderController(IMaxiKioscosUow uow)
        {
            _uow = uow;
        }

        
        public SimpleListItem[] Get()
        {
            try
            {
                return _uow.Proveedores.Listado().Where(m => !m.Eliminado).OrderBy(x => x.Nombre).Select(x => new SimpleListItem
                {
                    Id = x.ProveedorId,
                    Description = x.Nombre
                }).ToArray();
            }
            catch (Exception ex)
            {
                throw new ApplicationException(string.Format("Se produjo el siguiente error: {0}", ex.Message));
            }
            
        }
    }
}

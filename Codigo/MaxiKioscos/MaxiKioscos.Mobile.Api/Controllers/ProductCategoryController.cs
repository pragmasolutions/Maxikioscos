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

    public class ProductCategoryController : ApiController
    {
        //protected IMaxiKioscosUow _uow { get; set; }

        public ProductCategoryController()
        {
            
        }


        public SimpleListItem[] Get()
        {
           var _uow = new EFRepository<Rubro>();
            return _uow.Listado().OrderBy(x => x.Descripcion).Select(x => new SimpleListItem
            {
                Id = x.RubroId,
                Description = x.Descripcion
            }).ToArray();
        }
    }
}

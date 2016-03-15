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
    
    public class ProductController : ApiController
    {
        protected IMaxiKioscosUow _uow { get; set; }

        public ProductController(IMaxiKioscosUow uow)
        {
            _uow = uow;
        }

        public ProductRowResponse GetByCode(string code, int maxikioscoId)
        {
            var product = _uow.Productos.ProductoPorCodigo(code, maxikioscoId);

            if (product != null)
            {
                return new ProductRowResponse
                       {
                           ProductId = product.ProductoId,
                           Producto = product.Descripcion,
                           Codigo = product.Codigo,
                           StockActual = product.StockActual.Value,
                           Identifier = Guid.NewGuid(),
                           FechaUltimaModificacion = DateTime.Now,
                           Desincronizado = true,
                           Eliminado = false,
                           HabilitadoParaCorregir = true,
                           MotivoCorreccionId = null,
                           Diferencia = 0,
                           StockId = 0
                       };
            }

            return null;
        }
    }
}

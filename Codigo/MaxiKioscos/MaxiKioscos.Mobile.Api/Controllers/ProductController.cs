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

        public ProductRowResponse GetByCode([FromUri] ProductCodeRequest request)
        {
            if (request != null)
            {
                try
                {
                    var shop = _uow.MaxiKioscos.Listado().First(x => x.Identifier == request.MaxikioscoId);
                    var product = _uow.Productos.ProductoPorCodigo(request.Code, shop.MaxiKioscoId);

                    if (product.StockId.HasValue)
                    {
                        return new ProductRowResponse
                        {
                            StockId = product.StockId.Value,
                            Producto = product.Producto,
                            Codigo = product.Codigo,
                            StockActual = product.StockActual.Value,
                            Identifier = product.Identifier.Value,
                            FechaUltimaModificacion = DateTime.Now,
                            Desincronizado = true,
                            Eliminado = false,
                            HabilitadoParaCorregir = true,
                            MotivoCorreccionId = null,
                            Diferencia = 0
                        };
                    }
                }
                catch (Exception ex)
                {
                    throw new ApplicationException(string.Format("No se encontró producto para el código: {0}", request.Code));
                }
                
            }

            throw new ApplicationException(string.Format("No se encontró producto para el código: {0}", request.Code));
        }
    }
}

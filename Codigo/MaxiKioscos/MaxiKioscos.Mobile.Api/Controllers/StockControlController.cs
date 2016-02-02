using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using MaxiKioscos.Datos.Interfaces;
using MaxiKioscos.Datos.Repositorio;
using MaxiKioscos.Mobile.Api.Models.Request;
using MaxiKioscos.Mobile.Api.Models.Response;

namespace MaxiKioscos.Mobile.Api.Controllers
{
    [System.Web.Mvc.Authorize]
    public class StockControlController : ApiController
    {
        protected IMaxiKioscosUow _uow { get; set; }

        public StockControlController(IMaxiKioscosUow uow)
        {
            _uow = uow;
        }


        public StockControlPreviewResponse Get(StockControlPreviewRequest request)
        {
            var response = new StockControlPreviewResponse();
            if (request.ProviderId != null)
            {
                //Verifico si tiene facturas sin compras asociadas
                var billIds = _uow.Facturas.Listado().Where(f => f.ProveedorId == request.ProviderId).Select(f => f.FacturaId).ToList();
                var purchases = _uow.Compras.Listado().Count(c => billIds.Contains(c.FacturaId));
                if (billIds.Count() != purchases)
                    response.WarningMessage = "El proveedor seleccionado tiene facturas que no han sido completadas. Está seguro que desea continuar?";
            }
            var shop = _uow.MaxiKioscos.Listado().First(x => x.Identifier == request.ShopIdentifier);
            response.List = _uow.ControlesStock.ReporteControlStockVistaPrevia(shop.MaxiKioscoId, 
                                                                            request.ProviderId,
                                                                            request.ProductCategoryId, 
                                                                            request.OnlyBestSellers, 
                                                                            request.ExcludeZeroStock, 
                                                                            request.RowsAmount).ToArray();
            return response;
        }
    }
}

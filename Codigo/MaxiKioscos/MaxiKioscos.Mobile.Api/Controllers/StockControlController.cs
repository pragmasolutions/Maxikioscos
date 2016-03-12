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
using Newtonsoft.Json;

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


        public StockControlPreviewResponse Get([FromUri]StockControlPreviewRequest request)
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
        
        public List<ControlStockObtenerDetalleRow> GetObtenerDetalle([FromUri]StockControlDetailRequest request)
        {
            if (request != null)
            {
                var shop = _uow.MaxiKioscos.Listado().First(x => x.Identifier == request.ShopIdentifier);
                return _uow.ControlesStock.ObtenerDetalle(shop.MaxiKioscoId, request.ProviderId,
                                            request.ProductCategoryId, request.UserId, request.OnlyBestSellers,
                                            request.ExcludeZeroStock, request.RowsAmount, request.LowerLimit,
                                            request.UpperLimit);
            }

            return null;
        }
        
        public bool PostCerrar(StockControlCreateRequest request)
        {

            if (request != null)
            {

                var controlStock = new ControlStock();
                var shop = _uow.MaxiKioscos.Listado().First(x => x.Identifier == request.ShopIdentifier);
                //Set control stock
                controlStock.MaxiKioscoId = shop.MaxiKioscoId;
                controlStock.UsuarioId = request.UserId;
                controlStock.ProveedorId = request.ProviderId;
                controlStock.RubroId = request.ProductCategoryId;
                controlStock.CantidadFilas = request.RowsAmount;
                controlStock.ConStockCero= !request.ExcludeZeroStock;
                controlStock.MasVendidos = request.OnlyBestSellers;
                controlStock.LimiteInferior = request.LowerLimit;
                controlStock.LimiteSuperior = request.UpperLimit;
                controlStock.FechaCreacion = DateTime.Now;
                controlStock.FechaCorreccion = DateTime.Now;
                controlStock.Identifier = Guid.NewGuid();
                controlStock.Desincronizado = true;
                controlStock.Cerrado = true;

                var detalleList = new List<ControlStockDetalle>();

                var motivos = _uow.MotivosCorreccion.Listado();
                var detalles = request.ControlStockDetalle.Where(d => d.MotivoCorreccionId != null).ToList();
                if (detalles.Any())
                {
                    foreach (var controlStockDetalle in detalles)
                    {
                        var stock = _uow.Stocks.Obtener(controlStockDetalle.StockId);

                        var transaccion = new StockTransaccion()
                        {
                            Desincronizado = true,
                            Eliminado = false,
                            FechaUltimaModificacion = DateTime.Now,
                            Identifier = Guid.NewGuid(),
                            StockId = controlStockDetalle.StockId,
                            StockTransaccionTipoId = 3 //Correccion
                        };

                        var motivo = motivos.FirstOrDefault(m => m.MotivoCorreccionId == controlStockDetalle.MotivoCorreccionId);
                        transaccion.Cantidad = motivo.SumarAStock
                                                   ? controlStockDetalle.Diferencia.GetValueOrDefault()
                                                   : -controlStockDetalle.Diferencia.GetValueOrDefault();
                        _uow.StockTransacciones.Agregar(transaccion);
                        stock.StockActual += transaccion.Cantidad;

                        _uow.Stocks.Modificar(stock);
                        controlStockDetalle.Desincronizado = true;
                        detalleList.Add(new ControlStockDetalle()
                                        {
                                            StockId = controlStockDetalle.StockId,
                                            Cantidad = controlStockDetalle.StockActual,
                                            FechaUltimaModificacion = DateTime.Now,
                                            Desincronizado = true,
                                            Eliminado = false,
                                            Identifier = controlStockDetalle.Identifier,
                                            Correccion = controlStockDetalle.Diferencia,
                                            Precio = null,
                                            HabilitadoParaCorregir = controlStockDetalle.HabilitadoParaCorregir,
                                            ControlStockPrevioId = null
                                        });

                        controlStock.ControlStockDetalles = detalleList;
                    }
                }
                
                _uow.ControlesStock.Agregar(controlStock);
                _uow.Commit();

                //Deshabilito todos los ControlStockDetalle con controlStock abierto para el mismo stock
                if (detalleList.Any())
                    _uow.ControlesStock.DeshabilitarAbiertos(controlStock.ControlStockId, detalles.Select(d => d.StockId).ToArray());

                return true;
            }

            return false;
        }
    }
}

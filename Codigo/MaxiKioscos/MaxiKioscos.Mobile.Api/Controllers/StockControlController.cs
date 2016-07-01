using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;
using MaxiKioscos.Datos.Interfaces;
using MaxiKioscos.Entidades;
using MaxiKioscos.Mobile.Api.Models.Request;
using MaxiKioscos.Mobile.Api.Models.Response;

namespace MaxiKioscos.Mobile.Api.Controllers
{
    [EnableCors("*", "*", "*")]
    public class StockControlController : ApiController
    {
        protected IMaxiKioscosUow _uow { get; set; }

        public StockControlController(IMaxiKioscosUow uow)
        {
            _uow = uow;
        }


        public StockControlPreviewResponse Get([FromUri]StockControlPreviewRequest request)
        {
            try
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
            catch (Exception ex)
            {
                throw new ApplicationException(string.Format("Se produjo el siguiente error: {0}", ex.Message));
            }
        }
        
        public List<ControlStockObtenerDetalleRow> GetObtenerDetalle([FromUri]StockControlDetailRequest request)
        {
            if (request != null)
            {
                try
                {
                    var shop = _uow.MaxiKioscos.Listado().First(x => x.Identifier == request.ShopIdentifier);
                    return _uow.ControlesStock.ObtenerDetalle(shop.MaxiKioscoId, request.ProviderId,
                                                request.ProductCategoryId, request.UserId, request.OnlyBestSellers,
                                                request.ExcludeZeroStock, request.RowsAmount, request.LowerLimit,
                                                request.UpperLimit);
                }
                catch (Exception ex)
                {
                    throw new ApplicationException(string.Format("Se produjo el siguiente error: {0}", ex.Message));
                }
            }

            throw new ApplicationException("El conjunto de parámetros no puede ser nulo.");
        }

        [HttpPost]
        public bool Cerrar(StockControlCreateRequest request)
        {

            if (request != null)
            {
                try
                {
                    var controlStock = new ControlStock();
                    var shop = _uow.MaxiKioscos.Listado().First(x => x.Identifier == request.ShopIdentifier);
                    //Set control stock
                    controlStock.MaxiKioscoId = shop.MaxiKioscoId;
                    controlStock.UsuarioId = request.UserId;
                    controlStock.ProveedorId = request.ProviderId;
                    controlStock.RubroId = request.ProductCategoryId;
                    controlStock.CantidadFilas = request.RowsAmount;
                    controlStock.ConStockCero = !request.ExcludeZeroStock;
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
                                Correccion = controlStockDetalle.Diferencia ?? 0,
                                Precio = null,
                                HabilitadoParaCorregir = controlStockDetalle.HabilitadoParaCorregir,
                                ControlStockPrevioId = null,
                                MotivoCorreccionId = controlStockDetalle.MotivoCorreccionId ?? 6
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
                catch (Exception ex)
                {
                    throw new ApplicationException(string.Format("Se produjo el siguiente error: {0}", ex.Message));
                }
            }

            throw new ApplicationException("El conjunto de parámetros no puede ser nulo.");
        }
        
        public IList<StockControlResumeResponse> GetResumen([FromUri]StockControlResumeRequest request)
        {
            if (request != null)
            {
                try
                {
                    var dateTo = request.DateTo.AddDays(1);
                    var shop = _uow.MaxiKioscos.Listado().First(x => x.Identifier == request.MaxikioscoIdentifier);
                    var controls = _uow.ControlesStock.Listado(r => r.Rubro, p => p.Proveedor).OrderByDescending(x => x.FechaCreacion)
                            .Where(c => c.MaxiKioscoId == shop.MaxiKioscoId &&
                                    c.FechaUltimaModificacion >=
                                    request.DateFrom &&
                                    c.FechaUltimaModificacion <= dateTo)
                                    .Take(10)
                                    .ToList()
                                    .Select(cs => new StockControlResumeResponse
                                                    {
                                                        StockControlId = cs.ControlStockId,
                                                        NroControl = cs.NroControl,
                                                        Proveedor = cs.Proveedor != null ? cs.Proveedor.Nombre : null,
                                                        Rubro = cs.Rubro != null ? cs.Rubro.Descripcion : null,
                                                        LimiteInferior = cs.LimiteInferior,
                                                        LimiteSuperior = cs.LimiteSuperior,
                                                        Fecha = String.Format("{0} {1}", cs.FechaCreacion.ToShortDateString(), cs.FechaCreacion.ToShortTimeString())
                                                    }).ToList();
                    return controls;

                }
                catch (Exception ex)
                {
                    throw new ApplicationException(string.Format("Se produjo el siguiente error: {0}", ex.Message));
                }
            }

            throw new ApplicationException("El conjunto de parámetros no puede ser nulo.");
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MaxiKioscos.Datos.Interfaces;
using MaxiKioscos.Datos.Repositorio;
using MaxiKioscos.Entidades;
using MaxiKioscos.Negocio;
using MaxiKioscos.Seguridad;
using MaxiKioscos.Web.Configuration;
using MaxiKioscos.Web.Filters;
using MaxiKioscos.Web.Infrastructure.Alerts;
using MaxiKioscos.Web.Models;
using PagedList;

namespace MaxiKioscos.Web.Controllers
{
    [ActivityAuthorize(Actions = MaxikioscoPermisos.STOCK)]
    public class StocksController : BaseController
    {
        private IStockNegocio StockNegocio { get; set; }

        public StocksController(IMaxiKioscosUow uow, IStockNegocio stockNegocio)
        {
            Uow = uow;
            StockNegocio = stockNegocio;
        }

        public ActionResult Index(StockFiltrosModel filtros)
        {
            var stocks = StockNegocio.Listado(UsuarioActual.CuentaId, filtros.MaxiKioscoId, filtros.NecesitaReposicion,
                                            filtros.ProductoDescripcion, filtros.ProveedorId, filtros.Page);

            var pageNumber = filtros.Page ?? 1;

            var pageSize = AppSettings.DefaultPageSize;

            IPagedList<StockDto> list = stocks.ToPagedList(pageNumber, pageSize);

            var stockModel = new StockListadoModel();

            stockModel.List = list;
            stockModel.Filtros = filtros;

            return PartialOrView(stockModel);
        }

        public ActionResult Editar(int productoId, int maxiKioscoId)
        {
            var repo = new EFRepository<Entidades.MaxiKiosco>();
            var maxi = repo.Obtener(maxiKioscoId);
            repo.MaxiKioscosEntities.StockActualizar(maxi.Identifier, productoId);
            Stock stock = Uow.Stocks.Obtener(s => s.ProductoId == productoId
                && s.MaxiKioscoId == maxiKioscoId,
                s => s.MaxiKiosco, s => s.Producto,
                s => s.StockTransacciones);

            if (stock == null)
            {
                stock = new Stock();

                var maxiKiosco = Uow.MaxiKioscos.Obtener(maxiKioscoId);
                var producto = Uow.Productos.Obtener(productoId);

                stock.MaxiKioscoId = maxiKioscoId;
                stock.ProductoId = productoId;
                stock.MaxiKiosco = maxiKiosco;
                stock.Producto = producto;
                stock.FechaCreacion = DateTime.Now;
                stock.OperacionCreacion = "Edición en web";
            }

            var model = new StockModel()
            {
                MaxiKiosco = stock.MaxiKiosco.Nombre,
                MotivoCorreccionId = UsuarioActual.Cuenta.MotivoCorreccionPorDefecto,
                Producto = stock.Producto.Descripcion,
                StockActual = stock.StockActual,
                PrecioConIVA = stock.Producto.PrecioConIVA,
                Stock = stock
            };

            return PartialView(model);
        }

        [HttpPost]
        public ActionResult Editar(StockModel model)
        {
            if (!ModelState.IsValid)
            {
                return PartialView(model);
            }

            StockNegocio.ActualizarStock(model.Stock, model.Diferencia, model.MotivoCorreccionId, model.PrecioConIVA);

            var stock = Uow.Stocks.Obtener(p => p.StockId == model.Stock.StockId, s => s.Producto, s => s.MaxiKiosco);

            var ultimaOperacionMensaje =
                string.Format("Ultimo Stock Actualizado. Producto:{0}, Maxikiosco:{1}, Diferencia:{2}",
                    stock.Producto.Descripcion,
                    stock.MaxiKiosco.Nombre,
                    model.Diferencia);

            return Json(new { exito = true }).WithSuccess(ultimaOperacionMensaje);
        }

        public ActionResult Transferir(int productoId, int maxiKioscoId)
        {
            Stock stock = Uow.Stocks.Obtener(s => s.ProductoId == productoId
                && s.MaxiKioscoId == maxiKioscoId,
                s => s.MaxiKiosco, s => s.Producto,
                s => s.StockTransacciones);

            if (stock == null)
            {
                stock = new Stock();

                var maxiKiosco = Uow.MaxiKioscos.Obtener(maxiKioscoId);
                var producto = Uow.Productos.Obtener(productoId);

                stock.MaxiKioscoId = maxiKioscoId;
                stock.ProductoId = productoId;
                stock.MaxiKiosco = maxiKiosco;
                stock.Producto = producto;
                stock.FechaCreacion = DateTime.Now;
                stock.OperacionCreacion = "Transferencia manual en web";
                stock.Identifier = Guid.NewGuid();
            }

            stock.StockActual = stock.StockTransacciones
                .Select(st => st.Cantidad)
                .DefaultIfEmpty(0).Sum();

            var model = new TransferirStockModel
                            {
                                Stock = stock,
                                Unidades = 1
                            };

            return PartialView(model);
        }

        [HttpPost]
        public ActionResult Transferir(TransferirStockModel model)
        {
            ValidarTransferencia(model);
            if (!ModelState.IsValid)
            {
                model.Stock.Producto = Uow.Productos.Obtener(model.Stock.ProductoId);
                return PartialView(model);
            }

            StockNegocio.TransferirStock(model.Stock, model.Unidades, model.DestinoId);

            var maxikioscoOrigen = Uow.MaxiKioscos.Obtener(m => m.MaxiKioscoId == model.Stock.MaxiKioscoId);
            var maxikioscoDestino = Uow.MaxiKioscos.Obtener(m => m.MaxiKioscoId == model.DestinoId);

            var ultimaOperacionMensaje =
                string.Format("Último Stock Trasferido. Producto:{0}, Maxikiosco Origen:{1}, Maxikiosco Destino:{2}, Unidades:{3}",
                    model.Stock.Producto.Descripcion,
                    maxikioscoOrigen.Nombre,
                    maxikioscoDestino.Nombre,
                    model.Unidades);

            return Json(new { exito = true }).WithSuccess(ultimaOperacionMensaje);
        }

        private void ValidarTransferencia(TransferirStockModel model)
        {
            if (model.Stock.MaxiKioscoId == model.DestinoId)
            {
                ModelState.AddModelError("DestinoId", "El kiosco de destino no puede ser igual al de origen");
            }
        }

    }
}

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaxiKioscos.Datos.Interfaces;
using MaxiKioscos.Entidades;

namespace MaxiKioscos.Negocio
{
    public class StockNegocio : IStockNegocio
    {
        private IMaxiKioscosUow Uow { get; set; }

        public StockNegocio(IMaxiKioscosUow uow)
        {
            Uow = uow;
        }

        public void ActualizarStock(Stock stock, decimal diferencia, int motivoCorreccionId, decimal precioConIVA)
        {
            ////Obtenemos el producto a actualizar
            var producto = Uow.Productos.Obtener(stock.ProductoId);

            if (producto == null)
                throw new ApplicationException("No se ha encontrado el producto");

            if (!producto.AceptaCantidadesDecimales && (stock.StockActual % 1 != 0))
                throw new ApplicationException("El producto no acepta cantidades decimales");

            var stockTransaccion = new StockTransaccion();
            var now = DateTime.Now;


            producto.PrecioConIVA = precioConIVA;
            producto.PrecioSinIVA = precioConIVA / 1.21m;

            //3 = Corrección
            stockTransaccion.StockTransaccionTipoId = 3;
            stockTransaccion.Identifier = Guid.NewGuid();


            var motivo = Uow.MotivosCorreccion.Obtener(motivoCorreccionId);
            if (!motivo.SumarAStock)
            {
                diferencia = -diferencia;
            }

            var stockTransacciones = Uow.StockTransacciones.Listado().Where(st => st.StockId == stock.StockId);

            //Creamos una nueva transaccion con la diferencia entre el stock actual y el ingresado por el usuario.
            var stockActual = stockTransacciones.Select(st => st.Cantidad)
                .DefaultIfEmpty(0)
                .Sum();

            stock.StockActual = stockActual + diferencia;

            if (stock.StockId == 0)
            {
                stock.Identifier = Guid.NewGuid();
                Uow.Stocks.Agregar(stock);

                stockTransaccion.Stock = stock;
                stockTransaccion.Cantidad = diferencia;
            }
            else
            {
                stockTransaccion.Cantidad = diferencia;
                stockTransaccion.StockId = stock.StockId;
                Uow.Stocks.Modificar(stock);
            }

            Uow.StockTransacciones.Agregar(stockTransaccion);

            ////Agregamos la correccion de stock.
            var correccionStock = new CorreccionStock();

            correccionStock.Cantidad = stockTransaccion.Cantidad;
            correccionStock.MotivoCorreccionId = motivoCorreccionId;
            correccionStock.ProductoId = stock.ProductoId;
            correccionStock.Precio = producto.PrecioConIVA;
            correccionStock.Fecha = now;
            correccionStock.Identifier = Guid.NewGuid();
            correccionStock.MaxiKioscoId = stock.MaxiKioscoId;

            ////Set sincronization properties.
            correccionStock.FechaUltimaModificacion = now;
            correccionStock.Desincronizado = true;

            Uow.Productos.Modificar(producto);
            Uow.CorreccionesDeStock.Agregar(correccionStock);

            Uow.Commit();
        }

        public void TransferirStock(Stock stockOrigen, int unidades, int destinoId)
        {
            ////Obtenemos el producto a actualizar
            var producto = Uow.Productos.Obtener(stockOrigen.ProductoId);

            if (producto == null)
                throw new ApplicationException("No se ha encontrado el producto");

            var now = DateTime.Now;

            //Actualizo el origen
            var transOrigen = new StockTransaccion
                                  {
                                      Cantidad = -unidades,
                                      Identifier = Guid.NewGuid(),
                                      FechaUltimaModificacion = now,
                                      StockTransaccionTipoId = 3
                                  };
            if (stockOrigen.StockId == 0)
            {
                stockOrigen.StockActual = -unidades;
                stockOrigen.StockTransacciones = new Collection<StockTransaccion> { transOrigen };
                Uow.Stocks.Agregar(stockOrigen);
            }
            else
            {
                stockOrigen.StockActual -= unidades;
                stockOrigen.FechaUltimaModificacion = now;
                Uow.Stocks.Modificar(stockOrigen);

                transOrigen.StockId = stockOrigen.StockId;
                Uow.StockTransacciones.Agregar(transOrigen);
            }

            var correccionOrigen = new CorreccionStock
                                       {
                                           Cantidad = transOrigen.Cantidad,
                                           MotivoCorreccionId = 5, //Transferencia
                                           ProductoId = stockOrigen.ProductoId,
                                           Precio = producto.PrecioConIVA,
                                           Fecha = now,
                                           Identifier = Guid.NewGuid(),
                                           MaxiKioscoId = stockOrigen.MaxiKioscoId,
                                           FechaUltimaModificacion = now,
                                           Desincronizado = true
                                       };
            Uow.CorreccionesDeStock.Agregar(correccionOrigen);


            //Ahora actualizo el destino
            var transDestino = new StockTransaccion
                                  {
                                      Cantidad = unidades,
                                      Identifier = Guid.NewGuid(),
                                      FechaUltimaModificacion = now,
                                      StockTransaccionTipoId = 3
                                  };

            var stockDestino = Uow.Stocks.Obtener(s => s.MaxiKioscoId == destinoId && s.ProductoId == stockOrigen.ProductoId);
            if (stockDestino == null)
            {
                stockDestino = new Stock()
                                   {
                                       Desincronizado = true,
                                       Identifier = Guid.NewGuid(),
                                       MaxiKioscoId = destinoId,
                                       ProductoId = stockOrigen.ProductoId,
                                       StockActual = unidades,
                                       StockTransacciones = new Collection<StockTransaccion> { transDestino }
                                   };
                Uow.Stocks.Agregar(stockDestino);
            }
            else
            {
                stockDestino.FechaUltimaModificacion = now;
                stockDestino.StockActual += unidades;
                Uow.Stocks.Modificar(stockDestino);

                transDestino.StockId = stockDestino.StockId;
                Uow.StockTransacciones.Agregar(transDestino);
            }

            var correccionDestino = new CorreccionStock
            {
                Cantidad = transDestino.Cantidad,
                MotivoCorreccionId = 5, //Transferencia
                ProductoId = stockOrigen.ProductoId,
                Precio = producto.PrecioConIVA,
                Fecha = now,
                Identifier = Guid.NewGuid(),
                MaxiKioscoId = stockDestino.MaxiKioscoId,
                FechaUltimaModificacion = now,
                Desincronizado = true
            };
            Uow.CorreccionesDeStock.Agregar(correccionDestino);

            Uow.Commit();
        }

        public IQueryable<StockDto> Listado(int cuentaId, int? maxiKioscoId, bool? necesitaReposicion,
            string productoDescripcion, int? proveedorId, int? page)
        {

            var productos = Uow.Productos.Listado()
                               .Where(p => p.CuentaId == cuentaId);

            var maxiKioscos = Uow.MaxiKioscos.Listado()
                               .Where(p => p.CuentaId == cuentaId);

            var stocks = Uow.Stocks.Listado(s => s.MaxiKiosco)
                               .Where(p => p.MaxiKiosco.CuentaId == cuentaId);

            var stockTransacciones = Uow.StockTransacciones.Listado();

            ////Cross join entre productos y maxikisocos
            var q = (from p in productos
                     from m in maxiKioscos
                     select new { Producto = p, MaxiKiosco = m });

            //Left join con transacciones de stock
            var q2 = (from pm in q
                      join s in stocks on new { a = pm.Producto.ProductoId, b = pm.MaxiKiosco.MaxiKioscoId }
                      equals new { a = s.ProductoId, b = s.MaxiKioscoId } into stGroup
                      from stg in stGroup.DefaultIfEmpty()
                      join stran in stockTransacciones on stg.StockId equals stran.StockId into stranGroup
                      from strang in stranGroup.DefaultIfEmpty()
                      select new
                      {
                          pm.MaxiKiosco.MaxiKioscoId,
                          MaxiKioscoNombre = pm.MaxiKiosco.Nombre,
                          pm.Producto.ProductoId,
                          ProductoDescripcion = pm.Producto.Descripcion,
                          pm.Producto.StockReposicion,
                          Cantidad = (decimal?)strang.Cantidad
                      });

            //Agrupamos por maxikiosco y producto y definimos cantidades
            var q3 = (from stra in q2
                      group stra by
                      new
                      {
                          stra.MaxiKioscoId,
                          stra.MaxiKioscoNombre,
                          stra.ProductoId,
                          stra.ProductoDescripcion,
                          stra.StockReposicion
                      }
                          into strag
                          select new StockDto()
                          {
                              MaxiKioscoId = strag.Key.MaxiKioscoId,
                              MaxiKioscoNombre = strag.Key.MaxiKioscoNombre,
                              ProductoId = strag.Key.ProductoId,
                              ProductoDescripcion = strag.Key.ProductoDescripcion,
                              StockReposicion = strag.Key.StockReposicion,
                              StockActual = strag.Select(x => x.Cantidad)
                              .DefaultIfEmpty(0)
                              .Sum()
                          }).AsQueryable();

            ////Filtramos por maxikiosco.
            if (maxiKioscoId.HasValue)
                q3 = q3.Where(s => s.MaxiKioscoId == maxiKioscoId);

            ////Filtramos por productos que necesitan reposicion.
            if (necesitaReposicion.HasValue)
                q3 = q3.Where(s => s.StockReposicion > s.StockActual);

            ////Filtramos por descripcion de producto
            if (!string.IsNullOrEmpty(productoDescripcion))
                q3 = q3.Where(s => s.ProductoDescripcion.Contains(productoDescripcion));

            if (proveedorId.HasValue)
            {
                var proveedorProductos = Uow.ProveedorProductos.Listado(p => p.Proveedor)
                                        .Where(p => p.Proveedor.CuentaId == cuentaId && p.ProveedorId == proveedorId);
                q3 = q3.Where(p => proveedorProductos.Any(pp => pp.ProductoId == p.ProductoId));
            }

            q3 = q3.OrderBy(p => p.MaxiKioscoNombre);

            return q3;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaxiKioscos.Datos.Interfaces;
using MaxiKioscos.Entidades;

namespace MaxiKioscos.Negocio
{
    public class TransferenciasNegocio : ITransferenciasNegocio
    {
        private IMaxiKioscosUow Uow { get; set; }

        public TransferenciasNegocio(IMaxiKioscosUow uow)
        {
            Uow = uow;
        }

        public void Crear(Transferencia transferencia)
        {
            transferencia.Identifier = Guid.NewGuid();
            transferencia.FechaCreacion = DateTime.Now;

            //Agregar una trasaccion por cada transferencia producto.
            for (int i = 0; i < transferencia.TransferenciaProductos.Count; i++)
            {
                var transferenciaProd = transferencia.TransferenciaProductos.ElementAt(i);
                transferenciaProd.Identifier = Guid.NewGuid();
                transferenciaProd.FechaUltimaModificacion = DateTime.Now;
                transferenciaProd.Orden = i + 1;
            }

            Uow.Transferencias.Agregar(transferencia);
            Uow.Commit();
        }

        public void Aprobar(Transferencia transferencia)
        {
            foreach (TransferenciaProducto transferenciaProd in transferencia.TransferenciaProductos.Where(x => !x.Eliminado).ToList())
            {
                ProcesarStock(transferenciaProd, true, transferencia.DestinoId);
                ProcesarStock(transferenciaProd, false, transferencia.OrigenId);
            }
            transferencia.FechaUltimaModificacion = DateTime.Now;
            transferencia.Desincronizado = true;
            transferencia.FechaAprobacion = DateTime.Now;
            //Uow.Transferencias.Modificar(transferencia);
            Uow.Commit();
        }

        private void ProcesarStock(TransferenciaProducto transferenciaProd, bool sumar, int maxikioscoId)
        {
            var stockTransaccion = new StockTransaccion
            {
                Identifier = Guid.NewGuid(),
                Cantidad = sumar ? transferenciaProd.Cantidad : -transferenciaProd.Cantidad,
                StockTransaccionTipoId = 4, //Transferencia
                FechaUltimaModificacion = DateTime.Now
            };

            //Obtengo la instancia de stock para la transferencia del producto
            Stock stock = Uow.Stocks.Obtener(s => s.MaxiKioscoId == maxikioscoId && s.ProductoId == transferenciaProd.ProductoId);
            if (stock == null)
            {
                stock = new Stock
                {
                    Identifier = Guid.NewGuid(),
                    MaxiKioscoId = maxikioscoId,
                    ProductoId = transferenciaProd.ProductoId,
                    OperacionCreacion = "Aprobar transferencia desde web",
                    FechaCreacion = DateTime.Now
                };
                Uow.Stocks.Agregar(stock);
            }

            stockTransaccion.Stock = stock;
            Uow.StockTransacciones.Agregar(stockTransaccion);
        }


        public void Editar(Transferencia transferencia, bool aprobar)
        {
            var trans = Uow.Transferencias.Obtener(t => t.TransferenciaId == transferencia.TransferenciaId,
                                                    t => t.TransferenciaProductos);
            var originales = trans.TransferenciaProductos.Where(tp => !tp.Eliminado);
            
            var paraEliminar = originales.Select(o => o.TransferenciaProductoId).ToList();

            var i = 1;
            foreach (var tp in transferencia.TransferenciaProductos)
            {
                tp.Orden = i;
                if (tp.TransferenciaProductoId == 0)
                {
                    tp.TransferenciaId = transferencia.TransferenciaId;
                    Uow.TransferenciaProductos.Agregar(tp);
                }
                else
                {
                    var original = originales.FirstOrDefault(o => tp.TransferenciaProductoId == o.TransferenciaProductoId);
                    if (original != null)
                    {
                        original.Cantidad = tp.Cantidad;
                        original.PrecioVenta = tp.PrecioVenta;
                        original.ProductoId = tp.ProductoId;
                        original.StockDestino = tp.StockDestino;
                        original.StockOrigen = tp.StockDestino;
                        Uow.TransferenciaProductos.Modificar(original);
                        paraEliminar.Remove(original.TransferenciaProductoId);
                    }
                }
                i++;
            }

            foreach (var id in paraEliminar)
            {
                Uow.TransferenciaProductos.Eliminar(id);
            }

            trans.OrigenId = transferencia.OrigenId;
            trans.DestinoId = transferencia.DestinoId;
            

            if (aprobar)
            {
                Aprobar(trans);
            }
            else
            {
                trans.FechaUltimaModificacion = DateTime.Now;
                trans.Desincronizado = true;
                Uow.Commit();
            }
        }

        public void Aprobar(int transferenciaId)
        {
            var transferencia = Uow.Transferencias.Obtener(t => t.TransferenciaId == transferenciaId, t => t.TransferenciaProductos);
            Aprobar(transferencia);
        }
    }
}

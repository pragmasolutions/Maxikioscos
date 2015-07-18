using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaxiKioscos.Datos.Interfaces;
using MaxiKioscos.Entidades;

namespace MaxiKioscos.Negocio
{
    public class ComprasNegocio : IComprasNegocio
    {
        private IMaxiKioscosUow Uow { get; set; }

        public ComprasNegocio(IMaxiKioscosUow uow)
        {
            Uow = uow;
        }

        public void Crear(Compra compra)
        {
            compra.Identifier = Guid.NewGuid();
            
            var factura = Uow.Facturas.Obtener(compra.FacturaId);

            Uow.Facturas.Modificar(factura);

            //Fix para prevenir gurdar la factura.
            compra.Factura = null;

            ////Agregar una trasaccion por cada compra producto.
            foreach (CompraProducto compraProd in compra.ComprasProductos)
            {
                compraProd.Identifier = Guid.NewGuid();
                compraProd.FechaUltimaModificacion = DateTime.Now;

                var stockTransaccion = new StockTransaccion
                                           {
                                               Identifier = Guid.NewGuid(),
                                               Cantidad = compraProd.Cantidad,
                                               StockTransaccionTipoId = 2, //Compra
                                               FechaUltimaModificacion = DateTime.Now
                                           };

                //Tipo = 2 / Compra. TODO: Map an enum.

                ////Obtengo la instancia de stock para la compra del producto
                Stock stock = Uow.Stocks.Obtener(s => s.MaxiKioscoId == factura.MaxiKioscoId && s.ProductoId == compraProd.ProductoId);
                if (stock == null)
                {
                    stock = new Stock
                                {
                                    Identifier = Guid.NewGuid(),
                                    MaxiKioscoId = factura.MaxiKioscoId,
                                    ProductoId = compraProd.ProductoId
                                };
                    Uow.Stocks.Agregar(stock);
                }

                stockTransaccion.Stock = stock;
                Uow.StockTransacciones.Agregar(stockTransaccion);

                ////Actualizar el costo del producto para el proveedor seleccionado.
                var proveedorProducto = Uow.ProveedorProductos
                    .Obtener(pp => pp.ProductoId == compraProd.ProductoId &&
                        pp.ProveedorId == factura.ProveedorId);

                //Si el producto no esta cargado para el proveedor debemos crearlo
                if (proveedorProducto == null)
                {
                    proveedorProducto = new ProveedorProducto();
                    proveedorProducto.Identifier = Guid.NewGuid();
                    proveedorProducto.ProductoId = compraProd.ProductoId;
                    proveedorProducto.ProveedorId = factura.ProveedorId;
                    proveedorProducto.CostoConIVA = compraProd.CostoActualizado.GetValueOrDefault();
                    proveedorProducto.CostoSinIVA = proveedorProducto.CostoConIVA / 1.21m;
                    proveedorProducto.FechaUltimoCambioCosto = DateTime.Now;
                    Uow.ProveedorProductos.Agregar(proveedorProducto);
                }
                else
                {
                    var nuevoCosto = compraProd.CostoActualizado ?? proveedorProducto.CostoConIVA;
                    if (nuevoCosto != proveedorProducto.CostoConIVA)
                        proveedorProducto.FechaUltimoCambioCosto = DateTime.Now;

                    proveedorProducto.CostoConIVA = nuevoCosto;
                    proveedorProducto.CostoSinIVA = proveedorProducto.CostoConIVA / 1.21m;
                    Uow.ProveedorProductos.Modificar(proveedorProducto);
                }

                ////Actualizar el precio y el costo del producto.
                var producto = Uow.Productos.Obtener(compraProd.ProductoId);
                producto.PrecioConIVA = compraProd.PrecioActualizado ?? producto.PrecioConIVA;
                producto.PrecioSinIVA = producto.PrecioConIVA / 1.21m;
                Uow.Productos.Modificar(producto);
            }

            Uow.Compras.Agregar(compra);
            Uow.Commit();
        }

        public string UltimoNumeroCompra(int maxikioscoId)
        {
            var ultimaCompra = Uow.Compras.Listado(c => c.Factura.MaxiKiosco)
                                          .Where(c => c.Factura.MaxiKioscoId == maxikioscoId)
                                          .OrderByDescending(c => c.Numero)
                                          .FirstOrDefault();

            return ultimaCompra != null ? ultimaCompra.Numero : 0.ToString();
        }
    }
}

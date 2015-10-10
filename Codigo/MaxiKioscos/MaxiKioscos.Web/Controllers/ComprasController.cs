using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MaxiKioscos.Datos.Interfaces;
using MaxiKioscos.Entidades;
using MaxiKioscos.Negocio;
using MaxiKioscos.Web.Comun.Helpers;
using MaxiKioscos.Web.Configuration;
using MaxiKioscos.Web.Models;
using PagedList;

namespace MaxiKioscos.Web.Controllers
{
    public class ComprasController : BaseController
    {
        private IComprasNegocio ComprasNegocio { get; set; }

        public ComprasController(IMaxiKioscosUow uow, IComprasNegocio comprasNegocio)
        {
            Uow = uow;
            ComprasNegocio = comprasNegocio;
        }

        public ActionResult Index(ComprasListadoModel model, int? page)
        {
            model.Filtros = model.Filtros ?? new ComprasFiltrosModel()
            {
                Desde = model.Desde,
                Nro = model.Nro,
                Hasta = model.Hasta,
                ProveedorId = model.ProveedorId
            };

            var compras = Uow.Compras.Listado(c => c.Factura.Proveedor,
                c => c.ComprasProductos)
                .Where(c => c.CuentaId == UsuarioActual.CuentaId)
                .Where(model.Filtros.GetFilterExpression())
                .OrderByDescending(c => c.Fecha);


            var pageNumber = page ?? 1;
            var pageSize = AppSettings.DefaultPageSize;
            IPagedList<Compra> lista = compras.ToPagedList(pageNumber, pageSize);

            var listadoModel = new ComprasListadoModel
            {
                List = lista,
                Filtros = model.Filtros
            };
            return PartialOrView(listadoModel);
        }

        public ActionResult Listado(ComprasFiltrosModel filtros, int? page)
        {
            var compras = Uow.Compras.Listado(c => c.Factura.Proveedor,
                c => c.ComprasProductos)
                .Where(c => c.CuentaId == UsuarioActual.CuentaId)
                .Where(filtros.GetFilterExpression())
                .OrderByDescending(c => c.Fecha);

            var lista = compras.ToPagedList(page ?? 1, AppSettings.DefaultPageSize);
            var listadoModel = new ComprasListadoModel
            {
                List = lista,
                Filtros = filtros,
                Desde = filtros.Desde,
                Nro = filtros.Nro,
                Hasta = filtros.Hasta,
                ProveedorId = filtros.ProveedorId
            };


            return PartialView("_Listado", listadoModel);
        }

        public ActionResult Detalle(int id)
        {
            var compra = ObtenerCompra(id);

            if (compra == null)
            {
                return HttpNotFound();
            }

            return PartialView(compra);
        }

        public ActionResult Crear()
        {
            var compra = new Compra() { Fecha = DateTime.Now };
            ViewBag.CantidadIngresada = null;

            return PartialView(compra);
        }

        public ActionResult CargarProducto(int productoId, int maxikioscoId, int proveedorId)
        {
            var productoCompleto = Uow.Productos.Obtener(productoId, maxikioscoId, proveedorId);

            var productoProveedor =
                Uow.ProveedorProductos.Obtener(pp => pp.ProductoId == productoId
                    && pp.ProveedorId == proveedorId);

            var compraProducto = new CompraProducto
                                     {
                                         ProductoId = productoId,
                                         Cantidad = 1,
                                         Producto = new Producto { Descripcion = productoCompleto.Descripcion },
                                         PrecioActual = productoCompleto.PrecioConIVA,
                                         CostoActual = productoProveedor != null ? productoProveedor.CostoConIVA : 0,
                                         Identifier = Guid.NewGuid()
                                     };

            compraProducto.PrecioActualizado = compraProducto.PrecioActual;
            compraProducto.CostoActualizado = productoProveedor != null ? productoProveedor.CostoConIVA : (decimal?)null;

            //Cargamos el stock actual del producto0
            compraProducto.StockAnterior = productoCompleto.Stock;
            compraProducto.StockActual = productoCompleto.Stock + compraProducto.Cantidad;
            compraProducto.PrimerCodigoProducto = productoCompleto.Codigo;
            compraProducto.ProductoMarca = productoCompleto.Marca;

            return PartialView(compraProducto);
        }

        [HttpPost]
        public ActionResult Crear(Compra compra)
        {
            if (!ModelState.IsValid)
            {
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError);
            }

            compra.CuentaId = UsuarioActual.CuentaId;
            ComprasNegocio.Crear(compra);

            return Json(new { exito = true });
        }

        public ActionResult EditarProducto()
        {
            return PartialView(new EditarProductoModel());
        }

        [HttpGet]
        public virtual JsonResult GetNumeroFacturas(string q)
        {
            var results = Uow.Facturas.Listado().Where(f => f.AutoNumero.Contains(q.ToLower()))
                                                .Where(f => f.MaxiKiosco.CuentaId == UsuarioActual.CuentaId && !f.Compras.Any())
                                                .OrderByDescending(f => f.Fecha);

            return new JsonResult()
            {
                Data = results.ToArray(),
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }

        [HttpGet]
        public virtual JsonResult GetFactura(string autonumero)
        {
            var results = Uow.Facturas.Obtener(f => f.AutoNumero.ToLower() == autonumero.ToLower());

            return new JsonResult()
            {
                Data = new { factura = results },
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }

        #region Helpers

        private Compra ObtenerCompra(int compraId)
        {
            Compra compra = Uow.Compras.Obtener(c => c.CompraId == compraId,
                c => c.ComprasProductos.Select(cp => cp.Producto.Marca),
                c => c.Factura.Proveedor,
                c => c.Factura.UsuarioCreador,
                c => c.MaxiKiosco);

            //Filtramos las compra productos eliminadas
            compra.ComprasProductos = compra.ComprasProductos.Where(cp => !cp.Eliminado).ToList();

            return compra;
        }

        #endregion
    }
}

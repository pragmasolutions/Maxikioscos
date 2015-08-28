using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.UI;
using MaxiKioscos.Datos.Interfaces;
using MaxiKioscos.Entidades;
using MaxiKioscos.Web.Comun.Atributos;
using MaxiKioscos.Web.Comun.Helpers;
using MaxiKioscos.Web.Configuration;
using MaxiKioscos.Web.Models;
using PagedList;

namespace MaxiKioscos.Web.Controllers
{
    public class ProductosController : BaseController
    {
        public ProductosController(IMaxiKioscosUow uow)
        {
            Uow = uow;
        }

        public ActionResult Index(ProductosFiltrosModel productosFiltrosModel, int? page)
        {

            List<Producto> productos = Listado(productosFiltrosModel);

            var pageNumber = page ?? 1;
            var pageSize = 30;
            IPagedList<Producto> lista = productos.OrderBy(s => s.Descripcion).ToPagedList(pageNumber, pageSize);

            var listadoModel = new ProductosListadoModel
                                   {
                                       List = lista,    
                                       Filtros = productosFiltrosModel ?? new ProductosFiltrosModel()
                                   };

            return PartialOrView(listadoModel);
        }

        public ActionResult Listado(ProductosFiltrosModel filtros, int? page)
        {
            var productos = Listado(filtros);
            var pageSize = 30;
            var lista = PagedListHelper<Producto>.Crear(productos, pageSize, page);

            var listadoModel = new ProductosListadoModel
            {
                List = lista,
                Filtros = filtros,
                Codigo = filtros.Codigo,
                Descripcion = filtros.Descripcion,
                MarcaId = filtros.MarcaId,
                Precio = filtros.Precio,
                RubroId = filtros.RubroId,
                StockReposicion = filtros.StockReposicion
            };

            return PartialView("_Listado", listadoModel);
        }

        public ActionResult Seleccionar()
        {
            ProductoSeleccionarModel productoSeleccionarModel = new ProductoSeleccionarModel();
            productoSeleccionarModel.BuscarPorDescripcion = true;
            return PartialView(productoSeleccionarModel);
        }

        //[OutputCache(NoStore = true, Duration = 0, VaryByParam = "None")]
        public ActionResult ListadoParaSeleccionar(ProductoSeleccionarModel productoSeleccionarModel)
        {
            var productos = Uow.Productos.Listado(p => p.Rubro, p => p.Marca, p => p.CodigosProductos)
                .Where(p => !p.EsPromocion &&
                    (string.IsNullOrEmpty(productoSeleccionarModel.Descripcion)
                            || (productoSeleccionarModel.BuscarPorDescripcion && p.Descripcion.ToLower().Contains(productoSeleccionarModel.Descripcion.ToLower()))
                            || (!productoSeleccionarModel.BuscarPorDescripcion && p.CodigosProductos.Any(cp => cp.Codigo.StartsWith(productoSeleccionarModel.Descripcion)))));

            if (productoSeleccionarModel.BuscarPorDescripcion)
                productos = productos.OrderBy(p => p.Descripcion);
            else
                productos = productos.OrderBy(p => p.CodigosProductos.Select(c => c.Codigo).FirstOrDefault());

            productos = productos.Take(10);

            return PartialView(productos);
        }

        public ActionResult Detalle(int id)
        {
            Producto producto = Uow.Productos.Obtener(p => p.ProductoId == id, p => p.Rubro,
                p => p.Marca,
                p => p.CodigosProductos,
                p => p.ProveedorProductos.Select(pp => pp.Proveedor));

            if (producto == null)
            {
                return HttpNotFound();
            }

            producto.CodigosProductos = producto.CodigosProductos.Where(cp => !cp.Eliminado).ToList();

            return PartialView(producto);
        }

        public ActionResult Crear()
        {
            var producto = new Producto();
            producto.CodigosProductos = new Collection<CodigoProducto>() { new CodigoProducto() };
            //LlenarControles();
            return PartialView(producto);
        }

        [HttpPost]
        public ActionResult Crear(Producto producto)
        {
            if (producto.CodigosProductos.Count == 0)
            {
                return new HttpStatusCodeResult
                    (HttpStatusCode.InternalServerError, "El producto debe contener al menos un código");
            }

            producto.Identifier = Guid.NewGuid();
            producto.CuentaId = UsuarioActual.CuentaId;
            producto.Desincronizado = true;


            if (!ModelState.IsValid)
            {
                //LlenarControles();
                return PartialView(producto);
            }

            var valido = ControlCodigos(producto);
            if (!valido)
            {
                return Json(new { exito = false, error = "Código de producto duplicado" });
            }

            foreach (var codigo in producto.CodigosProductos)
            {
                codigo.Identifier = Guid.NewGuid();
                codigo.Desincronizado = true;
                Uow.CodigosDeProducto.Agregar(codigo);
            }

            foreach (var proveedorProducto in producto.ProveedorProductos)
            {
                proveedorProducto.Identifier = Guid.NewGuid();
                proveedorProducto.Desincronizado = true;
                Uow.ProveedorProductos.Agregar(proveedorProducto);
            }
            producto.Descripcion = producto.Descripcion.ToUpper();
            Uow.Productos.Agregar(producto);;
            Uow.Commit();

            return Json(new { exito = true, codigo = producto.CodigosProductos.First().Codigo });
        }

        public ActionResult Editar(int id)
        {
            Producto producto = Uow.Productos.Obtener(p => p.ProductoId == id,
                p => p.CodigosProductos, p => p.ProveedorProductos);

            if (producto == null)
            {
                return HttpNotFound();
            }

            producto.CodigosProductos = producto.CodigosProductos.Where(cp => !cp.Eliminado).ToList();

            if (producto.CodigosProductos.Count == 0)
            {
                producto.CodigosProductos = new Collection<CodigoProducto>();
            }
            //LlenarControles();
            return PartialView(producto);
        }

        [HttpPost]
        public ActionResult Editar(Producto producto)
        {

            if (!ModelState.IsValid)
            {
                //LlenarControles();
                return PartialView(producto);
            }


            if (producto.CodigosProductos.Count == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError, "El producto debe contener al menos un código");
            }

            var valido = ControlCodigos(producto);
            if (!valido)
            {
                return Json(new { exito = false, error = "Código de producto duplicado" });
            }

            ActualizarCodigos(producto);
            ActualizarCostos(producto);
            producto.Descripcion = producto.Descripcion.ToUpper();
            Uow.Productos.Modificar(producto);
            Uow.Commit();

            return Json(new { exito = true });
        }

        public ActionResult Eliminar(int id)
        {
            Producto producto = Uow.Productos.Obtener(p => p.ProductoId == id, p => p.Rubro,
                p => p.Marca,
                p => p.CodigosProductos,
                p => p.ProveedorProductos.Select(pp => pp.Proveedor));

            if (producto == null)
            {
                return HttpNotFound();
            }

            producto.CodigosProductos = producto.CodigosProductos.Where(cp => !cp.Eliminado).ToList();
            return PartialView(producto);
        }

        [HttpPost]
        public ActionResult Eliminar(int id, FormCollection collection)
        {
            Producto producto = Uow.Productos.Obtener(p => p.ProductoId == id,
                p => p.CodigosProductos,
                p => p.ProveedorProductos);

            if (producto == null)
            {
                return HttpNotFound();
            }

            foreach (var codigo in producto.CodigosProductos)
            {
                Uow.CodigosDeProducto.Eliminar(codigo);
            }

            foreach (var costos in producto.ProveedorProductos)
            {
                Uow.ProveedorProductos.Eliminar(costos);
            }

            Uow.Productos.Eliminar(producto);
            Uow.Commit();

            return Json(new { exito = true });
        }

        public ActionResult CodigoProducto(int productoId)
        {
            var codigo = new CodigoProducto
                                    {
                                        ProductoId = productoId,
                                        Identifier = Guid.NewGuid()
                                    };
            return PartialView(codigo);
        }

        public ActionResult CostoProducto(int productoId)
        {
            var producto = Uow.Productos.Obtener(productoId);
            if (producto == null)
            {
                producto = new Producto();
            }

            var costo = new ProveedorProducto()
            {
                Producto = producto,
                ProductoId = productoId,
                Identifier = Guid.NewGuid(),
            };

            return PartialView(costo);
        }

        public ActionResult CodigoDuplicadoPopup()
        {
            return PartialView();
        }

        public ActionResult Stock(int id)
        {
            var list = Uow.Productos.ObtenerStock(id);
            return PartialView(list);
        }

        #region Helpers

        private bool ControlCodigos(Producto producto)
        {
            foreach (var codigo in producto.CodigosProductos)
            {
                //Controlar si ya existe el codigo que se esta editando.
                var cod = codigo.Codigo;
                var codigos = Uow.CodigosDeProducto.Listado().Where(cp => cp.Codigo == cod && cp.CodigoProductoId != codigo.CodigoProductoId).ToList();
                if (codigos.Count > 0)
                {
                    return false;
                }
            }
            return true;
        }

        private void ActualizarCodigos(Producto producto)
        {
            //Eliminar los codigos que estan vacios
            foreach (var codigo in producto.CodigosProductos.ToList())
            {
                if (string.IsNullOrEmpty(codigo.Codigo))
                    producto.CodigosProductos.Remove(codigo);
            }

            var codigos = Uow.CodigosDeProducto.Listado()
                .Where(cp => cp.ProductoId == producto.ProductoId)
                .ToList();

            var codigosAEliminar = codigos
                .Where(cp => producto.CodigosProductos.All(x => x.CodigoProductoId != cp.CodigoProductoId))
                .ToList();

            var codigosAAgregar = producto.CodigosProductos
                .Where(cp => cp.CodigoProductoId == 0)
                .ToList();

            var codigosAModificar =
               codigos
               .Where(cp => !codigosAAgregar.Any(x => x.CodigoProductoId == cp.CodigoProductoId))
               .Where(cp => !codigosAEliminar.Any(x => x.CodigoProductoId == cp.CodigoProductoId))
               .ToList();

            //Eliminar codigos de producto
            foreach (var codigoProducto in codigosAEliminar)
            {
                Uow.CodigosDeProducto.Eliminar(codigoProducto);
            }

            //Agregar codigos de producto
            foreach (var codigoProducto in codigosAAgregar)
            {
                codigoProducto.Identifier = Guid.NewGuid();
                Uow.CodigosDeProducto.Agregar(codigoProducto);
            }

            //Modificar codigos de producto actuales
            foreach (var codigoProducto in codigosAModificar)
            {
                var codigoActualizado =
                    producto.CodigosProductos.FirstOrDefault(c => c.CodigoProductoId == codigoProducto.CodigoProductoId);

                if (codigoActualizado != null)
                {
                    codigoProducto.Codigo = codigoActualizado.Codigo;
                    Uow.CodigosDeProducto.Modificar(codigoProducto);
                }
            }

            ////Removemos los codigos de la entidad productos para evitar
            //// conflictos con los codigos actualizados anterior mente.
            producto.CodigosProductos.Clear();
        }

        private void ActualizarCostos(Producto producto)
        {
            var costos = Uow.ProveedorProductos.Listado()
                .Where(pp => pp.ProductoId == producto.ProductoId)
                .ToList();

            var costosAEliminar = costos
                .Where(pp => producto.ProveedorProductos.All(x => x.ProveedorProductoId != pp.ProveedorProductoId))
                .ToList();

            var costosAAgregar = producto.ProveedorProductos
                .Where(cp => cp.ProveedorProductoId == 0)
                .ToList();

            var costosAModificar =
               costos
               .Where(cp => !costosAAgregar.Any(x => x.ProveedorProductoId == cp.ProveedorProductoId))
               .Where(cp => !costosAEliminar.Any(x => x.ProveedorProductoId == cp.ProveedorProductoId))
               .ToList();

            //Eliminar codigos de producto
            foreach (var costo in costosAEliminar)
            {
                Uow.ProveedorProductos.Eliminar(costo);
            }

            //Agregar codigos de producto
            foreach (var costo in costosAAgregar)
            {
                costo.Identifier = Guid.NewGuid();
                costo.Desincronizado = true;
                costo.FechaUltimoCambioCosto = DateTime.Now;
                Uow.ProveedorProductos.Agregar(costo);
            }

            //Modificar codigos de producto actuales
            foreach (var costo in costosAModificar)
            {
                var costoActualizado = producto.ProveedorProductos.FirstOrDefault(c => c.ProveedorProductoId == costo.ProveedorProductoId);

                if (costoActualizado != null)
                {
                    if (costo.CostoConIVA != costoActualizado.CostoConIVA)
                        costo.FechaUltimoCambioCosto = DateTime.Now;

                    costo.CostoConIVA = costoActualizado.CostoConIVA;
                    costo.CostoSinIVA = costoActualizado.CostoSinIVA;
                    costo.ProveedorId = costoActualizado.ProveedorId;
                    costo.ProductoId = costoActualizado.ProductoId;
                    costo.Desincronizado = true;

                    Uow.ProveedorProductos.Modificar(costo);
                }
            }

            ////Removemos los codigos de la entidad productos para evitar
            //// conflictos con los codigos actualizados anterior mente.
            producto.ProveedorProductos.Clear();
        }

        private List<Producto> Listado(ProductosFiltrosModel filtros)
        {
            return Uow.Productos
                .Listado(p => p.Rubro, f => f.Marca, f => f.CodigosProductos,
                         f => f.ProveedorProductos.Select(pp => pp.Proveedor),
                         p => p.ComprasProductos.Select(cp => cp.Compra))
                .Where(p => p.CuentaId == UsuarioActual.CuentaId && !p.EsPromocion)
                .Where(filtros.GetFilterExpression())
                .OrderBy(p => p.Descripcion)
                .ToList();
        }

        #endregion
    }
}

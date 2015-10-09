using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity.Infrastructure;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Web.Mvc;
using System.Web.UI;
using MaxiKioscos.Datos.Interfaces;
using MaxiKioscos.Entidades;
using MaxiKioscos.Web.Comun.Atributos;
using MaxiKioscos.Web.Comun.Helpers;
using MaxiKioscos.Web.Configuration;
using MaxiKioscos.Web.Models;
using PagedList;
using MaxiKioscos.Negocio;

namespace MaxiKioscos.Web.Controllers
{
    public class PromocionesController : BaseController
    {
        private IPromocionesNegocio PromocionesNegocio { get; set; }

        public PromocionesController(IMaxiKioscosUow uow, IPromocionesNegocio promocionesNegocio)
        {
            Uow = uow;
            PromocionesNegocio = promocionesNegocio;
        }

        public ActionResult Index(PromocionesFiltrosModel promocionesFiltrosModel, int? page)
        {

            IQueryable<Producto> productos = Listado(promocionesFiltrosModel);

            var pageNumber = page ?? 1;
            var pageSize = 30;
            IPagedList<Producto> lista = productos.OrderBy(s => s.Descripcion).ToPagedList(pageNumber, pageSize);

            var listadoModel = new PromocionesListadoModel
                                   {
                                       List = lista,
                                       Filtros = promocionesFiltrosModel ?? new PromocionesFiltrosModel()
                                   };

            return PartialOrView(listadoModel);
        }

        public ActionResult Listado(PromocionesFiltrosModel filtros, int? page)
        {
            var productos = Listado(filtros);
            var pageSize = 30;
            var lista = productos.ToPagedList(page ?? 1, pageSize);

            var listadoModel = new PromocionesListadoModel
            {
                List = lista,
                Filtros = filtros,
                Codigo = filtros.Codigo,
                Descripcion = filtros.Descripcion,
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
                .Where(p => string.IsNullOrEmpty(productoSeleccionarModel.Descripcion)
                            || (productoSeleccionarModel.BuscarPorDescripcion && p.Descripcion.ToLower().Contains(productoSeleccionarModel.Descripcion.ToLower()))
                            || (!productoSeleccionarModel.BuscarPorDescripcion && p.CodigosProductos.Any(cp => cp.Codigo.StartsWith(productoSeleccionarModel.Descripcion))));

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
                p => p.PromocionesHijos,
                p => p.PromocionesHijos.Select(ph => ph.Hijo),
                p => p.ProveedorProductos.Select(pp => pp.Proveedor));

            if (producto == null)
            {
                return HttpNotFound();
            }

            producto.CodigosProductos = producto.CodigosProductos.Where(cp => !cp.Eliminado).ToList();
            producto.PromocionMaxikioscos = PromocionesNegocio.ObtenerStock(id);
            return PartialView(producto);
        }

        public ActionResult Crear()
        {
            var promocion = new Producto();
            promocion.CodigosProductos = new Collection<CodigoProducto>() { new CodigoProducto() };
            promocion.MarcaId = 1;
            promocion.PromocionMaxikioscos = Uow.MaxiKioscos.Listado().Select(m => new PromocionMaxikiosco
                                                                                   {
                                                                                       MaxiKioscoId = m.MaxiKioscoId,
                                                                                       MaxiKioscoNombre = m.Nombre,
                                                                                       StockActual = 0,
                                                                                       StockAnterior = 0
                                                                                   }).ToList();

            //LlenarControles();
            return PartialView(promocion);
        }


        [HttpPost]
        public ActionResult Crear(Producto producto)
        {
            if (producto.CodigosProductos.Count == 0)
            {
                return new HttpStatusCodeResult
                    (HttpStatusCode.InternalServerError, "El producto debe contener al menos un código");
            }
            producto.EsPromocion = true;
            producto.Identifier = Guid.NewGuid();
            producto.CuentaId = UsuarioActual.CuentaId;
            producto.Desincronizado = true;

            //hardcodeo la marca para que no rompa la garcha en la validacion
            producto.MarcaId = 1;
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

            producto.MarcaId = null;
            foreach (var codigo in producto.CodigosProductos)
            {
                codigo.Identifier = Guid.NewGuid();
                Uow.CodigosDeProducto.Agregar(codigo);
            }

            foreach (var hijo in producto.PromocionesHijos)
            {
                hijo.Identifier = Guid.NewGuid();
                Uow.ProductoPromociones.Agregar(hijo);
            }

            foreach (var proveedorProducto in producto.ProveedorProductos)
            {
                proveedorProducto.Identifier = Guid.NewGuid();
                Uow.ProveedorProductos.Agregar(proveedorProducto);
            }

            producto.Descripcion = producto.Descripcion.ToUpper();
            Uow.Productos.Agregar(producto);
            Uow.Commit();

            ActualizarStock(producto, "Creación");
            return Json(new { exito = true, codigo = producto.CodigosProductos.First().Codigo });
        }

        public ActionResult Editar(int id)
        {
            Producto producto = Uow.Productos.Obtener(p => p.ProductoId == id,
                p => p.CodigosProductos, p => p.ProveedorProductos, p => p.PromocionesHijos, p => p.PromocionesPadres);

            if (producto == null)
            {
                return HttpNotFound();
            }

            producto.CodigosProductos = producto.CodigosProductos.Where(cp => !cp.Eliminado).ToList();

            if (producto.CodigosProductos.Count == 0)
            {
                producto.CodigosProductos = new Collection<CodigoProducto>();
            }
            producto.MarcaId = 1;
            producto.PromocionMaxikioscos = PromocionesNegocio.ObtenerStock(id);
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

            producto.MarcaId = null;
            producto.EsPromocion = true;

            ActualizarCodigos(producto);
            ActualizarCostos(producto);
            ActualizarPromociones(producto);
            producto.Descripcion = producto.Descripcion.ToUpper();
            Uow.Productos.Modificar(producto);

            try
            {
                Uow.Commit();
                ActualizarStock(producto, "Edición");
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
            

            return Json(new { exito = true });
        }

        public ActionResult Eliminar(int id)
        {
            Producto producto = Uow.Productos.Obtener(p => p.ProductoId == id, p => p.Rubro,
                p => p.Marca,
                p => p.CodigosProductos,
                p => p.PromocionesHijos,
                p => p.PromocionesHijos.Select(ph => ph.Hijo),
                p => p.ProveedorProductos.Select(pp => pp.Proveedor));

            if (producto == null)
            {
                return HttpNotFound();
            }

            producto.CodigosProductos = producto.CodigosProductos.Where(cp => !cp.Eliminado).ToList();
            producto.PromocionMaxikioscos = PromocionesNegocio.ObtenerStock(id);

            return PartialView(producto);
        }

        [HttpPost]
        public ActionResult Eliminar(int id, FormCollection collection)
        {
            Producto producto = Uow.Productos.Obtener(p => p.ProductoId == id,
                p => p.CodigosProductos,
                p => p.PromocionesHijos,
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

            foreach (var hijo in producto.PromocionesHijos)
            {
                Uow.ProductoPromociones.Eliminar(hijo);
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

        public ActionResult PromocionProducto(int productoId)
        {
            var producto = Uow.Productos.Obtener(productoId);
            if (producto == null)
            {
                producto = new Producto();
            }

            var promo = new ProductoPromocion()
            {
                Hijo = producto,
                HijoId = productoId,
                Identifier = Guid.NewGuid(),
            };
            return PartialView(promo);
        }

        public ActionResult CodigoDuplicadoPopup()
        {
            return PartialView();
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

        private void ActualizarPromociones(Producto producto)
        {
            var promos = Uow.ProductoPromociones.Listado()
                .Where(pp => pp.PadreId == producto.ProductoId)
                .ToList();

            var promosAEliminar = promos
                .Where(pp => producto.PromocionesHijos.All(x => x.ProductoPromocionId != pp.ProductoPromocionId))
                .ToList();

            var promosAAgregar = producto.PromocionesHijos
                .Where(cp => cp.ProductoPromocionId == 0)
                .ToList();

            var promosAModificar =
               promos
               .Where(cp => !promosAAgregar.Any(x => x.ProductoPromocionId == cp.ProductoPromocionId))
               .Where(cp => !promosAEliminar.Any(x => x.ProductoPromocionId == cp.ProductoPromocionId))
               .ToList();

            //Eliminar codigos de producto
            foreach (var promo in promosAEliminar)
            {
                Uow.ProductoPromociones.Eliminar(promo);
            }

            
            //Agregar codigos de producto
            foreach (var promo in promosAAgregar)
            {
                promo.Identifier = Guid.NewGuid();
                promo.Desincronizado = true;
                promo.PadreId = producto.ProductoId;
                Uow.ProductoPromociones.Agregar(promo);
            }

            //Modificar codigos de producto actuales
            foreach (var promo in promosAModificar)
            {
                var original = producto.PromocionesHijos.FirstOrDefault(c => c.ProductoPromocionId == promo.ProductoPromocionId);

                if (original != null)
                {
                    promo.Unidades = original.Unidades;
                    promo.HijoId = original.HijoId;
                    promo.Desincronizado = true;

                    Uow.ProductoPromociones.Modificar(promo);
                }
            }

            producto.PromocionesHijos.Clear();
        }

        private void ActualizarStock(Producto producto, string operacion)
        {
            var seActualizo = false;
            foreach (var promo in producto.PromocionMaxikioscos)
            {
                seActualizo = true;
                var diferencia = promo.StockActual - promo.StockAnterior;
                if (diferencia != 0)
                {
                    var stock = Uow.Stocks.Obtener(s => s.ProductoId == producto.ProductoId && s.MaxiKioscoId == promo.MaxiKioscoId);
                    if (stock == null)
                    {
                        stock = new Stock
                        {
                            ProductoId = producto.ProductoId,
                            MaxiKioscoId = promo.MaxiKioscoId,
                            StockActual = promo.StockActual,
                            Identifier = Guid.NewGuid(),
                            Desincronizado = true,
                            OperacionCreacion = operacion + " desde promociones web",
                            FechaCreacion = DateTime.Now,
                            StockTransacciones = new List<StockTransaccion>()
                            {
                                new StockTransaccion()
                                {
                                    Cantidad = diferencia,
                                    Desincronizado = true,
                                    Eliminado = false,
                                    Identifier = Guid.NewGuid(),
                                    StockTransaccionTipoId = 3
                                }
                            }
                        };
                        Uow.Stocks.Agregar(stock);
                    }
                    else
                    {
                        stock.StockActual += diferencia;
                        Uow.Stocks.Modificar(stock);

                        var trans = new StockTransaccion()
                        {
                            Desincronizado = true,
                            Identifier = Guid.NewGuid(),
                            Cantidad = diferencia,
                            StockId = stock.StockId,
                            StockTransaccionTipoId = 3
                        };
                        Uow.StockTransacciones.Agregar(trans);
                    }
                }
                
            }

            if (seActualizo)
            {
                Uow.Commit();;
            }
        }

        private IQueryable<Producto> Listado(PromocionesFiltrosModel filtros)
        {
            return Uow.Productos
                .Listado(p => p.Rubro, f => f.Marca, f => f.CodigosProductos,
                         p => p.PromocionesHijos, p => p.PromocionesHijos.Select(pp => pp.Hijo),
                         f => f.ProveedorProductos.Select(pp => pp.Proveedor),
                         p => p.ComprasProductos.Select(cp => cp.Compra))
                .Where(p => p.CuentaId == UsuarioActual.CuentaId && p.EsPromocion)
                .Where(filtros.GetFilterExpression())
                .OrderBy(p => p.Descripcion);
        }

        #endregion
    }
}

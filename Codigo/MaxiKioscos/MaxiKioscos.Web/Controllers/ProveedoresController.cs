using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MaxiKioscos.Datos.Interfaces;
using MaxiKioscos.Entidades;
using MaxiKioscos.Web.Comun.Helpers;
using MaxiKioscos.Web.Configuration;
using MaxiKioscos.Web.Models;
using PagedList;

namespace MaxiKioscos.Web.Controllers
{
    public class ProveedoresController : BaseController
    {
        public ProveedoresController(IMaxiKioscosUow uow)
        {
            Uow = uow;
        }

        public ActionResult Index(ProveedoresListadoModel model, int? page)
        {
            model.Filtros = model.Filtros ?? new ProveedoresFiltrosModel()
            {
                CuitNro = model.CuitNro,
                LocalidadId = model.LocalidadId,
                PalabrasABuscar = model.PalabrasABuscar,
                TipoCuitId = model.TipoCuitId
            };
            List<Proveedor> proveedores = Uow.Proveedores.Listado(p => p.Localidad, p => p.TipoCuit)
                .Where(p => p.CuentaId == UsuarioActual.CuentaId)
                .Where(model.Filtros.GetFilterExpression())
                .ToList();

            var pageNumber = page ?? 1;
            var pageSize = AppSettings.DefaultPageSize;
            IPagedList<Proveedor> lista = proveedores.OrderBy(s => s.Nombre).ToPagedList(pageNumber, pageSize);
            model.List = lista;

            return PartialOrView(model);
        }

        public ActionResult Listado(ProveedoresFiltrosModel filtros, int? page)
        {
            var proveedores = Uow.Proveedores.Listado(p => p.Localidad, p => p.TipoCuit)
                .Where(p => p.CuentaId == UsuarioActual.CuentaId)
                .Where(filtros.GetFilterExpression());

            var lista = proveedores.ToPagedList(page ?? 1, AppSettings.DefaultPageSize);
            var listadoModel = new ProveedoresListadoModel
            {
                List = lista,
                Filtros = filtros,
                CuitNro = filtros.CuitNro,
                LocalidadId = filtros.LocalidadId,
                PalabrasABuscar = filtros.PalabrasABuscar,
                TipoCuitId = filtros.TipoCuitId
            };

            return PartialView("_Listado", listadoModel);
        }

        public ActionResult Detalle(int id)
        {
            Proveedor proveedor = Uow.Proveedores.Obtener(p => p.ProveedorId == id,
                p => p.Localidad, p => p.TipoCuit);

            if (proveedor == null)
            {
                return HttpNotFound();
            }

            return PartialView(proveedor);
        }

        public ActionResult Crear()
        {
            var proveedor = new Proveedor();
            return PartialView(proveedor);
        }

        [HttpPost]
        public ActionResult Crear(Proveedor proveedor)
        {
            if (!ModelState.IsValid)
            {
                return PartialView();
            }

            proveedor.Identifier = Guid.NewGuid();
            proveedor.CuentaId = 1;
            proveedor.Desincronizado = true;
            Uow.Proveedores.Agregar(proveedor);
            Uow.Commit();

            return PartialView();
        }

        public ActionResult Editar(int id)
        {
            Proveedor proveedor = Uow.Proveedores.Obtener(id);

            if (proveedor == null)
            {
                return HttpNotFound();
            }

            return PartialView(proveedor);
        }

        [HttpPost]
        public ActionResult Editar(Proveedor proveedor)
        {
            if (!ModelState.IsValid)
            {
                return PartialView();
            }
            
            proveedor.Desincronizado = true;
            Uow.Proveedores.Modificar(proveedor);
            Uow.Commit();

            return PartialView();
        }

        public ActionResult Eliminar(int id)
        {
            Proveedor proveedor = Uow.Proveedores.Obtener(p => p.ProveedorId == id,
                p => p.Localidad, p => p.TipoCuit);

            if (proveedor == null)
            {
                return HttpNotFound();
            }

            return PartialView(proveedor);
        }

        [HttpPost]
        public ActionResult Eliminar(int id, FormCollection collection)
        {
            Proveedor proveedor = Uow.Proveedores.Obtener(id);
            if (proveedor == null)
            {
                return HttpNotFound();
            }
            Uow.Proveedores.Eliminar(proveedor);
            Uow.Commit();
            return PartialView();
        }
    }
}

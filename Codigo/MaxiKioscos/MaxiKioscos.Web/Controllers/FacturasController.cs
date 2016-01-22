using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MaxiKioscos.Datos.Interfaces;
using MaxiKioscos.Entidades;
using MaxiKioscos.Seguridad;
using MaxiKioscos.Web.Comun.Helpers;
using MaxiKioscos.Web.Configuration;
using MaxiKioscos.Web.Filters;
using MaxiKioscos.Web.Models;
using PagedList;

namespace MaxiKioscos.Web.Controllers
{
    [ActivityAuthorize(Actions = MaxikioscoPermisos.FACTURAS)]
    public class FacturasController : BaseController
    {
        public FacturasController(IMaxiKioscosUow uow)
        {
            Uow = uow;
        }

        public ActionResult Index(FacturasListadoModel model,int? page)
        {
            model.Filtros = model.Filtros ?? new FacturasFiltrosModel()
            {
                Desde = model.Desde,
                FacturaNro = model.FacturaNro,
                Hasta = model.Hasta,
                MaxiKioscoId = model.MaxiKioscoId,
                ProveedorId = model.ProveedorId,
                TieneCompra = model.TieneCompra
            };

            List<Factura> facturas = Uow.Facturas.Listado(f => f.Proveedor, f => f.MaxiKiosco, f => f.Compras)
                .Where(f => f.MaxiKiosco.CuentaId == UsuarioActual.CuentaId)
                .Where(model.Filtros.GetFilterExpression())
                .OrderByDescending(f => f.Fecha)
                .ToList();

            facturas =
                facturas.Where(
                    f =>
                        string.IsNullOrEmpty(model.Filtros.FacturaNro) ||
                        (f.NroFormateado.StartsWith(model.Filtros.FacturaNro) ||
                         f.AutoNumero.StartsWith(model.Filtros.FacturaNro))).ToList();
            var pageNumber = page ?? 1;
            var pageSize = AppSettings.DefaultPageSize;
            IPagedList<Factura> lista = facturas.ToPagedList(pageNumber, pageSize);

            var listadoModel = new FacturasListadoModel
            {
                List = lista,
                Filtros = model.Filtros
            };
            return PartialOrView(listadoModel);
        }

        public ActionResult Listado(FacturasFiltrosModel filtros, int? page)
        {
            var facturas = Uow.Facturas.Listado(f => f.Proveedor, f => f.MaxiKiosco, f => f.Compras)
                .Where(f => f.MaxiKiosco.CuentaId == UsuarioActual.CuentaId)
                .Where(filtros.GetFilterExpression()).ToList();

            facturas =
               facturas.Where(
                   f =>
                       string.IsNullOrEmpty(filtros.FacturaNro) ||
                       (f.NroFormateado.StartsWith(filtros.FacturaNro) ||
                        f.AutoNumero.StartsWith(filtros.FacturaNro)))
                .OrderByDescending(f => f.Fecha).ToList();


            var lista = facturas.ToPagedList(page ?? 1, AppSettings.DefaultPageSize);
            var listadoModel = new FacturasListadoModel
            {
                List = lista,
                Filtros = filtros,
                Desde = filtros.Desde,
                FacturaNro = filtros.FacturaNro,
                Hasta = filtros.Hasta,
                MaxiKioscoId = filtros.MaxiKioscoId,
                ProveedorId = filtros.ProveedorId,
                TieneCompra = filtros.TieneCompra
            };


            return PartialView("_Listado", listadoModel);
        }

        public ActionResult Detalle(int id)
        {
            Factura factura = Uow.Facturas.Obtener(f => f.FacturaId == id, f => f.MaxiKiosco, f => f.Proveedor);
            return PartialView(factura);
        }

        public ActionResult Crear()
        {
            LlenarControles();
            return PartialView(new Factura() { Fecha = DateTime.Now});
        }

        private void LlenarControles()
        {
            var provedores = new SelectList(Uow.Proveedores.Listado(), "ProveedorId", "Nombre").ToList();
            provedores.Insert(0, new SelectListItem());
            ViewBag.Proveedores = new SelectList(provedores, "Value", "Text");

            var kioscos = new SelectList(Uow.MaxiKioscos.Listado(), "MaxiKioscoId", "Nombre").ToList();
            kioscos.Insert(0, new SelectListItem());
            ViewBag.MaxiKioscos = new SelectList(kioscos, "Value", "Text");
        }

        [HttpPost]
        public ActionResult Crear(Factura factura)
        {
            if (!ModelState.IsValid)
            {
                LlenarControles();
                return PartialView(factura);
            }
            factura.Identifier = Guid.NewGuid();
            factura.UsuarioId = UsuarioActual.Usuario.UsuarioId;
            factura.FechaCreacion = DateTime.Now;

            var maxikiosco = Uow.MaxiKioscos.Obtener(factura.MaxiKioscoId);
            var fact = Uow.Facturas.Listado(f => f.MaxiKiosco).Where(f => f.MaxiKioscoId == factura.MaxiKioscoId && f.AutoNumero.StartsWith("WEB_")).OrderBy(f => f.FacturaId).ToList();
            if (fact.Any())
            {
                var fact2 = fact.Last();
                var primerParte = String.Format("WEB_{0}", maxikiosco.Abreviacion);
                var numero = Convert.ToInt32(fact2.AutoNumero.Replace(primerParte, ""));
                factura.AutoNumero = String.Format("{0}{1}", primerParte, numero + 1);
            }
            else
            {
                
                factura.AutoNumero = String.Format("WEB_{0}1", maxikiosco.Abreviacion);
            }
            
            
            Uow.Facturas.Agregar(factura);
            Uow.Commit();

            return new JsonResult() { Data = new { exito = true }, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        public ActionResult Editar(int id)
        {
            LlenarControles();
            Factura factura = Uow.Facturas.Obtener(f => f.FacturaId == id, f => f.MaxiKiosco, f => f.Proveedor);
            return PartialView(factura);
        }

        [HttpPost]
        public ActionResult Editar(Factura factura)
        {
            if (!ModelState.IsValid)
            {
                LlenarControles();
                return PartialView(factura);
            }

            Uow.Facturas.Modificar(factura);
            Uow.Commit();

            return new JsonResult() { Data = new { exito = true }, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        public ActionResult Eliminar(int id)
        {
            Factura factura = Uow.Facturas.Obtener(f => f.FacturaId == id, f => f.MaxiKiosco, f => f.Proveedor);
            return PartialView(factura);
        }

        [HttpPost]
        public ActionResult Eliminar(int id, FormCollection collection)
        {
            Factura factura = Uow.Facturas.Obtener(f => f.FacturaId == id,f => f.Compras);
            if (factura == null)
            {
                return HttpNotFound();
            }

            if (factura.TieneCompra)
            {
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError);
            }

            Uow.Facturas.Eliminar(factura);
            Uow.Commit();
            return new JsonResult() { Data = new { exito = true }, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        public ActionResult Finalizar(int id)
        {
            Factura factura = Uow.Facturas.Obtener(f => f.FacturaId == id, f => f.MaxiKiosco, f => f.Proveedor);
            return PartialView(factura);
        }

        [HttpPost]
        public ActionResult Finalizar(int id, FormCollection collection)
        {
            Factura factura = Uow.Facturas.Obtener(f => f.FacturaId == id, f => f.Compras);
            if (factura == null)
            {
                return HttpNotFound();
            }

            if (factura.Finalizada)
            {
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError);
            }

            factura.Finalizada = true;

            Uow.Facturas.Modificar(factura);

            Uow.Commit();

            return new JsonResult() { Data = new { exito = true }, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        [HttpPost]
        public ActionResult Obtener(int facturaId)
        {
            Factura factura = Uow.Facturas.Obtener(f => f.FacturaId == facturaId, f => f.Proveedor,f => f.MaxiKiosco);
            if (factura == null || factura.Proveedor == null)
            {
                return HttpNotFound();
            }

            var proveedor = factura.Proveedor;
            return Json(new
                {
                    facturaNro = factura.FacturaNro,
                    importeTotal = factura.ImporteTotal, 
                    proveedorId = proveedor.ProveedorId,
                    proveedor = proveedor.Nombre,
                    maxiKioscoId = factura.MaxiKioscoId,
                    maxikiosco = factura.MaxiKiosco.Nombre,
                    percepcionDGR = proveedor.PercepcionDGR,
                    aplicaPercepcionIVA = proveedor.AplicaPercepcionIVA,
                    autoNumero = factura.AutoNumero,
                    tipoComprobante = factura.Proveedor.TipoComprobante
                });
        }
    }
}

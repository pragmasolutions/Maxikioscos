using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
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
    public class CostosController : BaseController
    {
        public CostosController(IMaxiKioscosUow uow)
        {
            Uow = uow;
        }

        public ActionResult Index(CostosListadoModel model,int? page)
        {
            model.Filtros = model.Filtros ?? new CostosFiltrosModel()
            {
                Desde = model.Desde,
                NroComprobante = model.NroComprobante,
                Hasta = model.Hasta,
                MaxiKioscoId = model.MaxiKioscoId,
                UsuarioId = model.UsuarioId,
                Estado = model.Estado,
                CategoriaCostoId = model.CategoriaCostoId
            };

            IQueryable<Costo> costos = Uow.Costos.Listado(c => c.CategoriaCosto, c => c.CierreCaja,
                                            c => c.CierreCaja.Usuario, c => c.CierreCaja.MaxiKiosco)
                .Where(model.Filtros.GetFilterExpression())
                .OrderByDescending(f => f.Fecha);

            var pageNumber = page ?? 1;
            var pageSize = AppSettings.DefaultPageSize;
            IPagedList<Costo> lista = costos.ToPagedList(pageNumber, pageSize);

            var listadoModel = new CostosListadoModel
            {
                List = lista,
                Filtros = model.Filtros
            };
            return PartialOrView(listadoModel);
        }

        public ActionResult Listado(CostosFiltrosModel filtros, int? page)
        {
            var costos = Uow.Costos.Listado(c => c.CategoriaCosto, c => c.CierreCaja,
                                            c => c.CierreCaja.Usuario, c => c.CierreCaja.MaxiKiosco)
                .Where(filtros.GetFilterExpression())
                .OrderByDescending(f => f.Fecha);

            var lista = costos.ToPagedList(page ?? 1, AppSettings.DefaultPageSize);
            var listadoModel = new CostosListadoModel
            {
                List = lista,
                Filtros = filtros,
                Desde = filtros.Desde,
                NroComprobante = filtros.NroComprobante,
                Hasta = filtros.Hasta,
                MaxiKioscoId = filtros.MaxiKioscoId,
                UsuarioId = filtros.UsuarioId,
                Estado = filtros.Estado,
                CategoriaCostoId = filtros.CategoriaCostoId
            };


            return PartialView("_Listado", listadoModel);
        }

        public ActionResult Detalle(int id)
        {
            Costo costo = Uow.Costos.Obtener(c => c.CostoId == id, c => c.CategoriaCosto, c => c.CierreCaja,
                                            c => c.CierreCaja.Usuario, c => c.CierreCaja.MaxiKiosco);
            return PartialView(costo);
        }
        
        public ActionResult Eliminar(int id)
        {
            Costo costo = Uow.Costos.Obtener(c => c.CostoId == id, c => c.CategoriaCosto, c => c.CierreCaja,
                                            c => c.CierreCaja.Usuario, c => c.CierreCaja.MaxiKiosco);
            return PartialView(costo);
        }

        [HttpPost]
        public ActionResult Eliminar(int id, FormCollection collection)
        {
            Costo costo = Uow.Costos.Obtener(f => f.CostoId == id);
            if (costo == null)
            {
                return HttpNotFound();
            }

            if (costo.Aprobado)
            {
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError);
            }

            Uow.Costos.Eliminar(costo);
            Uow.Commit();
            return new JsonResult() { Data = new { exito = true }, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        [HttpPost]
        public ActionResult Aprobar(int id)
        {
            Costo costo = Uow.Costos.Obtener(id);
            if (costo == null)
            {
                return HttpNotFound();
            }
            costo.Aprobado = true;
            costo.Desincronizado = true;
            Uow.Costos.Modificar(costo);
            Uow.Commit();
            return new JsonResult() { Data = new { exito = true }, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        //[HttpPost]
        //public ActionResult Obtener(int id)
        //{
        //    Costo costo = Uow.Costos.Obtener(c => c.CostoId == id, c => c.CategoriaCosto, c => c.CierreCaja,
        //                                    c => c.CierreCaja.Usuario, c => c.CierreCaja.MaxiKiosco);
        //    if (costo == null)
        //    {
        //        return HttpNotFound();
        //    }

        //    var proveedor = costo.Proveedor;
        //    return Json(new
        //        {
        //            costoNro = costo.CostoNro,
        //            importeTotal = costo.ImporteTotal, 
        //            proveedorId = proveedor.ProveedorId,
        //            proveedor = proveedor.Nombre,
        //            maxiKioscoId = costo.MaxiKioscoId,
        //            maxikiosco = costo.MaxiKiosco.Nombre,
        //            percepcionDGR = proveedor.PercepcionDGR,
        //            aplicaPercepcionIVA = proveedor.AplicaPercepcionIVA,
        //            autoNumero = costo.AutoNumero,
        //            tipoComprobante = costo.Proveedor.TipoComprobante
        //        });
        //}
    }
}

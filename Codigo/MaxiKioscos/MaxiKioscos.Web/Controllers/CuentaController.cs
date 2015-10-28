using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MaxiKioscos.Datos.Interfaces;
using MaxiKioscos.Entidades;
using MaxiKioscos.Seguridad;
using MaxiKioscos.Web.Comun.Atributos;
using MaxiKioscos.Web.Comun.Helpers;
using MaxiKioscos.Web.Configuration;
using MaxiKioscos.Web.Models;
using PagedList;
using WebMatrix.WebData;

namespace MaxiKioscos.Web.Controllers
{
    [AjaxAuthorize(Roles = MaxikioscoRoles.AnyAdminRoles)]
    public class CuentaController : BaseController
    {
        public CuentaController(IMaxiKioscosUow uow)
        {
            Uow = uow;
        }

        public ActionResult Index(int? page)
        {
            var cuenta = Uow.Cuentas.Obtener(c => c.CuentaId == UsuarioActual.CuentaId, c => c.MotivoCorreccion);
            return PartialOrView(cuenta);
        }


        public ActionResult Editar(int id)
        {
            Cuenta cuenta = Uow.Cuentas.Obtener(id);
            return PartialView(cuenta);
        }

        [HttpPost]
        public ActionResult Editar(Cuenta cuenta)
        {
            if (cuenta.SincronizarAutomaticamente.GetValueOrDefault() && cuenta.IntervaloSincronizacion == null)
                ModelState.AddModelError("IntervaloSincronizacion", "Debe ingresar un intervalo de sincronización");

            if (!ModelState.IsValid)
                return PartialView(cuenta);
            
            Uow.Cuentas.Modificar(cuenta);
            Uow.Commit();
            var obj = new
                          {
                              cuenta.PorcentajePercepcionIVA,
                              cuenta.AplicarPercepcionIVADesde,
                              cuenta.MargenImporteFactura
                          };
            UsuarioActual.ResetearValoresCacheados();
            return new JsonResult() { Data = new { exito = true, fields = obj }, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

    }
}

using System.Web.Mvc;
using MaxiKioscos.Datos.Interfaces;
using MaxiKioscos.Seguridad;
using MaxiKioscos.Web.Comun.Atributos;

namespace MaxiKioscos.Web.Controllers
{
    [AjaxAuthorize(Roles = MaxikioscoRoles.AnyAdminRoles)]
    public abstract class BaseController : Controller
    {
        protected IMaxiKioscosUow Uow { get; set; }

        protected ActionResult PartialOrView(object model)
        {
            if (this.Request.IsAjaxRequest()) return PartialView(model);
            return View(model);
        }

        // NOT NECESSARY TO DISPOSE THE UOW IN OUR CONTROLLERS
        // Recall that we let IoC inject the Uow into our controllers
        // We can depend upon on IoC to dispose the UoW for us
        // when Web API disposes the IoC container.        
        // 
        // IF YOU DIDN'T USE IoC, WE WOULD NEED THE FOLLOWING
        //
        //// base ApiController is IDisposable
        //// Dispose of the repository if it is IDisposable
        //protected override void Dispose(bool disposing)
        //{
        //    if (Uow != null && Uow is IDisposable)
        //    {
        //        ((IDisposable)Uow).Dispose();
        //        Uow = null;
        //    }
        //    base.Dispose(disposing);
        //}
    }

}

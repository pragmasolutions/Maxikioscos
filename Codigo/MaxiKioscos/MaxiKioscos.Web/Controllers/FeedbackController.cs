using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using Mandrill;
using MaxiKioscos.Datos.Interfaces;
using MaxiKioscos.Email;
using MaxiKioscos.Email.Models;
using MaxiKioscos.Entidades;
using MaxiKioscos.Negocio;
using MaxiKioscos.Web.Comun.Helpers;
using MaxiKioscos.Web.Configuration;
using MaxiKioscos.Web.Filters;
using MaxiKioscos.Web.Models;
using Maxikioscos.Comun.Logger;
using PagedList;

namespace MaxiKioscos.Web.Controllers
{
    [Authorize]
    //[InitializeSimpleMembership]
    public class FeedbackController : BaseController
    {
        private readonly IEmailNotificationService _notificationService;
        private ITicketErrorNegocio TicketErrorNegocio { get; set; }

        public FeedbackController(IMaxiKioscosUow uow, ITicketErrorNegocio ticketErrorNegocio, IEmailNotificationService notificationService)
        {
            _notificationService = notificationService;
            TicketErrorNegocio = ticketErrorNegocio;
            Uow = uow;
        }

        public ActionResult Index(TicketErrorListadoModel model, int? page)
        {
            model.Filtros = model.Filtros ?? new TicketErrorFiltrosModel()
            {
                Titulo = model.Titulo,
                EstadoId = model.EstadoId,
                TicketNro = model.TicketNro
            };

            List<TicketError> tickets = Uow.TicketErrores.Listado(t => t.Usuario, f => f.MensajeTicketErrores)
                //.Where(model.Filtros.GetFilterExpression())
                .OrderByDescending(f => f.Fecha)
                .ToList();


            var pageNumber = page ?? 1;
            var pageSize = AppSettings.DefaultPageSize;
            IPagedList<TicketError> lista = tickets.ToPagedList(pageNumber, pageSize);

            var listadoModel = new TicketErrorListadoModel
            {
                List = lista,
                Filtros = model.Filtros
            };
            return PartialOrView(listadoModel);
        }

        public ActionResult Listado(TicketErrorFiltrosModel filtros, int? page)
        {
            var tickets = Uow.TicketErrores.Listado(t => t.Usuario, f => f.MensajeTicketErrores)
                .Where(filtros.GetFilterExpression())
                .OrderByDescending(f => f.Fecha);

            var lista = tickets.ToPagedList(page ?? 1, AppSettings.DefaultPageSize);
            var listadoModel = new TicketErrorListadoModel
            {
                List = lista,
                Filtros = filtros,
                Titulo = filtros.Titulo,
                EstadoId = filtros.EstadoId,
                TicketNro = filtros.TicketNro
            };


            return PartialView("_Listado", listadoModel);
        }

        public ActionResult ReportarError()
        {
            return PartialView(new ReportarErrorModel());
        }

        [HttpPost]
        public async Task<ActionResult> ReportarError(ReportarErrorModel error)
        {
            if (!ModelState.IsValid)
            {
                return PartialView(error);
            }

            try
            {
                error.FirstName = UsuarioActual.Usuario.Nombre;
                error.LastName = UsuarioActual.Usuario.Apellido;
                error.WebUrl = AppSettings.BaseURL;

                var ticket = new TicketError
                                 {
                                     EstadoTicketId = EstadoTicketEnum.Pendiente,
                                     Fecha = DateTime.Now,
                                     Mensaje = error.Description,
                                     UsuarioId = UsuarioActual.Usuario.UsuarioId,
                                     Origen = OrigenTicketEnum.Web,
                                     Titulo = error.Titulo,
                                     Email = error.EmailAddress
                                 };
                var result = TicketErrorNegocio.ReportarError(error, ticket);
                if (result == null)
                    return PartialView("ReportarErrorFail");
            }
            catch (Exception ex)
            {
                EventLogger.Log(ex);
                return PartialView("ReportarErrorFail");
            }

            return PartialView("ReportarErrorSuccess");
        }


        public ActionResult Ticket(int id)
        {
            var ticket = Uow.TicketErrores.Obtener(t => t.TicketErrorId == id, t => t.Usuario, 
                                                                                t => t.MensajeTicketErrores,
                                                                                t => t.EstadoTicket);
            var model = new TicketErrorModel() { Ticket = ticket };
            return PartialOrView(model);
        }

        public ActionResult MensajesListado(int id)
        {
            var ticket = Uow.TicketErrores.Obtener(t => t.TicketErrorId == id, t => t.Usuario,
                                                                                t => t.MensajeTicketErrores,
                                                                                t => t.EstadoTicket,
                                                                                t => t.MensajeTicketErrores.Select(m => m.Usuario));
            return PartialView("_MensajesListado", ticket.MensajeTicketErrores.ToList());
        }

        [HttpPost]
        public ActionResult EnviarMensaje(MensajeModel model)
        {
            var mensaje = new MensajeTicketError()
                              {
                                  Fecha = DateTime.Now,
                                  Texto = model.NuevoMensaje,
                                  TicketErrorId = model.TicketId,
                                  UsuarioId = UsuarioActual.Usuario.UsuarioId,
                                  EsDeAdmin = UsuarioActual.EsRol("SuperAdministrador") 
                              };
            Uow.MensajesTicketError.Agregar(mensaje);
            Uow.Commit();
            var ticket = Uow.TicketErrores.Obtener(model.TicketId);
            var emails = UsuarioActual.EsRol("SuperAdministrador")
                            ? new List<string>() { ticket.Email }
                            : ConfigurationManager.AppSettings["ReportarErrorDevelopersEmails"].Split(',').ToList();
            
            var data = new NotificacionTicketModel()
            {
                Emails = emails,
                Mensaje = mensaje.Texto,
                TicketId = mensaje.TicketErrorId,
                Titulo = String.Format("[{0}] {1}", ticket.TicketErrorId, ticket.Titulo),
                Fecha = String.Format("{0} {1}", DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString())
            };
            var result = _notificationService.EnviarNotificacionTicket(data, AppSettings.BaseURL);
            return Json(new { success = result.Status == EmailResultStatus.Sent }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult AbrirTicket(int id)
        {
            var ticket = Uow.TicketErrores.Obtener(id);
            ticket.EstadoTicketId = EstadoTicketEnum.EnProgreso;
            ticket.FechaEnProgreso = DateTime.Now;
            Uow.TicketErrores.Modificar(ticket);

            try
            {
                Uow.Commit();
                return Json(new {exito = true}, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return Json(new { exito = false }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult CerrarTicket(int id)
        {
            var ticket = Uow.TicketErrores.Obtener(id);
            ticket.EstadoTicketId = EstadoTicketEnum.Cerrado;
            ticket.FechaCierre = DateTime.Now;
            Uow.TicketErrores.Modificar(ticket);

            try
            {
                Uow.Commit();
                return Json(new { exito = true }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return Json(new { exito = false }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult EliminarTicket(int id)
        {
            var ticket = Uow.TicketErrores.Obtener(id);
            ticket.EstadoTicketId = EstadoTicketEnum.Eliminado;
            ticket.FechaCierre = DateTime.Now;
            Uow.TicketErrores.Modificar(ticket);

            try
            {
                Uow.Commit();
                return Json(new { exito = true }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return Json(new { exito = false }, JsonRequestBehavior.AllowGet);
            }
        }

        
    }
}

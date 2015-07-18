using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;
using MaxiKioscos.Datos;
using MaxiKioscos.Datos.Helpers;
using MaxiKioscos.Datos.Interfaces;
using MaxiKioscos.Email;
using MaxiKioscos.Email.Models;
using MaxiKioscos.Entidades;
using MaxiKioscos.Negocio;
using MaxiKioscos.Services.Contracts;

namespace MaxiKioscos.Services
{
    public class NotificacionService : BaseService, INotificacionService
    {
        private ITicketErrorNegocio TicketErrorNegocio { get; set; }

        public NotificacionService(IMaxiKioscosUow uow, ITicketErrorNegocio ticketErrorNegocio)
        {
            Uow = uow;
            TicketErrorNegocio = ticketErrorNegocio;
        }

        public bool ReportarError(ReportarErrorRequest request)
        {
            var error = new ReportarErrorModel
                            {
                                Description = request.Mensaje,
                                EmailAddress = request.Email,
                                FirstName = request.Nombre,
                                LastName = request.Apellido,
                                Titulo = request.Titulo,
                                WebUrl = request.WebUrl
                            };

            var usuario = Uow.Usuarios.Obtener(u => u.Identifier == request.UsuarioIdentifier);
            var ticket = new TicketError
            {
                EstadoTicketId = EstadoTicketEnum.Pendiente,
                Fecha = DateTime.Now,
                Mensaje = error.Description,
                UsuarioId = usuario.UsuarioId,
                Origen = OrigenTicketEnum.Desktop,
                Titulo = error.Titulo,
                Email = error.EmailAddress
            };
            try
            {
                var result = TicketErrorNegocio.ReportarError(error, ticket);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            
        }
    }
}

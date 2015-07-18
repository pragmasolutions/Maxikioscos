using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mandrill;
using MaxiKioscos.Datos.Interfaces;
using MaxiKioscos.Email;
using MaxiKioscos.Email.Models;
using MaxiKioscos.Entidades;

namespace MaxiKioscos.Negocio
{
    public class TicketErrorNegocio : ITicketErrorNegocio
    {
        private readonly IEmailNotificationService _notificationService;
        private IMaxiKioscosUow Uow { get; set; }

        public TicketErrorNegocio(IMaxiKioscosUow uow, IEmailNotificationService notificationService)
        {
            Uow = uow;
            _notificationService = notificationService;
        }

        public List<EmailResult> ReportarError(ReportarErrorModel model, TicketError ticket)
        {
            Uow.TicketErrores.Agregar(ticket);
            Uow.Commit();

            model.TicketErrorID = ticket.TicketErrorId;
            return _notificationService.EnviarErrorPorMail(model);
        }
    }
}

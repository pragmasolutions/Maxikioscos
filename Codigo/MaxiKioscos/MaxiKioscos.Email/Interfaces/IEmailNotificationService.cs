using System.Collections.Generic;
using System.Net.Mail;
using System.Threading.Tasks;
using Mandrill;
using MaxiKioscos.Email.Models;

namespace MaxiKioscos.Email
{
    public interface IEmailNotificationService
    {
        List<EmailResult> EnviarErrorPorMail(ReportarErrorModel errorData);
        EmailResult EnviarNotificacionTicket(NotificacionTicketModel data, string baseUrl);
    }
}

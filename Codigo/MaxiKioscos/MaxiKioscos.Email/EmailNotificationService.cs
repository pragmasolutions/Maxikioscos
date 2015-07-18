using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.IO;
using System.Net.Mail;
using System.Reflection;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using Mandrill;
using MaxiKioscos.Email.Models;
using SimpleSurvey.Business.Helpers;
using System.Linq;

namespace MaxiKioscos.Email
{
    public class EmailNotificationService : IEmailNotificationService
    {
        public List<EmailResult> EnviarErrorPorMail(ReportarErrorModel errorData)
        {
            var mailstext = ConfigurationManager.AppSettings["ReportarErrorDevelopersEmails"];
            var emails = mailstext.Split(',').ToList();
            var variables = new List<merge_var>
                                {
                                    new merge_var()
                                        {name = "FIRSTNAME", content = errorData.FirstName},
                                    new merge_var()
                                        {name = "LASTNAME", content = errorData.LastName},
                                    new merge_var()
                                        {name = "EMAILADDRESS", content = errorData.EmailAddress},
                                    new merge_var()
                                        {name = "DESCRIPCION", content = errorData.Description},
                                    new merge_var()
                                        {name = "TICKETID", content = errorData.TicketErrorID.ToString()},
                                    new merge_var()
                                        {name = "TITULO", content = errorData.Titulo },
                                    new merge_var()
                                        {name = "BASEURL", content = errorData.WebUrl }
                                };
            var subject = String.Format("Reporte de error [Ticket: #{0}]", errorData.TicketErrorID);
            return EmailHelper.SendMailTemplate(emails, "errortemplate", variables, subject);
        }

        public EmailResult EnviarNotificacionTicket(NotificacionTicketModel data, string baseUrl)
        {
            var variables = new List<merge_var>
                                {
                                    new merge_var()
                                        {name = "TITULO", content = data.Titulo},
                                    new merge_var()
                                        {name = "FECHA", content = data.Fecha},
                                    new merge_var()
                                        {name = "MENSAJE", content = data.Mensaje},
                                    new merge_var()
                                        {name = "TICKETID", content = data.TicketId.ToString()},
                                    new merge_var()
                                        {name = "BASEURL", content = baseUrl }
                                };
            var subject = String.Format("Han respondido tu mensaje [Ticket: #{0}]", data.TicketId);
            return EmailHelper.SendMailTemplate(data.Emails, "notificacionmensaje", variables, subject).FirstOrDefault();
        }
    }
}

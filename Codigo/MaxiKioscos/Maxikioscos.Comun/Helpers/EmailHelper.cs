using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Mandrill;
using System.Configuration;
using Maxikioscos.Comun.Logger;

namespace SimpleSurvey.Business.Helpers
{
    public class EmailHelper
    {
        private static string _mandrillApiKey = ConfigurationManager.AppSettings["MandrillApiKey"];
        private static string _senderEmail = ConfigurationManager.AppSettings["MailUser"];
        
        
        public static List<EmailResult> SendMail(List<string> toMails, string subject, string htmlBody, bool async = false)
        {
            try
            {
                var api = new MandrillApi(_mandrillApiKey);

                var email = new EmailMessage()
                {
                    from_email = _senderEmail,
                    subject = subject,
                    html = htmlBody
                };
                var to = toMails.Select(mailTo => new EmailAddress(mailTo)).ToList();

                email.to = to;
                if (async)
                {
                    var result = api.SendMessageAsync(email);
                    return result.Result;
                }
                return api.SendMessage(email);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static List<EmailResult> SendMailTemplate(List<string> toMails, string templateName, List<merge_var> mergeVars, string subject)
        {
            try
            {
                var api = new MandrillApi(_mandrillApiKey);

                var email = new EmailMessage
                                {
                                    from_email = _senderEmail,
                                    subject = subject
                                };

                var to = toMails.Select(mailTo => new EmailAddress(mailTo)).ToList();

                email.to = to;
                foreach (merge_var item in mergeVars)
                {
                    email.AddGlobalVariable(item.name, item.content);
                }

                var result = api.SendMessageAsync(email, templateName, null);
                return result.Result;
            }
            catch (Exception ex)
            {
                EventLogger.Log(ex);
                return null;
                //ManagementBLL.LogError("SendMailMandrill", ex.Message, "EmailHelper", string.Empty);
            }
        }
    }

    public class RecipientVariable
    {
        public string Recipient { get; set; }
        public string Name { get; set; }
        public string Content { get; set; }
    }
}
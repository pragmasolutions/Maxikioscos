using System;
using System.Configuration;
using System.Diagnostics;
using System.Net.Mail;
using System.Net;
using Maxikioscos.Comun.Helpers;

namespace Maxikioscos.Comun.Logger
{
    public static class EventLogger
    {      
        private static string _EventLogName;   // Custom event log name. eg. Mindridge

        private static string _MailServer;     // SMTP Server
        private static string _MailUsername;   // SMTP Username
        private static string _MailPassword;   // SMTP Password
        private static string _EmailSender;    // Email sender address (usually, noreply@xyz.com )
        private static string _EmailReceiver;  // Recipient of error emails
        private static string _MailSubject;    // Mail subject

        /// <summary>
        /// Default constuctor reads log configs from configuration file
        /// </summary>
        static EventLogger()
        {
            // EventLog name
            _EventLogName = ConfigurationManager.AppSettings["EventLogName"];
            if (string.IsNullOrEmpty(_EventLogName))
                _EventLogName = "Mindridge";

            // SMTP values
            _MailServer = ConfigurationManager.AppSettings["SMTPServer"];
            if (!string.IsNullOrEmpty(_MailServer))
            {
                _MailUsername = ConfigurationManager.AppSettings["SMTPUsername"];
                _MailPassword = ConfigurationManager.AppSettings["SMTPPassword"];

                // Email receipient
                _EmailReceiver = ConfigurationManager.AppSettings["ErrorEmailReceiver"];
                _MailSubject = ConfigurationManager.AppSettings["ErrorMailSubject"];
                if (string.IsNullOrEmpty(_MailSubject))
                    _MailSubject = "Auto generated error message";
            }
        }

        public static void Log(string format, params object[] args)
        {
            TextLogger.Log(format, args);
        }

        public static void Log(Exception ex)
        {
            var inner = ExceptionHelper.GetInnerException(ex);
            TextLogger.Log(inner.Message + "\r\n" + inner.StackTrace);
        }

        /// <summary>
        /// Logs an exception to the event log
        /// </summary>
        /// <param name="ex">Exception</param>
        private static void LogToEventLog(Exception ex) { LogToEventLog(ex.ToString(), ex.Source, EventLogEntryType.Information); }

        /// <summary>
        /// Logs an exception to the event log
        /// </summary>
        /// <param name="ex">Exception</param>
        /// <param name="evtType">EventLog</param>
        private static void LogToEventLog(Exception ex, EventLogEntryType evtType) { LogToEventLog(ex.ToString(), ex.Source, evtType); }

        /// <summary>
        /// Log an error message to the event log
        /// </summary>
        /// <param name="_message"></param>
        private static void LogToEventLog(string message, string eventSource, EventLogEntryType evtType)
        {
            //Here is an issue. ASP.NET does not have privilages by default to write to the event log
            //so, what we do is to try, if fail, we send us a mail to say so.
            //The solutions are many. One is to:
            //To do so, open regedt32 (not the standard, regedit) and navigate to HKEY_LOCAL_MACHINE\System\CurrentControlSet\Services\EventLog and click on "Security-->Permissions..." in the menu.  Add the ASPNET account for the local machine and place a check next to "Full Control"

            try
            {
                //Create our own log if it not already exists
                if (!System.Diagnostics.EventLog.SourceExists(eventSource))
                    System.Diagnostics.EventLog.CreateEventSource(eventSource, _EventLogName);

                System.Diagnostics.EventLog eventLog = new System.Diagnostics.EventLog();
                eventLog.Source = eventSource;
                eventLog.WriteEntry(message, evtType);
            }
            catch (Exception e)
            {
                //send us a email and tell that there is a permission problem
                SendMail(e.Message);
            }
        }

        /// <summary>
        /// Send the error message to the specified recepient
        /// </summary>
        /// <param name="ex"></param>
        private static void SendMail(Exception ex) { SendMail(ex.ToString()); }

        /// <summary>
        /// Send the error message to the specified recepient 
        /// </summary>
        /// <param name="message"></param>
        private static void SendMail(string message)
        {
            try
            {
                // Form the mail message
                MailMessage mailMessage = new MailMessage(_EmailSender, _EmailReceiver, _MailSubject, 
                    "Error message:\n" + message + "\n\n" );

                // send the email
                SmtpClient mailClient = new SmtpClient(_MailServer);
                mailClient.UseDefaultCredentials = false;
                mailClient.Credentials = new NetworkCredential(_MailUsername, _MailPassword);

                mailClient.Send(mailMessage);
            } // try
            catch (Exception)
            {
            } // catch
        }
    }
}

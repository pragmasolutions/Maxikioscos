using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.ServiceModel;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaxiKioscos.Winforms.IoC;
using MaxiKioscos.Winforms.Login;
using MaxiKioscos.Winforms.Principal;
using MaxiKioscos.Winforms.Sincronizacion;
using Microsoft.AspNet.SignalR.Client;
using log4net;
using MaxiKioscos.Winforms.Helpers;

namespace MaxiKioscos.Winforms
{
    static class Program
    {
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool SetForegroundWindow(IntPtr hWnd);

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            bool createdNew = true;
            using (Mutex mutex = new Mutex(true, Assembly.GetEntryAssembly().GetName().Name, out createdNew))
            {
                if (createdNew)
                {
                    StartApp();
                }
                else
                {
                    Process current = Process.GetCurrentProcess();
                    foreach (Process process in Process.GetProcessesByName(current.ProcessName))
                    {
                        if (process.Id != current.Id)
                        {
                            SetForegroundWindow(process.MainWindowHandle);
                            break;
                        }
                    }
                }
            }
        }

        private static void StartApp()
        {
            CompositionRoot.Wire(new ApplicationModule());
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //Config log4net
            log4net.Config.DOMConfigurator.Configure();

#if (!DEBUG)
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            Application.ThreadException += ApplicationOnThreadException;
            AppDomain.CurrentDomain.UnhandledException += CurrentDomainOnUnhandledException;

            DatabaseUpdate databaseUpdate = new DatabaseUpdate();
            const string connectionStringName = "SchemaUpdater";
            const string snapshotFolder = "Snapshots";
            databaseUpdate.UpgradeDatabase(connectionStringName, snapshotFolder);
#endif
            Application.Run(CompositionRoot.Resolve<mdiPrincipal>());
        }

        private static void CurrentDomainOnUnhandledException(object sender, UnhandledExceptionEventArgs unhandledExceptionEventArgs)
        {
            LogManager.GetLogger("errors").Error(unhandledExceptionEventArgs.ExceptionObject);

            var mensaje = GetGlobalExeptionMessage((Exception)unhandledExceptionEventArgs.ExceptionObject);

            MessageBox.Show(mensaje);

            Application.Exit();
        }

        private static string GetGlobalExeptionMessage(Exception ex)
        {
            var mensaje = string.Format("Ha ocurrido un error.\r\n\n" +
                                        "{0}\r\n\n" +
                                        "por favor contactese con soporte",
                                        ex.Message);

            return mensaje;
        }

        private static void ApplicationOnThreadException(object sender, ThreadExceptionEventArgs threadExceptionEventArgs)
        {
            LogManager.GetLogger("errors").Error(threadExceptionEventArgs.Exception);

            var mesange = GetGlobalExeptionMessage(threadExceptionEventArgs.Exception);
            
            MessageBox.Show(mesange); 
        }
    }
}

using System;
using System.Threading;
using MaxiKiosco.Seguridad.WebSecurity;
using System.IO;
using MaxiKioscos.IoC;
using Ninject;
using Ninject.Web.Common;
using WebMatrix.WebData;
using System.Web;

namespace MaxiKioscos.Services
{
    public class Global : NinjectHttpApplication
    {
        private static SimpleMembershipInitializer _initializer;
        private static object _initializerLock = new object();
        private static bool _isInitialized;

        protected void Application_Start()
        {
            LazyInitializer.EnsureInitialized(ref _initializer, ref _isInitialized, ref _initializerLock);
        }

        protected override IKernel CreateKernel()
        {
            LazyInitializer.EnsureInitialized(ref _initializer, ref _isInitialized, ref _initializerLock);
            var kernel = new StandardKernel();
            IoCConfig.RegisterBindings(kernel);
            return kernel;
        }

        protected override void OnApplicationStarted()
        {
            log4net.Config.XmlConfigurator.Configure(new FileInfo(Server.MapPath("~/Web.config")));

            base.OnApplicationStarted();
        }

        protected void Application_BeginRequest(Object sender, EventArgs e)
        {
            if (HttpContext.Current.Request.HttpMethod == "OPTIONS")
            {
                HttpContext.Current.Response.AddHeader("Access-Control-Allow-Methods", "GET, POST, OPTIONS");

                HttpContext.Current.Response.End();
            }
        }
    }
}
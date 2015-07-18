using System;
using System.Globalization;
using System.Threading;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using MaxiKiosco.Seguridad.WebSecurity;
using MaxiKioscos.Web.Comun.Binders;
using MaxiKioscos.Web.Ioc;
using WebMatrix.WebData;

namespace MaxiKioscos.Web
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        private static SimpleMembershipInitializer _initializer;
        private static object _initializerLock = new object();
        private static bool _isInitialized;

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            // Tell App to use our custom Ioc (Ninject)
            //DependencyResolver.SetResolver(new NinjectDependencyResolver());
            ControllerBuilder.Current.SetControllerFactory(new NinjectControllerFactory());

            Thread.CurrentThread.CurrentCulture = new CultureInfo("es-AR");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("es-AR");

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AuthConfig.RegisterAuth();

            ModelBinders.Binders.Add(typeof(DateTime), new DateTimeModelBinder());
            ModelBinders.Binders.Add(typeof(DateTime?), new NullableDateTimeModelBinder());

            ModelBinders.Binders.Add(typeof(decimal), new DecimalModelBinder());
            ModelBinders.Binders.Add(typeof(decimal?), new DecimalModelBinder());

            LazyInitializer.EnsureInitialized(ref _initializer, ref _isInitialized, ref _initializerLock);
        }

        protected void Session_Start()
        {
            
        }
    }
}
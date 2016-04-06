using System;
using System.Threading;
using MaxiKiosco.Seguridad.WebSecurity;
using MaxiKioscos.IoC;
using Ninject;
using Ninject.Web.Common;
using WebMatrix.WebData;

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
    }
}
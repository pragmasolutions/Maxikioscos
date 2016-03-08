using System.Security.Principal;
using System.Web;
using MaxiKioscos.Datos;
using MaxiKioscos.Datos.Helpers;
using MaxiKioscos.Datos.Interfaces;
using MaxiKioscos.Mobile.Api;
using MaxiKioscos.Mobile.Api.IoC;
using Ninject;
using Ninject.Web.Common;

namespace MaxiKioscos.Mobile.Api
{
    public class IoCConfig
    {
        public static void Config(StandardKernel kernel)
        {
            RegisterBindings(kernel);

            IocContainer.Initialize(new NinjectIocContainer(kernel));
        }


        private static void RegisterBindings(IKernel kernel)
        {
            kernel.Bind<RepositoryFactories>().To<RepositoryFactories>().InSingletonScope();
            kernel.Bind<IRepositoryProvider>().To<RepositoryProvider>();
            kernel.Bind<IMaxiKioscosUow>().To<MaxiKioscosUow>().InRequestScope();

            kernel.Bind<IIdentity>().ToMethod(c => HttpContext.Current.User.Identity);
        }
    }
}
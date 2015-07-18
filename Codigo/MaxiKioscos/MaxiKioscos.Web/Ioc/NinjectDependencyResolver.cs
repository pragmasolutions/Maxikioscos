using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MaxiKiosco.Seguridad.WebSecurity;
using MaxiKioscos.Datos;
using MaxiKioscos.Datos.Helpers;
using MaxiKioscos.Datos.Interfaces;
using MaxiKioscos.Negocio;
using MaxiKioscos.Seguridad;
using Ninject;

namespace MaxiKioscos.Web.Ioc
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;

        public NinjectDependencyResolver()
        {
            kernel = new StandardKernel();
            AddBindings();
        }

        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }

        private void AddBindings()
        {
            kernel.Bind<RepositoryFactories>().To<RepositoryFactories>()
              .InSingletonScope();

            kernel.Bind<IRepositoryProvider>().To<RepositoryProvider>();
            ////Add bindings
            kernel.Bind<IMaxiKioscosUow>().To<MaxiKioscosUow>();
            kernel.Bind<IAuthService>().To<WebSecurityAuthService>();
        }
    }
}
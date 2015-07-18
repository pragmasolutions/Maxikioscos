using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using MaxiKiosco.Seguridad.WebSecurity;
using MaxiKioscos.Datos;
using MaxiKioscos.Datos.Helpers;
using MaxiKioscos.Datos.Interfaces;
using MaxiKioscos.IoC;
using MaxiKioscos.Seguridad;
using Ninject;

namespace MaxiKioscos.Web.Ioc
{
    public class NinjectControllerFactory : DefaultControllerFactory
    {
        private IKernel kernel;

        public NinjectControllerFactory()
        {
            kernel = new StandardKernel();
            NinjectServiceHelper.Kernel = kernel;
            IoCConfig.RegisterBindings(kernel);
        }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            return controllerType == null
                       ? null
                       : (IController)kernel.Get(controllerType);
        }
    }
}
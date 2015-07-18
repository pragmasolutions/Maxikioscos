using MaxiKioscos.IoC;
using Ninject;
using Ninject.Web.Common;

namespace MaxiKioscos.Services
{
    public class Global : NinjectHttpApplication
    {
        protected override IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            IoCConfig.RegisterBindings(kernel);
            return kernel;
        }
    }
}
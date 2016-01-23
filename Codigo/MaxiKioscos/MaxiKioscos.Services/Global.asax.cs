using System.IO;
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

        protected override void OnApplicationStarted()
        {
            log4net.Config.XmlConfigurator.Configure(new FileInfo(Server.MapPath("~/Web.config")));

            base.OnApplicationStarted();
        }
    }
}
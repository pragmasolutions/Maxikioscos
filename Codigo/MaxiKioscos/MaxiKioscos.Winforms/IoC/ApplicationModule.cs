using MaxiKiosco.Seguridad.WebSecurity;
using MaxiKioscos.Datos;
using MaxiKioscos.Datos.Helpers;
using MaxiKioscos.Datos.Interfaces;
using MaxiKioscos.Seguridad;
using MaxiKioscos.Winforms.Sincronizacion;
using MaxiKioscos.Winforms.SincronizationService;
using Ninject.Modules;

namespace MaxiKioscos.Winforms.IoC
{
    public class ApplicationModule : NinjectModule
    {
        public override void Load()
        {
            Bind<RepositoryFactories>().To<RepositoryFactories>().InSingletonScope();
            Bind<IRepositoryProvider>().To<RepositoryProvider>();
            Bind<IMaxiKioscosUow>().To<MaxiKioscosUow>();
            Bind<IAuthService>().To<WebSecurityAuthService>();
            Bind<ISincronizacionManager>().To<SincronizacionManager>().InSingletonScope();
            Bind<ISincronizacionService>().To<SincronizacionServiceClient>();
        }
    }
}

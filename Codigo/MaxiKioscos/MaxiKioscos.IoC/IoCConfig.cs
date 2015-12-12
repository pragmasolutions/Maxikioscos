
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaxiKiosco.Seguridad.WebSecurity;
using MaxiKioscos.Datos;
using MaxiKioscos.Datos.Helpers;
using MaxiKioscos.Datos.Interfaces;
using MaxiKioscos.Email;
using MaxiKioscos.Negocio;
using MaxiKioscos.Seguridad;
using Ninject;

namespace MaxiKioscos.IoC
{
    /// <summary>
    /// Helper class to register all global config of ninject.
    /// </summary>
    public class IoCConfig
    {
        /// <summary>
        /// Register all the binding.
        /// </summary>
        /// <param name="kernel"></param>
        public static void RegisterBindings(IKernel kernel)
        {
            kernel.Bind<RepositoryFactories>().To<RepositoryFactories>().InSingletonScope();
            kernel.Bind<IRepositoryProvider>().To<RepositoryProvider>();
            kernel.Bind<IMaxiKioscosUow>().To<MaxiKioscosUow>();
            kernel.Bind<IStockNegocio>().To<StockNegocio>();
            kernel.Bind<ISincronizacionNegocio>().To<SincronizacionNegocio>();
            kernel.Bind<IComprasNegocio>().To<ComprasNegocio>();
            kernel.Bind<ITransferenciasNegocio>().To<TransferenciasNegocio>();
            kernel.Bind<IControlStockNegocio>().To<ControlStockNegocio>();
            kernel.Bind<IPromocionesNegocio>().To<PromocionesNegocio>();
            kernel.Bind<ITicketErrorNegocio>().To<TicketErrorNegocio>();
            kernel.Bind<IAuthService>().To<WebSecurityAuthService>();
            kernel.Bind<IEmailNotificationService>().To<EmailNotificationService>();
        }
    }
}

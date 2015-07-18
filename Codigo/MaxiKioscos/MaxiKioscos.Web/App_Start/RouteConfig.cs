using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MaxiKioscos.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            string[] namespaces = new[] { "MaxiKioscos.Web.Controllers" };

            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
               "ExportacionDetalle",
               "Sincronizacion/Exportacion/exp-{secuencia}.xml",
               new
               {
                   action = "Detalle",
                   controller = "Sincronizacion",
                   secuencia = "",
                   type = UrlParameter.Optional
               },
               namespaces
           );

            routes.MapRoute(
                name: "Root",
                url: "",
                defaults: new { controller = "Sincronizacion", action = "EstadoKioscos" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
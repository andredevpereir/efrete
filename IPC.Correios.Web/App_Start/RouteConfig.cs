using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;

namespace IPC.Correios.Middleware.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute("Resultado", "{controller}/{action}", new { controller = "Home", action = "Resultado" });
            routes.MapRoute("BuscaEndereco", "{controller}/{action}", new { controller = "Home", action = "BuscaEndereco" });
            routes.MapRoute("BuscaCEP", "{controller}/{action}", new { controller = "Home", action = "BuscaCEP" });
        }
    }
}
